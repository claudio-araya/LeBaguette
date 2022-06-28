using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public Animator abrirMenuPausa;
    bool comprobar;

    private void Start()
    {
        Cursor.visible = false;
        comprobar = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")){

            if (comprobar == true){
                Pausa();
                
            }else{
                Reanudar();

            }
        }

        if (Input.GetButtonDown("Restart"))
        {
            Reiniciar();
        }
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        comprobar = false;
        abrirMenuPausa.Play("menuAbrir");
        Debug.Log("pausa");
     
    }
    
    public void Reanudar()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        comprobar = true;
        abrirMenuPausa.Play("menuCerrar");
        Debug.Log("reanudar");
     
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