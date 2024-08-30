using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 10f;
    public static int health = 5;
    public SpriteRenderer sr;
    public Animator anim;
    // private int jumpCount = 0;
    // public int maxJumpCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sr.flipX = false;
            anim.SetBool("Run", true);
            anim.SetBool("Jump", false);

        }else if(Input.GetKey("a")|| Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sr.flipX = true;
            anim.SetBool("Run", true);
            anim.SetBool("Jump", false);

        }else if(Input.GetKey("w")|| Input.GetKey("up") && ground.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("Jump", true);
            anim.SetBool("inGround", false);
            anim.SetBool("Run", false);
            // if (jumpCount <= maxJumpCount)
            // {
            //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //     jumpCount++;
            // }
        }else if(Input.GetKey("s")|| Input.GetKey("down"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        }else if(ground.isGrounded)
        {
            anim.SetBool("inGround", true);
            anim.SetBool("Jump", false);
        }else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("Run", false);
            anim.SetBool("Jump", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (ground.isGrounded)
    //     {
    //        jumpCount = 0;
    //     }
    //     if(Input.GetKey("d")|| Input.GetKey("right"))
    //     {
    //         rb.velocity = new Vector2(speed, rb.velocity.y);
    //     }else if(Input.GetKey("a")|| Input.GetKey("left"))
    //     {
    //         rb.velocity = new Vector2(-speed, rb.velocity.y);
    //     }else if(Input.GetKey("w")|| Input.GetKey("up") && ground.isGrounded)
    //     {
    //         rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    //         if(Input.GetKey("w")|| Input.GetKey("up") && !ground.isGrounded){
    //             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //         }

    //         if (jumpCount <= maxJumpCount)
    //         {
    //             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //             jumpCount++;
    //         }
    //     }else if(Input.GetKey("s")|| Input.GetKey("down"))
    //     {
    //         rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    //     }
    // }
}
