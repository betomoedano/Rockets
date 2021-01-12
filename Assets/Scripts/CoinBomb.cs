using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBomb : MonoBehaviour
{
    public GameObject item;
    public ParticleSystem particleLauncher;

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            
            for (int j = 0; j < 10; j++)
                {
                    Instantiate(item, transform.position + new Vector3(j * .5f, 0, 0), Quaternion.identity);
                }
            particleLauncher.Play();
            Destroy(this.gameObject);
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
