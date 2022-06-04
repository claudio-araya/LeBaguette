using UnityEngine;
using UnityEngine.SceneManagement;


public class Key : MonoBehaviour
{
    ControlJuego controljuego;
    public Timer2 tiempo;
    public int key = 0;
    public int puntaje;

    private void Awake()
    {
        controljuego = GameObject.Find("ControlJuego").GetComponent(typeof(ControlJuego)) as ControlJuego;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            tiempo = FindObjectOfType<Timer2>();
            puntaje = (tiempo.minutos * 6000) + (tiempo.segundos * 100) + (tiempo.centesimas);
            Debug.Log(puntaje);

            //timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, centesimas);

            GetComponent<SpriteRenderer>().enabled = false;
            controljuego.desbloquearNivel();
            Destroy(gameObject, 1f);
            //SceneManager.LoadScene("LevelSelectorTest");

        }
    }
}
