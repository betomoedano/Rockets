using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;


public class GameState : MonoBehaviour
{
    public int coins = 0;
    public int bestFly = 0;
    //public string currentSkin;

    public static GameState gameState;

    private string fileRute;


    void Start()
    {
        LoadData();
    }


     void Awake()
    {
        fileRute = Application.persistentDataPath + "data.dat";
        if(gameState == null)
        {
            gameState = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(gameState != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter br = new BinaryFormatter();
        FileStream file = File.Create(fileRute);
        DataToSave coinsToSave = new DataToSave();
        coinsToSave.coins = coins;
        coinsToSave.bestFly = bestFly;
        //coinsToSave.currentSkin = currentSkin;

        br.Serialize(file, coinsToSave);
        file.Close();   
    }


    void LoadData()
    {
        if(File.Exists(fileRute))
        {
            BinaryFormatter br = new BinaryFormatter();
            FileStream file = File.Open(fileRute, FileMode.Open);

            DataToSave dataToSave = (DataToSave)br.Deserialize(file);
            coins = dataToSave.coins;
            bestFly = dataToSave.bestFly;
            //currentSkin = dataToSave.currentSkin;
            file.Close();   
        }
        else
        {
            coins = 0;
            bestFly = 0;
            //currentSkin = null;
        }
           
    }
}

[Serializable]
class DataToSave
{
    public int coins;
    public int bestFly;
    //public string currentSkin;
}
