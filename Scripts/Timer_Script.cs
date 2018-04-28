using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer_Script : MonoBehaviour
{
    public Text timerText;
    private float timer = 0.0f;
    public Movement_Controller MC;
    void Start()
    {
        timerText.text = "";
    }
    void Update()
    {
        
        timer += Time.deltaTime;
        timerText.text = ((int)timer).ToString();
        if (timer >= 30.0f)
        {
            timer = 0;
            Debug.Log("mc death");
            MC.Death();
        }
    }
}
