using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{

    public GameObject startScreen;
    public GameObject pauseButton;
    public GameObject boxCollider;
    public GameObject score;
    public GameObject distance;
    public GameObject clockButton, nuclearButton;
   
    private void OnMouseDown()
    {
        FoxController.foxControllerInstance.TapToPlay();
        FoxController.moving = true;
        NotificationCenter.DefaultCenter().PostNotification(this, "TapToPlay");
        startScreen.SetActive(false);
        score.SetActive(true);
        distance.SetActive(true);
        pauseButton.SetActive(true);
        clockButton.SetActive(true);
        nuclearButton.SetActive(true);
        boxCollider.SetActive(false);
    }
}
