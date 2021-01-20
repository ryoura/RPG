using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : Enemy
{
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
        OnStartActionState(ActionState.Walk);
    }
    /// <summary>
    /// 弾に当たったら死亡
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            ChangeActionState(ActionState.Dead);
        }
    }
}