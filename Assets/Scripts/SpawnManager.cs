using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerController;

    public Transform spawnPosition;
    public GameObject enemyPrefab;

    private float spawnRate = 3f;
    private float startDelay = 3f;

    public ParticleSystem spawnParticleSystem;
    public GameObject particle;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        StartCoroutine("spawnRandomTarget");
    }

    // Controlador de spawnear los enemigos
    private IEnumerator spawnRandomTarget()
    {
        while(!playerController.isGameOver)
        {
        // Cada 3s se spawnea un enemigo
        yield return new WaitForSeconds(spawnRate);

        // Instancia los enemigos
        Instantiate(enemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
        Instantiate(spawnParticleSystem, particle.transform.position, transform.rotation);
        }
    }
}
