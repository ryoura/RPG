using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : Enemy
{
    [SerializeField]
    int hp;

    public GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ターゲットの位置を目的地に設定する。
        agent.destination = target.transform.position;
        PlayAnimation(AnimationID.Walk);
    }


    void HP() 
    {
        if (hp < 0)
        {
            PlayAnimation(AnimationID.Dead);
        }
    }
}