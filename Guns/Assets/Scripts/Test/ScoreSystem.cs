using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int score;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            score += 5;
        }
    }
}
