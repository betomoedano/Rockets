using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
    public Button button;
    public Text priceLabel;
    public Image itemSprite;
    public Text spriteName;
    public bool isOwned = false;

    private ShopItem shopItem;
    private ShopScrollList shopScrollList;

    public void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(ShopItem currentItem, ShopScrollList currenShopScrollList)
    {
        shopItem = currentItem;
        priceLabel.text = shopItem.price.ToString();
        itemSprite.sprite = shopItem.icon;
        spriteName.text = shopItem.spriteName;

        shopScrollList = currenShopScrollList;
        
    }


    public void HandleClick()
    {        
        shopScrollList.TryToDisableButton(this, shopItem);
        shopScrollList.TryToBuy(shopItem);
    }

 
}
