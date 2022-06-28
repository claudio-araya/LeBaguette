using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    public Animator abrirMenuPausa;
    bool comprobar = true;
    bool comprobar2;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
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
        abrirMenuPausa.Play("menuAbrir");
        comprobar = false;
    
        //botonPausa.SetActive(false);
        //comprobar2 = true;
    }
    
    public void Reanudar()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
     
        abrirMenuPausa.Play("menuCerrar");
        comprobar = true;
    
    
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