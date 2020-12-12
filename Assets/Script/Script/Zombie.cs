using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,

        Move,
        Attack,
        
        Dead,
    }

    public GameObject target;
    NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shell"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}