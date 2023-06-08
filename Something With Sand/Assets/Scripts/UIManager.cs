using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] RectTransform gameOver;
    [SerializeField] TMPro.TextMeshProUGUI tutorialText;

    static readonly string[] TutorialTexts = new string[]
    {
        "<color=red>RUN</color> \n HOLD <color=green>LEFT</color> MOUSE BUTTON TO MOVE",
        "<color=red>AVOID</color> THE FALLING <color=red>BOMBS</color> ",
        "COLLECT <color=green>HOUR GLASSES</color> TO ADD TIME",
        "DON'T LET YOUR TIME AND HEALTH HIT \n <color=red>0</color>"
    };

    private void Start()
    {
        GameManager.instance.Player.OnHealthUpdated += OnPlayerHealthUpdated;
        GameManager.instance.OnGameLost += OnGameLost;
        StartCoroutine(TutorialRoutine());
    }

    void OnPlayerHealthUpdated(int health)
    {
        healthSlider.value = Mathf.InverseLerp(0, Player.MaxHealth, health);
    }

    private void OnGameLost()
    {
        gameOver.gameObject.SetActive(true);
    }

    IEnumerator TutorialRoutine()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < TutorialTexts.Length; i++)
        {
            ShowTutorialText(i);
            yield return new WaitForSeconds(3f);
        }

        HideTutorialText();

        void ShowTutorialText(int index)
        {
            string txt = TutorialTexts[index];
            tutorialText.text = txt;
        }

        void HideTutorialText()
        {
            tutorialText.text = string.Empty;
        }
    }
}
