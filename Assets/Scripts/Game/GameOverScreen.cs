using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject camaraGameOver;
    public GameObject startMenu;
    public GameObject pauseButton;
    public Animator transition;
   
    // Start is called before the first frame update
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "CharacterHasDead");
    }
    void CharacterHasDead()
    {       
        camaraGameOver.SetActive(true);
        FoxController.moving = false;
        pauseButton.SetActive(false);
    } 


    public void RestartScene()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        NotificationCenter.DefaultCenter().PostNotification(this, "GameRestarted");
        SceneManager.LoadScene("MainScene");
        pauseButton.SetActive(true);
    }
    public void LoadShopScene()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        camaraGameOver.SetActive(false);
        startMenu.SetActive(false);
        StartCoroutine(LoadShop());
    }

    IEnumerator LoadShop()
    {
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene("Shop");
    }
}
