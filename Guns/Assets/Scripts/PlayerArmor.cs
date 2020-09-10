using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerArmor : MonoBehaviour, Idamageable
{
    public float maxArmor = 10f;
    public float curArmor;

    public event EventHandler OnShieldBroken;
    public void TakeDamage(float damage)
    {
        if (curArmor >= damage)
        {
            curArmor -= damage;
        }
        else if (curArmor <= damage)
        {
            curArmor = 0;
        }
    }

    void Start()
    {
        curArmor = maxArmor;
        StartCoroutine(ShieldGenerate());
    }

    void Update()
    {
        if (curArmor <= 0)
        {
            OnShieldBroken?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            TakeDamage(3);
        }
    }

    IEnumerator ShieldGenerate()
    {
        while (true)
        {
            if (curArmor < maxArmor)
            {
                curArmor += 1;
                yield return new WaitForSeconds(2f);
            }
            else
            {
                yield return null;
            }
        }
    }
}
