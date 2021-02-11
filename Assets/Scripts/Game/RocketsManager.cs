using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System;

public class RocketsManager : MonoBehaviour
{
    public Unlockable unlockable;
    private string unlockablePath;
    public Button rocket1, rocket2, rocket3, rocket4, rocket5, rocket6, pack1, pack2;
    public GameObject label1, label2, label3, label4, label5, label6, label7, label8;
    public GameObject useRocket1, useRocket2, useRocket3, useRocket4, useRocket5, useRocket6, usePack1, usePack2;
    public GameObject purchaseSucces, notMoney, scrollView;
    public Image skinPack1, skinPack2;

    void Awake()
    {
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
    }

    void Start()
    {
        AdManager.adsInstance.showBanner();
        unlockablePath = Application.persistentDataPath + "/Unlockeable.json";
        //Debug.Log(unlockablePath);
        if (File.Exists(unlockablePath))
        {
            string json = File.ReadAllText(unlockablePath);
            unlockable = JsonUtility.FromJson<Unlockable>(json);
        }
        if(unlockable.hasPack1)
        {
            skinPack1.color = new Color(255,255,255);
        }
        if(unlockable.hasPack2)
        {
            skinPack2.color = new Color(255,255,255);
        }
        RenderShop();
    }

    public void BuyRocket1()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        if(GameState.gameState.coins >= 5000)
        {
            GameState.gameState.coins -= 5000;
            GameState.gameState.SaveData();
            FoxController.currentSkin = "3";
            scrollView.SetActive(false); 
            purchaseSucces.SetActive(true);
            unlockable.hasRocket1 = true;
            RenderShop();
            SaveJson();
        }
        else
        {
            scrollView.SetActive(false);
            notMoney.SetActive(true);
        }
    }
    public void BuyRocket2()
    {
        FindObjectOfType<AudioManager>().Play("tap");        
        if(GameState.gameState.coins >= 20000)
        {
            GameState.gameState.coins -= 20000;
            GameState.gameState.SaveData();
            FoxController.currentSkin = "12";
            scrollView.SetActive(false); 
            purchaseSucces.SetActive(true);
            unlockable.hasRocket2 = true;
            RenderShop();
            SaveJson();
        }
        else
        {
            scrollView.SetActive(false);
            notMoney.SetActive(true);
        }
    }
    public void BuyRocket3()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        if(GameState.gameState.coins >= 15000)
        {
            GameState.gameState.coins -= 15000;
            GameState.gameState.SaveData();
            FoxController.currentSkin = "9";
            scrollView.SetActive(false); 
            purchaseSucces.SetActive(true);
            unlockable.hasRocket3 = true;
            RenderShop();
            SaveJson();
        }
        else
        {
            scrollView.SetActive(false);
            notMoney.SetActive(true);
        }
    }
    public void BuyRocket4()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        if(GameState.gameState.coins >= 15000)
        {
            GameState.gameState.coins -= 15000;
            GameState.gameState.SaveData();
            FoxController.currentSkin = "11";
            scrollView.SetActive(false); 
            purchaseSucces.SetActive(true);
            unlockable.hasRocket4 = true;
            RenderShop();
            SaveJson();
        }
        else
        {
            scrollView.SetActive(false);
            notMoney.SetActive(true);
        }
    }
    public void BuyRocket5()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        if(GameState.gameState.coins >= 20000)
        {
            GameState.gameState.coins -= 20000;
            GameState.gameState.SaveData();
            FoxController.currentSkin = "10";
            scrollView.SetActive(false); 
            purchaseSucces.SetActive(true);
            unlockable.hasRocket5 = true;
            RenderShop();
            SaveJson();
        }
        else
        {
            scrollView.SetActive(false);
            notMoney.SetActive(true);
        }
    }
    public void BuyRocket6()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        if(GameState.gameState.coins >= 20000)
        {
            GameState.gameState.coins -= 20000;
            GameState.gameState.SaveData();
            FoxController.currentSkin = "7";
            scrollView.SetActive(false); 
            purchaseSucces.SetActive(true);
            unlockable.hasRocket6 = true;
            RenderShop();
            SaveJson();
        }
        else
        {
            scrollView.SetActive(false);
            notMoney.SetActive(true);
        }
    }
    public void BuyPack1()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        if(IAPManager.hasPurchasedPack1 == true)
        {
            skinPack1.color = new Color(255,255,255);
            unlockable.hasPack1 = true;
            FoxController.currentSkin = "GOLDEN10";
            RenderShop();
            SaveJson(); 
        }
    }
    public void BuyPack2()
    {
        FindObjectOfType<AudioManager>().Play("tap");
        if(IAPManager.hasPurchasedPack2 == true)
        {
            skinPack2.color = new Color(255,255,255);
            unlockable.hasPack2 = true;
            FoxController.currentSkin = "Golden";
            RenderShop();
            SaveJson();
        }
    }
    public void RenderShop()
    {

        if (unlockable.hasRocket1)
        {
            rocket1.interactable = false;
            label1.SetActive(false);
            useRocket1.SetActive(true);
        }
        if (unlockable.hasRocket2)
        {
            rocket2.interactable = false;
            label2.SetActive(false);
            useRocket2.SetActive(true);
        }
        if (unlockable.hasRocket3)
        {
            rocket3.interactable = false;
            label3.SetActive(false);
            useRocket3.SetActive(true);
        }
        if (unlockable.hasRocket4)
        {
            rocket4.interactable = false;
            label4.SetActive(false);
            useRocket4.SetActive(true);
        }
        if (unlockable.hasRocket5)
        {
            rocket5.interactable = false;
            label5.SetActive(false);
            useRocket5.SetActive(true);
        }
        if (unlockable.hasRocket6)
        {
            rocket6.interactable = false;
            label6.SetActive(false);
            useRocket6.SetActive(true);
        }
        if (unlockable.hasPack1)
        {
            pack1.interactable = false;
            label7.SetActive(false);
            usePack1.SetActive(true);
        }
        if (unlockable.hasPack2)
        {
            pack2.interactable = false;
            label8.SetActive(false);
            usePack2.SetActive(true);
        }
    }
    private void SaveJson()
    {
        string json = JsonUtility.ToJson(unlockable);
        File.WriteAllText(unlockablePath, json);
    }
}