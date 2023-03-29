using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireM : MonoBehaviour
{
    [Header("最大移動距離")] public float maxDistance = 2.0f;
    private Rigidbody2D rb;
    private Vector3 defaultPos;
    public float change=1.3f;
    private int mH;
    private int mV;
    private string playerTag = "Player";
    private bool move=false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Destroy(this.gameObject);
        }
        Vector3 kero = new Vector3(-0.2690541f,0.26659f,0.2678221f);
        gameObject.transform.localScale = kero;
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float d = Vector3.Distance(transform.position,defaultPos);
        //最大移動距離を超えている
        if (d > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            rb.MovePosition(transform.position -= transform.up * Time.deltaTime * GManager.instance.speed*0.35f);
            rb.MovePosition(transform.position += transform.right * Time.deltaTime *GManager.instance.speed);
        }
        if ((d > change)&&!move){ 
            int ran=Random.Range(0, 3);
            Vector3 posi = this.transform.position;
            if((int)posi.y==(int)GManager.instance.setp_y[ran]) ran=(ran+1)%3;
            transform.position = new Vector3(posi.x, GManager.instance.setp_y[ran] ,0);
            move=true;
        }
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == playerTag)
        {
           Destroy(this.gameObject);
           if(!GManager.instance.hit&&!GManager.instance.disguiseR){
                if(GManager.instance.currentHp<1){
                    Debug.Log("ゲームオーバー");
                } 
                //現在のHPからダメージを引く
                GManager.instance.currentHp -= 1;
                GManager.instance.hit=true;
           }
        }
    }
}
