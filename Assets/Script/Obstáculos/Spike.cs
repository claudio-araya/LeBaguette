using UnityEngine;

public class Spike : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;

    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {
        // Mueve la Spike solo si esta en modo "attacking"
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirections();
        // Revisa que la Spike vea al jugador en cualquiera de las 4 direcciones
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //Derecha
        directions[1] = -transform.right * range; //Izquierda
        directions[2] = transform.up * range; //Arriba
        directions[3] = -transform.up * range; //Abajo
    }
    private void Stop()
    {
        destination = transform.position; //Cambia la posisión a la que esta acutualmenmte, así no puede moverse
        attacking = false;
    }

    protected void OnTriggerEnter2D(Collider2D collision) // Si la Spike toca al jugador se detiene, y si toca el suelo tambien
    {
        if (collision.tag == "Player")
            Stop();
        
    }

}