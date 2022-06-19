using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{

    public Animator animDoorOpen;
    
    protected void OnTriggerEnter2D(Collider2D collision) // Si el suelo toca al player se desactiva
    {
        if (collision.tag == "Player"){
            animDoorOpen.Play("DoorOpen");
        }
    }
}