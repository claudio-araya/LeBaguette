using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Boton : MonoBehaviour
{
    public string escena;
    public Color[] colores;
    public bool seleccionado = false;
    public Animator animacion1,animacion2,animacion3;
    public Image boton;
    
    void Start(){ 
    
        boton.color = colores[0]; 
    }

    void FixedUpdate()
    {
        if (seleccionado)
        {
            boton.color = colores[1];

        }else
        {
            boton.color = colores[0];
        }


        if (Input.GetKeyDown(KeyCode.Space) && seleccionado)
        {
            SceneManager.LoadScene(escena, LoadSceneMode.Single);
        }

    }
}

