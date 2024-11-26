using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShinaido2 : MonoBehaviour
{
    //もろもろの表示テキスト定義
    [SerializeField] Text nameT;
    [SerializeField] Text zokuseiT;
    [SerializeField] Text jyukubunT;
    [SerializeField] Text shinaidoT;
    [SerializeField] Text dateShinchokuT;
    [SerializeField] Text kaiwaT;
    [SerializeField] Text mitsugimonoT;

    //衣装の画像素材
    [SerializeField] GameObject naokoClose;
    [SerializeField] GameObject yasukoClose;
    [SerializeField] GameObject yoshikoClose;
    [SerializeField] GameObject hidetaClose;
    [SerializeField] GameObject hideyaClose;
    [SerializeField] GameObject yasuoClose;
    [SerializeField] GameObject[] mikaihous;
    [SerializeField] GameObject mikaihou1;
    [SerializeField] GameObject mikaihou2;
    [SerializeField] GameObject mikaihou3;
    [SerializeField] GameObject mikaihou4;
    [SerializeField] GameObject mikaihou5;
    [SerializeField] GameObject Tachie;
    [SerializeField] Image kyaraTachie;

    [SerializeField] Sprite[] kyaraImage;

    int kyara = AkagonohateData.shinaidoWho;
    void Start()
    {
        //戻るボタンの遷移先を操作
        AkagonohateData.maeScene = "16Shinaido1";

        //名前・衣装ボタンの表示
        if (kyara == 1) {
            //名前表示
            nameT.text = ("井伊直子");
            //衣装一覧表示
            naokoClose.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i].SetActive(true);
                }
            }
            //立ち絵表示
            for (int i = 0; i < 5; i++) {
                if (AkagonohateData.isyoSyojiFlg[i] == 1) {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }

        }
        if (kyara == 2)
        {
            nameT.text = ("徳川康子");
            yasukoClose.SetActive(true);
            for (int i = 10; i < 15; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-10].SetActive(true);
                }
            }
            //立ち絵表示
            for (int i = 10; i < 15; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 3)
        {
            nameT.text = ("松平吉子");
            yoshikoClose.SetActive(true);
            for (int i = 20; i < 25; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-20].SetActive(true);
                }
            }
            //立ち絵表示
            for (int i = 20; i < 25; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 4)
        {
            nameT.text = ("徳川秀太");
            hidetaClose.SetActive(true);
            for (int i = 30; i < 35; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-30].SetActive(true);
                }
            }
            //立ち絵表示
            for (int i = 30; i < 35; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 5)
        {
            nameT.text = ("結城秀也");
            hideyaClose.SetActive(true);
            for (int i = 40; i < 45; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-40].SetActive(true);
                }
            }
            //立ち絵表示
            for (int i = 40; i < 45; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 6)
        {
            nameT.text = ("榊原康男");
            yasuoClose.SetActive(true);
            for (int i = 50; i < 55; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-50].SetActive(true);
                }
            }
            //立ち絵表示
            for (int i = 50; i < 55; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
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
        int shinaiTMP = AkagonohateData.shinaiLv[kyara - 1];
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

    /// <summary>
    /// 所持衣装ボタン(画面右下)が押されたときの処理(立ち絵差し替え)
    /// </summary>
    /// <param name="isyouNo"></param>
    public void pushKyaraBtn(int isyouNo) {
        kyaraTachie.sprite = kyaraImage[isyouNo];
    }

    void Update()
    {
        
    }
}
