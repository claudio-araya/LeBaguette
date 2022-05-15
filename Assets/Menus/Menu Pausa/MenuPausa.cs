using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pausa();
    }
    public void Pausa()
    {
        Time.timeScale = 0f;

        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Reanudar();
    }

    public void Volver()
    {
        SceneManager.LoadScene("LevelSelectorTest");
        Time.timeScale = 1f;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1f;
    }
}