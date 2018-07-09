using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{


    private float time = 30f;
    Text timer;
    // Use this for initialization
    void Awake()
    {
        timer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = "Time left: " + Mathf.RoundToInt(time % 60);
        time -= Time.deltaTime;

        if (time <= 0)
        {

        }
    }
}