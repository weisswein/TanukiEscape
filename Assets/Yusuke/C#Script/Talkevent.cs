using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talkevent : MonoBehaviour
{
        [SerializeField] [Header("メッセージ（キャラ名）")] private string[] msgCaraName;
        [SerializeField] [Header("メッセージ（内容）")] private string[] msgContent;
        [SerializeField] GameObject[] charactersprite;
        [SerializeField] int[] finalturn;
        public static bool Talkable = true;
        int counter=0;
        int counter2=0;
        GameObject objCanvas = null;

        void Start()
        {
            objCanvas = gameObject.transform.Find("Canvas").gameObject;
            objCanvas.SetActive(false);
        }

        void Update()
        {
            if (Talkable && counter == 0)
            {
                counter++;
                StartCoroutine("ShowLog");
            }
        }

        IEnumerator ShowLog()
        {
            GameObject objCaraName = objCanvas.transform.Find("CaraName").gameObject;
            GameObject objContent = objCanvas.transform.Find("Content").gameObject;

            objCanvas.SetActive(true);

            for (int i = charactersprite.GetLowerBound(0); i <= charactersprite.GetUpperBound(0); i++){
                counter2=finalturn[i];
            }

            for (int i = msgCaraName.GetLowerBound(0); i <= msgCaraName.GetUpperBound(0); i++)
            {
                objCaraName.GetComponent<Text>().text = msgCaraName[i];
                objContent.GetComponent<Text>().text = msgContent[i];

                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                yield return null;
            }

            objCanvas.SetActive(false);
}
}
