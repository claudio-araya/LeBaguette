using System.Collections;
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
	
	[Header("JUMP - Salto")]
	[SerializeField] private float JumpForce; // Fuerza del salto
	[SerializeField] private float JumpCoyoteTime; // Valor del Coyote 
	[SerializeField] private float JumpBufferTime; // Tiempo en el que podemos volver a presionar el salto 

	[Range(0,1)] 
	public float JumpCutMultiplier; // Corte del salto al mantener presionado

	[SerializeField] private float FallGravityMultiplier;
	private Vector2 MoveInput; // Vector de eje X y eje Y

	private bool isJumping; // Si se encuentra saltando
	private bool JumpInputRealeased; // Si el salto se encuentra liberado 
	private float lastGroundedTime; // tiempo desde la ultima vez en el suelo
	private float lastJumpTime; // tiempo desde el ultimo salto
	private float gravityScale;

	private void Start(){

		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<DetecColision>();
		gravityScale = rb.gravityScale;

	}

	private void Update(){

		#region INPUTS

			MoveInput.x = Input.GetAxisRaw("Horizontal");
			MoveInput.y = Input.GetAxisRaw("Vertical");

			if(Input.GetKey(KeyCode.C)){
				lastJumpTime = JumpBufferTime;
			}

			if(Input.GetKeyUp(KeyCode.C)){
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

			float targetSpeed = MoveInput.x * MaxMoveSpeed; // calcula la direccion en la que queremos movernos y nuestra velocidad deseada
			float speedDif = targetSpeed - rb.velocity.x; //calcula la diferencia entre la velocidad actual y la velocidad deseada
			float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Acceleration : Decceleration; // cambiar la tasa de aceleracion dependiendo de la situacion
			float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, VelPower) * Mathf.Sign(speedDif); //aplica aceleracion a la diferencia de velocidad, la eleva a una potencia establecida para que la aceleracion aumente con velocidades mas altas, finalmente se multiplica por signo para volver a aplicar la direccion
			rb.AddForce(movement * Vector2.right); // aplica fuerza fuerza a rigidbody, multiplicando por Vector2.right para que solo afecte el eje X

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
