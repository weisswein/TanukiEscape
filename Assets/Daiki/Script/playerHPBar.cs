using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        Debug.Log("Start currentHp : " + GManager.instance.currentHp);
    }
    //Enemyタグのオブジェクトに触れると発動
    
    void Update()
    {
        Debug.Log("After currentHp : " + GManager.instance.currentHp);

        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //(float)をつけてfloatの変数として振舞わせる。
        slider.value = (float)GManager.instance.currentHp / (float)GManager.instance.maxHp; ;
        Debug.Log("slider.value : " + slider.value);
    }
}
