using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event System.Action OnGameLost;
    private int finalScore;


    void Awake()
    {
        if (instance == null) instance = this;
    }

    Player _player;
    public Player Player
    {
        get
        {
            if (_player == null) _player = FindObjectOfType<Player>();
            return _player;
        }

    }

    public void GameLost()
    {
        OnGameLost?.Invoke();
        Invoke(nameof(RestartGame), 5f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetFinalScore(int score)
    {
        finalScore = score;
    }

    public int GetFinalScore()
    {
        return finalScore;
    }
}
