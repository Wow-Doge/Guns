using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyHealth : MonoBehaviour, Idamageable
{
    float curHP;
    public float maxHP = 20f;

    public event EventHandler OnDead;
    void Start()
    {
        curHP = maxHP;
    }

    void Update()
    {
        if (curHP <= 0)
        {
            Die();
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        curHP -= damage;
    }

    public void Die()
    {
        OnDead?.Invoke(this, EventArgs.Empty);
    }
    public bool IsDead()
    {
        return curHP <= 0;
    }
}
