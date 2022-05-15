using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadObjeto : MonoBehaviour

{

    private Rigidbody2D rb;

    private void Start(){

		rb = GetComponent<Rigidbody2D>();

	}

    protected void OnCollisionEnter2D(Collision2D collision){ // Si el suelo toca al player se desactiva
        if (collision.gameObject.tag == "Player"){
            rb.gravityScale = 5;
            StartCoroutine(delay());

        }
            
   
    }

    IEnumerator delay(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }


}