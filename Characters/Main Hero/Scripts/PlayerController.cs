using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    

    private float speed = 10f;
    public float jumpForce = 8f;
    public float moveInput;


    public Rigidbody2D rb;

    public bool facingRight = true;

    public GroundChecker gCheck;

    public object player;

    public WallJump wJump;

    void Start()
    {
        gCheck.extraJumps = gCheck.extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {

        Walk();

        Freeze();

        FlipCondition();


    }


    public void Walk()
    {
        if (!wJump.blockMoveX)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        
    }


    public void FlipCondition()
    {
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    void Freeze()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }



    public void Jump()
    {

        if (gCheck.isGrounded == true || wJump.canWallJump == true)
        {
            wJump.canJump = true;
            wJump.blockMoveX = false;
        }

        else
        {
            wJump.canJump = false;
        }


    }

    public void DoJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }





}
