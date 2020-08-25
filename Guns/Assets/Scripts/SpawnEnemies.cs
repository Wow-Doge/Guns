using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    Vector2 spawnposition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WaveSpawn());
        }
    }
    IEnumerator WaveSpawn()
    {
        yield return new WaitForSeconds(0.2f);
        SpawnEnemy();
        yield return new WaitForSeconds(3f);
        SpawnEnemy();
        yield return new WaitForSeconds(4f);
        SpawnEnemy();
    }
    void SpawnEnemy()
    {
        foreach (GameObject enemy in enemies)
        {
            spawnposition.x = Random.Range(transform.position.x - 10, transform.position.x + 10);
            spawnposition.y = Random.Range(transform.position.y - 4, transform.position.y + 4);
            spawnposition = new Vector2(spawnposition.x, spawnposition.y);
            Instantiate(enemy, spawnposition, Quaternion.identity);
        }
    }
}
