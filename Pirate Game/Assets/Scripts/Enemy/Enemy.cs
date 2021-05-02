using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    public Enemy_Health enemyHealth;
    private SpriteRenderer enemyRenderer;
    public Rigidbody2D rb2d;
    public Cannonball cannonball;
    public GameManager sManager;
    public GameObject scoreManager;
    public GameObject childs;
    public GameObject explosion;
    public GameObject player;
    public Transform enemyTrasnform;
    private NavMeshAgent agent;
    [Header("Movement Settings")]
    bool canMove = true;
    private Transform playerPos;
    [SerializeField] float followDistance;
    [SerializeField] float chaseRadius;
    [Header("Health Settings")]
    public int currentHealth;
    public int maxHealth;
    public int damageTakenContact = 1;
    public int damageTakenProjectile = 1;
    [Header("Sprite Settings")]
    public Sprite lowHealth;
    public int lowHealthvalue;
    public Sprite mediumHealth;
    public int mediumHealthvalue;
    public Sprite fullHealth;
    public Sprite deadSprite;
    [Header("Death Settings")]
    public bool exploded;
    public int scoreOnDeath = 1;



    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //scoreManager = GameObject.FindGameObjectWithTag("Manager");
        sManager = scoreManager.GetComponent<GameManager>();
        currentHealth = maxHealth;
        enemyHealth.SetMaxHealth(maxHealth);
    }
    private void Start()
    {
        if (enemyRenderer == null)
            enemyRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(damageTakenProjectile);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            TakeDamage(damageTakenContact);
        }
    }
    void Update()
    {
        if (canMove)
            Movement();
        else
            agent.SetDestination(this.transform.position);
    }
    void Movement()
    {
        Vector3 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rb2d.rotation = angle;

        if (Vector2.Distance(transform.position, playerPos.position) > followDistance &&
            Vector2.Distance(transform.position, playerPos.position) < chaseRadius)
        {
            agent.SetDestination(playerPos.position);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyHealth.SetHealth(currentHealth);
        SpriteChange();
        if (currentHealth <= 0)
            Dead();
    }
    public void SpriteChange()
    {
        if (currentHealth <= mediumHealthvalue && currentHealth > lowHealthvalue)
        {
            enemyRenderer.sprite = mediumHealth;
        }
        if (currentHealth <= lowHealthvalue)
        {
            enemyRenderer.sprite = lowHealth;
        }
        if (currentHealth <= 0)
        {
            enemyRenderer.sprite = deadSprite;
        }
    }
    public void Dead()
    {
        canMove = false;
        if (exploded == false)
        {
            GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionEffect, 1.5f);
            exploded = true;
            if (player.GetComponent<Player_Mov>().currentHealth > 0)
            {
                sManager.score++;
            }
            childs.SetActive(false);
            GameManager.Instance.enemys.Remove(this.gameObject);
            Destroy(gameObject, 2f);
        }

    }
}
