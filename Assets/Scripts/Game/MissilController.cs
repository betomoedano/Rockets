using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MissilController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject explotion;
    public ParticleSystem explotionParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "shield")
        {
            Destroy(gameObject);
        }

        else if (collision.tag == "Player")
        {
            Time.timeScale = 1f;
            Instantiate(explotionParticles, transform.position, Quaternion.identity);
            GameObject character = GameObject.Find("Character");
            character.SetActive(false);
            Destroy(gameObject);
            NotificationCenter.DefaultCenter().PostNotification(this, "CharacterHasDead");
        }
        
    }
}
