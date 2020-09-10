using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrop : MonoBehaviour, ICollectable
{
    public void Collectable(float amount)
    {
        PlayerEnergy playerEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
        if (playerEnergy.curEnergy + amount <= playerEnergy.maxEnergy)
        {
            playerEnergy.curEnergy += amount;
        }
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collectable(5);
            Destroy(gameObject);
        }
    }
}
