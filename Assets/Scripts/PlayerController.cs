using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // private Vector3 initialPos = new Vector3(0, 100, 0);
    public float speed = 4f;
    public float runSpeed = 7f;
    public float rotSpeed = 40f;
    public float rot = 0f;
    public float deathSpeed = 0f;

    public Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;
    public GameObject shooter1;
    public GameObject shooter2;
    public GameObject explosions;
    public GameObject shotLight;
    public GameObject deathLight;

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem explosionParticleSystem2;
    public ParticleSystem explosionParticleSystem3;

    public GameObject wayPoint;
    private float timer = 0.5f;

    public bool isGameOver = false;

    private GameManager gameManager;

    private AudioSource playerAudioSource;
    public AudioClip shotClip;

    public AudioClip explosionClip;


    private bool isCoroutineExecuting = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        gameManager = FindObjectOfType<GameManager>();

        shotLight.SetActive(false);
        deathLight.SetActive(false);
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Se dispara el proyectil 1
            Instantiate(projectilePrefab, shooter1.transform.position, transform.rotation);
            Instantiate(explosionParticleSystem, shooter1.transform.position, transform.rotation);

            // Se dispara el proyectil 2
            Instantiate(projectilePrefab2, shooter2.transform.position, transform.rotation);
            Instantiate(explosionParticleSystem, shooter2.transform.position, transform.rotation);

            // Ejecuta una vez el audio de disparo
            playerAudioSource.PlayOneShot(shotClip, 1f);

            StartCoroutine(ShotLightWaiter());
        }
    }

    private void Movement()
    {
        // Caminar
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Walk", 1);

            moveDir = new Vector3(0, 0, 1);
            moveDir = moveDir * speed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("Walk", 0);

            moveDir = new Vector3(0, 0, 0);
        }

        // Correr
        if (Input.GetKey (KeyCode.LeftShift))
        {
            anim.SetInteger("Run", 1);

            moveDir = new Vector3(0, 0, 1);
            moveDir = moveDir * runSpeed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetInteger("Run", 0);

            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        // Si colisiona con un obstacle, destruye ambos objetos
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionParticleSystem2, explosions.transform.position, transform.rotation);
            Instantiate(explosionParticleSystem3, explosions.transform.position, transform.rotation);

            AudioSource.PlayClipAtPoint(explosionClip, transform.position, 1f);

            PersistentData.sharedInstance.kills = gameManager.kills;
            PersistentData.sharedInstance.highestScore = gameManager.highestScore;

            isGameOver = true;
            StartCoroutine(GameOverWaiter());
            Time.timeScale = 0;
        }
    }

    void UpdatePosition()
    {
        // La posición del jugador será la posición del waypoint
        wayPoint.transform.position = transform.position;
    }

   
    IEnumerator GameOverWaiter()
    {
        deathLight.SetActive(true);

        yield return new WaitForSecondsRealtime(0.05f);
        deathLight.SetActive(false);

        yield return new WaitForSecondsRealtime(2);

        // Carga la escena 3
        SceneManager.LoadScene("3. Game Over");

        Time.timeScale = 1;
    }

    IEnumerator ShotLightWaiter()
    {
        yield return new WaitForSeconds(0.05f);
    }
}