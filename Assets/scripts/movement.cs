using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 10f;
    private int jumpCount = 0;
    public int maxJumpCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.isGrounded)
        {
           jumpCount = 0;
        }
        if(Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }else if(Input.GetKey("a")|| Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }else if(Input.GetKey("w")|| Input.GetKey("up") && ground.isGrounded)
        {
            // rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // if(Input.GetKey("w")|| Input.GetKey("up") && !ground.isGrounded){
            //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            // }

            if (jumpCount <= maxJumpCount)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;
            }
        }else if(Input.GetKey("s")|| Input.GetKey("down"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        }
    }
}
