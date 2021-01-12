using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class RocketsManager : MonoBehaviour
{
    public Unlockable unlockable;
    private string unlockablePath;

    public Button rocket1, rocket2, rocket3, rocket4, rocket5, rocket6, pack1, pack2;
    public GameObject label1, label2, label3, label4, label5, label6, label7, label8;
    public GameObject useRocket1, useRocket2, useRocket3, useRocket4, useRocket5, useRocket6, usePack1, usePack2;


    void Start()
    {
        unlockablePath = $"{Application.persistentDataPath}/Unlockeable.json";
        Debug.Log(unlockablePath);
        if (File.Exists(unlockablePath))
        {
            string json = File.ReadAllText(unlockablePath);
            unlockable = JsonUtility.FromJson<Unlockable>(json);
        }
        RenderShop();
    }

    public void BuyRocket1()
    {
        unlockable.hasRocket1 = true;
        RenderShop();
        SaveJson();
    }
    public void BuyRocket2()
    {
        unlockable.hasRocket2 = true;
        RenderShop();
        SaveJson();
    }
    public void BuyRocket3()
    {
        unlockable.hasRocket3 = true;
        RenderShop();
        SaveJson();
    }
    public void BuyRocket4()
    {
        unlockable.hasRocket4 = true;
        RenderShop();
        SaveJson();
    }
    public void BuyRocket5()
    {
        unlockable.hasRocket5 = true;
        RenderShop();
        SaveJson();
    }
    public void BuyRocket6()
    {
        unlockable.hasRocket6 = true;
        RenderShop();
        SaveJson();
    }
    public void BuyPack1()
    {
        unlockable.hasPack1 = true;
        RenderShop();
        SaveJson();
    }
    public void BuyPack2()
    {
        unlockable.hasPack2 = true;
        RenderShop();
        SaveJson();
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