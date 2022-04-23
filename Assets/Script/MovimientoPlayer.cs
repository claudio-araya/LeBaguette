using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour{

    // REFERENCIAS 

    private Rigidbody2D rb;
    private DetecColision coll;
    
    [Header("MOVIMIENTO")]

    [SerializeField] public float VelocidadMax;
    [SerializeField] public float Aceleración;
    [SerializeField] public float Desaceleración;
    [SerializeField] public float VelPower;
    

    [Header("SALTO")]
    
    [SerializeField] public float FuerzaSalto;
    [SerializeField] public float CoyoteTime;
    [SerializeField] [Range(0,1)] public float CorteSalto; 
   

    // Condiciones 
    [Header("VERIFICANDO CONDICIONES")]
    
    // Movimiento 
    public bool CanMove = true;
    public bool isFacingRight = true;
    public bool isRunning;
    // Salto
    public bool isJumping;
    // Pared 

    //Dash 

    // VARIABLES SIN VALOR 
    private Vector2 MoveInput;
    public float x;
    public float y;


    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<DetecColision>();
    
    }

    private void Update(){
        
        #region INPUTS 
            x = Input.GetAxis("Horizontal");
        	y = Input.GetAxis("Vertical");
			MoveInput.x = Input.GetAxisRaw("Horizontal");
			MoveInput.y = Input.GetAxisRaw("Vertical");
        #endregion
        
        #region GIRO PLAYER
            if(MoveInput.x > 0 && !isFacingRight){
                Girar();
            }

            if(MoveInput.x < 0 && isFacingRight){
                Girar();
            }
        #endregion
    }

    private void FixedUpdate(){

        #region MOVIMIENTO   
			if(CanMove){

				float targetSpeed = MoveInput.x * VelocidadMax; // calcula la direccion en la que queremos movernos y nuestra velocidad deseada
				float speedDif = targetSpeed - rb.velocity.x; //calcula la diferencia entre la velocidad actual y la velocidad deseada
				float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Aceleración : Desaceleración; // cambiar la tasa de aceleracion dependiendo de la situacion
				float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, VelPower) * Mathf.Sign(speedDif); //aplica aceleracion a la diferencia de velocidad, la eleva a una potencia establecida para que la aceleracion aumente con velocidades mas altas, finalmente se multiplica por signo para volver a aplicar la direccion
                rb.AddForce(movement * Vector2.right); // aplica fuerza fuerza a rigidbody, multiplicando por Vector2.right para que solo afecte el eje X
			}
		#endregion
        
    }

    private void Girar(){

        Vector3 MoveActual = gameObject.transform.localScale;
        MoveActual.x *= -1;
        gameObject.transform.localScale = MoveActual;
        isFacingRight = !isFacingRight;

    }

}
