using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public Animator abrirMenuPausa;
    bool comprobar = false;
    bool comprobar2 = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reiniciar();
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        if (comprobar == false)
        {
            abrirMenuPausa.Play("menuAbrir");
            comprobar = true;
        }
        //botonPausa.SetActive(false);
        comprobar2 = true;
    }
    
    public void Reanudar()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        if (comprobar2 == true)
        {
            //abrirMenuPausa.Play("menuCerrar");
            comprobar = false;
        }
        //botonPausa.SetActive(true);
    }

    public void Reiniciar()
    {
        LevelLoader.LoadLevel(SceneManager.GetActiveScene().name);
        Reanudar();
    }

    public void Volver()
    {
        LevelLoader.LoadLevel("LevelSelectorTest");
        Time.timeScale = 1f;
        BGmusic.instance.GetComponent<AudioSource>().Play();
    }

    public void BackMenu()
    {
        LevelLoader.LoadLevel("mainMenu");
        Time.timeScale = 1f;
        BGmusic.instance.GetComponent<AudioSource>().Play();
    }
}