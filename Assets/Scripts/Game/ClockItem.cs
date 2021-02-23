using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItem : MonoBehaviour
{
    public bool magnet = false;
    GameObject characterGO;

    public void Start()
    {
        characterGO = GameObject.Find("Character");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Magnet"))
        {
            magnet = true;
        }
        if (other.CompareTag("Player"))
        {
            FoxController.foxControllerInstance.clockCollected++;
            FoxController.foxControllerInstance.clockCounter.text = FoxController.foxControllerInstance.clockCollected.ToString();
            Destroy(this.gameObject);
        }
    }

    public void Update()
    {
        if (magnet)
        {
            transform.position = Vector3.MoveTowards(transform.position, characterGO.transform.position, 25f * Time.deltaTime);
        }
    }
}
