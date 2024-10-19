using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShinaido2 : MonoBehaviour
{
    //もろもろの表示テキスト定義
    public Text nameT;
    public Text zokuseiT;
    public Text jyukubunT;
    public Text shinaidoT;
    public Text dateShinchokuT;
    public Text kaiwaT;
    public Text mitsugimonoT;

    //衣装の画像素材
    [SerializeField] GameObject naokoClose;
    [SerializeField] GameObject yasukoClose;
    [SerializeField] GameObject yoshikoClose;
    [SerializeField] GameObject hidetaClose;
    [SerializeField] GameObject hideyaClose;
    [SerializeField] GameObject yasuoClose;
    [SerializeField] GameObject mikaihou1;
    [SerializeField] GameObject mikaihou2;
    [SerializeField] GameObject mikaihou3;
    [SerializeField] GameObject mikaihou4;
    [SerializeField] GameObject mikaihou5;

    int kyara = AkagonohateData.shinaidoWho;
    void Start()
    {
        //名前・衣装ボタンの表示
        if (kyara == 1) {
            nameT.text = ("井伊直子");
            naokoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[0] == 0) {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[1] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[2] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[3] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[4] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 2)
        {
            nameT.text = ("徳川康子");
            yasukoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[10] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[11] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[12] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[13] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[14] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 3)
        {
            nameT.text = ("松平吉子");
            yoshikoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[20] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[21] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[22] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[23] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[24] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 4)
        {
            nameT.text = ("徳川秀太");
            hidetaClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[30] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[31] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[32] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[33] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[34] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 5)
        {
            nameT.text = ("結城秀也");
            hideyaClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[40] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[41] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[42] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[43] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[44] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 6)
        {
            nameT.text = ("榊原康男");
            yasuoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[50] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[51] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[52] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[53] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[54] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }

        //属性の表示
        if (kyara == 1 || kyara == 6) {
            zokuseiT.text = ("属性：徳川財閥上級使用人");
        }
        if (kyara == 3 || kyara == 4)
        {
            zokuseiT.text = ("属性：者ノ富学園高等部(生徒)");
        }
        if (kyara == 5)
        {
            zokuseiT.text = ("属性：者ノ富学園大学(学生)");
        }
        if (kyara == 2)
        {
            zokuseiT.text = ("属性：徳川財閥総裁");
        }

        //住区分の表示
        if (kyara == 1 || kyara == 2 || kyara == 3 || kyara == 4)
        {
            jyukubunT.text = ("住区分：屋敷内");
        }
        else {
            jyukubunT.text = ("住区分：屋敷外");
        }

        //親愛Lvの表示
        int shinaiTMP = AkagonohateData.shinaido[kyara - 1];
        shinaidoT.text = ("現在の親愛Lv　　" + shinaiTMP);

        //デート進捗の表示
        int dateTMP = AkagonohateData.dateCount[kyara - 1];
        dateShinchokuT.text = ("デート進捗　　" + dateTMP + "回");

        //累計会話回数の表示
        int kaiwaTMP = AkagonohateData.kaiwaCount[kyara - 1];
        kaiwaT.text = ("累計会話回数　　" + kaiwaTMP + "回");

        //累計貢物個数の表示
        int mitsugiTMP = AkagonohateData.mitsugiCount[kyara - 1];
        mitsugimonoT.text = ("累計貢物個数　　" + mitsugiTMP + "個");
    }


    void Update()
    {
        
    }
}
