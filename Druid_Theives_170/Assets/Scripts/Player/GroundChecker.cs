using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private PlayerMovement playerMove = null;
    private ParticleSystem stompParticles = null;

    private void Start()
    {
        playerMove = transform.parent.gameObject.GetComponent<PlayerMovement>();
        stompParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerMove.isGrounded = true;
            stompParticles.Emit(15);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerMove.isGrounded = false;
        }
    }

}
