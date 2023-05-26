using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    private Transform playerSpawnPoint;
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            playerSpawnPoint = collision.gameObject.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            
        }
    }
    private void Die()
    {
        if(AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_DEATH);
        }
        //không cho nhân vật di chuyển
        rb.bodyType = RigidbodyType2D.Static;
        //play death animation
        animator.SetTrigger("Death");
    }
    private void ReSpawn()
    {
        //set vị trí nhân vật về vị trí ban đầu
        this.transform.position = playerSpawnPoint.position;
        //cho nhân vật di chuyển
        rb.bodyType = RigidbodyType2D.Dynamic;
        //reset animation state
        animator.Rebind();
    }
}
