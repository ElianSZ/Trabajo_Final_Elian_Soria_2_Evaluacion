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

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        StartCoroutine("spawnRandomTarget");
    }

    // Controlador de spawnear los obst�culos
    private IEnumerator spawnRandomTarget()
    {
        while(!playerController.isGameOver)
        {
        // Cada 3s se spawnea un obst�culo
        yield return new WaitForSeconds(spawnRate);

        // Instancia los obst�culos
        Instantiate(enemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
        }
    }
}
