using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    float ammo;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Shooting shooting = player.GetComponent<Shooting>();
        ammo = shooting.ammo;
        text.text = "Ammo: " + ammo;
    }
}
