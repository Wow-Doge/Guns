using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyUI : MonoBehaviour
{
    Image image;
    PlayerEnergy playerEnergy;
    [SerializeField]
    TextMeshProUGUI energyNumber;
    void Start()
    {
        image = GetComponent<Image>();
        playerEnergy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>();
    }
    void Update()
    {
        image.fillAmount = playerEnergy.curEnergy * (1f / playerEnergy.maxEnergy) / 1f;
        energyNumber.text = playerEnergy.curEnergy + " / " + playerEnergy.maxEnergy;
    }
}
