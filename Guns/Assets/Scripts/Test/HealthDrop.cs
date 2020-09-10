using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour, ICollectable
{
    public void Collectable(float amount)
    {
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (playerHealth.curHealth + amount <= playerHealth.maxHealth)
        {
            playerHealth.curHealth += amount;
        }
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collectable(1);
            Destroy(gameObject);
        }
    }
}
