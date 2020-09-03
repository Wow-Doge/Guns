using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public SpriteRenderer spriteRenderer;
    public Guns guns;
    [HideInInspector]
    float nextTimeToFire = 0f;

    [HideInInspector]
    public float damage;
    PlayerInventory playerInventory;
    PlayerEnergy playerEnergy;
    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerEnergy = GetComponent<PlayerEnergy>();
        damage = guns.damage;
    }
    void Update()
    {
        spriteRenderer.sprite = guns.sprite;
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / guns.rateOfFire;
            Shoot();
            playerEnergy.curEnergy -= guns.energyCost;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            guns = playerInventory.guns[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            guns = playerInventory.guns[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            guns = playerInventory.guns[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            guns = playerInventory.guns[3];
        }
    }

    void Shoot()
    {
        switch (guns.gunType)
        {
            case Guns.GunType.Rifle:
            case Guns.GunType.Pistol:
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
                rb2d.AddForce(firePoint.up * guns.bulletSpeed, ForceMode2D.Impulse);
                break;
            case Guns.GunType.Shotgun:
                GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb2d2 = bullet2.GetComponent<Rigidbody2D>();
                rb2d2.AddForce((firePoint.up + firePoint.up) * guns.bulletSpeed, ForceMode2D.Impulse);
                GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb2d3 = bullet3.GetComponent<Rigidbody2D>();
                rb2d3.AddForce((firePoint.up + -firePoint.right) * guns.bulletSpeed, ForceMode2D.Impulse);
                GameObject bullet4 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb2d4 = bullet4.GetComponent<Rigidbody2D>();
                rb2d4.AddForce((firePoint.up + firePoint.right) * guns.bulletSpeed, ForceMode2D.Impulse);
                break;
            case Guns.GunType.Rocket:
                Debug.Log("Rocket");
                break;
            default:
                break;
        }
    }
}
