using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    Vector2 spawnposition;
    Transform areaTransform;
    void Start()
    {
        areaTransform = GetComponent<Transform>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        foreach(GameObject enemy in enemies)
        {
            spawnposition.x = Random.Range(areaTransform.position.x - 5, areaTransform.position.x + 5);
            spawnposition.y = Random.Range(areaTransform.position.x - 5, areaTransform.position.y + 5);
            spawnposition = new Vector2(spawnposition.x, spawnposition.y);
            Instantiate(enemy, spawnposition, Quaternion.identity);
        }
        Debug.Log("Do something");
    }
}
