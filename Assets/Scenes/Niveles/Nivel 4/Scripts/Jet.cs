using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    private Rigidbody2D body;
    public float FuerzaY;
    
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jet")){
            body.AddForce(FuerzaY * Vector2.up, ForceMode2D.Impulse);
        
        }
    }
}
