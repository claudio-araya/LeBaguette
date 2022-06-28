using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadTest : MonoBehaviour
{

    //public Rigidbody2D rb;
    public PlayerMovement Player;
    public float force;
    private float RotateZ;
    private Quaternion Rotation;
 
    private void Start()
    {
    
        RotateZ = transform.localRotation.eulerAngles.z;
        Rotation = Quaternion.Euler( 0, 0, RotateZ);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Rotation * Vector2.up * force, ForceMode2D.Impulse);
            Player.inpulse222();
        
        }
    }
 
}
