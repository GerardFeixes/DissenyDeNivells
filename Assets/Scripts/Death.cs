using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public GameObject startPosition;

    bool restartPosition;
    // Start is called before the first frame update
    void Start()
    {
        restartPosition = false;   
    }

    // Update is called once per frame
    void Update()
    {
     if(restartPosition)
        {
            transform.position = startPosition.transform.position;
            restartPosition = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lava")
        {
            Debug.Log("You died");
            restartPosition = true;
        }
    }
}
