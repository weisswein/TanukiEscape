using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabitt_attack : MonoBehaviour
{
     [Header("攻撃オブジェクト")] public GameObject attackObj;

     private Animator anim;
     private float timer;
     public float interval;

     // Start is called before the first frame update
     void Start()
     {
        Attack();
          /*anim = GetComponent<Animator>();
          if (anim == null || attackObj == null)
          {
              Debug.Log("設定が足りません");
              Destroy(this.gameObject);
          }
          else
          {
              attackObj.SetActive(false);
          }*/
     }

     // Update is called once per frame
     void Update()
     {
        if(timer > interval)
        {
            Attack();
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
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
