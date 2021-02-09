using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopItem
{
    public Sprite icon;
    public int price = 10000;
    public string spriteName = "Ring";
}

public class ShopScrollList : MonoBehaviour
{

    public List<ShopItem> itemList;
    public Transform contentPanel;
    public Text actualCoins;
    public SimpleObjectPool buttonObjectPool;
    public GameObject panelPurchaseSuccessful;
    public GameObject notEnoughCoins;
    public GameObject scrollView;


    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }

    public void LoadShop()
    {
        ShopData shopData = SaveSystem.LoadShop();

        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].price = shopData.toSaveItems[i].priceLabelText;
            itemList[i].spriteName = shopData.toSaveItems[i].currentSpriteName;
        }
    }

    void Start()
    {
        RefreshScore();
        //RefreshDisplay();
    }

    public void RefreshDisplay()
    {  
        AddButtons();
    }
    public void RefreshScore()
    {
        actualCoins.text = GameState.gameState.coins.ToString();
    }


    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            ShopItem item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            ButtonItem sampleButton = newButton.GetComponent<ButtonItem>();
            sampleButton.Setup(item, this);
        }
    }

    public void TryToBuy(ShopItem shopItem)
    { 
        if (GameState.gameState.coins >= shopItem.price) 
        {
            panelPurchaseSuccessful.SetActive(true);
            scrollView.SetActive(false);
            GameState.gameState.coins -= shopItem.price;
            GameState.gameState.SaveData();
            RefreshScore();
        }
        else
        {
            notEnoughCoins.SetActive(true);
            scrollView.SetActive(false);
        }
    }

    public void TryToDisableButton(ButtonItem currentButton, ShopItem shopItem)
    {
        if (GameState.gameState.coins >= shopItem.price)
        {
            currentButton.button.interactable = false;
            currentButton.priceLabel.text = "OWNED";
            currentButton.isOwned = true;
            FoxController.currentSkin = shopItem.spriteName;
            //GameState.gameState.currentSkin = shopItem.spriteName;
            //GameState.gameState.SaveData();
        }
    }

    //private void RemoveButtons()
    //{
    //    while (contentPanel.childCount > 0)
    //    {
    //        GameObject toRemove = transform.GetChild(0).gameObject;
    //        buttonObjectPool.ReturnObject(toRemove);
    //    }
    //}

    //public void TryTransferItemToOtherShop(Item item)
    //{
    //    if (otherShop.gold >= item.price)
    //    {
    //        gold += item.price;
    //        otherShop.gold -= item.price;

    //        AddItem(item, otherShop);
    //        RemoveItem(item, this);

    //        RefreshDisplay();
    //        otherShop.RefreshDisplay();
    //        Debug.Log("enough gold");

    //    }
    //    Debug.Log("attempted");
    //}

    //void AddItem(Item itemToAdd, ShopScrollList shopList)
    //{
    //    shopList.itemList.Add(itemToAdd);
    //}

    //private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    //{
    //    for (int i = shopList.itemList.Count - 1; i >= 0; i--)
    //    {
    //        if (shopList.itemList[i] == itemToRemove)
    //        {
    //            shopList.itemList.RemoveAt(i);
    //        }
    //    }
    //}


}
