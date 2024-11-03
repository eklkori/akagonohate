using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
        }
    }

    private AkagonohateData akagoData;

    public void Hai()
    {
        //幕ごとの評価計算
        akagoData = FindObjectOfType<AkagonohateData>(); // インスタンス化
        int[] bi = akagoData.GetBi;
        int[] hu = akagoData.GetBi;
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
        int kekkaBi = 0;
        int kekkaHu = 0;
        int forCount = 0;
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0: forCount = 0; break;
                case 1: forCount = 8; break;
                case 2: forCount = 16; break;
            }
            for (int j = forCount; j < forCount + 8; j++)
            {
                kekkaBi += bi[j];
                kekkaHu += hu[j];
            }
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
                if (AkagonohateData.runner[forCount] != -1) 
                {
                    int hikaku = bi[AkagonohateData.runner[forCount]] + hu[AkagonohateData.runner[forCount]];
                    //レア度の違いによる差分計算処理(イベント時のみ？)
                    if (AkagonohateData.eventFlg == 1)
                    {
                        if (AkagonohateData.runner[forCount] % 10 == 0 || AkagonohateData.runner[forCount] % 10 == 1)
                        {
                            hikaku += 1;
                        }
                        else if (AkagonohateData.runner[forCount] % 10 == 2 || AkagonohateData.runner[forCount] % 10 == 3)
                        {
                            hikaku += 2;
                        }
                        else
                        {
                            //星3：通常は12、ピックアップ衣装は30
                            if (AkagonohateData.runner[forCount] == pickUp1 || AkagonohateData.runner[forCount] == pickUp2)
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
                        MVP = AkagonohateData.runner[forCount];
                        hikakuTMP = hikaku;
                    }
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
        int[] totalHikakuTMP = new int[24];
        for (int i = 0; i < 24; i++)
        {
            if (AkagonohateData.runner[i] != -1)
            {
                totalHikakuTMP[i] = bi[AkagonohateData.runner[i]] + hu[AkagonohateData.runner[i]];
                //レア度の違いによる差分計算処理(イベント時のみ？)
                if (AkagonohateData.eventFlg == 1)
                {
                    if (AkagonohateData.runner[forCount] % 10 == 0 || AkagonohateData.runner[forCount] % 10 == 1)
                    {
                        totalHikakuTMP[i] += 1;
                    }
                    else if (AkagonohateData.runner[forCount] % 10 == 2 || AkagonohateData.runner[forCount] % 10 == 3)
                    {
                        totalHikakuTMP[i] += 2;
                    }
                    else
                    {
                        //星3：通常は12、ピックアップ衣装は30
                        if (AkagonohateData.runner[forCount] == pickUp1 || AkagonohateData.runner[forCount] == pickUp2)
                        {
                            totalHikakuTMP[i] += 30;
                        }
                        else
                        {
                            totalHikakuTMP[i] += 12;
                        }
                    }
                }

            }
        }
        //重複チェック


        //鍵の所持数を引く・上書き
        AkagonohateData.itemSyojisu[2]--;
        //人足アイテム所持数を引く・上書き
        int moTMP = int.Parse(moT.text);
        int yuTMP = int.Parse(yuT.text);
        int niTMP = int.Parse(niT.text);
        AkagonohateData.itemSyojisu[3] -= moTMP;
        AkagonohateData.itemSyojisu[4] -= yuTMP;
        AkagonohateData.itemSyojisu[5] -= niTMP;
        AkagonohateData.moZen = moTMP;
        AkagonohateData.yuZen = yuTMP;
        AkagonohateData.niZen = niTMP;

        SceneManager.LoadScene("11Runway");
    }
}
