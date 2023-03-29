 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class GManager : MonoBehaviour
 {
    [Header("スピード")] public float speed = 6.0f;
    public static GManager instance = null;
    public int currentHp=20;
    public int maxHp=20;
    public bool GameStart = false;
    public int syamozi = 0;
    public bool hit=false;
    public bool dash=false;
    public bool disguiseR=false;
    public bool cool=false;
    public bool end=false;
    public float[] setp_y;
    public float[] setp_ye;
    public float[] setp_yf;
    public float setp_x;
    public float dashTime;
    public int lane_num;
     private void Awake()
     {
         if(instance == null)
         {
             instance = this;
             DontDestroyOnLoad(this.gameObject); 
         }
         else
         {
             Destroy(this.gameObject);
         }
     }
 }