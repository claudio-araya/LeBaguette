using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMove : MonoBehaviour
{
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
            (mousePosX/Screen.width) * 10 + (Screen.width /2),
            (mousePosY / Screen.height) * 10 + (Screen.height / 2));
    }
}
