using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


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

    [SerializeField] int pickUp1;  //ピックアップ中の衣装No①を格納
    [SerializeField] int pickUp2;  //ピックアップ中の衣装No②を格納

    //鍵数表示(ポップアップ用)
    public Text nowT;
    public Text afterT;

    //人足設定表示値
    public Text moT;
    public Text yuT;
    public Text niT;


    public void kaishi()
    {
        //テスト用
        //AkagonohateData.itemSyojisu[2] = 3;

        haikei.SetActive(true);
        popupBase2.SetActive(true);
        setteishita.SetActive(true);
        key.SetActive(true);
        hai.SetActive(true);
        iie.SetActive(true);
        haiBtn.SetActive(true);
        iieBtn.SetActive(true);
        sankaku.SetActive(true);

        nowT.text = AkagonohateData.itemSyojisu[2].ToString();
        int tmp = AkagonohateData.itemSyojisu[2]-1;
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

    public void Hai()
    {
        //設定中の人足値を変数にセット
        int moTMP = int.Parse(moT.text);
        int yuTMP = int.Parse(yuT.text);
        int niTMP = int.Parse(niT.text);

        //幕ごとの評価計算
        AkagonohateData akagoData = ScriptableObject.CreateInstance<AkagonohateData>(); //インスタンス化する
        //akagoData = FindObjectOfType<AkagonohateData>(); // インスタンス化
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
        //①各幕ごと
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
                    Debug.Log("kekkaBi = " + kekkaBi);
                    Debug.Log("kekkaHu = " + kekkaHu);

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
            kekkaBi += moTMP*5;
            kekkaHu += yuTMP*5;
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
            if (AkagonohateData.eventFlg == 1) {
                AkagonohateData.eventRuikei[1] += kekkaBi;
                AkagonohateData.eventRuikei[2] += kekkaHu;
            }
            Debug.Log("評価計算結果：" + kekkaBi +" "+ kekkaHu);
        }
        //②総合
        if (AkagonohateData.runwayRes[0] == 1 && AkagonohateData.runwayRes[1] == 1 && AkagonohateData.runwayRes[2] == 1)
        {
            AkagonohateData.runwayRes[3] = 1;
        }
        else if 
            (AkagonohateData.runwayRes[0] == 1 || AkagonohateData.runwayRes[0] == 2 && AkagonohateData.runwayRes[1] == 1 || AkagonohateData.runwayRes[1] == 2 && AkagonohateData.runwayRes[2] == 1 || AkagonohateData.runwayRes[2] == 2)
        {
            AkagonohateData.runwayRes[3] = 2;
        }
        else 
        {
            AkagonohateData.runwayRes[3] = 3;
        }

        //MVPキャラを判定
        //①各幕ごと
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
                    Debug.Log("hikaku = " + hikaku);
                }
            }
            switch (i)
            {
                case 0: AkagonohateData.runwayMVP[0] = MVP; break;
                case 1: AkagonohateData.runwayMVP[1] = MVP; break;
                case 2: AkagonohateData.runwayMVP[2] = MVP; break;
            }
        }

        //②総合
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


        //鍵の所持数を引く・上書き
        AkagonohateData.itemSyojisu[2]--;
        //人足アイテム所持数を引く・上書き
        AkagonohateData.itemSyojisu[3] -= moTMP;
        AkagonohateData.itemSyojisu[4] -= yuTMP;
        AkagonohateData.itemSyojisu[5] -= niTMP;
        AkagonohateData.moZen = moTMP;
        AkagonohateData.yuZen = yuTMP;
        AkagonohateData.niZen = niTMP;

        SceneManager.LoadScene("11Runway");
    }
}
