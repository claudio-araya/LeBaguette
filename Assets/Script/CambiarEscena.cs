using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonJugar(){
        SceneManager.LoadScene("LevelSelectorTest");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    public void BotonVolverMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
