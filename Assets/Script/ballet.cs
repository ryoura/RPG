using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballet : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
