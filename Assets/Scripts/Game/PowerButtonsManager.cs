using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButtonsManager : MonoBehaviour
{
    public GameObject PopUpNotCoins,PopUpNotNuclear;
    public ParticleSystem explotionParticles;
    public Text nuclearPopUp;
    public GameObject spriteColor, clockColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (FoxController.foxControllerInstance.nuclearCollected == 0)
        {
            spriteColor.SetActive(false);
        }
        else
        {
            spriteColor.SetActive(true);
        }
        if (FoxController.foxControllerInstance.clockCollected == 0)
        {
            clockColor.SetActive(false);
        }
        else
        {
            clockColor.SetActive(true);
        }
    }
    public void Clock()
    {
        if(FoxController.foxControllerInstance.clockCollected > 0)
        {
            FoxController.foxControllerInstance.ClockButtonPressed();         
        }
        else
        {
            StartCoroutine(PopUp());
            print("not clocks collected");
        }
    }

    IEnumerator PopUp()
    {

        PopUpNotCoins.SetActive(true);
        yield return new WaitForSeconds(1);
        PopUpNotCoins.SetActive(false);

    }

    IEnumerator PopUpNuclear()
    {
        PopUpNotNuclear.SetActive(true);
        yield return new WaitForSeconds(1);
        PopUpNotNuclear.SetActive(false);

    }

    public void Nuclear()
    {
        if (FoxController.foxControllerInstance.nuclearCollected > 0)
        {
            FoxController.foxControllerInstance.nuclearCollected--;
            nuclearPopUp.text = FoxController.foxControllerInstance.nuclearCollected.ToString();
            FindObjectOfType<AudioManager>().Play("mine");
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Missile");
            for (int i = 0; i < asteroids.Length; i++)
            {
                Instantiate(explotionParticles, asteroids[i].transform.position, Quaternion.identity);
                Destroy(asteroids[i]);
            }
        }
        else
        {
            StartCoroutine(PopUpNuclear());
        }
    }

}
