using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{ 

    public float scrollSpeed = 0.2f;
    private Material myMaterial;

    private void Awake()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset = new Vector2(Time.time * scrollSpeed , 0);
    }
}
