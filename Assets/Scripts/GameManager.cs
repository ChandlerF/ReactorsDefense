using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool GameIsOver = false;
    private LeaderboardController Leaderboard;
    [SerializeField] private GameObject HelpText;

    private void Awake()
    {
        instance = this;
        Leaderboard = GetComponent<LeaderboardController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.instance.Play("MenuSelect");
            SceneManager.LoadScene("Menu");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.instance.Play("MenuSelect");
            SceneManager.LoadScene("Level1");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }


    private void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        AudioManager.instance.Play("ReactorDeath");
        HelpText.SetActive(true);
        Leaderboard.AddNewHighscore(PlayerInfo.instance.Name, NumberCounter.instance.Value);
    }
}
