using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    //public static bool GameIsOver = false;

    public GameObject GameOverMenuUI;

    public void GameOverPart()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1f;
    }

    public void QuitDirect()
    {
        Application.Quit();
    }
}
