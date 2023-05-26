using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineImpulseSource cinemachineImpulseSourse;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            cinemachineImpulseSourse.GenerateImpulse(Camera.main.transform.forward);
        }
    }
}
