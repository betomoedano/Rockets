using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    public bool trigger = false;
    public bool magnet = false;
    Vector2 characterPosition;
    Transform characterTransform;
    GameObject characterGO;
    Rigidbody2D rbCoin;
    float timeStamp;
    //public ParticleSystem coinParticles;

    public void Start()
    {
        rbCoin = GetComponent<Rigidbody2D>();
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
            timeStamp = Time.time;
        }

    }

    public void Update()
    {
        if(magnet)
        {
            characterPosition = -(transform.position - characterGO.transform.position ).normalized;
            rbCoin.velocity = new Vector2(characterPosition.x, characterPosition.y) * 50f * (Time.time/timeStamp);
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
