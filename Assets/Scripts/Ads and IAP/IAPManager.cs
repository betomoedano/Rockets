using System;
using UnityEngine;
using UnityEngine.Purchasing;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;
    public Unlockable unlockable;


    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    public static bool hasPurchasedPack1, hasPurchasedPack2;

    //Step 1 create your products
    //private string removeAds = "";
    private string coin10000 = "coin_10000";
    private string coin50000 = "coin_50000";
    private string skin150k = "skin150k";
    private string skin250k = "skin250k";


    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        
        builder.AddProduct(skin150k, ProductType.NonConsumable);
        builder.AddProduct(skin250k, ProductType.NonConsumable);
        builder.AddProduct(coin10000, ProductType.Consumable);
        builder.AddProduct(coin50000, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods

    public void Skin150k()
    {
        BuyProductID(skin150k);
    }
    
    public void Skin250k()
    {
        BuyProductID(skin250k);
    }

    public void BuyCoin10000()
    {
        BuyProductID(coin10000);
    }

    public void BuyCoin50000()
    {
        BuyProductID(coin50000);
    }


    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, skin150k, StringComparison.Ordinal))
        {          
            GameState.gameState.coins += 50000;
            GameState.gameState.SaveData();
            hasPurchasedPack1 = true;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, skin250k, StringComparison.Ordinal))
        {
            GameState.gameState.coins += 50000;
            GameState.gameState.SaveData();
            hasPurchasedPack2 = true;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin10000, StringComparison.Ordinal))
        {
            GameState.gameState.coins += 10000;
            GameState.gameState.SaveData();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin50000, StringComparison.Ordinal))
        {
            GameState.gameState.coins += 50000;
            GameState.gameState.SaveData();
        }
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }

    //**************************** Dont worry about these methods ***********************************
    

    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
        GameObject o = new GameObject("IAPManager");
        instance = o.AddComponent<IAPManager>();
        DontDestroyOnLoad(o);
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}