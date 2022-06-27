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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Reanudar();
    }

    public void Volver()
    {
        SceneManager.LoadScene("LevelSelectorTest");
        Time.timeScale = 1f;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1f;
    }
}