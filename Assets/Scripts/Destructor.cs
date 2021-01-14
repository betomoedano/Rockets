using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{

    public ParticleSystem explotion;

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(explotion, other.transform.position, Quaternion.identity);
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
