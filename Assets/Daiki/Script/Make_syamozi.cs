using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_syamozi : MonoBehaviour
{
    [Header("攻撃オブジェクト")] public GameObject getObj;

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
        if(GManager.instance.GameStart){
            if((timer> interval-move)&&(!movef)){
                int ran=Random.Range(0, 3);
                transform.position = new Vector3(6.27f, GManager.instance.setp_y[ran] ,0);
                movef=true;
            }
            if(timer > interval)
            {
                Attack();
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
        GameObject g = Instantiate(getObj);
        g.transform.SetParent(transform);
        g.transform.position = getObj.transform.position;
        g.transform.rotation = getObj.transform.rotation;
        g.SetActive(true);
    }   
}
