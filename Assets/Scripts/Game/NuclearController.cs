using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed, pingPongSpeed, movingSpeed;
    public Transform targetTop, targetDown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, 0f);
        if (Vector3.Distance(transform.position, targetDown.transform.position) <= 0)
        {
            GoUp();
        }
        else
        {
            GoDown();
        }

    }
    public void GoUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTop.position, movingSpeed * Time.deltaTime);  
    }
    public void GoDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetDown.position, movingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("shield"))
        {
            Destroy(gameObject);
        }
    }
}
