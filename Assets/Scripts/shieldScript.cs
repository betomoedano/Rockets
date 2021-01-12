using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    public ParticleSystem explotion;
    public GameObject shield;
    //public PolygonCollider2D polygon;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Missile")
        {
            Destroy(collision.gameObject);
            Instantiate(explotion, transform.position, Quaternion.identity);
            shield.SetActive(false);
            FoxController.shieldOn = false;

            //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Missile");
            //foreach (GameObject enemy in enemies)
            //GameObject.Destroy(enemy);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
