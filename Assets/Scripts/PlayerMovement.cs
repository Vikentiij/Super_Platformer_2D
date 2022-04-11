using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GirlMovementController2D controller;

    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // bool fire = false;

    float groundedFix;

    // Update is called once per frame
    void Update()
    {
        groundedFix -= Time.deltaTime;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            groundedFix = 0.2f;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            // fire = true;
            animator.SetBool("IsFire", true);

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            // fire = false;
            animator.SetBool("IsFire", false);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        if (groundedFix <= 0)
            animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        // move our character

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
