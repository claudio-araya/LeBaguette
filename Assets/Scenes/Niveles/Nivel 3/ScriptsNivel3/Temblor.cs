using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Temblor : MonoBehaviour
{
    public static Temblor Instance{get;private set;}
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTimer > 0){

            shakeTimer -= Time.deltaTime;

            if(shakeTimer <= 0f){

                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
                                                                       
    }
    private void Awake(){
        Instance = this;
        cinemachineVirtualCamera=GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity,float time){
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=
    
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
}
