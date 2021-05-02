using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Foward : MonoBehaviour
{
    [Header("Referemces")]
    public Transform cannonDirection;
    public GameObject cannonballPrefab;
    [Header("Shooting Settings")]
    public float cannonballForce;
    public bool canShoot = true;
    public float delay = 0.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && canShoot == true)
        {
            Shoot();
            canShoot = false;
            StartCoroutine(CannonDelay());
        }
    }
    void Shoot()
    {
       GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection.position, cannonDirection.rotation);
       Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
       rbCannonball.AddForce(cannonDirection.right * cannonballForce, ForceMode2D.Impulse);
    }
    
    IEnumerator CannonDelay()
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
