﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Guns guns;
    float ammo;
    bool isReloading;
    float nextTimeToFire = 0f;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        ammo = guns.ammo;
        damage = guns.damage;
    }

    void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (ammo > 0)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / guns.rateOfFire;
                Shoot();
            }
        }
        if (ammo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(firePoint.up * guns.bulletSpeed, ForceMode2D.Impulse);
        ammo -= 1;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(guns.reloadTime);
        ammo = guns.ammo;
        isReloading = false;
    }
}
