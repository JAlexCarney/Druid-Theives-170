using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaEvents : MonoBehaviour
{
    private GameObject deathScreen;
    private ParticleSystem deathParticles;
    private GameObject visual;
    private Rigidbody2D playerBody;
    private PlayerMovement playerMovement;

    public void Start()
    {
        deathScreen = transform.Find("DeathScreen").gameObject;
        deathParticles = transform.Find("DeathParticles").gameObject.GetComponent<ParticleSystem>();
        visual = transform.Find("Visual").gameObject;
        playerBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Die()
    {
        // enable death screen
        deathScreen.SetActive(true);
        // emit death particles
        deathParticles.Emit(20);
        // disable visual
        visual.SetActive(false);
        // disable player movement
        playerMovement.Stop();
        playerBody.isKinematic = true;
        Invoke("Reload", 2);
    }

    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
