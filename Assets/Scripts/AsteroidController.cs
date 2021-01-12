using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public ParticleSystem explotionParticles;
    //private Transform target;
 


    public void Start()
    {

    }

    private void FixedUpdate()
    {
        //characterPos = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime );
        transform.position = transform.position + new Vector3(2 * Time.deltaTime, 0f, 0f);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
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
