 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text UItexto;
    private int segundos = 57;
    private int minutos = 9;
    public int total = 0;

    private void Awake()
    {
        InvokeRepeating("Cronometro", 0f, 1f);
    }
    
    void Cronometro()
    {

        segundos++;
        if (segundos == 60)
        {
            segundos = 0;
            minutos++;
        }
        
        if(minutos >= 10)
        {
            if (segundos >= 10)
            {
                UItexto.text = (minutos.ToString() + ":" + segundos.ToString());
            }
            else
            {
                UItexto.text = (minutos.ToString() + ":0" + segundos.ToString());
            }
        }
        else
        {
            if (segundos >= 10)
            {
                UItexto.text = ("0" + minutos.ToString() + ":" + segundos.ToString());
            }
            else
            {
                UItexto.text = ("0" + minutos.ToString() + ":0" + segundos.ToString());
            }

        }

        total = minutos * 60 + segundos;
        Debug.Log("El jugador lleva en total "+total);
        
        total = 0;
    }

}
