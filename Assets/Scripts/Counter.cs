using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public float currentTime;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) currentTime = 30f;

        text.text = currentTime.ToString();
    }
}
