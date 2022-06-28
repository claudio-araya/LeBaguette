using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitarJet : MonoBehaviour
{
    public Jet ScriptJet;
    public GameObject ImageJet;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            ScriptJet.enabled = false;
            ImageJet.SetActive(false);

        }
    }
}
