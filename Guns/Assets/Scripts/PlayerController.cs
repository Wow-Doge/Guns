using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rb2d;
    Vector2 movement;
    Vector2 mousePos;

    public Camera cam;

    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        rb2d = GetComponent<Rigidbody2D>();
        playerHealth.OnDead += PlayerHealth_OnDead;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void PlayerHealth_OnDead(object sender, System.EventArgs e)
    {
        //Do something
        playerHealth.OnDead -= PlayerHealth_OnDead;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDirection = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }
}
