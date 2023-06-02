using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] RectTransform gameOver;

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.instance.Player.OnHealthUpdated += OnPlayerHealthUpdated;
        GameManager.instance.OnGameLost += OnGameLost;

    }

    // Update is called once per frame
    void Update()
    {
        
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
