using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Gun")]
public class Guns : ScriptableObject
{
    public string gunName;
    public float ammo;
    public float damage;
}
