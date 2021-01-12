using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    private void Start()
    {

    }
    public void OnMouseDown()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "GamePaused");
    }

   




}
