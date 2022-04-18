﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Referencias")]
	private Rigidbody2D rb;
	private DetecColision coll;

	[Header("RUN - MOVIMIENTO")]
	[SerializeField] private float MaxMoveSpeed; // Velocidad de Movimiento 
	[SerializeField] private float Acceleration; // Aceleracion
	[SerializeField] private float Decceleration; // Desaceleracion
	[SerializeField] private float VelPower; // Poder de Velocidad 
	
	[Header("JUMP - SALTO")]
	[SerializeField] private float JumpForce; // Fuerza del salto
	[SerializeField] private float JumpCoyoteTime; // Valor del Coyote 

	[Range(0,1)] 
	public float JumpCutMultiplier; // Corte del salto al mantener presionado

	[SerializeField] private float FallGravityMultiplier;

	[Header(" WALL - PARED")]

	[SerializeField] private float ClimbTheWall; 
	[SerializeField] private float LowerTheWall; 
	private Vector2 MoveInput; // Vector de eje X y eje Y

	[Header("VERIFICANDO")]
	public bool CanMove = true;
	public bool isJumping; // Si se encuentra saltando
	public bool JumpInputRealeased; // Si el salto se encuentra liberado 

	// Variables De Tiempo
	private float lastGroundedTime; // tiempo desde la ultima vez en el suelo
	private float lastJumpTime; // tiempo desde el ultimo salto
	private float JumpBufferTime = 0.1f; // Tiempo para volver a saltar 
	private float gravityScale;

	private void Start(){

		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<DetecColision>();
		gravityScale = rb.gravityScale;

	}

	private void Update(){

		#region INPUTS
			float x = Input.GetAxis("Horizontal");
        	float y = Input.GetAxis("Vertical");
			MoveInput.x = Input.GetAxisRaw("Horizontal");
			MoveInput.y = Input.GetAxisRaw("Vertical");

			if(Input.GetKey(KeyCode.C)){ // Sigue Ocurriendo Mientras se mantenga presionada la tecla 
				lastJumpTime = JumpBufferTime;
			}

			if(Input.GetKeyUp(KeyCode.C)){ // Ocurre una 1 vez, cuando suelta la tecla devuelve true 
				OnJumpUp();
			}

		#endregion

		#region CHECKS

			if(coll.onGround){ // Verifica si se encuentra en el suelo

				lastGroundedTime = JumpCoyoteTime;

			}

			if(rb.velocity.y <= 0 && JumpInputRealeased){

				isJumping = false;

			}

			// Condiciones de agarre
			if(coll.onWall && Input.GetKey(KeyCode.X)){

				rb.gravityScale = 0;
				rb.velocity = new Vector2(rb.velocity.x, 0);

				float speedModifier = y > 0 ? ClimbTheWall : LowerTheWall;

				rb.velocity = new Vector2(rb.velocity.x, y * (MaxMoveSpeed * speedModifier));

			}else{

				rb.gravityScale = gravityScale;

			}


		#endregion

		#region JUMP

			if(lastGroundedTime > 0 && lastJumpTime > 0 && !isJumping){
				Jump();
			}

		#endregion

		#region TIMERS

			lastGroundedTime -= Time.deltaTime;
			lastJumpTime -= Time.deltaTime;
			
		#endregion

	}

	private void FixedUpdate(){
		
		#region RUN - MOVIMIENTO   
			if(CanMove){

				float targetSpeed = MoveInput.x * MaxMoveSpeed; // calcula la direccion en la que queremos movernos y nuestra velocidad deseada
				float speedDif = targetSpeed - rb.velocity.x; //calcula la diferencia entre la velocidad actual y la velocidad deseada
				float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Acceleration : Decceleration; // cambiar la tasa de aceleracion dependiendo de la situacion
				float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, VelPower) * Mathf.Sign(speedDif); //aplica aceleracion a la diferencia de velocidad, la eleva a una potencia establecida para que la aceleracion aumente con velocidades mas altas, finalmente se multiplica por signo para volver a aplicar la direccion
				rb.AddForce(movement * Vector2.right); // aplica fuerza fuerza a rigidbody, multiplicando por Vector2.right para que solo afecte el eje X
			}
		#endregion

		#region Jump Gravity
			if (rb.velocity.y < 0 && lastGroundedTime <= 0){

				rb.gravityScale = gravityScale * FallGravityMultiplier;
			
			}else{
				
				rb.gravityScale = gravityScale;
			}
		#endregion

	}

	private void Jump(){ // Realiza el salto

		rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
		lastGroundedTime = 0;
		lastJumpTime = 0;
		isJumping = true;
		JumpInputRealeased = false;

	}

	private void OnJumpUp(){

		if (rb.velocity.y > 0 && isJumping){
			
			rb.AddForce(Vector2.down * rb.velocity.y * (1 - JumpCutMultiplier), ForceMode2D.Impulse);
		}

		JumpInputRealeased = true;
		lastJumpTime = 0;

	}


}
