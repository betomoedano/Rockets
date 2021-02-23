using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FoxController : MonoBehaviour {

    public float jumpForce = 5f;
    public float speed = 10f;
    public float rotationSpeed = 45f;
    public Rigidbody2D rb2D;
    public static bool moving = false;
    public static string currentSkin = "Rocket-2";
    public static bool shieldOn = false;

    public GameObject explotion;
    int aux = 0;
    public GameObject shield;

    public Text timerText;
    public GameObject timer, magnet;
    float secondsLeft = 3f;
    public bool takingAway = false;
    public bool triggerClock = false;
    public bool taptoplay = false;
    public ParticleSystem explotionParticles;

    public static FoxController foxControllerInstance;
    public int clockCollected = 0;
    public int nuclearCollected = 0;
    public Text clockCounter, nuclear;
    public Button clockButton;
    public bool clicked;


    private void Awake()
    {
        foxControllerInstance = this;
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
        if(collision.CompareTag("shield"))
        {
            shield.SetActive(true);
            Destroy(collision.gameObject);
            shieldOn = true;
        }
        if(collision.CompareTag("Hole"))
        {
            StartCoroutine(MagnetSwitch());
        }
    }

    IEnumerator MagnetSwitch()
    {
        magnet.SetActive(true);
        yield return new WaitForSeconds(12);
        magnet.SetActive(false);
    }

    public void ClockButtonPressed()
    {
        clockCollected--;
        clockCounter.text = clockCollected.ToString();
        FindObjectOfType<AudioManager>().Play("ticktock2");
        timer.SetActive(true);
        triggerClock = true;
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
        clockButton.interactable = false;
        Time.timeScale = .5f;
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        timerText.text = secondsLeft.ToString();
        takingAway = false;
        clockButton.interactable = true;
        if (secondsLeft == 0)
        {
            Time.timeScale = 1f;
            triggerClock = false;
            secondsLeft = 3;
            timer.SetActive(false);
            timerText.text = "3";
            FindObjectOfType<AudioManager>().Mute("ticktock2");
        }
    }

    public void TapToPlay()
    {
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        taptoplay = true;
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!IsPointerOverUIObject())
                {
                    if (moving)
                    {
                        RotateUp();
                        rb2D.isKinematic = false;
                        rb2D.velocity = new Vector3(speed, 0, 0);
                        Vector2 movement = new Vector2(0, 1);
                        rb2D.AddForce(movement * jumpForce);
                    }
                    else
                    {
                        StartRunning();
                        clicked = true;
                    }
                    moving = true;
                }
            }
        }
        else
        {
            RotateDown();
        }
    }
   
    public void StartRunning()
    {
        Vector2 movement = new Vector2(0, 0);
        rb2D.AddForce(movement * speed);
        moving = true;
    }
    void RotateDown()
    {
        transform.eulerAngles = new Vector3(0, 0, -10 * rotationSpeed * Time.deltaTime);
    }

    void RotateUp()
    {
        transform.eulerAngles = new Vector3(0, 0, 10 * rotationSpeed * Time.deltaTime);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

