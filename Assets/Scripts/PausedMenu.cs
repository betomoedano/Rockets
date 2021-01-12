using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausedMenu;
    public GameObject gameOverMenu;


    private void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "GamePaused");
    }

    void GamePaused()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }
    public void Resume()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Paused()
    {
            Time.timeScale = 0f;
            pausedMenu.SetActive(true);
            GameIsPaused = true;
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Portada");
        GameObject character = GameObject.Find("Character");
        character.SetActive(false);
        Time.timeScale = 1f;
        FoxController.moving = false;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("MainScene");
        GameObject character = GameObject.Find("Character");
        character.SetActive(false);
        Time.timeScale = 1f;
        FoxController.moving = false;
    }
}
