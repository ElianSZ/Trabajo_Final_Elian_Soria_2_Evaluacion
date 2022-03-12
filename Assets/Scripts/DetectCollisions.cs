using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameManager gameManager;

    private AudioSource collisionAudioSource;
    public AudioClip explosionClip;

    public ParticleSystem explosionParticleSystem;

    void Start()
    {
        collisionAudioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Enemy"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);
            gameManager.kills = gameManager.kills + 1;

            AudioSource.PlayClipAtPoint(explosionClip, transform.position, 1f);
            Instantiate(explosionParticleSystem, transform.position, transform.rotation);

        }

        if (otherTrigger.gameObject.CompareTag("Obstacle"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);
        }
    }
}