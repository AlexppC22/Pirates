using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Side : MonoBehaviour
{
    [Header("Referemces")]
    public Transform cannonDirection_Top_R;
    public Transform cannonDirection_Middle_R;
    public Transform cannonDirection_Bottom_R;
    public Transform cannonDirection_Top_L;
    public Transform cannonDirection_Middle_L;
    public Transform cannonDirection_Bottom_L;
    public GameObject cannonballPrefab;
    [Header("Shooting Settings")]
    public bool canShootRight;
    public bool canShootLeft;
    public float delay = 1f;
    public float cannonballForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && canShootRight == true)
        {
            Shoot_Top_R();
            Shoot_Middle_R();
            Shoot_Bottom_R();
            canShootRight = false;
            StartCoroutine(CannonDelayRight());
        }
        if (Input.GetKeyDown(KeyCode.L) && canShootLeft == true)
        {
            Shoot_Top_L();
            Shoot_Middle_L();
            Shoot_Bottom_L();
            canShootLeft = false;
            StartCoroutine(CannonDelayLeft());
        }
    }

    void Shoot_Top_R()
    {
        GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection_Top_R.position, cannonDirection_Top_R.rotation);
        Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
        rbCannonball.AddForce(-cannonDirection_Top_R.right * cannonballForce, ForceMode2D.Impulse);
    }
    void Shoot_Middle_R()
    {
            GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection_Middle_R.position, cannonDirection_Middle_R.rotation);
            Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
            rbCannonball.AddForce(-cannonDirection_Middle_R.right * cannonballForce, ForceMode2D.Impulse);
    }
    void Shoot_Bottom_R()
    {
            GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection_Bottom_R.position, cannonDirection_Bottom_R.rotation);
            Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
            rbCannonball.AddForce(-cannonDirection_Bottom_R.right * cannonballForce, ForceMode2D.Impulse);
    }
    
    void Shoot_Top_L()
    {
        GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection_Top_L.position, cannonDirection_Top_L.rotation);
        Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
        rbCannonball.AddForce(cannonDirection_Top_L.right * cannonballForce, ForceMode2D.Impulse);
    }
    void Shoot_Middle_L()
    {
            GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection_Middle_L.position, cannonDirection_Middle_L.rotation);
            Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
            rbCannonball.AddForce(cannonDirection_Middle_L.right * cannonballForce, ForceMode2D.Impulse);
    }
    void Shoot_Bottom_L()
    {
            GameObject Cannonball = Instantiate(cannonballPrefab, cannonDirection_Bottom_L.position, cannonDirection_Bottom_L.rotation);
            Rigidbody2D rbCannonball = Cannonball.GetComponent<Rigidbody2D>();
            rbCannonball.AddForce(cannonDirection_Bottom_L.right * cannonballForce, ForceMode2D.Impulse);
    }


    IEnumerator CannonDelayRight()
    {
        yield return new WaitForSeconds(delay);
        canShootRight = true;
    }
    IEnumerator CannonDelayLeft()
    {
        yield return new WaitForSeconds(delay);
        canShootLeft = true;
    }
    
}
