using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UniMail;

public class sendMail : MonoBehaviour
{
    [SerializeField] InputField IF;
    [SerializeField] Text txt;
    [SerializeField] InputField IF2;
    [SerializeField] Text txt2;
    [SerializeField] GameObject otoiawaseText;
    [SerializeField] GameObject setsumeibun;
    [SerializeField] GameObject soushinBtn;
    [SerializeField] GameObject uketamawarimashita;
    [SerializeField] GameObject machigatteimasu;
    [SerializeField] GameObject popUpMenu;

    /// <summary>
    /// ���₢���킹�E�V���A���R�[�h���͂̊Ǘ�
    /// </summary>
    void Start()
    {
        IF = IF.GetComponent<InputField>();
        txt = txt.GetComponent<Text>();
        IF2 = IF2.GetComponent<InputField>();
        txt2 = txt2.GetComponent<Text>();
    }

    string text = "";
    string text2 = "";
    int btnFlg = 0;
    public void BtnFlg() {
        btnFlg = 0;
    }
    private void Update()
    {
        //���₢���킹�̏���
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
        //Debug.Log(text);

        //�V���A���R�[�h���͂̏���
        txt2.text = IF2.text;
        text2 = txt2.text;
    }

    /// <summary>
    /// ���M�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void sendmail()
    {
        Debug.Log(text);
        Mail.Send("8031edokorilove@gmail.com", "�y�g�q�̉ʂ��₢���킹�z���[�U�[ID�F", text);
        btnFlg++;
        IF.text = "";
        otoiawaseText.SetActive(false);
        setsumeibun.SetActive(false);
        uketamawarimashita.SetActive(true);
        soushinBtn.SetActive(false);
    }

    /// <summary>
    /// �V���A���R�[�h���͊���(�m��)�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void kakuteiBtn() {
        if (text2 == "" || text2.Length <= 6)
        {
            machigatteimasu.SetActive(true);
            Debug.Log(text2);
        }
        else
        {
            int icchiFlg = 0;
            for (int i = 0; i < 3; i++) //�V���A���R�[�h�̌���for������
            {
                if (AkagonohateData.serialCodes[i] == text2)
                {
                    AkagonohateData.serialCodes[i] = "";
                    icchiFlg++;
                    popUpMenu.GetComponent<menuBtn>().konyu(1001);
                    break;
                }
            }
            if (icchiFlg == 0)
            {
                machigatteimasu.SetActive(true);
            }
            Debug.Log(text2);
        }
    }
}
