using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;


public class goRunway : MonoBehaviour
{
    [SerializeField] GameObject kaishiBtn;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject popupBase2;
    [SerializeField] GameObject setteishita;
    [SerializeField] GameObject key;
    [SerializeField] GameObject hai;
    [SerializeField] GameObject hai2;
    [SerializeField] GameObject iie;
    [SerializeField] GameObject sankaku;
    [SerializeField] GameObject haiBtn;
    [SerializeField] GameObject hai2Btn;
    [SerializeField] GameObject iieBtn;
    [SerializeField] GameObject imasugu;
    [SerializeField] GameObject tarimasen;
    [SerializeField] GameObject now;
    [SerializeField] GameObject after;

    [SerializeField] int pickUp1;  //ピックアップ中の衣装No�@を格納
    [SerializeField] int pickUp2;  //ピックアップ中の衣装No�Aを格納

    //鍵数表示(ポップアップ用)
    [SerializeField] Text nowT;
    [SerializeField] Text afterT;

    //人足設定表示値
    [SerializeField] Text moT;
    [SerializeField] Text yuT;
    [SerializeField] Text niT;

    //日付取得
    DateTime localDate = DateTime.Now;
    DateTime today;

    private void Start()
    {
        
    }

    /// <summary>
    /// ランウェイ前のポップアップ表示
    /// </summary>
    public void kaishi()
    {
        //テスト用
        //AkagonohateData.itemSyojisu[2] = 3;
        //テスト用処理END

        haikei.SetActive(true);
        popupBase2.SetActive(true);
        setteishita.SetActive(true);
        key.SetActive(true);
        hai.SetActive(true);
        iie.SetActive(true);
        haiBtn.SetActive(true);
        iieBtn.SetActive(true);
        sankaku.SetActive(true);

        nowT.text = (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]).ToString();
        int tmp = AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] - 1;
        afterT.text = tmp.ToString();

        now.SetActive(true);
        after.SetActive(true);

        if (tmp < 0) {
            setteishita.SetActive(false);
            key.SetActive(false);
            hai.SetActive(false);
            iie.SetActive(false);
            sankaku.SetActive(false);
            hai2.SetActive(true);
            imasugu.SetActive(true);
            hai2Btn.SetActive(true);
            tarimasen.SetActive(true);
            now.SetActive(false);
            after.SetActive(false);
        }
    }

    private AkagonohateData akagoData;

    /// <summary>
    /// ランウェイの開始
    /// </summary>
    public void Hai()
    {
        //DBの値取得
        AkagonohateData akagoData = ScriptableObject.CreateInstance<AkagonohateData>(); //インスタンス化する
        int[] bi = akagoData.GetBi;
        int[] hu = akagoData.GetHu;

        //設定中の人足値を変数にセット
        int moTMP = int.Parse(moT.text);
        int yuTMP = int.Parse(yuT.text);
        int niTMP = int.Parse(niT.text);

        //評価計算処理
        hyouka(moTMP, yuTMP, niTMP);

        //MVPキャラを判定
        //�@各幕ごと
        int forCount = 0;
        for (int i = 0; i < 3; i++) {
            switch (i)
            {
                case 0: forCount = 0; break;
                case 1: forCount = 8; break;
                case 2: forCount = 16; break;
            }
            int MVP = -1;
            int hikakuTMP = -1;
            for (int j = forCount; j < forCount + 8; j++)
            {
                if (AkagonohateData.runner[j] != -1)
                {
                    int hikaku = bi[AkagonohateData.runner[j]] + hu[AkagonohateData.runner[j]];
                    //レア度の違いによる差分計算処理(イベント時のみ？)
                    if (AkagonohateData.eventFlg == 1)
                    {
                        if (AkagonohateData.runner[j] % 10 == 0 || AkagonohateData.runner[j] % 10 == 1)
                        {
                            hikaku += 1;
                        }
                        else if (AkagonohateData.runner[j] % 10 == 2 || AkagonohateData.runner[j] % 10 == 3)
                        {
                            hikaku += 2;
                        }
                        else
                        {
                            //星3：通常は12、ピックアップ衣装は30
                            if (AkagonohateData.runner[j] == pickUp1 || AkagonohateData.runner[j] == pickUp2)
                            {
                                hikaku += 30;
                            }
                            else
                            {
                                hikaku += 12;
                            }
                        }
                    }
                    if (hikakuTMP < hikaku) {
                        MVP = AkagonohateData.runner[j];
                        hikakuTMP = hikaku;
                    }
                    //Debug.Log("hikaku = " + hikaku);
                }
            }
            switch (i)
            {
                case 0: AkagonohateData.runwayMVP[0] = MVP; break;
                case 1: AkagonohateData.runwayMVP[1] = MVP; break;
                case 2: AkagonohateData.runwayMVP[2] = MVP; break;
            }
        }

        //�A総合
        //重複チェック
        int[] chofukuCheck = new int[24];
        for (int i = 0; i < 24; i++) {
            if (AkagonohateData.runner[i] != -1) {
                for (int j = 0; j <= i; j++) 
                {
                    if (AkagonohateData.runner[i] == AkagonohateData.runner[j]) {
                        chofukuCheck[i]++;
                    }
                }
            }
        }
        //全ランナーのステータス合計値を計算
        int[] totalHikaku = new int[24];
        for (int i = 0; i < 24; i++)
        {
            if (AkagonohateData.runner[i] != -1)
            {
                totalHikaku[i] = bi[AkagonohateData.runner[i]] + hu[AkagonohateData.runner[i]];
                //レア度の違いによる差分計算処理(イベント時のみ？)
                if (AkagonohateData.eventFlg == 1)
                {
                    if (AkagonohateData.runner[i] % 10 == 0 || AkagonohateData.runner[i] % 10 == 1)
                    {
                        totalHikaku[i] += 1;
                    }
                    else if (AkagonohateData.runner[i] % 10 == 2 || AkagonohateData.runner[i] % 10 == 3)
                    {
                        totalHikaku[i] += 2;
                    }
                    else
                    {
                        //星3：通常は12、ピックアップ衣装は30
                        if (AkagonohateData.runner[i] == pickUp1 || AkagonohateData.runner[i] == pickUp2)
                        {
                            totalHikaku[i] += 30;
                        }
                        else
                        {
                            totalHikaku[i] += 12;
                        }
                    }
                }
                totalHikaku[i] *= chofukuCheck[i];
            }
        }
        //一番ステータス合計値の高いキャラを総合MVPに選出
        int kakunin = totalHikaku.Max();
        for (int i = 0; i < 24; i++) {
            if (totalHikaku[i] == kakunin) {
                AkagonohateData.runwayMVP[3] = AkagonohateData.runner[i];
                break;
            }
        }
        //MVPキャラ判定END

        //獲得親愛度・獲得デートPtを計算
        //�@獲得親愛度：ランナー2人ごとに+1(奇数の場合は切り捨て)
        //変数の初期化
        for (int i = 0; i < 6; i++)
        {
            AkagonohateData.KshinaiPt[i] = 0;
        }
        //計算
        for (int i = 0; i < 24; i++)
        {
            if (AkagonohateData.runner[i] != -1)
            {
                int keisan = AkagonohateData.runner[i] / 10;
                switch (keisan)
                {
                    case 0: AkagonohateData.KshinaiPt[0]++; break;
                    case 1: AkagonohateData.KshinaiPt[1]++; break;
                    case 2: AkagonohateData.KshinaiPt[2]++; break;
                    case 3: AkagonohateData.KshinaiPt[3]++; break;
                    case 4: AkagonohateData.KshinaiPt[4]++; break;
                    case 5: AkagonohateData.KshinaiPt[5]++; break;
                }
            }
        }
        //多すぎるので1/2する処理　＋親愛Ptデータに加算
        for (int i = 0; i < 6; i++)
        {
            AkagonohateData.KshinaiPt[i] = AkagonohateData.KshinaiPt[i]/2;
            AkagonohateData.shinaiPt[i] += AkagonohateData.KshinaiPt[i];
        }

        //�A獲得デートPt：
        //(美しさ＋ユーモア＋イベント特攻)*ランウェイ総合評価(優：3、良：1.5、可：0.7)を8*3=24枠分　(要検討)
        //※各キャラごとに分けて加算
        //※もぎり・誘導員で上乗せされた分は、1個につき5ずつ加算
        //変数の初期化
        for (int i = 0; i < 6; i++)
        {
            AkagonohateData.KdatePt[i] = 0;
        }
        //計算
        for (int i = 0; i < 24; i++)
        {
            int Event = 0;
            int res = 0;
            int tmp = 0;
            //イベント特攻ステータスの計算(レア度により分岐) ※イベント時のみ
            if (AkagonohateData.runner[i] != -1)
            {
                if (AkagonohateData.eventFlg == 1)
                {
                    int keisan = AkagonohateData.runner[i] % 10;
                    if (keisan == 0 || keisan == 1)
                    {
                        Event = 1;
                    }
                    else if (keisan == 2 || keisan == 3)
                    {
                        Event = 2;
                    }
                    else if (AkagonohateData.runner[i] == pickUp1 || AkagonohateData.runner[i] == pickUp2)
                    {
                        Event = 30;
                    }
                    else
                    {
                        Event = 12;
                    }
                }
                //Debug.Log(AkagonohateData.runner[i]);
                //Debug.Log("bi=" + bi[AkagonohateData.runner[i]] + "hu=" + hu[AkagonohateData.runner[i]]);
                res = (bi[AkagonohateData.runner[i]] + hu[AkagonohateData.runner[i]] + Event);
                switch (AkagonohateData.runwayRes[3])
                {
                    case 1: tmp = res * 3; break;
                    case 2: tmp = res * 15 / 10; break;
                    case 3: tmp = res * 7 / 10; break;
                }
                //キャラごとに振り分け
                int keisan2 = AkagonohateData.runner[i] / 10;
                switch (keisan2)
                {
                    case 0: AkagonohateData.KdatePt[0] += tmp; break;
                    case 1: AkagonohateData.KdatePt[1] += tmp; break;
                    case 2: AkagonohateData.KdatePt[2] += tmp; break;
                    case 3: AkagonohateData.KdatePt[3] += tmp; break;
                    case 4: AkagonohateData.KdatePt[4] += tmp; break;
                    case 5: AkagonohateData.KdatePt[5] += tmp; break;
                }
            }
        }
        //人足分を加算　※設定されているキャラにのみ
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 24; j++) {
                Debug.Log("AkagonohateData.runner[j]=" + AkagonohateData.runner[j]+"  i="+i);
                int tmp = AkagonohateData.runner[j] / 10;
                Debug.Log(tmp);
                if (tmp == i && AkagonohateData.runner[j] != -1) {
                    Debug.Log("あ　"+moTMP * 5);
                    Debug.Log(AkagonohateData.KdatePt[i]+" moTMP="+moTMP+" yuTMP="+yuTMP);
                    AkagonohateData.KdatePt[i] += moTMP * 5;
                    AkagonohateData.KdatePt[i] += yuTMP * 5;
                    //Debug.Log(AkagonohateData.KdatePt[i]);
                    break;
                }
            }
        }

        //獲得銭を上書き
        AkagonohateData.KItem[0] = 0;
        for (int i = 0; i < 6; i++) {
            AkagonohateData.KItem[0] += AkagonohateData.KdatePt[i];
        }
        //獲得後の銭総額が9999999(上限)を超える場合、減算
        if (AkagonohateData.itemSyojisu[0] + AkagonohateData.KItem[0] > 9999999) {
            AkagonohateData.KItem[0] = 9999999 - AkagonohateData.itemSyojisu[0];
        }
        //所持銭に加算
        AkagonohateData.itemSyojisu[0] += AkagonohateData.KItem[0];

        //人足ボーナス値(人足によって割り増しされたデートPtの合計値)の上書き
        AkagonohateData.KItem[3] = moTMP;
        AkagonohateData.KItem[4] = yuTMP;
        AkagonohateData.KItem[5] = niTMP;
        Debug.Log(AkagonohateData.KItem[3] + " " + AkagonohateData.KItem[4] + " " + AkagonohateData.KItem[5]);

        //鍵の所持数を引く・上書き
        AkagonohateData.itemSyojisu[2]--;
        //人足アイテム所持数を引く・上書き
        AkagonohateData.itemSyojisu[3] -= moTMP;
        AkagonohateData.itemSyojisu[4] -= yuTMP;
        AkagonohateData.itemSyojisu[5] -= niTMP;
        AkagonohateData.moZen = moTMP;
        AkagonohateData.yuZen = yuTMP;
        AkagonohateData.niZen = niTMP;

        //鍵の回復カウントが始まる場合、鍵の消費開始時間を上書き
        TimeSpan sa = today - AkagonohateData.runwayRireki[1];
        TimeSpan kijyun = new TimeSpan(0, 10, 0, 0);
        TimeSpan hour = new TimeSpan(0, 2, 0, 0);
        if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] >= 4)
        {
            //鍵が全回復しているとき
            AkagonohateData.runwayRireki[1] = today;
        }
        else
        {
            //全回復する前に鍵が消費された場合を想定
            if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] == 3){
                kijyun -= hour * 4;
            }
            else if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] == 2)
            {
                kijyun -= hour * 3;
            }
            else if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] == 1)
            {
                kijyun -= hour * 2;
            }
            else if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] == 0)
            {
                kijyun -= hour * 1;
            }
            //基準より差が大きい場合は鍵の全回復前に消費しているので、runwayRireki[1]を2時間巻き戻して調整する
            if (sa > kijyun) {
                AkagonohateData.runwayRireki[1] -= hour;
            }
        }

        //報酬付与のためのランウェイ累計回数の上書き処理
        //その日初めてのランウェイの場合、変数の初期化
        if (AkagonohateData.runwayRireki[0].Date != today.Date) {
            AkagonohateData.countDay[1] = 0;
        }
        AkagonohateData.countDay[1]++;
        //その週初めてのランウェイの場合、変数の初期化
        //今週の最初の日(月曜日)を取得
        DateTime dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
        if (dtLastMonday <= today)
        {
            AkagonohateData.countDay[3] = 0;
        }
        AkagonohateData.countDay[3]++;

        //最終ランウェイ履歴の上書き
        AkagonohateData.runwayRireki[0] = today;

        SceneManager.LoadScene("11Runway", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("10RunwaySet");
    }

    /// <summary>
    /// 評価計算(幕ごと＋総合)
    /// </summary>
    /// <param name="moTMP"></param>
    /// <param name="yuTMP"></param>
    /// <param name="niTMP"></param>
    public void hyouka(int moTMP,int yuTMP,int niTMP) {
        //DBの値取得
        AkagonohateData akagoData = ScriptableObject.CreateInstance<AkagonohateData>(); //インスタンス化する
        int[] bi = akagoData.GetBi;
        int[] hu = akagoData.GetHu;
        int kijyunBi = 0;
        int kijyunHu = 0;

        //優良可の判断基準値を設定(要検討)
        switch (AkagonohateData.basyo)
        {
            case 1: kijyunBi = 30; kijyunHu = 30; break;
            case 2: kijyunBi = 70; kijyunHu = 70; break;
            case 3: kijyunBi = 100; kijyunHu = 50; break;
            case 4: kijyunBi = 60; kijyunHu = 120; break;
            case 5: kijyunBi = 140; kijyunHu = 140; break;
            case 6: kijyunBi = 200; kijyunHu = 100; break;
            case 7: kijyunBi = 120; kijyunHu = 200; break;
            case 8: kijyunBi = 170; kijyunHu = 170; break;
            case 9: kijyunBi = 250; kijyunHu = 100; break;
        }
        //優良可の判定
        //�@各幕ごと
        int forCount = 0;
        for (int i = 0; i < 3; i++)
        {
            int kekkaBi = 0;
            int kekkaHu = 0;
            switch (i)
            {
                case 0: forCount = 0; break;
                case 1: forCount = 8; break;
                case 2: forCount = 16; break;
            }
            for (int j = forCount; j < forCount + 8; j++)
            {
                if (AkagonohateData.runner[j] != -1)
                {
                    kekkaBi += bi[AkagonohateData.runner[j]];
                    kekkaHu += hu[AkagonohateData.runner[j]];
                    //Debug.Log("kekkaBi = " + kekkaBi);
                    //Debug.Log("kekkaHu = " + kekkaHu);

                    //親愛Lvの分1ずつ上乗せ
                    int tmp = AkagonohateData.runner[j] / 10;
                    switch (tmp)
                    {
                        case 0: kekkaBi += AkagonohateData.shinaiLv[0]; kekkaHu += AkagonohateData.shinaiLv[0]; break;
                        case 1: kekkaBi += AkagonohateData.shinaiLv[1]; kekkaHu += AkagonohateData.shinaiLv[1]; break;
                        case 2: kekkaBi += AkagonohateData.shinaiLv[2]; kekkaHu += AkagonohateData.shinaiLv[2]; break;
                        case 3: kekkaBi += AkagonohateData.shinaiLv[3]; kekkaHu += AkagonohateData.shinaiLv[3]; break;
                        case 4: kekkaBi += AkagonohateData.shinaiLv[4]; kekkaHu += AkagonohateData.shinaiLv[4]; break;
                        case 5: kekkaBi += AkagonohateData.shinaiLv[5]; kekkaHu += AkagonohateData.shinaiLv[5]; break;
                    }
                }
            }
            //人足設定値を反映
            kekkaBi += moTMP * 5;
            kekkaHu += yuTMP * 5;
            //判定処理
            if (kijyunBi <= kekkaBi && kijyunHu <= kekkaHu)
            {
                AkagonohateData.runwayRes[i] = 1;
            }
            else if (kijyunBi * 85 / 100 <= kekkaBi && kijyunHu * 85 / 100 <= kekkaHu)
            {
                AkagonohateData.runwayRes[i] = 2;
            }
            else
            {
                AkagonohateData.runwayRes[i] = 3;
            }
            //※イベント時のみ
            //美しさ・ユーモア性の累計獲得ポイントに加算
            if (AkagonohateData.eventFlg == 1)
            {
                AkagonohateData.eventRuikei[1] += kekkaBi;
                AkagonohateData.eventRuikei[2] += kekkaHu;
            }
            //Debug.Log("評価計算結果：" + kekkaBi +" "+ kekkaHu);
        }
        //�A総合
        if (AkagonohateData.runwayRes[0] == 1 && AkagonohateData.runwayRes[1] == 1 && AkagonohateData.runwayRes[2] == 1)
        {
            AkagonohateData.runwayRes[3] = 1;
        }
        else if
            (AkagonohateData.runwayRes[0] != 3 && AkagonohateData.runwayRes[1] != 3 && AkagonohateData.runwayRes[2] != 3)
        {
            AkagonohateData.runwayRes[3] = 2;
        }
        else
        {
            AkagonohateData.runwayRes[3] = 3;
        }
    }

    private void Update()
    {
        //当日日時の取得
        today = localDate;
    }
}
