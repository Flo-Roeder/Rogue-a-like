using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smooth;
    public float zoom;
    void FixedUpdate()
    {
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = Vector3.Lerp(transform.position, playerPosition + new Vector3(2, 2, zoom),smooth);
    }
}
