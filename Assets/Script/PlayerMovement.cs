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
	
	[Header("JUMP - SALTO")]
	[SerializeField] private float JumpForce; // Fuerza del salto
	[SerializeField] private float JumpCoyoteTime; // Valor del Coyote 

	[Range(0,1)] 
	public float JumpCutMultiplier; // Corte del salto al mantener presionado

	[SerializeField] private float FallGravityMultiplier;
	
	[SerializeField] private Vector2 WallJumpForce;
	public float WallJumpStopRunTime;

	[Header(" WALL - PARED")]

	[SerializeField] private bool CanWallJump;

	[SerializeField] private bool SlideWall; // Deja deslizarse
	[SerializeField] private float ClimbTheWall; // Fuerza con la que sube el personaje 
	[SerializeField] private float LowerTheWall; // Fuerza con la que baja el personaje

	[Header("DASH")]
	[SerializeField] private float dashSpeed;
	[SerializeField] private float TimeDash;
	private Vector2 MoveInput; // Vector de eje X y eje Y

	[Header("VERIFICANDO")]
	public bool CanMove = true; // Puede moverse 
	public bool isJumping; // Si se encuentra saltando
	public bool JumpInputRealeased; // Si el salto se encuentra liberado 
	public bool climbing;

	public bool isDashing;
	public bool CanDash;

	// Variables De Tiempo
	private float lastGroundedTime; // tiempo desde la ultima vez en el suelo
	private float lastJumpTime; // tiempo desde el ultimo salto
	private float JumpBufferTime = 0.1f; // Tiempo para volver a saltar 
	private float gravityScale;

	private Vector2 dir;

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
			Vector2 dir = new Vector2(MoveInput.x, MoveInput.y);

			if(Input.GetKey(KeyCode.C)){ // Sigue Ocurriendo Mientras se mantenga presionada la tecla 
				lastJumpTime = JumpBufferTime;
				
			}

			if(Input.GetKeyUp(KeyCode.C)){ // Ocurre una 1 vez, cuando suelta la tecla devuelve true 
				OnJumpUp();
			
			}

			if (Input.GetKeyDown(KeyCode.Z) && CanDash){
            	
				CanDash = false;
				isDashing = true;
				if(dir == Vector2.zero){
					dir = new Vector2(transform.localScale.x, 0);
							
				}   
                Dash(dir);

        	}


		#endregion

		#region CHECKS

			if(coll.onGround){ // Verifica si se encuentra en el suelo

				lastGroundedTime = JumpCoyoteTime;
				CanDash = true;
			}

			if(rb.velocity.y <= 0 && JumpInputRealeased){

				isJumping = false;

			}
			

			// Condiciones de agarre
			if(coll.onWall && Input.GetKey(KeyCode.X)){
				
				climbing = true;
				rb.gravityScale = 0;
				rb.velocity = new Vector2(rb.velocity.x, 0);

				float speedModifier = y > 0 ? ClimbTheWall : LowerTheWall;

				rb.velocity = new Vector2(rb.velocity.x, y * (MaxMoveSpeed * speedModifier));

			}else{
				climbing = false;
				rb.gravityScale = gravityScale;
				

			}


		#endregion

		#region JUMP

			if(JumpInputRealeased && lastJumpTime > 0 && !isJumping){
					
				if(lastGroundedTime > 0){
					
					Jump();
					Debug.Log("Salto Normal ");

				}else if(coll.onWall && CanWallJump){

					WallJump(WallJumpForce.x, WallJumpForce.y);
					//StopMovement(WallJumpStopRunTime);
					Debug.Log("Salto en pared");
				}
					
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
			if (rb.velocity.y < 0 && lastGroundedTime <= 0 && !climbing){

				rb.gravityScale = gravityScale * FallGravityMultiplier;
				
			
			}else if(SlideWall){
				
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

	private void WallJump(float jumpForceX, float jumpForceY)
	{
		//flips x force if facing other direction, since when we Turn() our player the CheckPoints swap around
		
		jumpForceX *= coll.wallSide;

		float momentumForce = rb.velocity.x * Mathf.Sign(jumpForceX);

		//apply force, using impluse force mode
		rb.AddForce(new Vector2(jumpForceX + momentumForce, jumpForceY), ForceMode2D.Impulse);
		//rb.velocity = new Vector2(jumpForceX, jumpForceY);
		lastJumpTime = 0;
		isJumping = true;
		JumpInputRealeased = false;

	}
	private IEnumerator StopMovement(float duration)
	{
		CanMove = false;
		yield return new WaitForSeconds(duration);
		CanMove = true;
	}

	private void Dash(Vector2 dir)
    {

        rb.velocity += dir.normalized * dashSpeed;

		StopMovement(TimeDash);
    
    }


}
