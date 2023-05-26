using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer trailRenderer;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private BoxCollider2D boxCollider2D;

    private float directionX;
    bool IsJumping;
    private bool IsDoubleJump;

    private bool canDash = true;
    private bool isDashing;
    [SerializeField]
    private float dashingPower = 24f;
    [SerializeField]
    private float dashingTime = 0.2f;
    [SerializeField]
    private float dashingCooldown = 1f;

    [SerializeField]
    private ParticleSystem moveEffect;
    [SerializeField]
    private ParticleSystem jumpEffect;

    [Range(0,10)]
    [SerializeField]
    private int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField]
    private float dustFormationPeriod;

    private float counter;

    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling,
    }
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    private MovementState movementState;
    
    void Start()
    {
        trailRenderer.emitting = false;
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        counter += Time.deltaTime;
        if(IsGround() && Mathf.Abs(rb.velocity.x)>occurAfterVelocity)
        {
            if(counter>dustFormationPeriod)
            {
                moveEffect.Play();
                counter = 0;
            }
        }
        directionX = Input.GetAxis("Horizontal");
        ChangeDirection();
        UpdateAnimation();
        if(Input.GetKeyDown(KeyCode.LeftShift)&&canDash)
        {
            StartCoroutine(Dash());
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_DASH);
            }
        }
        Jumping();
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        Moving();
        
        
    }
    private void ChangeDirection()
    {
        if (directionX > 0)//nhân vật quay sang phải
        {
            spriteRenderer.flipX = false;
        }
        if (directionX < 0)//nhân vật quay sang trái
        {
            spriteRenderer.flipX = true;
        } 
    }
    private void Moving()
    {
        rb.velocity = new Vector2(directionX * playerSpeed, rb.velocity.y);
    }
    private void UpdateAnimation()
    {
        if(directionX!=0)
        {
            //đang di chuyển
            movementState = MovementState.Running;
        }
        else
        {
            //đứng yên
            movementState = MovementState.Idle;
        }
        if(rb.velocity.y>0.1f)
        {
            //nhảy
            movementState = MovementState.Jumping;
        }
        if(rb.velocity.y<-0.1f)
        {
            //ngã
            movementState = MovementState.Falling;
        }
        animator.SetInteger("State", (int)movementState);
    }
    private void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            IsJumping = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            IsJumping = false;
        }
        if(IsGround() && !IsJumping)
        {
            IsDoubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if(IsGround() || IsDoubleJump)
            {
           
                if(AudioManager.HasInstance)
                {
                    AudioManager.Instance.PlaySE(AUDIO.SE_JUMP);
                }
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                IsDoubleJump = !IsDoubleJump;
                animator.SetBool("DoubleJump", !IsDoubleJump);
                //jump effect
                if(!IsDoubleJump)
                {
                    jumpEffect.Play();
                }
            }
        }
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,
            0f, Vector2.down, 0.1f, jumpableGround);
    }
    private IEnumerator Dash()
    {
        canDash = false;//khi nhân vật lướt,set= false để nhân vật k lướt liên tục 2 lần
        isDashing = true;//ngăn chặn input của nhân vật khi đang lướt
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;//set trọng lực = 0 để khi nhân vật nhảy và lướt sẽ k bị rơi
        rb.velocity=new Vector2(directionX*dashingPower,0f);//set khoảng cách lướt của nhân vật
        trailRenderer.emitting = true;//hiển thị đường vẽ khi lướt
        yield return new WaitForSeconds(dashingTime);//khoảng thời gian khi nhân vật lướt
        trailRenderer.emitting = false;//tắt đường vẽ khi lướt
        rb.gravityScale = originalGravity;//đặt trọng lực về giá trị ban đầu
        isDashing = false;//cho nhân vật di chuyển bình thường
        yield return new WaitForSeconds(dashingCooldown);//thời gian chờ để lướt lần tiếp theo
        canDash = true;//cho nhân vật lướt lần tiếp theo
    }
}
