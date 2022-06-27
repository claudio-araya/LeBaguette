using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionSelector : MonoBehaviour
{
    [SerializeField] private Vector2 posicionalfinal;
    private Vector2 posicionInicial;

    private void Awake()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, posicionInicial, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = posicionInicial;
    }
}
