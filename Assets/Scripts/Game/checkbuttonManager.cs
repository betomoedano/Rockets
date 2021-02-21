using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkbuttonManager : MonoBehaviour
{
    public string thisSkin;
    public Image image, marco;

    void Start () 
    {
    }
    void Update()
    {
        var tempColor = image.color;
        tempColor.a = .5f;
        if(FoxController.currentSkin == thisSkin)
        {
            marco.color = new Color(marco.color.r, marco.color.g, image.color.b, 1f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }
        else
        {
            marco.color = new Color(marco.color.r, marco.color.g, image.color.b, .4f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, .4f);
        }
    }
}
