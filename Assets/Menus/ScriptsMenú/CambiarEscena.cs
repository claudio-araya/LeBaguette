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
        LevelLoader.LoadLevel("LevelSelectorTest");
    }

    public void BotonOpciones()
    {
        SceneManager.LoadScene("opcionesScene", LoadSceneMode.Single);
    }

    public void BotonVolverMenu()
    {
        LevelLoader1.LoadSelector("mainMenu");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    
}
