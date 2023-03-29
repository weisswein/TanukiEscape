using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabitt_attack : MonoBehaviour
{
    [Header("攻撃オブジェクト")] public GameObject attackObj;

    private Animator anim;
    private float timer;
    public float interval;
    public float move;
    private bool movef;

     // Start is called before the first frame update
     void Start()
     {
     }

     // Update is called once per frame
     void Update()
     {
        if((GManager.instance.GameStart)&&(!GManager.instance.end)){
            if((timer> interval-move)&&(!movef)){
                int ran=Random.Range(0, 3);
                transform.position = new Vector3(-6.76f, GManager.instance.setp_y[ran] ,0);
                movef=true;
            }
            if(timer > interval)
            {
                Attack();
                interval-=0.01f;
                timer = 0.0f;
                movef=false;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
     }
    public void Attack()
    {
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.transform.rotation = attackObj.transform.rotation;
        g.SetActive(true);
    }   
}
