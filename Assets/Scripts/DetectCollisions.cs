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

    // Colisión de enemigos
    private void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Enemy"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);

            GameManager.instance.AddPoint();

            AudioSource.PlayClipAtPoint(explosionClip, transform.position, 1f);
            Instantiate(explosionParticleSystem, transform.position, transform.rotation);
        }
    }
}