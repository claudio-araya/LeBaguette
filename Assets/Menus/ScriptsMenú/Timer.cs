 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text UItexto;
    private int segundos = 0;
    private int minutos = 0;
    public int total = 0;
    public float mili = 0;

    private void Awake(){
        InvokeRepeating("Cronometro", 0f, 0.05f);
    }

    void Cronometro() {

        segundos++;
        mili++;
        if (mili == 1000) { 
            if (segundos == 60) {
                segundos = 0;
                minutos++;
            }
        }
        if (minutos >= 10){
            if (segundos >= 10)
                UItexto.text = (minutos.ToString() + ":" + segundos.ToString() + ":" + mili.ToString());
            else
                UItexto.text = (minutos.ToString() + ":0" + segundos.ToString() + ":" + mili.ToString());
        }
        else{
            if (segundos >= 10)
                UItexto.text = ("0" + minutos.ToString() + ":" + segundos.ToString() + ":" + mili.ToString());
            else
                UItexto.text = ("0" + minutos.ToString() + ":0" + segundos.ToString() + ":" + mili.ToString());
        }

        total = minutos * 60 + segundos;
        Debug.Log("El jugador lleva en total "+mili);
        total = 0;
    }
}
