using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racoon_move : MonoBehaviour
{
    public float rotate_speed;
    public float setp_x;
    private int lane_num=0;
    private bool push_flag;
    private bool dash=false;
    public AnimationCurve dashCurve;
    private bool change=false;
    private float dashTime; 
    private float hitTime; 
    private int hitcount=0; 
    private float xspeed=0.0f; 
    private Rigidbody2D rb;
    private Vector3 defaultPos;
    [Header("最大移動距離")] public float maxDistance = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        //回転
        myTransform.Rotate(0,0,-1.0f*(rotate_speed+xspeed*3),Space.World);
        //
        
        Vector3 posi = this.transform.position;
        if (Input.GetKey (KeyCode.UpArrow)) {
            if((!push_flag)&&(lane_num<2)){
                lane_num+=1;
                transform.position = new Vector3(posi.x, GManager.instance.setp_y[lane_num] ,0);
                push_flag=true;
            }
            
        }
        else if (Input.GetKey (KeyCode.DownArrow)) {
            if((!push_flag)&&(lane_num>0)){
                lane_num-=1;
                transform.position = new Vector3(posi.x, GManager.instance.setp_y[lane_num] ,0);
                push_flag=true;
            }
            
        }
        else if (Input.GetKey (KeyCode.RightArrow)) {
            if(!push_flag){
                dash=true;
                push_flag=true;
                defaultPos = transform.position;
            }      
            
        }
        else{
            push_flag=false;
        }
        if(dash){ 
            dashTime += Time.deltaTime*1.2f;
            xspeed += dashCurve.Evaluate(dashTime);
            if(posi.x<setp_x&&xspeed<0){
                dash=false;
                xspeed=0.0f;
                dashTime=0.0f;
                transform.position = new Vector3(setp_x, GManager.instance.setp_y[lane_num] ,0);
            }
        }
        transform.Translate (xspeed*0.1f, 0, 0,Space.World);

        if(GManager.instance.hit){
            if(hitTime>0.05f){
                if(change){
                    GetComponent<Renderer>().material.color = Color.white;
                    change=!change;
                }
                else{
                    GetComponent<Renderer>().material.color = Color.red;
                    change=!change;
                }
                hitTime=0.0f;
                hitcount+=1;
            }
            else hitTime+=Time.deltaTime;
            if(hitcount>=4){
                GManager.instance.hit=false;
                hitcount=0;
            }
        }
    }
}
