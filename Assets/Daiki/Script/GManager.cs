 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class GManager : MonoBehaviour
 {
    public static GManager instance = null;
    public int currentHp=20;
    public int maxHp=20;
    public bool GameStart = false;
    public int syamozi = 0;
    public bool hit=false;
    public float[] setp_y;
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