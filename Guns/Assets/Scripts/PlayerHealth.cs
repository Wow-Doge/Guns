using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, Idamageable
{
    public float maxHealth = 20f;
    public float curHealth;

    public event EventHandler OnDead;

    PlayerArmor playerArmor;
    void Start()
    {
        playerArmor = GetComponent<PlayerArmor>();
        curHealth = maxHealth;
    }

    void Update()
    {
        if (curHealth <= 0)
        {
            OnDead?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            if (playerArmor.curArmor <= 0)
            {
                TakeDamage(2);
            }
            if (playerArmor.curArmor > 0)
            {
                return;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
    }
}
