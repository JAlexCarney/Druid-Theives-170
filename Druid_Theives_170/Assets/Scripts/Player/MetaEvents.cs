using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaEvents : MonoBehaviour
{
    public GameObject playerprefab;
    private GameObject deathScreen;
    private ParticleSystem deathParticles;
    private GameObject visual;
    private Rigidbody2D playerBody;
    private PlayerMovementTopDown playerMovement;

    public void Start()
    {
        deathScreen = transform.Find("DeathScreen").gameObject;
        deathParticles = transform.Find("DeathParticles").gameObject.GetComponent<ParticleSystem>();
        visual = transform.Find("Visual").gameObject;
        playerBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovementTopDown>();
    }

    public void Die()
    {
        // enable death screen
        deathScreen.SetActive(true);
        // emit death particles
        deathParticles.Emit(20);
        // disable player movement
        playerMovement.Stop();
        playerBody.isKinematic = true;
        Invoke("Reload", 2);
    }

    public void Reload()
    {
        Instantiate(playerprefab);
        Destroy(this.transform.gameObject);
    }
}
