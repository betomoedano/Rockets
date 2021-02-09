using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class colorToPrefab
{
    public GameObject prefab;
    public Color color;
}

public class CoinGenerator: MonoBehaviour
{

    public Texture2D coinMap;
    public colorToPrefab[] colortoPrefab;
    public GameObject parentObject;
  
    void Start()
    {
        GenerateMap();           ;
    }

    void GenerateMap()
    {
         for(int x = 0; x < coinMap.width; x++)
        {
            for(int y = 0; y < coinMap.height; y++)
            {
                GenerateCoins(x,y);
            }
        }
    }

    void GenerateCoins(int x, int y)
    {
        Color mapColor = coinMap.GetPixel(x, y);

        foreach(colorToPrefab obj in colortoPrefab)
        {
            if (obj.color.Equals(mapColor))
            {
                Vector2 pos = new Vector2(x, y);
                Instantiate(obj.prefab, pos, Quaternion.identity, parentObject.transform);
            }
        }
    }
}
