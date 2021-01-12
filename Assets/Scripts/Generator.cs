using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] obj;
    public float timeMin = .5f;
    public float timeMax = 1f;
    //public Transform posA;
    //public Transform posB;
    //Vector3 nextPos;
    //public float speed = 5f;


    void Start()
    {
        //Generate();
        NotificationCenter.DefaultCenter().AddObserver(this, "TapToPlay");
        NotificationCenter.DefaultCenter().AddObserver(this, "CharacterHasDead");
        NotificationCenter.DefaultCenter().AddObserver(this, "GameRestarted");
        //nextPos = posA.transform.position;

    }

    void GameRestarted(Notification notificacion)
    {      
            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
            Invoke("Generate", Random.Range(timeMin, timeMax));  
    }

    void CharacterHasDead(Notification notificacion)
    {
        FoxController.moving = false;
    }

    void TapToPlay(Notification notification)
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Generate", Random.Range(timeMin, timeMax));
        //NotificationCenter.DefaultCenter().RemoveObserver(this, "Running");
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        //if(Vector3.Distance(transform.position, nextPos) <= 1)
        //{
            //changeDestination();
        //}
        
    }

    //void changeDestination()
    //{
        //nextPos = nextPos != posA.transform.position ? posA.transform.position : posB.transform.position;     
    //}

    void Generate()
    {
        if(FoxController.moving == true)
        {
            Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
            Invoke("Generate", Random.Range(timeMin, timeMax));
        }         
    }
}
