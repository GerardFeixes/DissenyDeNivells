using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourFinish : MonoBehaviour
{
    public GameObject lava;

    public GameObject lavaDown;

    public float lavaSpeed;

    public bool moveLava;

    // Start is called before the first frame update
    void Start()
    {
        moveLava = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveLava)
        lava.transform.position = Vector3.MoveTowards(lava.transform.position, lavaDown.transform.position, lavaSpeed * Time.deltaTime);
    }

    void OnColliderEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            moveLava = true;
        }
    }





}
