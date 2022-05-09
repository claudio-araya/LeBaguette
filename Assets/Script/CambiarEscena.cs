using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonJugar(){
        SceneManager.LoadScene("LevelSelectorTest");
    }

    public void BotonOpciones()
    {
        SceneManager.LoadScene("opcionesScene");
    }

    public void BotonVolverMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    
}
