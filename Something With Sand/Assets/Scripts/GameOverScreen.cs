using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        int finalScore = GameManager.instance.GetFinalScore();
        scoreText.text = "Game Over\nScore: " + finalScore.ToString();
    }
}
