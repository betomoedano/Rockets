using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 1f;
            NotificationCenter.DefaultCenter().PostNotification(this, "CharacterHasDead");
            GameObject character = GameObject.Find("Character");
            character.SetActive(false);
        }

        else
        {
            Destroy(other.gameObject);
        }

       // foreach (Transform child in transform)
       // {
        //    child.parent = null;
       // }

    }

}
