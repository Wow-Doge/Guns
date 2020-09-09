using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject energyDrop;

    EnemyHealth enemyHealth;
    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.OnDead += EnemyDropWhenDead;
    }

    private void EnemyDropWhenDead(object sender, System.EventArgs e)
    {
        Debug.Log("Drop something");
        //Drop xyz.....
    }
}
