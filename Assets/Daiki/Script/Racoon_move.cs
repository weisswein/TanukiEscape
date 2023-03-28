using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racoon_move : MonoBehaviour
{
    public float rotate_speed;
    public float setp_x;
    public float[] setp_y;
    private int lane_num=0;
    private bool push_flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        //回転
        myTransform.Rotate(0,0,-1.0f*rotate_speed,Space.World);
        //
        if (Input.GetKey (KeyCode.UpArrow)) {
            if((!push_flag)&&(lane_num<2)){
                lane_num+=1;
                transform.position = new Vector3(setp_x, setp_y[lane_num] ,0);
                push_flag=true;
            }
            
        }
        else if (Input.GetKey (KeyCode.DownArrow)) {
            if((!push_flag)&&(lane_num>0)){
                lane_num-=1;
                transform.position = new Vector3(setp_x, setp_y[lane_num] ,0);
                push_flag=true;
            }
            
        }
        else push_flag=false;
    }
}
