using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : MonoBehaviour
{
    public string escena;
    public Color[] colores;
    public bool seleccionado = false;
    public Image boton;
    private MenuPausa menu;

    void Start(){

        menu = FindObjectOfType<MenuPausa>();
        boton.color = colores[0]; 
    }

    void Update()
    {
        if (seleccionado)
        {
            boton.color = colores[1];

        }else
        {
            boton.color = colores[0];
        }


        if (Input.GetButton("Jump") && seleccionado && escena == "Resume")
        {
            menu.Reanudar();
        } else if (Input.GetButton("Jump") && seleccionado && escena == "Reiniciar")
        {
            menu.Reiniciar();
        } else if (Input.GetButton("Jump") && seleccionado)
        {
            SceneManager.LoadScene(escena, LoadSceneMode.Single);
        }


    }
}

