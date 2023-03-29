using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHPBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
    }
    //Enemyタグのオブジェクトに触れると発動
    
    void Update()
    {
        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //(float)をつけてfloatの変数として振舞わせる。
        slider.value = (float)GManager.instance.currentHp / (float)GManager.instance.maxHp;
    }
}
