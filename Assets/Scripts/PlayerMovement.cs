using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D col2d;
    Animator animator;
    
    /* public float cooldown;
    public float cooldownTimer; */

    private float horizontalMovement;
    public float movementSpeed;
    [SerializeField] private bool jump = false;
    public float jumpForce;
    [SerializeField] private bool groundCheck;
    public bool isWalking = false;
    // public int dash;


    void Start()
    {
        QualitySettings.vSyncCount = 1;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col2d = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

    }

    

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && groundCheck)
        {
            if (!isWalking)
                {
                    SoundManager.instance.playOneShot(soundTypes.walk);
                    isWalking = true;
                }
        }
        
        if (!groundCheck || Input.GetAxisRaw("Horizontal") == 0)
        {
            isWalking = false;
            SoundManager.instance.Stop();
        } */     

        /* if (cooldownTimer > 0)
        {cooldownTimer -= Time.deltaTime;}
        if (cooldownTimer < 0)
        {cooldownTimer = 0;}

        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer == 0)
        {
            Debug.Log("cd");
            Dash();
            cooldownTimer = cooldown;
        } */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        groundCheck = Grounded();
        

    }

    void FixedUpdate()  
    {
        Move();
        
        if (Grounded() && jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        jump = false;
        animatonControl();

    }

    void Move()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");



        
        
        if (horizontalMovement != 0 && groundCheck)
        {
            if (!isWalking)
            {
                isWalking = true;
                SoundManager.instance.playOneShot(soundTypes.walk);
            }
            
            animator.SetBool("isRunning", true);
        }            
        if (horizontalMovement == 0 || !groundCheck)
        {
            if (isWalking)
            {
                isWalking = false;
                SoundManager.instance.Stop();
            }
            animator.SetBool("isRunning", false);
        }
        
        if (Input.GetKey(KeyCode.D))
        {   
            spriteRenderer.flipX = false;
            transform.position += new Vector3(movementSpeed * horizontalMovement * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            transform.position += new Vector3(movementSpeed * horizontalMovement * Time.deltaTime, 0f, 0f);
        }

    }

    bool Grounded()
    {
        float laserLength = 0.3f;
        Vector2 startPosition = (Vector2) transform.position - new Vector2(0f, (col2d.bounds.extents.y) + 0.05f);
        int layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.down, laserLength, layerMask);
        
        return hit.collider != null;
    }

    /*void Dash()
    {
        if (!spriteRenderer.flipX)
        {   
            transform.position += new Vector3(dash * horizontalMovement * Time.deltaTime, 0f, 0f);
        }
        if (spriteRenderer.flipX)
        {
            transform.position += new Vector3(dash * horizontalMovement * Time.deltaTime, 0f, 0f);
        }

    }*/

   void animatonControl()
    {
        if (rb.velocity.y > 0f)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("Jump", true);
        }
        if (rb.velocity.y < 0f)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("isFalling", true);
        }
        if (groundCheck)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("isFalling", false);
        }
      
    }
    
}
