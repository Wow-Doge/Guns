using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public GameObject rangeProjectile;

    public float fireRate = 2f;
    float nextFire;

    void Start()
    {
        nextFire = fireRate;

    }

    void Update()
    {
        
        nextFire -= Time.deltaTime;
        if (nextFire < 0)
        {
            Shoot();
            nextFire = fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(rangeProjectile, transform.position, Quaternion.identity);
    }
}
