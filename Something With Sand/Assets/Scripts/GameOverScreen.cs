using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public int highscore = 0;


    private void Start()
    {

        highscore = PlayerPrefs.GetInt("highscore", 0);
        int finalScore = GameManager.instance.GetFinalScore();
        scoreText.text = "GAME OVER\n SCORE: " + finalScore.ToString() + "\n \n HIGHSCORE: " + highscore.ToString();
    }
}
