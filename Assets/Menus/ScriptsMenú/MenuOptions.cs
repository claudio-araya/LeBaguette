using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class MenuOptions : MonoBehaviour
{
    public Toggle vSyncToggle;
    public Toggle fullscreenToggle;

    void Start()
    {
        RevisarResolucion();

        fullscreenToggle.isOn = Screen.fullScreen;            
    }
    public void Volumen(float volumen)
    {

    }
    
    //For some reason no logro hacer que funcione :((
    public void LimitarFPS()
    {
        if (vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    public TMP_Dropdown resolucionesDropdown;
    Resolution[] resoluciones;                  //Arreglo que guarda todas las resoluciones de nuestro ordenador

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }

        resolucionesDropdown.AddOptions(opciones);
        resolucionesDropdown.value = resolucionActual;
        resolucionesDropdown.RefreshShownValue();

        resolucionesDropdown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }
    
    public void CambiarResolucion(int indexResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropdown.value);

        Resolution resolucion = resoluciones[indexResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}