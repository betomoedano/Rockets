using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    public bool trigger = false;
    //public ParticleSystem coinParticles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !trigger)
        {
            trigger = true;
            Destroy(this.gameObject);
            //Instantiate(coinParticles, transform.position, Quaternion.identity);
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementPoints", 1);
            
        }
    }

}
