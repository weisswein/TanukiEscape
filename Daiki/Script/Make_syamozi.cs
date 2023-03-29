using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_syamozi : MonoBehaviour
{
    public GameObject[] getObj = new GameObject[3];

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
        int obj_num;
        int rano=Random.Range(1, 31);
        if((rano%10==0)&&(rano!=20)) obj_num=2;
        else if(rano%4==0) obj_num=1;
        else obj_num=0;
        GameObject g = Instantiate(getObj[obj_num]);
        g.transform.SetParent(transform);
        g.transform.position = getObj[obj_num].transform.position;
        g.transform.rotation = getObj[obj_num].transform.rotation;
        g.SetActive(true);
    }   
}
