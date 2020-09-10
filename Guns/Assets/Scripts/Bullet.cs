using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerAttack playerAttack = player.GetComponent<PlayerAttack>();
        damage = playerAttack.damage;
    }

    void Update()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Idamageable damageable = collision.GetComponent<Idamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}