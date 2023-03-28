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
        if(GManager.instance.GameStart){
            timer += Time.deltaTime;
            var span = new TimeSpan(0, 0, (int)timer);
            timeText.text = span.ToString(@"mm\:ss");

            if (timer <= 0)
            {
                // 0秒になったときの処理
                Debug.Log("Go Next Scene!");
            }
        }
        else{
            if(timer > 2.0){
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