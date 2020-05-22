using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{

    float y;
    public float speedY = 20;

    void FixedUpdate()
    {
        y += Time.deltaTime * speedY;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
