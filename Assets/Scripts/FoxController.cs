using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxController : MonoBehaviour {

    public float jumpForce = 5f;
    public float speed = 10f;
    private Rigidbody2D rb2D;
    public static bool moving = false;
    public static string currentSkin = "Rocket-2";
    public static bool shieldOn = false;

    public GameObject explotion;
    int aux = 0;
    public GameObject shield;

    public Text timerText;
    public GameObject timer;
    float secondsLeft = 3f;
    public bool takingAway = false;
    public bool triggerClock = false;

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(currentSkin);
        rb2D.isKinematic = true;
        NotificationCenter.DefaultCenter().AddObserver(this, "TapToPlay");      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "shield")
        {
            shield.SetActive(true);
            Destroy(collision.gameObject);
            shieldOn = true;
        }
        if(collision.tag == "Clock")
        {
            Destroy(collision.gameObject);
            timer.SetActive(true);
            triggerClock = true;
        }
        if(collision.tag == "Lasik")
        {
          
        }
    }

    public void DestroyAllGameObjects(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
         for(int i=0; i< enemies.Length; i++)
         {
             Destroy(enemies[i]);
         }
    }


    public void startCoroutine()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerClock());
        }
    }

    IEnumerator TimerClock()
    {
        Time.timeScale = .5f;
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        timerText.text = secondsLeft.ToString();
        takingAway = false;
        if(secondsLeft == 0)
        {
            Time.timeScale = 1f;
            triggerClock = false;
            secondsLeft = 3;
            timer.SetActive(false);
            timerText.text = "3";
        }
    }

    void TapToPlay()
    {
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {

        if(triggerClock == true)
        {
            startCoroutine();
        }


        aux = (int)transform.position.x;
        if(aux > 300){speed = 12f;}
        if(aux > 600){speed = 15f;}
        if (aux > 1000) { speed = 18f; }


        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(0, 0, rb2D.velocity.y * 150 * Time.deltaTime);
            //transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Ring");   
            if (moving)
            {      
                rb2D.isKinematic = false;
                rb2D.velocity = new Vector3(speed, 0, 0);
                Vector2 movement = new Vector2(0, 1);
                rb2D.AddForce(movement * jumpForce);
            }
            else{
                moving = true;
                Vector2 movement = new Vector2(0, 0);
                rb2D.AddForce(movement * speed);
            }           
            moving = true;
        }
        
        if(! Input.GetMouseButton(0))
        {
            //transform.Rotate(Vector3.back * 10 * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, rb2D.velocity.y * 2 );
        }
    }
}
