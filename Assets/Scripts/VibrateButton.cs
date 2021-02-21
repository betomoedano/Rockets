using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateButton : MonoBehaviour
{
    public GameObject onVibrate, offVibrate;

    void Start()
    {
        if(GameState.gameState.vibrate == true)
        {
            OnVibrate();
        }
        else
        {
            OffVibrate();
        }
    }

    public void OnVibrate()
    {
        GameState.gameState.vibrate = true;
        GameState.gameState.SaveData();
        onVibrate.SetActive(true);
        offVibrate.SetActive(false);
    }
    public void OffVibrate()
    {
        GameState.gameState.vibrate = false;
        GameState.gameState.SaveData();
        onVibrate.SetActive(false);
        offVibrate.SetActive(true);
    }


}
