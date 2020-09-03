using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            score += 5;
            text.text = "Score: " + score;
        }
    }
}
