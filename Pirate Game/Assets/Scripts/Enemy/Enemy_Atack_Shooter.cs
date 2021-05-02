using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Atack_Shooter : MonoBehaviour
{
    [Header("Atack Control")]
    public Transform cannonDirection;
    public GameObject cannonballPrefab;
    public float cannonballForce;
    public bool canShoot = true;
    public float delay = 0.5f;
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Shoot();
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Shoot();
        }
    }
    public void Update()
    {
    }
    public void Shoot()
    {
        if (canShoot)
        {
        GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection.position, cannonDirection.rotation);
        Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
        rbCannonball.AddForce(-cannonDirection.up * cannonballForce, ForceMode2D.Impulse);
        canShoot = false;
        StartCoroutine(CannonDelay());
        }
    }
    IEnumerator CannonDelay()
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
