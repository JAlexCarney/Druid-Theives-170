using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{
    Rigidbody2D body;
    private Animator animator = null;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    bool isStoped = false;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Mathf.Abs(horizontal) < 0.1 && Mathf.Abs(vertical) < 0.1)
        {
            animator.Play("Idle");
        }
        else
        {
            animator.Play("Run");
        }
    }

    public void Stop()
    {
        isStoped = true;
        body.velocity = new Vector2(0.0f, 0.0f);
    }

    void FixedUpdate()
    {
        if (!isStoped)
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }


            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }
}
