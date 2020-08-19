using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Shooting shooting = player.GetComponent<Shooting>();
        damage = shooting.damage;
    }

    void Update()
    {
        
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}