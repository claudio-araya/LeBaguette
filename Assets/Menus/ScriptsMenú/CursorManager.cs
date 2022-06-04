using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Texture2D cursorNormal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursorBoton;
    public Vector2 botonCursorHotSpot;


    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorBoton, botonCursorHotSpot, CursorMode.Auto);
    }
    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorNormal, normalCursorHotSpot, CursorMode.Auto);
    } 
}
