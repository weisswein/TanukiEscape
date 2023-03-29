using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
int score=0;
Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        this.scoretext=this.GetComponent<Text>();
        this.scoretext.text="Score: "+score.ToString()+" “_";
    }
}
