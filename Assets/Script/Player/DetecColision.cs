using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecColision : MonoBehaviour{

    [Header("LAYERS")]
    public LayerMask groundLayer; // Detector De Tilemap 

    [Header("DETECCION")]
    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;

    [Space]

    [Header("PUNTOS DE COLISION")]

    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset; // Puntos especificos de colision
    private Color debugCollisionColor = Color.red; // Color de los puntos de colision

    void Start(){
    }

    void Update()
    {  
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer); // Detecta si esta en el suelo
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer) // Detecta si hay una pared
            || Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer); 

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer); // Detecta si hay una pared a la derecha
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer); // Detecta si hay una pared a la izquierda

        wallSide = onRightWall ? -1 : 1; // Detecta el lado de la pared 
    }

    void OnDrawGizmos() // Dibuja los puntos de colision 
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
