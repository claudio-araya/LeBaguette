using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{

    public Animator animFT;
    public PlayerMovement personaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision) // Si el suelo toca al player se desactiva
    {
        if (collision.tag == "Player"){
            personaje.ControlLuz();
            StartCoroutine(delay());
        }
    }

    IEnumerator delay(){
        animFT.Play("TorchFade");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
