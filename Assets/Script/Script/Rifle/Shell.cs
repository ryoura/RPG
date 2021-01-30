using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position + transform.forward;
    }
}
