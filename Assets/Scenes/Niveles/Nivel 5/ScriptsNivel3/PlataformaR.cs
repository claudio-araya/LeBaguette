using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaR : MonoBehaviour
{
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision){ 
        if (collision.gameObject.tag == "Player"){
            StartCoroutine(delay());

        }
    }
    IEnumerator delay(){
        yield return new WaitForSeconds(0.5f);
        bc.enabled = false;
        sr.enabled = false;
        yield return new WaitForSeconds(1);
        bc.enabled = true;
        sr.enabled = true;
        
    }
}
