using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutedButton : MonoBehaviour
{
    bool muted;
    public GameObject butonMusic, buttonNoMusic;

    public void pauseSound()
    {
        muted = ! muted;
        AudioListener.volume = muted ? 0 : 1;
        butonMusic.SetActive(false);
        buttonNoMusic.SetActive(true);
        
    }
 
    public void NoPauseSound()
    {
        muted = ! muted;
        AudioListener.volume = muted ? 0 : 1;
        butonMusic.SetActive(true);
        buttonNoMusic.SetActive(false);
    }
}
