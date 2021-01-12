using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType {coin10000, coin50000}
    public PurchaseType purchaseType;

    public void OnClickPurchaseButton()
    {
        switch(purchaseType)
        {
            case PurchaseType.coin10000:
                IAPManager.instance.BuyCoin10000();
                break;

            case PurchaseType.coin50000:
                IAPManager.instance.BuyCoin50000();
                break;
        }
    }
}
