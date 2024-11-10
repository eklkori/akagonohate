using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Utage;
using UnityEngine.UI;

public class GoHome : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] Text shinaiPt;

    public AdvEngine engine;

    private void Start()
    {
        popUp.SetActive(false);
    }

    void Update()
    {
        //AdvEngineの初期化 ※宴関連
        if (!engine.Param.IsInit) return;

        //パラメーターの呼び出し
        int TEnd = engine.Param.GetParameterInt("TEnd");　//チュートリアル
        int BEnd = engine.Param.GetParameterInt("BEnd");　//物資調達チュートリアル
        int KEnd = engine.Param.GetParameterInt("KEnd");　//会話
        int DEnd = engine.Param.GetParameterInt("DEnd");　//デート
        //Debug.Log(TEnd);
        if (TEnd==1)
        {
            AkagonohateData.tutorealFlg = 1;
            SceneManager.LoadScene("05Home");
        }
        if (BEnd == 1)
        {
            AkagonohateData.busshiSyokaiFlg = 1;
            SceneManager.LoadScene("13Busshi");
        }
        if (KEnd == 1 || DEnd == 1)
        {
            if (AkagonohateData.kakuninchuFlg == 1 || AkagonohateData.kakuninchuFlg == 2)
            {
                SceneManager.LoadScene("18shinaido3");
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
                    SceneManager.LoadScene("06Tansaku");
                }
            }
        }
    }

    /// <summary>
    /// シナリオ終了後のポップアップ表示後の画面遷移
    /// </summary>
    public void end()
    {
        SceneManager.LoadScene("06Tansaku");
    }
}
