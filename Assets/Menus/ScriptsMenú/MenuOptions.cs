using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class MenuOptions : MonoBehaviour
{
    public Toggle vSyncToggle;
    public Toggle fullscreenToggle;

    public bool flagF;
    public bool flagV;

    public Resolucion[] resolucion;
    public int SelectedRes;
    public Text resText;



    // Screen.currentResolution.width + " x " + Screen.currentResolution.height;
    public void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void FullScreen()
    {
        if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
            flagF = true;
        }
        else
        {
            Screen.fullScreen = false;
            flagF = false;
        }
    }

    public void vSync()
    {
        if (vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
            flagV = true;

        }else
        {
            QualitySettings.vSyncCount = 0;
            flagV = false;
        }
    }

    public void left()
    {
        if (SelectedRes > 0)
        {
            SelectedRes--;
        }
        resText.text = resolucion[SelectedRes].width + " x " + resolucion[SelectedRes].height;
    }
    public void rigth()
    {
        if (SelectedRes < resolucion.Length - 1)
        {
            SelectedRes++;
        }
        resText.text = resolucion[SelectedRes].width + " x " + resolucion[SelectedRes].height;
    }

    public void SetResolution()
    {
        if (resText.text == "Nativo")
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullscreenToggle.isOn);
            resText.text = "Nativo";
        } 
        else
        {
            Screen.SetResolution(resolucion[SelectedRes].width, resolucion[SelectedRes].height, fullscreenToggle.isOn);
        }
    }

    public void guardar()
    {
        SetResolution();

        if (flagF)          //Para aplicar fullscreen solo si es True
        {        
            FullScreen();
        }
        if (flagV)          //Para aplicar vsync solo si es True 
        {        
            vSync();
        }
    }
}