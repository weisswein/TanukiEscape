using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTime : MonoBehaviour
{
    [Header("攻撃間隔")] public float timer;
    [Header("アイコンオブジェクト")] public GameObject iconObj;
    private float interval=2.0f;
    private Vector3 posi;
    void Start()
    {
        posi = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.instance.disguiseR)
        {   
            Debug.Log("ka");
            if(timer < 0)
            {
                GManager.instance.disguiseR=false;
                iconObj.SetActive(false);
            }
            else{
                timer -= Time.deltaTime;
                transform.localScale = new Vector3(timer/2, 1, 1);
                transform.position = new Vector3(posi.x-(0.5f-timer/4), posi.y ,0);
            } 
        }
        else
        {
            if(timer > interval)
            {
                timer = 2.0f;
                GManager.instance.cool=true;
                iconObj.SetActive(true);
            }
            else
            {
                timer += Time.deltaTime/3;
                transform.localScale = new Vector3(timer/2, 1, 1);
                transform.position = new Vector3(posi.x+(timer/4-0.5f), posi.y ,0);
            }
        }

        
    }
}