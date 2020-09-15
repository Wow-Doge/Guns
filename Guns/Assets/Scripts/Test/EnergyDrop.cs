using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrop : MonoBehaviour, ICollectable
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

    private void Update()
    {
        AutoCollect();
    }
}
