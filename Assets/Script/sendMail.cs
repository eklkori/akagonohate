using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UniMail;

public class sendMail : MonoBehaviour
{
    [SerializeField] public InputField IF;
    [SerializeField] public Text txt;
    [SerializeField] GameObject otoiawaseText;
    [SerializeField] GameObject setsumeibun;
    [SerializeField] GameObject soushinBtn;
    [SerializeField] GameObject uketamawarimashita;

    /// <summary>
    /// お問い合わせの管理
    /// </summary>
    void Start()
    {
        IF = IF.GetComponent<InputField>();
        txt = txt.GetComponent<Text>();
    }

    string text = "";
    int btnFlg = 0;
    public void BtnFlg() {
        btnFlg = 0;
    }
    private void Update()
    {
        txt.text = IF.text;
        text = txt.text;
        int mojisu = txt.text.Length;
        if (btnFlg == 0)
        {
            if (mojisu >= 10)
            {
                soushinBtn.SetActive(true);
            }
            else
            {
                soushinBtn.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 送信ボタンが押されたときの処理
    /// </summary>
    public void sendmail()
    {
        Debug.Log(text);
        Mail.Send("8031edokorilove@gmail.com", "【紅子の果お問い合わせ】ユーザーID：", text);
        btnFlg++;
        IF.text = "";
        otoiawaseText.SetActive(false);
        setsumeibun.SetActive(false);
        uketamawarimashita.SetActive(true);
        soushinBtn.SetActive(false);
    }
}
