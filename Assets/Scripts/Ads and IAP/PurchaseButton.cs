using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType {coin10000, coin50000, skin150k, skin250k}
    public PurchaseType purchaseType;

    public void OnClickPurchaseButton()
    {
        switch(purchaseType)
        {
            case PurchaseType.skin150k:
                IAPManager.instance.Skin150k();
                break;
            case PurchaseType.skin250k:
                IAPManager.instance.Skin250k();
                break;
            case PurchaseType.coin10000:
                IAPManager.instance.BuyCoin10000();
                break;
           case PurchaseType.coin50000:
                IAPManager.instance.BuyCoin50000();
                break;
        }
    }
}
