using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racoon_move : MonoBehaviour
{
    public float rotate_speed;
    public float setp_x;
    private bool push_flag;
    public AnimationCurve dashCurve;
    private bool change=false;
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

    void OnEnable(){
        Vector3 posi = this.transform.position;
        if(posi.x<setp_x){
            GManager.instance.dash=false;
            xspeed=0.0f;
            GManager.instance.dashTime=0.0f;
            transform.position = new Vector3(setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
        }
        else transform.position = new Vector3(GManager.instance.setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GManager.instance.currentHp<1){
            //this.layer = 8;
        }

        Transform myTransform = this.transform;
        //回転
        myTransform.Rotate(0,0,-1.0f*(rotate_speed+xspeed*3),Space.World);
        Vector3 posi = this.transform.position;
        if(xspeed!=0)GManager.instance.setp_x=posi.x;
        else GManager.instance.setp_x=setp_x;
        if (Input.GetKey (KeyCode.UpArrow)) {
            if((!push_flag)&&(GManager.instance.lane_num<2)){
                GManager.instance.lane_num+=1;
                transform.position = new Vector3(GManager.instance.setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
                push_flag=true;
            }
            
        }
        else if (Input.GetKey (KeyCode.DownArrow)) {
            if((!push_flag)&&(GManager.instance.lane_num>0)){
                GManager.instance.lane_num-=1;
                transform.position = new Vector3(GManager.instance.setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
                push_flag=true;
            }
            
        }
        else if (Input.GetKey (KeyCode.RightArrow)) {
            if(!GManager.instance.dash){
                GManager.instance.dash=true;
                defaultPos = transform.position;
                xspeed=0.0f;
                GManager.instance.dashTime=0.0f;
            }      
        }
        else push_flag=false;
        if(GManager.instance.dash){ 
            GManager.instance.dashTime += Time.deltaTime*1.2f;
            xspeed += dashCurve.Evaluate(GManager.instance.dashTime);
            if(posi.x<setp_x&&xspeed<0){
                GManager.instance.dash=false;
                xspeed=0.0f;
                GManager.instance.dashTime=0.0f;
                transform.position = new Vector3(setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
            }
        }
        if(posi.x>=9.05){
            xspeed=-1f;
            GManager.instance.dash=true;
        }
        else if(posi.x<setp_x){
            GManager.instance.dash=false;
            xspeed=0.0f;
            GManager.instance.dashTime=0.0f;
            transform.position = new Vector3(setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
        }
        transform.Translate (xspeed*0.14f, 0, 0,Space.World);

        if(GManager.instance.hit){
            //transform.position = new Vector3(GManager.instance.setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
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
