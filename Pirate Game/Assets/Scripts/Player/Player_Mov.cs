using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Mov : MonoBehaviour
{
    [Header("Referemces")]
    public Rigidbody2D Rb2D_Player;
    public Player_Health player_Health;
    public GameObject GameOverScreen;
    public GameObject explosion;
    public OptionsInformation Info;
    public SpriteRenderer playerRenderer;
    public float Input_Horizontal;
    public float Input_Vertical;
    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;
    [Header("Movement Settings")]
    public bool canControl = true;
    public float player_spd = 0.2f;
    public float player_rotation_spd = 0.2f;
    [Header("Sprite Settings:")]
    public Sprite lowHealth; 
    public int lowHealthvalue;
    public Sprite mediumHealth;
    public int mediumHealthvalue;
    public Sprite fullHealth;
    public Sprite Dead;
    bool exploded = false;
    [Header("Damage Settings:")]
    public int damageTakenProjectile = 1;
    public int damageTakenContact = 1;
    [Header("Gameover Settings")]
    public bool stopSpawns = false;
      
    void Start()
    {
        currentHealth = maxHealth;
        player_Health.SetMaxHealth(maxHealth); 
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(damageTakenProjectile);
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damageTakenContact);
        }
        
    }
    void Update()
    {
        SpriteChange();
        GameTimer();
        if(canControl)
        {
            Movement();
        }
        if(currentHealth <= 0 || Info.gameTime < 0)
        {
            GameOver();
        }
        
    }
    public void Movement()
    {
        Input_Horizontal = Input.GetAxisRaw("Horizontal");
        Input_Vertical = Input.GetAxisRaw("Vertical");

        Rb2D_Player.velocity = -transform.up * Input_Vertical * player_spd;

        float rotation = -Input_Horizontal * player_rotation_spd;
        transform.Rotate(Vector3.forward * rotation);
    }
    public void SpriteChange()
    {
            if(currentHealth <= mediumHealthvalue && currentHealth > lowHealthvalue)
            {
                playerRenderer.sprite = mediumHealth; 
            }
            if(currentHealth <= lowHealthvalue)
            {
                playerRenderer.sprite = lowHealth;
            }
            if(currentHealth <= 0)
            {
                playerRenderer.sprite = Dead;
            }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        player_Health.SetHealth(currentHealth);
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        stopSpawns = true;
        canControl = false;
        if(exploded == false)
        {
                GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(explosionEffect, 10f);
                exploded = true;
        }
    }
    public void GameTimer()
    {
        if (Info.gameTime > 0)
        {
            Info.gameTime -= Time.deltaTime;
        }
    }
}
