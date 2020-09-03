using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    Image image;
    PlayerHealth playerHealth;
    [SerializeField]
    TextMeshProUGUI healthNumber;
    void Start()
    {
        image = GetComponent<Image>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void Update()
    {
        image.fillAmount = playerHealth.curHealth * (1f / playerHealth.maxHealth) / 1f;
        healthNumber.text = playerHealth.curHealth + " / " + playerHealth.maxHealth;
    }
}
