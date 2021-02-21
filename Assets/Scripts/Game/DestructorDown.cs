using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorDown : MonoBehaviour
{

    public ParticleSystem explotion;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Mute("ticktock2");
            FindObjectOfType<AudioManager>().Play("mine");
            DestroyAllGameObjects("Clock");
            DestroyAllGameObjects("Missile");
            DestroyAllGameObjects("Coin");
            Instantiate(explotion, other.transform.position, Quaternion.identity);
            Time.timeScale = 1f;
            NotificationCenter.DefaultCenter().PostNotification(this, "CharacterHasDead");
            GameObject character = GameObject.Find("Character");
            character.SetActive(false);
        }
    }

    public void DestroyAllGameObjects(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

}

