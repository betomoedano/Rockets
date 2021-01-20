using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public void LoadSkinRocket1()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "3";
    }
    public void LoadSkinRocket2()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "12";
    }
    public void LoadSkinRocket3()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "9";
    }
    public void LoadSkinRocket4()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "11";
    }
    public void LoadSkinRocket5()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "10";
    }
    public void LoadSkinRocket6()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "7";
    }
    public void LoadSkinRocket7()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "GOLDEN10";
    }
    public void LoadSkinRocket8()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        FoxController.currentSkin = "Golden";
    }
}