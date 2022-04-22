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

    public void BotonOpciones()
    {
        SceneManager.LoadScene("opcionesScene");
    }

    public void BotonRanking()
    {
        SceneManager.LoadScene("rankingScene");
    }

    public void BotonCreditos()
    {
        SceneManager.LoadScene("creditosScene");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    public void BotonGraficos()
    {
        SceneManager.LoadScene("");
    }

    public void BotonSonidos()
    {
        SceneManager.LoadScene("");
    }

    public void BotonControles()
    {
        SceneManager.LoadScene("");
    }

    public void BotonVolverMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
