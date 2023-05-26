using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    //để mà phát hiện giữa 2 game object điều kiện tiên quyết là collider và rigidbody
    void OnTriggerExit2D(Collider2D collision)
    {
        //chạy 1 lần
        Debug.Log(collision.gameObject.name+"Exit");
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //chạy nhiều lần
        Debug.Log(collision.gameObject.name+"Stay");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //chạy 1 lần
        Debug.Log(collision.gameObject.name+"Enter");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
