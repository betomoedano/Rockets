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
        NotificationCenter.DefaultCenter().PostNotification(this, "TapToPlay");
        startScreen.SetActive(false);
        score.SetActive(true);
        distance.SetActive(true);
        pauseButton.SetActive(true);
        clockButton.SetActive(true);
        nuclearButton.SetActive(true);
        FoxController.moving = true;
        Object.Destroy(boxCollider);
    }
}
