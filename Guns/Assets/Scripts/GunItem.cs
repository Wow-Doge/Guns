using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public Guns gunInfo;
    SpriteRenderer gunSprite;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D gunCollider = gameObject.AddComponent<BoxCollider2D>();
        gunSprite = gameObject.AddComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gunSprite.sprite = gunInfo.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(gameObject);
    }
}
