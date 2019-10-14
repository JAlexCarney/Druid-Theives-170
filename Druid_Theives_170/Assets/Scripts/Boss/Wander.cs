using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Rigidbody2D body;
    //private Animator animator = null;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    float count = 0;
    int count2 = 0;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        if (count2 == 60)
        {
            horizontal = Random.Range(-1f, 1f); // -1 is left
            vertical = Random.Range(-1f, 1f); // -1 is down
            count2 = 0;
        }

        count += 0.1f;
        count2 += 1;

        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        /*if (Mathf.Abs(horizontal) < 0.1 && Mathf.Abs(vertical) < 0.1)
        {
            animator.Play("Idle");
        }
        else
        {
            animator.Play("Run");
        }*/
    }

    void FixedUpdate()
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
