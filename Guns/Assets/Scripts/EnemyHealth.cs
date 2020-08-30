﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float curHP;
    public float maxHP = 20f;
    void Start()
    {
        curHP = maxHP;
    }

    void Update()
    {
        if (curHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        curHP -= damage;
        //Debug.Log(gameObject.name + " HP: " + curHP);
    }
}
