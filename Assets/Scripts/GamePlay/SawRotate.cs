using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 2f;
    void Update()
    {
        transform.Rotate(0, 0, 360 * rotateSpeed * Time.deltaTime);
    }
}
