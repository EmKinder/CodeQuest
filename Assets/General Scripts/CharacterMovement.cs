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
    [SerializeField] bool movementUnlocked = false;
    [SerializeField] SpriteRenderer sprite;
    float spriteFlashTimer;
    [SerializeField] Material[] materials;
    int currentMat = 0;
    EventManager eventManager;

    private void Start()
    {
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
    }
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
            if (jumpTimer > 0.5f)
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
        if (movementUnlocked)
        {
            GetMovementInput();
            CharacterPosition();
            CharacterRotation();
            WalkAnimation();
            FootstepAudio();
        }
        else
        {
            spriteFlashTimer += Time.deltaTime;
            if(spriteFlashTimer >= 0.5f)
            {
               if(currentMat == 0)
                {
                    sprite.material = materials[1];
                    currentMat = 1;
                }
                else
                {
                    sprite.material = materials[0];
                    currentMat = 0;
                }
                spriteFlashTimer = 0.0f;
            }

           // Debug.Log(eventManager.GetPuzzleActiveName());

            if(eventManager.GetPuzzleActiveName() == "Movement")
            {
                
                CheckMovementSuccess();
            }
        }
    }

    void GetMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movementSqrMagnitude = Vector2.SqrMagnitude(movement);
    }

    void CharacterPosition()
    {
        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);
    }
    void CharacterRotation()
    {
        if (movement != Vector2.zero)
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

    private void OnMouseDown()
    {
        if (!movementUnlocked)
        {
            eventManager.StartPuzzle("Movement");
        }
    }

    void CheckMovementSuccess()
    {
        if (eventManager.GetLastPuzzleSuccess())
        {
            movementUnlocked = true;
            eventManager.SetLastPuzzleSuccess(false);
            eventManager.SetPuzzleActiveName(null);
            sprite.material = materials[0];

        }
    }
}
