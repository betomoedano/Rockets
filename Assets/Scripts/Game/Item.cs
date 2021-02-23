using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    public bool trigger = false;
    public bool magnet = false;
    GameObject characterGO;
    public float atractionSpeed =25f;

    //public ParticleSystem coinParticles;

    public void Start()
    {
        characterGO = GameObject.Find("Character");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !trigger)
        {
            FindObjectOfType<AudioManager>().Play("tap");
            if(GameState.gameState.vibrate){StartCoroutine(Vibrate());}
            trigger = true;
            Destroy(this.gameObject);
            //Instantiate(coinParticles, transform.position, Quaternion.identity);
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementPoints", 1);
            
        }
        if(other.CompareTag("Magnet"))
        {
            magnet = true;
        }

    }

    public void Update()
    {
        if(magnet)
        {
            transform.position = Vector3.MoveTowards(transform.position, characterGO.transform.position, atractionSpeed * Time.deltaTime);
        }
    }

    private IEnumerator Vibrate()
    {
        float interval = .05f;
        WaitForSeconds wait = new WaitForSeconds(interval);
        float t;

        for (t = 0; t < .1; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }

        yield return new WaitForSeconds(0.1f);
    }
}
