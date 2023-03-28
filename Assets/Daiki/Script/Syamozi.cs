using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syamozi : MonoBehaviour
{
    [Header("スピード")] public float speed = 3.0f;
    [Header("最大移動距離")] public float maxDistance = 20.0f;
    private string playerTag = "Player";
    private Rigidbody2D rb;
    private Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Destroy(this.gameObject);
        }
        Vector3 kero = new Vector3(0.5007837f,0.5007837f,0);
        gameObject.transform.localScale = kero;
        
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
            rb.MovePosition(transform.position -= transform.right * Time.deltaTime *speed);
        }
        
    }    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == playerTag)
        {
           Debug.Log("しゃもじゲット");
           GManager.instance.syamozi+=1;
           Destroy(this.gameObject);
        }
    }
}
