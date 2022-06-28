using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] public GameObject menuPausa;
    [SerializeField] public GameObject player;

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

        //if (Input.GetButtonDown("Restart"))
        //{
        //    Reiniciar();
        //}
    }

    public void Pausa()
    {
        menuPausa.SetActive(true);
        player.SetActive(false);
        Cursor.visible = true;
        comprobar = false;
        abrirMenuPausa.Play("menuAbrir");
        Debug.Log("pausa");
     
    }
    
    public void Reanudar()
    {
        player.SetActive(true);
        Cursor.visible = false;
        comprobar = true;
        abrirMenuPausa.Play("menuCerrar");
        Debug.Log("reanudar");
        menuPausa.SetActive(false);

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