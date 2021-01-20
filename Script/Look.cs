using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Transform cursor;

    void Update()
    {
        cursor.LookAt(target);
        
    }
}
