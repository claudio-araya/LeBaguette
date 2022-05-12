using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocultador : MonoBehaviour
{
    public GameObject entrada;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            StartCoroutine(delay());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            entrada.SetActive(false);
        }
    }

    IEnumerator delay(){
        yield return new WaitForSeconds(1);
        entrada.SetActive(true);
    }
}
