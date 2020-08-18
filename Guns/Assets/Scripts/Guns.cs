using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Gun")]
public class Guns : ScriptableObject
{
    public GunType gunType;
    public enum GunType
    {
        Shotgun,
        Rifle,
        Pistol,
        Rocket
    }
    public string gunName;
    public float ammo;
    public float damage;
    public float bulletSpeed;
    public float rateOfFire;
    public float reloadTime;

}
