using UnityEngine;
using UnityEngine.SceneManagement;


public class Key : MonoBehaviour
{
    public int key = 0;
    ControlJuego controljuego;

    private void Awake()
    {
        controljuego = GameObject.Find("ControlJuego").GetComponent(typeof(ControlJuego)) as ControlJuego;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            controljuego.desbloquearNivel();
            Destroy(gameObject, 1f);
            SceneManager.LoadScene("LevelSelectorTest");

        }
    }
}
