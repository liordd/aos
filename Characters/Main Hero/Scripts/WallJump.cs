using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{



    public bool canWallJump;
    public bool canJump;
    public bool blockMoveX;


    public PlayerController pCont;
    public GroundChecker gCheck;
    public CharacterAnimation charAnim;

    

    private Collider2D collision;

    private float coolDownTime = 0.5f;
    private float slidingTime = 0.2f;
    private float slidingStop = 0;
    private float nextJumpTime = 0;

    public float slideSpeed = 6f;

    public bool WallUpJump;

    // Update is called once per frame
    private void Update()
    {
        WallsJump();
    }



    private void WallsJump()
    {
        if (Time.time > nextJumpTime)
        {
            if (Input.GetKeyDown(KeyCode.W) && canJump)
            {
                pCont.DoJump();
                nextJumpTime = Time.time + coolDownTime;
            }

            else 
            {
                WallUpJump = false;
            }

        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {

            if (gCheck.isGrounded == false && Input.GetKey(KeyCode.J))
            {
                WallUpJump = true;
                canWallJump = true;
                pCont.rb.velocity = new Vector2(0, slideSpeed);
                slidingStop = Time.time + slidingTime;

                Debug.Log("Sliding");

            }

            else
            {
                canWallJump = false;
                WallUpJump = false;
                Debug.Log("Suck Cock");
            }

            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            canWallJump = false;
            WallUpJump = false;
        }
    }



}
