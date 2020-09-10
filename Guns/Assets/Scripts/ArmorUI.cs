using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmorUI : MonoBehaviour
{
    Image image;
    PlayerArmor playerArmor;
    [SerializeField]
    TextMeshProUGUI armorNumber;
    void Start()
    {
        image = GetComponent<Image>();
        playerArmor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerArmor>();
    }
    void Update()
    {
        image.fillAmount = playerArmor.curArmor * (1f / playerArmor.maxArmor) / 1f;
        armorNumber.text = playerArmor.curArmor + " / " + playerArmor.maxArmor;
    }
}
