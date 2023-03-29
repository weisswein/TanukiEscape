using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //public int countdownMinutes = 1;
    private float timer= 0.0f;
    private Text timeText;


    private void Start()
    {
        timeText = GetComponent<Text>();
        timer = 0;
    }

    void Update()
    {
        if((GManager.instance.GameStart)&&(!GManager.instance.end)){
            if((int)timer!=(int)(timer+=Time.deltaTime)&&(GManager.instance.speed<13))GManager.instance.speed+=(timer/300);
            timer += Time.deltaTime;
            //var span = new TimeSpan(0, 0, 70-(int)timer);
            timeText.text = ""+(70-(int)timer);
            //span.ToString(@"mm\:ss");
            if(timer>70.0f) GManager.instance.end=true;
        }
        else{
            if(timer > 2.0f){
                GManager.instance.GameStart=true;
                timer=0f;
                Debug.Log("START!");
            }
            else{
                timer += Time.deltaTime;
            }
        }
        
    }
}