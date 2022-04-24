using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    // REFERENCIAS 

    private PlayerMovement MovePlayer;
    private Animator anim;
    private DetecColision coll;

    void Start(){
        
        anim = GetComponent<Animator>();
        coll = GetComponent<DetecColision>();
        MovePlayer = GetComponent<PlayerMovement>();

    }

    
    void Update(){
        
        anim.SetBool("Correr", MovePlayer.x != 0);
        anim.SetBool("OnGround", coll.onGround);
        anim.SetBool("isJumping", MovePlayer.isJumping);
        anim.SetBool("MirarArriba", MovePlayer.y > 0 && MovePlayer.x == 0);
        anim.SetBool("Climbing", MovePlayer.climbing);
        anim.SetBool("SlideWall", MovePlayer.slideWall);
        anim.SetBool("ClimbingUp", MovePlayer.y > 0 && MovePlayer.climbing);
        anim.SetBool("isDashing", MovePlayer.isDashing);
    }
}
