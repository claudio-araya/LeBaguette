using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMove : MonoBehaviour
{
    public int fuerza;
    float mousePosX;
    float mousePosY;
    void Start()
    {
        
    }

    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
            (mousePosX/Screen.width) * fuerza + (Screen.width /2),
            (mousePosY / Screen.height) * fuerza + (Screen.height / 2));
    }
}
