using UnityEngine;
using UnityEngine.SceneManagement;


public class Key : MonoBehaviour
{
    [SerializeField] private GameObject menuTiempo;
    ControlJuego controljuego;
    public Timer2 tiempo;
    public int key = 0;
    public float puntaje;
    public string tiempoS;

    private void Awake()
    {
        controljuego = GameObject.Find("ControlJuego").GetComponent(typeof(ControlJuego)) as ControlJuego;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            menuTiempo.SetActive(true);

            tiempo = FindObjectOfType<Timer2>();
            puntaje = (float)(tiempo.timeElapsed); //(tiempo.minutos * 6000) + (tiempo.segundos * 100) + (tiempo.centesimas);
            tiempoS = string.Format("{0:00}:{1:00}:{2:00}", tiempo.minutos, tiempo.segundos, tiempo.centesimas);

            GetComponent<SpriteRenderer>().enabled = false;
            controljuego.desbloquearNivel();
            Destroy(gameObject, 1f);

        }
    }
}
