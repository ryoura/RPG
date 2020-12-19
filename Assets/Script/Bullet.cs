using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    int AttackPower;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward;
    }
}
