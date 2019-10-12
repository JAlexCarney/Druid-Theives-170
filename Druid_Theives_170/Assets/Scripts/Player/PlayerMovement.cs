using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MaxSpeed = 3.5f;
    private float MaxAirSpeed = 5f;
    private float JumpForce = 420f;
    private float AccSpeed = 10f;
    private bool isStopped = false;
    public bool isGrounded = false;

    private Rigidbody2D body = null;
    private GameObject visual = null;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        visual = transform.Find("Visual").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float xin = Input.GetAxis("Horizontal");

        // set anim state
        if (xin < 0)
        {
            visual.transform.localScale = new Vector3(-1, 1, 1);
        } else if (xin > 0)
        {
            visual.transform.localScale = new Vector3(1, 1, 1);
        }
        if (isGrounded == true)
        {
            visual.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            visual.transform.eulerAngles = new Vector3(0, 0, -xin*15);
        }

        Vector2 acc = new Vector2(xin * AccSpeed, 0.0f);
        if (!isStopped)
        {
            if (isGrounded)
            {
                GroundMovement(xin, acc);
            }
            else
            {
                AirMovement(xin, acc);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                body.AddForce(new Vector2(0.0f, JumpForce));
            }
        }
    }

    public void Stop()
    {
        isStopped = true;
        body.velocity = Vector3.zero;
    }

    private void GroundMovement(float xin, Vector2 acc)
    {
        if (Mathf.Abs(body.velocity.x) < MaxSpeed)
        {
            body.AddForce(acc);
        }
    }

    private void AirMovement(float xin, Vector2 acc)
    {
        if (Mathf.Sign(xin) == Mathf.Sign(body.velocity.x))
        {
            if (Mathf.Abs(body.velocity.x) < MaxAirSpeed)
                body.AddForce(acc);
        }
        else
        {
            body.AddForce(3 * acc);
        }
    }
}
