using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemDrops;

    EnemyHealth enemyHealth;
    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.OnDead += EnemyDropWhenDead;
    }

    private void EnemyDropWhenDead(object sender, System.EventArgs e)
    {
        Instantiate(itemDrops[UnityEngine.Random.Range(0, itemDrops.Length)], transform.position, Quaternion.identity);
    }
}
