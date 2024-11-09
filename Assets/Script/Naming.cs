using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class Naming : MonoBehaviour
{
    [SerializeField] InputField IF;
    [SerializeField] Text txt;
    [SerializeField] GameObject kakuteiBtn;
    void Start()
    {
        IF = IF.GetComponent<InputField>();
        txt = txt.GetComponent<Text>();
    }

    public void Update()
    {
        kakuteiBtn.SetActive(false);
        txt.text = IF.text;
        int mojisu = txt.text.Length;
        if (mojisu!=0) {
            kakuteiBtn.SetActive(true);
        }
    }

    /// <summary>
    /// プレイヤー名確定処理
    /// </summary>
    public void kakutei() {
        AkagonohateData.playerNmaeT = txt.text;
    }
}
