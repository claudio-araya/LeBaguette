using UnityEngine;

public class Invisible : MonoBehaviour
{

    public Animator animF;

    protected void OnTriggerEnter2D(Collider2D collision) // Si el suelo toca al player se desactiva
    {
        if (collision.tag == "Player"){
            animF.Play("Fade");
        }
    }

}