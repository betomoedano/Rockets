using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPurchaseSuccessful : MonoBehaviour
{
    public GameObject panelPurchaseSuccessful;
    public GameObject scrollView;

    // Start is called before the first frame update
    public void ClosingPanelPurchase()
    {
        panelPurchaseSuccessful.SetActive(false);
        scrollView.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
