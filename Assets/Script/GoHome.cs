using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Utage;

public class GoHome : MonoBehaviour
{
    public AdvEngine engine;
    
    void Update()
    {
        //AdvEngineの初期化
        if (!engine.Param.IsInit) return;

        //パラメーターの呼び出し
        int TEnd = engine.Param.GetParameterInt("TEnd");
        int BEnd = engine.Param.GetParameterInt("BEnd");
        int KEnd = engine.Param.GetParameterInt("KEnd");
        int DEnd = engine.Param.GetParameterInt("DEnd");
        Debug.Log(TEnd);
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
                SceneManager.LoadScene("06Tansaku");
            }
        }
    }
}
