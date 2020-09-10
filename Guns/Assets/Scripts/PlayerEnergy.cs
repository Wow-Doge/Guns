using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public float maxEnergy = 200f;
    public float curEnergy;

    void Start()
    {
        curEnergy = maxEnergy;
    }

    void Update()
    {
        
    }
}
