using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static Utage.UtageEditorPrefs;
using System;

public class tansakuPopUp : MonoBehaviour
{
    //素材の定義
    [SerializeField] Text XXnoheyaT;
    [SerializeField] Text shinaiT;
    [SerializeField] Text dateShinchoku;
    [SerializeField] Text nextShinaiPt;
    [SerializeField] Text koChuTe;
    [SerializeField] GameObject kyaraPopUp;
    [SerializeField] GameObject PtBar;
    [SerializeField] GameObject[] kyaraImages;
    [SerializeField] GameObject dateBtn;
    [SerializeField] GameObject dateKanou;
    [SerializeField] GameObject nakanaoriBtn;
    [SerializeField] GameObject nakanaoriKanou;

    private void Start()
    {
        //戻るボタンの遷移先を操作
        AkagonohateData.maeScene = "05Home";
    }

    //-----表示系-----

    public void showKyaraPopUp(int kyara) {
        AkagonohateData.tansakuKyara = kyara;
        Debug.Log(AkagonohateData.tansakuKyara);

        //UI表示
        kyaraPopUp.SetActive(true);

        //タイトル文字「XXの部屋」の差し替え
        switch (kyara)
        {
            case 0: XXnoheyaT.text = "直　子　の　部　屋"; break;
            case 1: XXnoheyaT.text = "康　子　の　部　屋"; break;
            case 2: XXnoheyaT.text = "吉　子　の　部　屋"; break;
            case 3: XXnoheyaT.text = "秀　太　の　部　屋"; break;
            case 4: XXnoheyaT.text = "秀　也　の　部　屋"; break;
            case 5: XXnoheyaT.text = "康　男　の　部　屋"; break;
        }

        //キャラ画像の差し替え
        for (int i = 0; i < 6; i++) {
            if (i == kyara)
            {
                kyaraImages[i].SetActive(true);
            }
            else 
            {
                kyaraImages[i].SetActive(false);
            }
        }

        //デート・仲直りボタンの表示制御
        //※デートの基準値は仮で1000に設定(要検討)
        if (AkagonohateData.datePt[kyara] >= 1000)
        {
            if (AkagonohateData.dateCount[kyara] == 5 && AkagonohateData.dateShichoFlg[404 + kyara * 20] == 0)
            {
                AkagonohateData.nakanaoriFlg[kyara] = 1;
                AkagonohateData.dateFlg[kyara] = 0;
            }
            else
            {
                AkagonohateData.nakanaoriFlg[kyara] = 0;
                AkagonohateData.dateFlg[kyara] = 1;
            }
        }
        else 
        {
            AkagonohateData.dateFlg[kyara] = 0;
        }
        //デートフラグが1の場合
        if (AkagonohateData.dateFlg[kyara] == 1)
        {
            Debug.Log(AkagonohateData.dateFlg[kyara]);
            Debug.Log(AkagonohateData.datePt[kyara]);
            dateBtn.SetActive(true);
            dateKanou.SetActive(true);
        }
        else
        {
            Debug.Log("あ");
            dateBtn.SetActive(false);
            dateKanou.SetActive(false);
        }
        //仲直りデートフラグが1の場合
        if (AkagonohateData.nakanaoriFlg[kyara] == 1)
        {
            nakanaoriBtn.SetActive(true);
            nakanaoriKanou.SetActive(true);
        }
        else
        {
            nakanaoriBtn.SetActive(false);
            nakanaoriKanou.SetActive(false);
        }

        //親愛Lv(左上)差し替え
        shinaiT.text = AkagonohateData.shinaiLv[kyara].ToString();

        //デート進捗回数差し替え
        dateShinchoku.text = AkagonohateData.dateCount[kyara].ToString();

        //次の親愛Lvアップまでに必要な親愛Ptの上書き
        //基準値を計算(レベルアップごとに上がりづらくする設計にする)
        int kijyun = 50 + AkagonohateData.shinaiLv[kyara] * AkagonohateData.shinaiLv[kyara];
        if (kijyun <= AkagonohateData.shinaiPt[kyara]) {
            AkagonohateData.shinaiLv[kyara]++;
            AkagonohateData.shinaiPt[kyara] = AkagonohateData.shinaiPt[kyara] - kijyun;
            kijyun = 50 + AkagonohateData.shinaiLv[kyara] * AkagonohateData.shinaiLv[kyara];
        }
        nextShinaiPt.text = (kijyun - AkagonohateData.shinaiPt[kyara]).ToString();

        //親愛Ptバーの書き換え
        //プレイヤーLv・EXPバーの制御
          //float kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
          //if (kijyun <= AkagonohateData.exp)
          //{
          //    AkagonohateData.playerLvI++;
          //}
          //kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
        float par = AkagonohateData.shinaiPt[kyara] / kijyun;
        PtBar.GetComponent<Image>().fillAmount = par;

        //木俣への想い差し替え
        //→3日連続会話すると「中」、5日連続会話すると「高」に上がる
        //1日会話しないごとに1ランクずつ下がる
        int kimata = 0;

        //今日の日付取得
        DateTime localDate = DateTime.Now;
        DateTime day = localDate.Date;

        if (AkagonohateData.kaiwaRireki[kyara] != null) {
            //前回会話日からの経過日数を取得
            int sa = day.Subtract(AkagonohateData.kaiwaRireki[kyara]).Days;

            //日付計算用(期間："1日"を変数にセット)
            TimeSpan ts = new TimeSpan(1, 0, 0, 0);

            //ランクを上げる処理
            if (AkagonohateData.kaiwaRireki[kyara + 10] != null && AkagonohateData.kaiwaRireki[kyara + 20] != null)
            {
                //低→中
                if (AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 10] + ts && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 20] + ts * 2 && sa <= 1)
                {
                    kimata = 2;
                }
                if (AkagonohateData.kaiwaRireki[kyara + 30] != null && AkagonohateData.kaiwaRireki[kyara + 40] != null)
                {
                    //中→高
                    if (AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 10] + ts && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 20] + ts * 2 && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 30] + ts * 3 && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 40] + ts * 4 && sa <= 1)
                    {
                        kimata = 1;
                    }
                }
            }
            //ランクを下げる処理
            if (sa == 2)
            {
                kimata = 2;
            }
            else　if(sa >= 3)
            {
                kimata = 3;
            }
        }
        switch (kimata)
        {
            case 1: koChuTe.text = "高"; break;
            case 2: koChuTe.text = "中"; break;
            case 3: koChuTe.text = "低"; break;
        }

        //データを上書き
        AkagonohateData.kimata[kyara] = kimata;
    }


    //非表示系-------------

    /// <summary>
    /// ポップアップ一括非表示(共通)
    /// </summary>
    public void closePopup() {
        kyaraPopUp.SetActive(false);
    }

}
