using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class MenuOptions : MonoBehaviour
{
    public Toggle vSyncToggle;
    public Toggle fullscreenToggle;

    public Resolucion[] resolucion;
    public int SelectedRes;
    public Text resText;

    public void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        if (resText.text == " ")
        {

        }
    }

    public void FullScreen()
    {
        if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    public void vSync()
    {
        if (vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }else
        {
            QualitySettings.vSyncCount = 0;
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
        Screen.SetResolution(resolucion[SelectedRes].width, resolucion[SelectedRes].height, fullscreenToggle.isOn);
    }

    public void guardar()
    {
        SetResolution();
        FullScreen();
        vSync();
    }

}