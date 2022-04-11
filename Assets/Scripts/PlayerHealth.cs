using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public GameObject playerPrefab;
    GameObject playerInstance;
    public int maxHealth = 100;
    public int currentHealth;
    // public GameObject deathEffect;

    public HealthBar healthBar;

    public Transform spawnPoint;
    public GameObject deathEffect;

    public float respawnTime = 1.5f;
    float currentRespawnTime;

    [SerializeField] AudioClip hitSound;
    AudioSource audioSource;

    bool isDying;

    // Start is called before the first frame update
    void Start()
    {
        isDying = false;
        gameObject.transform.position = spawnPoint.transform.position;
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }

        currentRespawnTime -= Time.deltaTime;
        if (isDying && currentRespawnTime <= 0)
            Start();

        if (gameObject.transform.position.y < -10) {
            Start();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {            
            TakeDamage(20);

            if (!isDying)
                audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
    }

    // void DoDamageToPlayer(){
    //    Debug.Log("Hit");
    // }

    void TakeDamage(int damage)
    {
        if (isDying)
            return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        isDying = true;
        currentRespawnTime = respawnTime;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
