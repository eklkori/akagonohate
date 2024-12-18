using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class showUIData : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject expBar;
    [SerializeField] GameObject[] keys;

    [SerializeField] Text playerLv;
    [SerializeField] Text playerName;
    [SerializeField] Text kenSyoji;
    [SerializeField] Text zeniSyoji;
    [SerializeField] Text keyHMMSS;

    //日付の取得　
    DateTime localDate = DateTime.Now;
    DateTime now;
    DateTime syouhiStart;
    void Start()
    {
        //テスト用START
        //AkagonohateData.itemSyojisu[2] = 3;
        //テスト用END
        syouhiStart = AkagonohateData.runwayRireki[1];
        Debug.Log(syouhiStart);
    }

    //テスト用処理START
    float countH = AkagonohateData.HH; //要検討
    float countM = AkagonohateData.MM; //要検討
    float countS = AkagonohateData.SS; //要検討
    //int keyTMP = 0;
    //テスト用処理END

    public void Update()
    {
        //テスト用処理START
        //　keyHMMSS.text = countS.ToString();
        //テスト用処理END

        //本番用処理END

        kenSyoji.text = AkagonohateData.itemSyojisu[1].ToString();
        zeniSyoji.text = AkagonohateData.itemSyojisu[0].ToString();
        playerLv.text = AkagonohateData.playerLvI.ToString();
        playerName.text = AkagonohateData.playerNmaeT;

        //鍵アイコンの表示
        for (int i = 0; i < AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]; i++) {
            keys[i].SetActive(true);
        }

        ExpBar();
        Keys();
    }

    /// <summary>
    /// プレイヤーLv・EXPバーの制御
    /// </summary>
    void ExpBar() {
        //プレイヤーLv・EXPバーの制御
        float kijyun = 100 + AkagonohateData.playerLvI* AkagonohateData.playerLvI;
        if (kijyun<= AkagonohateData.exp) {
            AkagonohateData.playerLvI++;
        }
        kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
        float par = AkagonohateData.exp / kijyun;
        expBar.GetComponent<Image>().fillAmount = par;
    }

    /// <summary>
    /// 鍵の制御
    /// </summary>
    void Keys() {
        //本番用処理START
        localDate = DateTime.Now;        //現在日時の取得
        now = localDate;                 //現在日時の取得
        TimeSpan sa = now - syouhiStart;        //現在日時と鍵の消費時刻との差を取得
        TimeSpan kijyun = new TimeSpan(0, 10, 0, 0);
        TimeSpan hour = new TimeSpan(0, 2, 0, 0);
        if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] >= 5)
        {
            //鍵がフル回復しているとき
            countH = 0;
            countM = 0;
            countS = 0;
        }
        else
        {
            //鍵がフル回復でないとき
            int saH = sa.Hours;
            int saM = sa.Minutes;
            int saS = sa.Seconds;
            if (saH >= 8)
            {
                kijyun = new TimeSpan(0, 10, 0, 0);
                saH -= 8;
            }
            else if (saH >= 6)
            {
                kijyun = new TimeSpan(0, 8, 0, 0);
                saH -= 6;
            }
            else if (saH >= 4)
            {
                kijyun = new TimeSpan(0, 6, 0, 0);
                saH -= 4;
            }
            else if (saH >= 2)
            {
                kijyun = new TimeSpan(0, 4, 0, 0);
                saH -= 2;
            }
            else
            {
                kijyun = new TimeSpan(0, 2, 0, 0);
            }
            TimeSpan showData = kijyun - sa;
            countH = showData.Hours;
            countM = showData.Minutes;
            countS = showData.Seconds;
        }

        //UI表示
        keyHMMSS.text = countH.ToString("f0") + ":" + countM.ToString("00") + ":" + countS.ToString("00");

        //テスト用処理(旧)
        //if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] < 5)
        //{
        //    countS -= Time.deltaTime;
        //    if (countS.ToString("f0") == "-1")
        //    {
        //        countM--;
        //        countS = 59;
        //        if (countM == -1)
        //        {
        //            countH--;
        //            countM = 59;
        //            if (countH == -1)
        //            {
        //                //鍵が1つ回復した時の処理
        //                countH = 1;
        //                if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] < 5)
        //                {
        //                    AkagonohateData.itemSyojisu[2]++;
        //                    keys[AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] - 1].SetActive(true);
        //                }
        //            }
        //        }
        //    }
        //    //DBデータの上書き
        //    AkagonohateData.HH = countH;
        //    AkagonohateData.MM = countM;
        //    AkagonohateData.SS = countS;

        //    //UI表示
        //    keyHMMSS.text = countH.ToString("f0") + ":" + countM.ToString("00") + ":" + countS.ToString("00");
        //}
        //else
        //{
        //    keyHMMSS.text = "0:00:00";
        //}
    }
}
