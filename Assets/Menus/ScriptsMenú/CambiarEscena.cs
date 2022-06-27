using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    
    void Update()
    {
        
    }

    public void BotonJugar(){
        LevelLoader1.LoadSelector("LevelSelectorTest");
    }

    public void BotonOpciones()
    {
        SceneManager.LoadScene("opcionesScene", LoadSceneMode.Single);
    }

    public void BotonVolverMenu()
    {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    
}
