using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        }
    }
}
