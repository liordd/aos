using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{


    private Animator anim;

    public GroundChecker gCheck;

    public WallJump wJump;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 

    }

    // Update is called once per frame
    void Update()
    {
       Run();
       Jump();
    }


    public void Run()
    {
        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) && gCheck.isGrounded == true)
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);
        }

        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (gCheck.isGrounded == true && wJump.canWallJump == false))
        {
            anim.SetBool("IsRunning", true);
        }

        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (gCheck.isGrounded == true && wJump.canWallJump == true))
        {
            anim.SetBool("IsRunning", true);
        }

        else
        {
            anim.SetBool("IsRunning", false);
        }



    }



    public void Jump()
    {

        if (gCheck.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (wJump.canWallJump == false)
                {
                    anim.SetBool("IsIdle", false);
                    anim.SetBool("IsSliding", false);
                    anim.SetBool("IsRunning", false);
                    anim.SetBool("IsFalling", false);

                }
                else if (wJump.canWallJump == true)
                {
                    anim.SetBool("IsSliding", true);
                    anim.SetBool("IsFalling", false);
                    anim.SetBool("IsRunning", false);
                    anim.SetBool("IsIdle", false);

                }
            }

     

            else if (wJump.canWallJump == true)
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsSliding", false);
                anim.SetBool("IsFalling", false);

            }

            else if (wJump.canWallJump == false)
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsSliding", false);
                anim.SetBool("IsFalling", false);

            }

        }

        else if (gCheck.isGrounded == false)
        {
            if (wJump.canWallJump == true)
            {
                anim.SetBool("IsSliding", true);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsFalling", false);

            }

            else if (wJump.canWallJump == false)
            {
                anim.SetBool("IsSliding", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsFalling", true);

            }

            if (wJump.WallUpJump == true)
            {
                anim.SetBool("IsWallJumping", true);
                anim.SetBool("IsSliding", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsRunning", false);
            }

            else if (wJump.WallUpJump == false)
            
            {
                anim.SetBool("IsWallJumping", false);
            }
        }

    }

}
