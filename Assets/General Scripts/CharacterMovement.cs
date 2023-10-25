using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Material[] materials;
    public Animator anim;
    public Rigidbody2D rb;
    EventManager eventManager;

    private Vector2 movement;
    public float movementSqrMagnitude;
    public float walkSpeed = 3.5f;
    public float jumpAmount = 7;

    bool movementUnlocked = true;
    bool jumpUnlocked = true;

    float jumpTimer;
    bool startJumpTimer = false;
    bool canJump = true;
    float canJumpTimer;
    float spriteFlashTimer;

    int currentMat = 0;

    public Tweener tweener;

    private void Start()
    {
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();

    }
    // Update is called once per frame
    void Update()
    {
       /* #region Jump Logic
        if (jumpUnlocked)
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
                if (jumpTimer > 0.2f)
                {
                   

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
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.D)) //MOVE RIGHT
        {

        }

        if (Input.GetKeyDown(KeyCode.A)) //MOVE LEFT
        {

        }*/

        if (tweener.HasActiveTween() && canJump)
        {
            anim.SetFloat("MovingSpeed", 1.0f);

        }
        else
        {
            anim.SetFloat("MovingSpeed", 0.0f);
        }
    }

    public void MoveLeft()
    {
        tweener.AddTween(this.gameObject.transform, this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(-1.0f, 0.0f, 0.0f), 0.5f);
        CharacterRotation("Left");

    }

    public void MoveRight()
    {
        tweener.AddTween(this.gameObject.transform, this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(1.0f, 0.0f, 0.0f), 0.5f);
        CharacterRotation("Right");
    }

    public void JumpForward()
    {
        tweener.AddTween(this.gameObject.transform, this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(1.0f, 1.0f, 0.0f), 1.0f);
        CharacterRotation("Right");
        anim.SetTrigger("isJumping");

    }

    public void JumpBack()
    {
        tweener.AddTween(this.gameObject.transform, this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(-1.0f, 1.0f, 0.0f), 1.0f);
        CharacterRotation("Left");
        anim.SetTrigger("isJumping");

    }

    void CharacterRotation(string rot)
    {
        if (rot == "Left")
            transform.localScale = new Vector2(-0.5f, 0.5f);
        else
            transform.localScale = new Vector2(0.5f, 0.5f);
    }
    void WalkAnimation()
    {
        anim.SetFloat("MovingSpeed", movementSqrMagnitude);
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

    void SpriteFlash()
    {
        spriteFlashTimer += Time.deltaTime;
        if (spriteFlashTimer >= 0.5f)
        {
            if (currentMat == 0)
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
    }
}
