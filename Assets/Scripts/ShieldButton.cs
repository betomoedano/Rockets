using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour
{

    public Button button;
    public int price = 50;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(BuyShield);
    }

    public void BuyShield()
    {
        if(GameState.gameState.coins >= price)
        {
            shield.SetActive(true);
            GameState.gameState.coins -= price;
            GameState.gameState.SaveData();
            button.interactable = false;
        }
        else
        {
            Debug.Log("Not enough coins!!");
        }
    }
}
