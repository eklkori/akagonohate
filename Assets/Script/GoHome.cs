using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Utage;
using UnityEngine.UI;
using System.Reflection.Emit;
//using static System.Net.Mime.MediaTypeNames;
using UnityEngine.TextCore.Text;

public class GoHome : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] Text shinaiPt;

    public AdvEngine engine;

    [SerializeField] int shichoFlg = -1; //視聴フラグ(会話)
    [SerializeField] int shichoFlgD = -1;　//視聴フラグ(デート)
    [SerializeField] int shichoFlgD1 = -1;　//視聴フラグ(デート)※分岐1
    [SerializeField] int shichoFlgD2 = -1;　//視聴フラグ(デート)※分岐2

    private void Start()
    {
        //テスト用処理START
        AkagonohateData.shinaiLv[0] = 10;
        Debug.Log("AkagonohateData.kaiwaNo=" + AkagonohateData.kaiwaNo);
        //テスト用処理END

        popUp.SetActive(false);

    }

    void Update()
    {
        //AdvEngineの初期化 ※宴関連
        if (!engine.Param.IsInit) return;

        //※デートの場合のみ
        //親愛Lvが基準値以上の場合、宴のフラグを操作して選択肢その2を表示するようにする
        string first = "";
        if (AkagonohateData.kaiwaNo != "")
        {
            first = AkagonohateData.kaiwaNo.Substring(0, 1);
        }
        if (first == "D")
        {
            //基準値の設定
            int kijyun = 0;
            switch (AkagonohateData.dateCount[AkagonohateData.tansakuKyara])
            {
                case 1: kijyun = 3; break;
                case 2: kijyun = 8; break;
                case 3: kijyun = 15; break;
                case 4: kijyun = 25; break;
                case 5: kijyun = 40; break;
            }
            //Debug.Log("kijyun=" + kijyun + " AkagonohateData.tansakuKyara=" + AkagonohateData.tansakuKyara);
            //Debug.Log("AkagonohateData.shinaiLv[AkagonohateData.tansakuKyara]=" + AkagonohateData.shinaiLv[AkagonohateData.tansakuKyara]);
            if (kijyun <= AkagonohateData.shinaiLv[AkagonohateData.tansakuKyara])
            {
                engine.Param.SetParameterInt("sentakuFlg", 1);
            }
            else
            {
                engine.Param.SetParameterInt("sentakuFlg", 0);
            }
        }

        //パラメーターの呼び出し
        int TEnd = engine.Param.GetParameterInt("TEnd");　//チュートリアル
        int BEnd = engine.Param.GetParameterInt("BEnd");　//物資調達チュートリアル
        int KEnd = engine.Param.GetParameterInt("KEnd");　//会話
        int DEnd = engine.Param.GetParameterInt("DEnd");　//デート
        shichoFlg = engine.Param.GetParameterInt("shichoFlg");　//視聴フラグ(会話)
        shichoFlgD = engine.Param.GetParameterInt("shichoFlgD");　//視聴フラグ(デート)
        shichoFlgD1 = engine.Param.GetParameterInt("shichoFlgD1");　//視聴フラグ(デート)※分岐1
        shichoFlgD2 = engine.Param.GetParameterInt("shichoFlgD2");　//視聴フラグ(デート)※分岐2
        //Debug.Log(TEnd);
        if (TEnd==1)
        {
            AkagonohateData.tutorealFlg = 1;
            SceneManager.LoadScene("05Home", LoadSceneMode.Additive);
            deleteNowScene();
        }
        if (BEnd == 1)
        {
            AkagonohateData.busshiSyokaiFlg = 1;
            SceneManager.LoadScene("13Busshi", LoadSceneMode.Additive);
            deleteNowScene();
        }
        if (KEnd == 1 || DEnd == 1)
        {
            if (AkagonohateData.kakuninchuFlg == 1 || AkagonohateData.kakuninchuFlg == 2)
            {
                SceneManager.LoadScene("18shinaido3", LoadSceneMode.Additive);
                deleteNowScene();
            }
            else
            {
                //本日初回会話だった場合(もしくはデートの場合)はポップアップを出してから終了
                if (AkagonohateData.KSyokaiFlg[AkagonohateData.tansakuKyara] == 1 || DEnd == 1)
                {
                    //UI更新
                    popUp.SetActive(true);
                    shinaiPt.text = AkagonohateData.KshinaiPt[AkagonohateData.tansakuKyara].ToString();

                    //初回フラグの更新
                    //AkagonohateData.KSyokaiFlg[AkagonohateData.tansakuKyara] = 0;
                }
                else
                {
                    SceneManager.LoadScene("06Tansaku", LoadSceneMode.Additive);
                    deleteNowScene();
                }
            }
        }

        //視聴済みフラグ上書き
        //※最初に会話No末尾1文字からデートNoを抽出
        if (AkagonohateData.kaiwaNo != "")
        {
            int dateNo = 0;
            char tmp = AkagonohateData.kaiwaNo[AkagonohateData.kaiwaNo.Length - 1];
            dateNo = (int)Char.GetNumericValue(tmp); //char→int変換
            int tmpFlg = 0;

            //会話視聴済みフラグの上書き
            if (first != "D")
            {
                if (shichoFlg != -1) //※視聴フラグには宴で会話Noを設定済み
                {
                    AkagonohateData.kaiwaShichoFlg[shichoFlg] = 1;
                }
            }
            //デート視聴済みフラグの上書き
            else
            {
                //デート(分岐1)視聴済みフラグの上書き
                if (shichoFlgD1 == 1)
                {
                    if (AkagonohateData.kakuninchuFlg == 1 || AkagonohateData.kakuninchuFlg == 2)
                    {
                        AkagonohateData.dateShichoFlg[200 + (AkagonohateData.shinaidoWho - 1) * 20 + dateNo - 1] = 1;
                        Debug.Log("AkagonohateData.dateShichoFlg[200 + (AkagonohateData.shinaidoWho - 1) * 20 + dateNo - 1]=" + AkagonohateData.dateShichoFlg[200 + (AkagonohateData.shinaidoWho - 1) * 20 + dateNo - 1]);
                    }
                    else
                    {
                        AkagonohateData.dateShichoFlg[200 + AkagonohateData.tansakuKyara * 20 + dateNo - 1] = 1;
                        Debug.Log("AkagonohateData.dateShichoFlg[200 + AkagonohateData.tansakuKyara * 20 + dateNo - 1]=" + AkagonohateData.dateShichoFlg[200 + AkagonohateData.tansakuKyara * 20 + dateNo - 1]);
                    }
                    tmpFlg = 1;
                }
                //デート(分岐2)視聴済みフラグの上書き
                else if (shichoFlgD2 == 1)
                {
                    if (AkagonohateData.kakuninchuFlg == 1 || AkagonohateData.kakuninchuFlg == 2)
                    {
                        AkagonohateData.dateShichoFlg[400 + (AkagonohateData.shinaidoWho - 1) * 20 + dateNo - 1] = 1;
                        Debug.Log("AkagonohateData.dateShichoFlg[400 + (AkagonohateData.shinaidoWho - 1) * 20 + dateNo - 1]=" + AkagonohateData.dateShichoFlg[400 + (AkagonohateData.shinaidoWho - 1) * 20 + dateNo - 1]);
                    }
                    else
                    {
                        AkagonohateData.dateShichoFlg[400 + AkagonohateData.tansakuKyara * 20 + dateNo - 1] = 1;
                        Debug.Log("AkagonohateData.dateShichoFlg[400 + AkagonohateData.tansakuKyara * 20 + dateNo - 1]=" + AkagonohateData.dateShichoFlg[400 + AkagonohateData.tansakuKyara * 20 + dateNo - 1]);
                    }
                    tmpFlg = 1;
                }
                if (tmpFlg == 1)
                {
                    //デート(全体)視聴済みフラグの上書き
                    AkagonohateData.dateShichoFlg[AkagonohateData.tansakuKyara * 20 + dateNo - 1] = 1;
                    Debug.Log("AkagonohateData.dateShichoFlg[AkagonohateData.tansakuKyara * 20 + dateNo - 1]=" + AkagonohateData.dateShichoFlg[AkagonohateData.tansakuKyara * 20 + dateNo - 1]);
                }
            }
        }
    }

    /// <summary>
    /// シナリオ終了後のポップアップ表示後の画面遷移
    /// </summary>
    public void end()
    {
        SceneManager.LoadScene("06Tansaku", LoadSceneMode.Additive);
        deleteNowScene();
    }

    void deleteNowScene() {
        SceneManager.UnloadSceneAsync("04Tutorial");
    }
}
