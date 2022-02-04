using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ButtonPlay()
    {
        AudioManager.instance.Play("MenuSelect");
        SceneManager.LoadScene("Level1");
    }
    public void ButtonLeaderboard()
    {
        AudioManager.instance.Play("MenuSelect");
        SceneManager.LoadScene("Leaderboard");
    }
    public void ButtonQuit()
    {
        AudioManager.instance.Play("MenuSelect");
        Application.Quit();
    }

    public void ButtonMenu()
    {
        AudioManager.instance.Play("MenuSelect");
        SceneManager.LoadScene("Menu");
    }

    public void ButtonTutorial()
    {
        AudioManager.instance.Play("MenuSelect");
        SceneManager.LoadScene("Tutorial");
    }
}
