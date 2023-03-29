using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disguise : MonoBehaviour
{
    [Header("プレイヤーオブジェクト")] public GameObject playerObj1;
    [Header("プレイヤーオブジェクト")] public GameObject playerObj2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.LeftArrow)&&(!GManager.instance.disguiseR)&&(GManager.instance.cool)) {
            Debug.Log("変化");
            playerObj1.SetActive(false);
            playerObj2.SetActive(true);
            GManager.instance.disguiseR=true;
            GManager.instance.cool=false;
        }
        else if(!GManager.instance.disguiseR){
            playerObj1.SetActive(true);
            playerObj2.SetActive(false);
        }
        
    }
}
