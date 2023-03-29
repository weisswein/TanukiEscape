using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_syamozi : MonoBehaviour
{
    private Text syamoziText;
    // Start is called before the first frame update
    void Start()
    {
        syamoziText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        syamoziText.text = ""+GManager.instance.syamozi;
        
    }
}
