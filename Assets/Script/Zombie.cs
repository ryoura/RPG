using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }
}
/*public int hitPoint = 100;  //HP
 //HPが0になったときに敵を破壊する
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
        }
 //ダメージを受け取ってHPを減らす関数
    public void Damage(int damage)
{
    //受け取ったダメージ分HPを減らす
    hitPoint -= damage;
}*/