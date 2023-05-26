using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float movespeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        Debug.Log("1-Distance form Enemy to Player: " + direction.magnitude);

        //float distance = Vector3.Distance(transform.position, playerTransform.position);
        //Debug.Log("2-Distance form Enemy to Player: " + distance);

        direction.Normalize();
        transform.Translate(direction * Time.deltaTime*movespeed);
    }
}
