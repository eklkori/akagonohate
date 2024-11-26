using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startKaiwa : MonoBehaviour
{
    //------------------------------------
    //会話・デート・貢ぐ開始時の処理を記載
    //
    //※親愛度確認画面からの処理はCshinaido3.csで実装済み
    //------------------------------------

    //日付取得
    DateTime localDate = DateTime.Now;
    DateTime today;
    private void Start()
    {
        //テスト用処理START
        AkagonohateData.datePt[0] = 1000;
        AkagonohateData.datePt[1] = 1000;
        //テスト用処理END

        //前画面をホーム画面に設定(戻るボタン押下時の設定)
        AkagonohateData.maeScene = "05Home";
    }

    /// <summary>
    /// kyaraNoは0始まり
    /// </summary>
    int kyaraNo = AkagonohateData.tansakuKyara;

    /// <summary>
    /// 会話開始処理
    /// </summary>
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
        if (today != AkagonohateData.kaiwaRireki[kyaraNo])
        {
            Debug.Log(today);
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
            AkagonohateData.kaiwaRireki[kyaraNo] = today;

            //※全キャラを通してその日初めての会話だった場合、日ごとの合算会話回数を初期化
            int tmp = 0;
            for (int i = 0; i < 6; i++) {
                if (AkagonohateData.kaiwaRireki[i] == today) {
                    tmp++;
                    break;
                }
            }
            if (tmp == 0) {
                AkagonohateData.countDay[0] = 0;
            }
            //※全キャラを通してその週初めての会話だった場合、週ごとの合算会話回数を初期化
            //今週の最初の日(月曜日)を取得
            DateTime dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
            int tmp2 = 0;
            for (int i = 0; i < 6; i++)
            {
                if (AkagonohateData.kaiwaRireki[i] >= dtLastMonday.Date)
                {
                    tmp2++;
                    break;
                }
            }
            if (tmp2 == 0)
            {
                AkagonohateData.countDay[2] = 0;
            }
        }
        else 
        {
            //初回フラグの更新
            AkagonohateData.KSyokaiFlg[kyaraNo] = 0;
        }

        //累計会話回数の上書き
        AkagonohateData.kaiwaCount[kyaraNo]++;

        //日ごとの合算会話回数の上書き
        AkagonohateData.countDay[0]++;

        //週ごとの合算会話回数の上書き
        AkagonohateData.countDay[2]++;

        Debug.Log(AkagonohateData.kaiwaNo);
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        AkagonohateData.maeScene = "06Tansaku";
        SceneManager.UnloadSceneAsync("06Tansaku");
    }

    public void startMitsugu() {
        SceneManager.LoadScene("08Mitsugu", LoadSceneMode.Additive);
        AkagonohateData.maeScene = "06Tansaku";
        SceneManager.UnloadSceneAsync("06Tansaku");
    }

    /// <summary>
    /// デート開始処理
    /// </summary>
    public void startDate() {
        //シナリオラベルの作成
        string kyaraName = "";
        Debug.Log(AkagonohateData.dateCount[kyaraNo] + 1);
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
        Debug.Log(kyaraNo);
        Debug.Log(AkagonohateData.datePt[kyaraNo]);

        Debug.Log(AkagonohateData.kaiwaNo);

        //画面遷移
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        AkagonohateData.maeScene = "06Tansaku";
        SceneManager.UnloadSceneAsync("06Tansaku");
    }

    void Update()
    {
        //当日日付の取得
        today = localDate.Date;
    }
}
