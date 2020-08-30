using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }
}
