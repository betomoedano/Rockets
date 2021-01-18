using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteController : MonoBehaviour
{
    public GameObject satelite, lasik, satelite2, lasik2, satelite3, lasik3;
    void Start()
    {
        
    }
    
    void Update()
    {
            if(transform.position.x > 100)
            {
                satelite.SetActive(true);
                satelite2.SetActive(true);
            }
            if(transform.position.x > 130)
            {
                lasik.SetActive(true);
                lasik2.SetActive(true);
            }
            if(transform.position.x > 190)
            {
                satelite.SetActive(false);
                lasik.SetActive(false);
                satelite2.SetActive(false);
                lasik2.SetActive(false);
            }
            if(transform.position.x > 200)
            {
                satelite3.SetActive(true);
            }
            if(transform.position.x > 230)
            {
                lasik3.SetActive(true);
            }
            if(transform.position.x > 300)
            {
                satelite3.SetActive(false);
            }

    }
}
