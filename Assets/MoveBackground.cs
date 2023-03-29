using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
[SerializeField] RectTransform Gb1;
[SerializeField] RectTransform Gb2;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gb1=Gb1.anchoredPosition;
        Vector3 gb2=Gb2.anchoredPosition;
        gb1 -= new Vector3(1,0,0);
        gb2 -= new Vector3(1,0,0);
        if(Gb1.anchoredPosition.x<-912) gb1 = new Vector3(1060,0,0);
        if(Gb2.anchoredPosition.x<-912) gb2 = new Vector3(1060,0,0);
        Gb1.anchoredPosition=gb1;
        Gb2.anchoredPosition=gb2;
        
    }
}
