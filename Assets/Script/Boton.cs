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
    [SerializeField] private TMP_Text texto;


    void Start()
    {
        texto.color = colores[0]; 
    }

    void Update()
    {
        if (seleccionado)
        {
            texto.color = colores[1];

        }else
        {
            texto.color = colores[0];
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && seleccionado) {
            SceneManager.LoadScene(escena, LoadSceneMode.Single);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
        }
    }
}
