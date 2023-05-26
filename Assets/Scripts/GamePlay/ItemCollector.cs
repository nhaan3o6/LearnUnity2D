using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public delegate void CollectApple(int apple);//định nghĩa hàm delegate
    public static CollectApple collectAppleDelegate;//khai báo hàm delegate
    private int apples = 0;
    private void Start()
    {
        if(GameManager.Instance!=null)
        {
            apples = GameManager.Instance.Aplles;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_COLLECT);
            }
            apples++;
            if(GameManager.Instance!=null)
            {
                GameManager.Instance.UpdateAplle(apples);
            }
            collectAppleDelegate(apples);//phát sự kiện
            Debug.Log("Apple: " + apples);
            Destroy(collision.gameObject);
        }
    }
}
