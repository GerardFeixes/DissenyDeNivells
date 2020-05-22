using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 startPosition;
    public int speed = 5;

    void Start()
    {
        startPosition = transform.position;
       // speed = 3;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, startPosition.z + Mathf.Sin(Time.time * speed));
    }
}
