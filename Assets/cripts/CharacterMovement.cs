using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 movement;
    private float movementSqrMagnitude;
    public float walkSpeed = 3.5f;
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpAmount = 7;
    float jumpTimer;
    bool startJumpTimer = false;
    bool canJump = true;
    float canJumpTimer;
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            startJumpTimer = true;

            anim.SetTrigger("isJumping");
        }
        if (startJumpTimer)
        {
            jumpTimer += Time.deltaTime;
            if(jumpTimer > 0.5f)
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                jumpTimer = 0.0f;
                startJumpTimer = false;

            }
        }
        if (!canJump)
        {
            canJumpTimer += Time.deltaTime;
            if (canJumpTimer > 1.0f)
            {
                canJumpTimer = 0.0f;
                canJump = true;
            }
        }
    GetMovementInput();
        CharacterPosition();
        CharacterRotation();
        WalkAnimation();
        FootstepAudio();
    }

    void GetMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movementSqrMagnitude = Vector2.SqrMagnitude(movement);
        Debug.Log(movement);
    }

    void CharacterPosition()
    {
        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);
    }
    void CharacterRotation()
    {
        if(movement != Vector2.zero)
        {
            if (movement.x < 0)
                transform.localScale = new Vector2(-0.5f, 0.5f);
            else
                transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }
    void WalkAnimation()
    {
        anim.SetFloat("MovingSpeed", movementSqrMagnitude);
    }
    void FootstepAudio()
    {

    }
}
