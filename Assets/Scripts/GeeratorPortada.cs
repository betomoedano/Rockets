using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeeratorPortada : MonoBehaviour
{

    public float timeMin = .5f;
    public float timeMax = 1f;
    public GameObject[] obj;

    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Generate()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Generate", Random.Range(timeMin, timeMax));
    }
}
