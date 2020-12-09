using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    public GameObject shell;
    public int Attack = 5;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shell")
        {
            Destroy(gameObject);
        }
    }
}