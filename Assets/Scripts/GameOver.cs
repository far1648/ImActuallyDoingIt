using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject text;
    public TextMeshProUGUI timerText;
    float timer = 5f;

    void Update()
    {
        if (text.gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
        }
        timerText.text = "Closing application in: " + timer + "s";
        if (timer <= 0)
        {
            Application.Quit();
        }
    }

    public void PlayAgain()
    {
        text.SetActive(true);
        Time.timeScale = 1;

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
