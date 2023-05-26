using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private float directionX;
    private float directionY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        Debug.Log(directionX);
        directionY = Input.GetAxis("Vertical");
        Debug.Log(directionY);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump");
        }
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Click");
        }
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Left Mouse Held Down");
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G is pressed");
        }
    }
}
