using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Referencias")]
	private Rigidbody2D rb;
	private SpriteRenderer sr;
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
	[SerializeField] private float ClimbTheWall; // Fuerza con la que sube el personaje 
	[SerializeField] private float LowerTheWall; // Fuerza con la que baja el personaje
	[SerializeField] private float slideGravity;


	[Header("DASH")]
	[SerializeField] private float dashSpeed;
	[SerializeField] private float TimeDash;
	[SerializeField] private float CoolDownDash;
	private Vector2 MoveInput; // Vector de eje X y eje Y

	[Header("VERIFICANDO")]
	public bool CanMove = true; // Puede moverse 
	public bool isJumping; // Si se encuentra saltando
	public bool JumpInputRealeased; // Si el salto se encuentra liberado 
	public bool climbing;
	public bool isFacingRight = true;
	public bool isDashing;
	public bool CanDash;
	public bool slideWall; // Deja deslizarse
	public bool Dead = false;

	// Variables De Tiempo
	private float lastGroundedTime; // tiempo desde la ultima vez en el suelo
	private float lastJumpTime; // tiempo desde el ultimo salto
	private float JumpBufferTime = 0.1f; // Tiempo para volver a saltar 
	private float gravityScale;
	private float nexDash;

	private Vector3 respawnPoint;
	private Vector2 dir;
	public float x;
    public float y;

	private void Start(){

		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<DetecColision>();
		sr = GetComponent<SpriteRenderer>();
		gravityScale = rb.gravityScale;
		respawnPoint = transform.position;

	}

	private void Update(){

		#region INPUTS
			x = Input.GetAxis("Horizontal");
        	y = Input.GetAxis("Vertical");
			MoveInput.x = Input.GetAxisRaw("Horizontal");
			MoveInput.y = Input.GetAxisRaw("Vertical");
			dir = new Vector2(MoveInput.x, MoveInput.y);

			if(Input.GetButton("Jump")){ // Sigue Ocurriendo Mientras se mantenga presionada la tecla 
				lastJumpTime = JumpBufferTime;
				
			}

			if(Input.GetButtonUp("Jump")){ // Ocurre una 1 vez, cuando suelta la tecla devuelve true 
				OnJumpUp();
			
			}


		#endregion

		#region GIRO PLAYER
            if(MoveInput.x > 0 && !isFacingRight){
                Girar();
            }

            if(MoveInput.x < 0 && isFacingRight){
                Girar();
            }
        #endregion

		#region CHECKS

			if(coll.onGround){ // Verifica si se encuentra en el suelo

				lastGroundedTime = JumpCoyoteTime;
				CanDash = true;
			}

			if(rb.velocity.y <= 0){

				isJumping = false;

			}
			
			// Condiciones de agarre
			if(coll.onWall && Input.GetButton("Grab") && CanMove){
				
				climbing = true;
				Grab();

			}else if(coll.onWall && rb.velocity.y < 0  && (x != 0)){
				slideWall = true;
				SlideWall();

			}else{

				climbing = false;
				slideWall = false;

			}
			
			if(Time.time > nexDash && Input.GetButtonDown("Dash") && CanDash && CanMove){
            	
				CanDash = false;
                Dash();

        	}//else{
				
				//isDashing = false;
				
			//}
		

		#endregion

		#region JUMP

			if(JumpInputRealeased && lastJumpTime > 0 && !isJumping){
					
				if(lastGroundedTime > 0 ){
					Jump();
				
				}

				if(!coll.onGround && coll.onWall && CanWallJump){

					WallJump(WallJumpForce.x, WallJumpForce.y);
					
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
			if (rb.velocity.y < 0 && lastGroundedTime <= 0 && climbing == false && slideWall == false){

				rb.gravityScale = gravityScale * FallGravityMultiplier;
		
			
			}else if(!slideWall && !climbing && !isDashing && CanMove){
				
				rb.gravityScale = gravityScale;
			
			}
		#endregion

	}

	private void Girar(){

		sr.flipX = isFacingRight;
        isFacingRight = !isFacingRight;

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

	private void Grab(){

		rb.gravityScale = 0;
		rb.velocity = new Vector2(rb.velocity.x, 0);	
		float speedModifier = y > 0 ? ClimbTheWall : LowerTheWall;
		rb.velocity = new Vector2(rb.velocity.x, y * (MaxMoveSpeed * speedModifier));
		
	}

	private void SlideWall(){

		rb.velocity = new Vector2(rb.velocity.x, -slideGravity);

	}

	private void WallJump(float jumpForceX, float jumpForceY)
	{

		rb.gravityScale = gravityScale;
		jumpForceX *= -coll.wallSide;  

        StartCoroutine(StopMovement(WallJumpStopRunTime));

		rb.velocity = new Vector2(jumpForceX, jumpForceY);
		
		Girar();

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

	private IEnumerator StopMovementDead(float duration)
	{
		CanMove = false;
		Dead = true;
		yield return new WaitForSeconds(duration);
		Dead = false;
		CanMove = true;
		transform.position = respawnPoint;
	}

	private IEnumerator StopDash(float duration)
	{
		CanMove = false;
		isDashing = true;
		yield return new WaitForSeconds(duration);
		isDashing = false;
		CanMove = true;
	}

	private void Dash()
    {
		nexDash = Time.time + CoolDownDash;
	
		if(dir == Vector2.zero){
			if(isFacingRight){
				dir = new Vector2(1, 0);
			}else{
				dir = new Vector2(-1, 0);
			}
		}

		StartCoroutine(StopDash(TimeDash));
		rb.gravityScale = 0;
        rb.velocity = dir.normalized * dashSpeed;
		

    }

	private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.layer == 7)
        {
			rb.velocity = new Vector2(0, 0);
			rb.gravityScale = 0;
			StartCoroutine(StopMovementDead(0.8f));
			
        }
    	
    }

	private void OnTriggerEnter2D(Collider2D collision){
		
		if(collision.gameObject.layer == 8)
        {
            respawnPoint = transform.position;
        }

	}

}
