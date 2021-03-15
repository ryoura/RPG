using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    int TotalScore;

    GameObject d = null;

    void Start()
    {
        d = GameObject.Find("Score");
    }

    void Update()
    {
        Text a = d.GetComponent<Text>();
        a.text = "Score" + TotalScore;
    }

    public void AddScore(int score) 
    {
        TotalScore += score;
    }
}
