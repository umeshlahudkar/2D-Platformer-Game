using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Increment score and Display Score in Game scene.
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
    
   
    public void ScoreIncrementer(int increment)  
    {
        // Score increment
        score += increment;
        ScoreDisplay();
    }


    public void ScoreDisplay()  
    {
        // Display score.
        scoreText.text = " Score : " + score;
    }
}
