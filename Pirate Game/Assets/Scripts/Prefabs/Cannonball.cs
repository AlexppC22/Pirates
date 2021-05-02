using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public GameObject explosion;
    public Player_Mov player;

    public void Update()
    {
        Destroy(gameObject, 2f);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosionEffect, 0.2f);
    }
    public void CollidedWithEnemy()
    {
        
    }
    
}
