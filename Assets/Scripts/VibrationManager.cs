using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public void VibrateFor1Second()
    {
        Handheld.Vibrate();
    }

    public IEnumerator Vibrate()
    {
        float interval = .05f;
        WaitForSeconds wait = new WaitForSeconds(interval);
        float t;

        for (t = 0; t < .1; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }

        yield return new WaitForSeconds(0.1f);
    }

}
