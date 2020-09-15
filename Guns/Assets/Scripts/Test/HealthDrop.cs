using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour, ICollectable
{
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void AutoCollect()
    {
        if (Vector2.Distance(player.position, transform.position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 5 * Time.deltaTime);
        }
    }

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

    private void Update()
    {
        AutoCollect();
    }
}
