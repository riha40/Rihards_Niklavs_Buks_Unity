using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] RectTransform gameOver;

    private void Start()
    {
        GameManager.instance.Player.OnHealthUpdated += OnPlayerHealthUpdated;
        GameManager.instance.OnGameLost += OnGameLost;
    }

    void OnPlayerHealthUpdated(int health)
    {
        healthSlider.value = Mathf.InverseLerp(0, Player.MaxHealth, health);
    }

    private void OnGameLost()
    {
        gameOver.gameObject.SetActive(true);
    }
}
