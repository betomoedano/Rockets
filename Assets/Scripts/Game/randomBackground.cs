using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomBackground : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void ChangeSprite(int num)
    {
        spriteRenderer.sprite = spriteArray[num];
    }

    //private void Awake()
    //{
    //    int num = Random.Range((int)0, (int)3);
    //    ChangeSprite(num);
    //}

    void Start()
    {
        int num = Random.Range((int)0, (int)4);
        ChangeSprite(num);
    }


}
