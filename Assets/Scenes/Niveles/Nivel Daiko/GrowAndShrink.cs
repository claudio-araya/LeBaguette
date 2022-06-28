using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAndShrink : MonoBehaviour
{
    public float scaleRate;
    public float minScale;
    public float maxScale;
    public float waitTime;
    float timer; 
 
    void Start()
    {
        
    }

    
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > waitTime){

            if(transform.localScale.x < minScale) {
            scaleRate = Mathf.Abs(scaleRate);

            }
            else if(transform.localScale.x > maxScale) {
                scaleRate = -Mathf.Abs(scaleRate);

            }
            transform.localScale += Vector3.one * scaleRate;
            timer = 0;

        }
       

    }

    
}
 
 
