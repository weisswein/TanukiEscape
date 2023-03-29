using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racoon_move : MonoBehaviour
{
    public float rotate_speed;//回転速度
    public float setp_x;//初期のx座標
    private bool push_flag;//キーを推したかどうか
    public AnimationCurve dashCurve;//速度変位
    private bool change=false;//色が変わっているかどうか
    private float hitTime;//ダメージ演出用のタイマー
    private int hitcount=0; //色の切り替え回数
    private float xspeed=0.0f; //キャラのx軸の速さ
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
        //切り替わったときに
        Vector3 posi = this.transform.position;
        //現在位置が基準位置より左なら初期化
        if(posi.x<=setp_x){
            GManager.instance.dash=false;
            xspeed=0.0f;
            GManager.instance.dashTime=0.0f;
            transform.position = new Vector3(setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
        }
        //違うなら元の位置を引き継ぐ
        else transform.position = new Vector3(GManager.instance.setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
    }

    // Update is called once per frame
    void Update()
    {
        //HPが0の時に攻撃やしゃもじをすり抜けるように
        if(GManager.instance.currentHp<1){
            //this.layer = 8;
        }

        //回転
        Transform myTransform = this.transform;
        myTransform.Rotate(0,0,-1.0f*(rotate_speed+xspeed*3),Space.World);
        Vector3 posi = this.transform.position;

        //スピードが0なら初期位置と記録
        if(xspeed!=0)GManager.instance.setp_x=posi.x;
        else GManager.instance.setp_x=setp_x;

        //上を押したら
        if (Input.GetKey (KeyCode.UpArrow)) {
            //上のレーンに移動
            if((!push_flag)&&(GManager.instance.lane_num<2)){
                GManager.instance.lane_num+=1;
                transform.position = new Vector3(GManager.instance.setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
                push_flag=true;
            }
            
        }
        //下を押したら
        else if (Input.GetKey (KeyCode.DownArrow)) {
            //下のレーンに移動
            if((!push_flag)&&(GManager.instance.lane_num>0)){
                GManager.instance.lane_num-=1;
                transform.position = new Vector3(GManager.instance.setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
                push_flag=true;
            }
            
        }
        //右を押したら
        else if (Input.GetKey (KeyCode.RightArrow)) {
            //ダッシュ状態に切り替え+念のために初期化
            if(!GManager.instance.dash){
                GManager.instance.dash=true;
                defaultPos = transform.position;
                xspeed=0.0f;
                GManager.instance.dashTime=0.0f;
            }      
        }
        else push_flag=false;

        //ダッシュ状態のとき
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

        //もしも右端に行ったら強制的に左に戻す
        if(posi.x>=9.05){
            xspeed=-1f;
            GManager.instance.dash=true;
        }
        //初期位置より左なら初期化
        else if(posi.x<setp_x){
            GManager.instance.dash=false;
            xspeed=0.0f;
            GManager.instance.dashTime=0.0f;
            transform.position = new Vector3(setp_x, GManager.instance.setp_y[GManager.instance.lane_num] ,0);
        }
        transform.Translate (xspeed*0.14f, 0, 0,Space.World);

        //攻撃が当たったとき
        if(GManager.instance.hit){
            //プレイヤーの色を変えてダメージ演出
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
