using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Transform target;

    private float speed = 2f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(target.position, rb2d.position) < 5)
        {
            rb2d.position = Vector2.MoveTowards(rb2d.position, target.position, speed * Time.deltaTime);
        }
    }
}
