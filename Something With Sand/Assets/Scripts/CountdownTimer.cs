using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] public float totalTime;
    [SerializeField] public float currentTime;

    public int score = 0;
    public int highscore = 0;
    private bool isCountingDown = true;
    public TMP_Text countdownText; 
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    Player Player;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        currentTime = totalTime;
        UpdateScore();
        Player = GetComponent<Player>();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    private void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f || Player.Health <= 0)
            {
                currentTime = 0f;
                isCountingDown = false;
                GameManager.instance.GameLost();
                HandleGameEnded();
            }
            else
            {
                score += 1;
                UpdateScore();
            }
            countdownText.text = FormatTime(currentTime);
        }
    }

    public void HandleGameEnded()
    {
        GetComponent<Animator>().SetTrigger("Death");
        GameManager.instance.SetFinalScore(score);
    }

    public void AddTime(float additionalTime)
    {
        currentTime += additionalTime;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("TIME LEFT: {0:00}:{1:00}", minutes, seconds);
    }
    private void UpdateScore()
    {
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore",score);
        }
    }
}