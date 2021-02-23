using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausedMenu;
    public GameObject gameOverMenu, nuclearButton, clockButton;


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
        nuclearButton.SetActive(true);
        clockButton.SetActive(true);
        FindObjectOfType<AudioManager>().Play("tap");
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Paused()
    {
        nuclearButton.SetActive(false);
        clockButton.SetActive(false);
        FindObjectOfType<AudioManager>().Mute("ticktock2");
        FindObjectOfType<AudioManager>().Play("tap");
        Time.timeScale = 0f;
        pausedMenu.SetActive(true);
        GameIsPaused = true;
    }
    public void LoadMainScene()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        SceneManager.LoadScene("Portada");
        GameObject character = GameObject.Find("Character");
        character.SetActive(false);
        Time.timeScale = 1f;
        FoxController.moving = false;
    }

    public void RestartScene()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        SceneManager.LoadScene("MainScene");
        GameObject character = GameObject.Find("Character");
        character.SetActive(false);
        Time.timeScale = 1f;
        FoxController.moving = false;
    }
    public void RestartSceneFromAdWatched()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        SceneManager.LoadScene("MainScene");
        FoxController.moving = false;
    }
}
