using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Increment score and Display in Game scene.
/// Attached on - text UI
/// </summary>
public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        ScoreDisplay();
    }
    
   
    public void ScoreIncrementer(int increment)  // Increment score
    {
        score += increment;
        ScoreDisplay();
    }


    public void ScoreDisplay()  // Display Score
    {
        scoreText.text = " Score : " + score;
    }
}
