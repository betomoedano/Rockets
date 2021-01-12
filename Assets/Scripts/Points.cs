using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour{

    public int points = 0;
    public int distanceInt = 0;
    public Text score;
    public Text distance;

    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementPoints");
        NotificationCenter.DefaultCenter().AddObserver(this, "CharacterHasDead");
        ScoreUpdatter();
    }


    //void CharacterHasDead(Notification notificacion)
    //{
    //        GameState.gameState.coins = GameState.gameState.coins + points;
    //        GameState.gameState.SaveData();
    //        points = 0;
    //}

    void IncrementPoints (Notification notificacion)
    {
        int pointsToIncreas = (int)notificacion.data;
        points += pointsToIncreas;
        ScoreUpdatter();
        //Debug.Log("Puntos  --> " + points);
    }

    void ScoreUpdatter()
    {
        score.text = points.ToString();

    }

    void DistanceUpdatter()
    {
        //GameObject MainCamera = GameObject.Find("MainCamera");
        float aux = transform.position.x;
        aux -= 7f;
        distance.text = aux.ToString("0");
        distanceInt = (int)aux + 1;
    }

    void Update()
    {

        DistanceUpdatter();
    }
}
