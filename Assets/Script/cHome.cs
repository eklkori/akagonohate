using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class cHome : MonoBehaviour
{
    //※ホーム画面にのみ置いておきたい処理は基本このスクリプトに記載

    //キャラ立ち絵表示系
    [SerializeField] GameObject[] kyaraBtns;
    [SerializeField] Sprite[] kyaraImage;
    [SerializeField] Image kyaraTachie;

    //通知アイコン
    [SerializeField] GameObject tsuchiTask;

    //選択中枠
    [SerializeField] GameObject[] sentakuchu;

    //イベント遷移用ボタン
    [SerializeField] GameObject eventBtn;

    //日付取得
    DateTime localDate = DateTime.Now;
    DateTime today;
    DateTime dtLastMonday;
    void Start()
    {
        //テスト用処理START
        AkagonohateData.eventFlg = 1;
        for (int i = 0; i < 6; i++)//タスク(イベント)の数だけforで回す
        {
            AkagonohateData.tasseiFlgE[i] = 1;
        }
        //テスト用処理END
        today = localDate.Date;

        //イベント開催中ボタンの表示制御
        if (AkagonohateData.eventFlg == 1)
        {
            eventBtn.SetActive(true);
        }
        else
        {
            eventBtn.SetActive(false);
        }

        //パートナー(ホーム画面立ち絵)初期表示
        int kyaraNo = AkagonohateData.partnerNo;
        kyaraBtn(kyaraNo);

        //タスクの完了判定※達成フラグの上書きも実施　(完了タスクがあれば赤丸アイコンを表示)
        //赤丸アイコンの初期化
        tsuchiTask.SetActive(false);

        //達成フラグの初期化
        //今週の最初の日(月曜日)を取得
        dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
        Debug.Log("dtLastMonday "+dtLastMonday);
        Debug.Log("today " + today);
        //日課(1日の最初のみ)
        if (today != AkagonohateData.kaiwaRireki[0].Date && today != AkagonohateData.kaiwaRireki[1] && today != AkagonohateData.kaiwaRireki[2] && today != AkagonohateData.kaiwaRireki[3] && today != AkagonohateData.kaiwaRireki[4] && today != AkagonohateData.kaiwaRireki[5] && today != AkagonohateData.runwayRireki[0])
        {
            for (int i = 0; i < 6; i++)//タスク(日課)の数だけforで回す
            {
                AkagonohateData.tasseiFlgN[i] = 1;
            }
        }
        //週間(週の最初のみ)
        if (dtLastMonday >= AkagonohateData.kaiwaRireki[0] && dtLastMonday >= AkagonohateData.kaiwaRireki[1] && dtLastMonday >= AkagonohateData.kaiwaRireki[2] && dtLastMonday >= AkagonohateData.kaiwaRireki[3] && dtLastMonday >= AkagonohateData.kaiwaRireki[4] && dtLastMonday >= AkagonohateData.kaiwaRireki[5] && dtLastMonday >= AkagonohateData.runwayRireki[0])
            for (int i = 0; i < 9; i++)//タスク(週間)の数だけforで回す
        {
            AkagonohateData.tasseiFlgS[i] = 1;
        }
        //イベント(イベント期間のみ)
        if (AkagonohateData.eventFlg == 1)
        {
            for (int i = 0; i < 6; i++)//タスク(イベント)の数だけforで回す
            {
                AkagonohateData.tasseiFlgE[i] = 1;
            }
        }

        //会話回数の算出(日)
        int iconFlg = 0;
        int countDay = 0;
        int countWeek = 0;
        for (int i = 0; i < 6; i++)
        {
            //誰かの最終会話日が今日であれば、countDayTMPが1になるので次のif文を通る
            if (AkagonohateData.kaiwaRireki[i] == today.Date)
            {
                countDay++;
                break;
            }
        }
        if (countDay >= 1)
        {
            if (AkagonohateData.countDay[0] >= 1) 
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgN[0] != 2)
                {
                    AkagonohateData.tasseiFlgN[0] = 0;
                }
            }
            if (AkagonohateData.countDay[0] >= 3)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgN[1] != 2)
                {
                    AkagonohateData.tasseiFlgN[1] = 0;
                }
            }
            if (AkagonohateData.countDay[0] >= 6)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgN[2] != 2)
                {
                    AkagonohateData.tasseiFlgN[2] = 0;
                }
            }
        }
        //ランウェイ回数の算出(日)
        if (AkagonohateData.runwayRireki[0].Date == today.Date)
        {
            if (AkagonohateData.countDay[1] >= 1)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgN[3] != 2)
                {
                    AkagonohateData.tasseiFlgN[3] = 0;
                }
            }
            if (AkagonohateData.countDay[1] >= 5)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgN[4] != 2)
                {
                    AkagonohateData.tasseiFlgN[4] = 0;
                }
            }
            if (AkagonohateData.countDay[1] >= 10)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgN[5] != 2)
                {
                    AkagonohateData.tasseiFlgN[5] = 0;
                }
            }
        }

        //会話回数の算出(週)
        for (int i = 0; i < 6; i++)
        {
            //誰かの最終会話日が週初めの月曜以降であれば、countDayTMPが1になるので次のif文を通る
            if (AkagonohateData.kaiwaRireki[i].Date >= dtLastMonday.Date)
            {
                countWeek++;
                break;
            }
        }
        if (countWeek >= 1)
        {
            if (AkagonohateData.countDay[3] >= 10)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[0] != 2)
                {
                    AkagonohateData.tasseiFlgS[0] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 20)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[1] != 2)
                {
                    AkagonohateData.tasseiFlgS[1] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 30)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[2] != 2)
                {
                    AkagonohateData.tasseiFlgS[2] = 0;
                }
            }
        }

        //ランウェイ回数の算出(週)
        if (AkagonohateData.runwayRireki[0].Date >= dtLastMonday.Date)
        {
            if (AkagonohateData.countDay[3] >= 15)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[3] != 2)
                {
                    AkagonohateData.tasseiFlgS[3] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 25)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[4] != 2)
                {
                    AkagonohateData.tasseiFlgS[4] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 35)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[5] != 2)
                {
                    AkagonohateData.tasseiFlgS[5] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 50)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[6] != 2)
                {
                    AkagonohateData.tasseiFlgS[6] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 60)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[7] != 2)
                {
                    AkagonohateData.tasseiFlgS[7] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 70)
            {
                iconFlg++;
                if (AkagonohateData.tasseiFlgS[8] != 2)
                {
                    AkagonohateData.tasseiFlgS[8] = 0;
                }
            }
        }

        //赤丸通知を表示
        if (iconFlg != 0)
        {
            tsuchiTask.SetActive(true);
        }
        //for (int i = 0; i < 4; i++) {
        //if (countDayTMP[i] != 0) {
        //        tsuchiTask.SetActive(true);
        //        break;
        //    }
        //}
    }

    /// <summary>
    /// パートナー選択ボタン押下時の初期表示
    /// </summary>
    public void syokihyouji() {
        //衣装所持 / 未所持により表示を制御
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1)
            {
                kyaraBtns[i].SetActive(true);
            }
            else {
                kyaraBtns[i].SetActive(false);
            }
        }

        //選択中枠の表示
        //初期化
        for (int i = 0; i < 60; i++) {
            sentakuchu[i].SetActive(false);
        }
        //選択中衣装のみに枠を表示
        int syojiCount = -1;
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1) {
                syojiCount++;
            }
            if (AkagonohateData.partnerNo == AkagonohateData.isyoSyojiFlg[i]) {
                sentakuchu[syojiCount].SetActive(true);
                break;
            }
        }

    }

    /// <summary>
    /// キャラボタンが押されたときの処理
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void kyaraBtn(int kyaraNo)
    {
        //画像差し替え処理
        AkagonohateData.partnerNo = kyaraNo;
        kyaraTachie.sprite = kyaraImage[AkagonohateData.partnerNo];

        //サイズ変更
        RectTransform rectTransform = kyaraTachie.GetComponent<RectTransform>();
        int num = kyaraNo / 10;
        //transform.localScale = new Vector3(1400, 2227, 0);
        switch (num)
        {
            case 0: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1830, 1); break;
            case 1: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1850, 1); break;
            case 2: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1730, 1); break;
            case 3: kyaraTachie.rectTransform.sizeDelta  = new Vector3(1500, 1870, 1); break;
            case 4: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1980, 1); break;
            case 5: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1940, 1); break;
        }
        //サイズ変更(被り物などで個別設定が必要になる場合があればここに記載)

    }

    /// <summary>
    /// イベント時限定イベントボタンが押されたときの処理
    /// </summary>
    public void pushEventBtn()
    {
        SceneManager.LoadScene("20Event");
    }
    void Update()
    {
        //当日日付の取得
        today = localDate.Date;
        dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
    }
}
