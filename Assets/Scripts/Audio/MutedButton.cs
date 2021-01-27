using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutedButton : MonoBehaviour
{
    bool muted = false;
    public GameObject butonMusic, buttonNoMusic;

    public void Start()
    {
        if(GameState.gameState.isMuted == true)
        {
            pauseSound();
        }
        else if(GameState.gameState.isMuted == false)
        {
            NoPauseSound();
        }
    }
    public void pauseSound()
    {
        muted = true;
        GameState.gameState.isMuted = muted;
        GameState.gameState.SaveData();
        AudioListener.volume = muted ? 0 : 1;
        butonMusic.SetActive(false);
        buttonNoMusic.SetActive(true);
        
    }
 
    public void NoPauseSound()
    {
        muted = false;
        GameState.gameState.isMuted = muted;
        GameState.gameState.SaveData();
        AudioListener.volume = muted ? 0 : 1;
        butonMusic.SetActive(true);
        buttonNoMusic.SetActive(false);
    }
}
