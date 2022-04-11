using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromPlayer : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int health;

    [SerializeField] bool turnRedOnLoseHealth = false;

    [SerializeField] float hitCooldownTime = 0.25f;
    [SerializeField] GameObject deadBodyPrefab;
    [SerializeField] AudioClip hitSound;
    AudioSource audioSource;
    float currentHitCooldownTime = 0f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        health = maxHealth;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hitSound;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        currentHitCooldownTime -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        if (currentHitCooldownTime >= 0)
          return;

        currentHitCooldownTime = hitCooldownTime;
        health -= damage;

        // Making the enemy turn red as it loses health 
        if (turnRedOnLoseHealth) {
            float colorValue = (float)health / (float)maxHealth;
            spriteRenderer.color = new Color(1f, colorValue, colorValue);
        }

        audioSource.Play();

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Instantiate(deadBodyPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
