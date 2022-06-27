using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class SelectorNiveles : MonoBehaviour
{
    [SerializeField] private Button botonPrev;
    [SerializeField] private Button botonNext;
    private int nivel;

    private void Awake()
    {
        SelectLevel(0);
    }
    private void SelectLevel(int indice)
    {
        botonPrev.interactable = (indice != 0);
        botonNext.interactable = (indice < 5);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == indice);
        }
    } 

    public void cambioNivel(int change)
    {
        nivel += change;
        SelectLevel(nivel);
    }
        
}
