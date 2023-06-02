using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] public float totalTime;
    [SerializeField] public float currentTime;
    [SerializeField] public int score = 0;

    private bool isCountingDown = true;
    public TMP_Text countdownText; 
    public TMP_Text scoreText;

    Player Player;

    private void Start()
    {
        currentTime = totalTime;
        UpdateScore();
        Player = GetComponent<Player>();
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

        return string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }
    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}