using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Animator transition;
    public Animator shopExit;
    public Text totalCoins;


    public void LoadMainScene()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        StartCoroutine(ShopExit());
        StartCoroutine(LoadMain());
    }

    public void OnEnable()
    {
        RefreshTotalCoinsLabel();
    }

    public void RefreshTotalCoinsLabel()
    {
        totalCoins.text = GameState.gameState.coins.ToString();
    }

    IEnumerator LoadMain()
    {
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator ShopExit()
    {
        shopExit.SetTrigger("ExitShop");
        yield return new WaitForSeconds(.3f);
    }

}
