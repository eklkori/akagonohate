using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startKaiwa : MonoBehaviour
{
    private void Start()
    {
        //テスト用処理START
        AkagonohateData.datePt[0] = 1000;
        AkagonohateData.datePt[1] = 1000;
        //テスト用処理END
    }
    /// <summary>
    /// kyaraNoは0始まり
    /// </summary>
    int kyaraNo = AkagonohateData.tansakuKyara;
    public void startKaiwas()
    {
        kyaraNo = AkagonohateData.tansakuKyara;

        Debug.Log("kyaraNo=" + kyaraNo);
        switch (kyaraNo)
        {
            //kaiwaNoにシナリオラベルを格納
            case 0: AkagonohateData.kaiwaNo = "naokoK"; break;
            case 1: AkagonohateData.kaiwaNo = "yasukoK"; break;
            case 2: AkagonohateData.kaiwaNo = "yoshikoK"; break;
            case 3: AkagonohateData.kaiwaNo = "hidetaK"; break;
            case 4: AkagonohateData.kaiwaNo = "hideyaK"; break;
            case 5: AkagonohateData.kaiwaNo = "yasuoK"; break;
        }

        //親愛Ptの上書き：1日の初回のみ各キャラ5ずつ上がる
        //今日の日付取得
        DateTime localDate = DateTime.Now;
        DateTime day = localDate.Date;

        if (day != AkagonohateData.kaiwaRireki[kyaraNo])
        {
            Debug.Log(day);
            Debug.Log(AkagonohateData.kaiwaRireki[kyaraNo]);
            //獲得親愛Ptの計算(木俣への想いを反映させる)
            int shinaiTMP = 0;
            switch (AkagonohateData.kimata[kyaraNo])
            {
                case 1: shinaiTMP = 1; break;
                case 2: shinaiTMP = 3; break;
                case 3: shinaiTMP = 5; break;
            }
            AkagonohateData.shinaiPt[kyaraNo] += shinaiTMP;
            AkagonohateData.KshinaiPt[kyaraNo] = shinaiTMP;

            //初回フラグの更新
            AkagonohateData.KSyokaiFlg[kyaraNo] = 1;

            //会話履歴の上書き
            //1日ずつ配列要素を後ろにずらす
            for (int i = 3; i >= 0; i--)
            {
                AkagonohateData.kaiwaRireki[kyaraNo + i * 10] = AkagonohateData.kaiwaRireki[kyaraNo + i * 10 + 10];
            }
            //配列の0番台に今日の日付を格納
            AkagonohateData.kaiwaRireki[kyaraNo] = day;
        }
        else 
        {
            //初回フラグの更新
            AkagonohateData.KSyokaiFlg[kyaraNo] = 0;
        }

        Debug.Log(AkagonohateData.kaiwaNo);
        SceneManager.LoadScene("04Tutorial");
    }

    public void startMitsugu() {
        SceneManager.LoadScene("08Mitsugu");
    }

    /// <summary>
    /// デート開始処理
    /// </summary>
    public void startDate() {
        //シナリオラベルの作成
        string kyaraName = "";
        Debug.Log(AkagonohateData.dateCount[0]);
        Debug.Log(kyaraNo);
        string dateShinchoku = (AkagonohateData.dateCount[kyaraNo] +1).ToString();
        switch (kyaraNo)
        {
            case 0: kyaraName = "naoko"; break;
            case 1: kyaraName = "yasuko"; break;
            case 2: kyaraName = "yoshiko"; break;
            case 3: kyaraName = "hideta"; break;
            case 4: kyaraName = "hideya"; break;
            case 5: kyaraName = "yasuo"; break;
        }
        AkagonohateData.kaiwaNo = ("D" + kyaraName + dateShinchoku);

        //累計デート回数の上書き
        AkagonohateData.dateCount[kyaraNo]++;

        //デートPtの初期化
        AkagonohateData.datePt[kyaraNo] = 0;

        Debug.Log(AkagonohateData.kaiwaNo);
        SceneManager.LoadScene("04Tutorial");
    }
}
