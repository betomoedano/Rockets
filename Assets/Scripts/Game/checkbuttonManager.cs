using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkbuttonManager : MonoBehaviour
{
    public string thisSkin;
    public Image image;

    void Start () 
    {
          image = GetComponent<Image>();
    }
    void Update()
    {
        var tempColor = image.color;
        tempColor.a = .5f;
        if(FoxController.currentSkin == thisSkin)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, .4f);
        }
    }
}
