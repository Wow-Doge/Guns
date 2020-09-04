using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class Guns : ScriptableObject
{
    public int gunID;

    public GunType gunType;
    public enum GunType
    {
        Shotgun,
        Rifle,
        Pistol,
        Rocket,
        Melee
    }

    public Sprite sprite;
    public string gunName;
    public float damage;
    public float bulletSpeed;
    public float rateOfFire;
    public float energyCost;
    //public GameObject bullet;
}
