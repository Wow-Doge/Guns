using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public Guns gunInfo;
    SpriteRenderer gunSprite;
    void Start()
    {
        BoxCollider2D gunCollider = gameObject.AddComponent<BoxCollider2D>();
        gunSprite = gameObject.AddComponent<SpriteRenderer>();
    }

    void Update()
    {
        gunSprite.sprite = gunInfo.sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
        playerInventory.guns.Add(gunInfo);
        Destroy(gameObject);
    }
}
