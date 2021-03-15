using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    [SerializeField]
    int MaxHp = 10;

    [SerializeField]
    int score = 100;

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shell"))
        {
            MaxHp -= 1;
            Debug.Log(MaxHp);
        }
    }

    void OnDestroy()
    {
        GameManeger gm = GameManeger.FindObjectOfType<GameManeger>();
        if (gm)
        {
            gm.AddScore(score);
        }
    }
}
