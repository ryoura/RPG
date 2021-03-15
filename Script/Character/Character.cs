using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    protected NavMeshAgent SelfNavmeshAgent { get; private set; }

    [SerializeField]
    float moveSpeed = 5.0f;

    protected void Move(Vector3 axis)
    {
        SelfNavmeshAgent = GetComponent<NavMeshAgent>();
        SelfNavmeshAgent.Move(axis * moveSpeed * Time.deltaTime);
    }
}
