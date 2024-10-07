using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class Naming : MonoBehaviour
{
    [SerializeField] public InputField IF;
    [SerializeField] public Text txt;
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
    /// �v���C���[���m�菈��
    /// </summary>
    public void kakutei() {
        AkagonohateData.playerNmaeT = txt.text;
    }
}
