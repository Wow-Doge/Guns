using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangeProjectile : MonoBehaviour
{
    Transform player;
    Vector2 target;
    Vector2 bulletPos;
    Rigidbody2D rb2d;
    [SerializeField]
    private float speed = 10f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        bulletPos = new Vector2(rb2d.position.x, rb2d.position.y);
    }

    void Update()
    {
        rb2d.AddForce((target - bulletPos).normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
