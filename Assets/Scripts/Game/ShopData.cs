using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ToSaveItems
{
    public int priceLabelText;
    public string currentSpriteName;
}

[System.Serializable]
public class ShopData
{
    public List<ToSaveItems> toSaveItems;

    public ShopData(ShopScrollList shopScrollList)
    {
        for (int i = 0; i < shopScrollList.itemList.Count; i++)
        {
            shopScrollList.itemList[i].price = toSaveItems[i].priceLabelText;
            shopScrollList.itemList[i].spriteName = toSaveItems[i].currentSpriteName;

        }
    }
        
}
