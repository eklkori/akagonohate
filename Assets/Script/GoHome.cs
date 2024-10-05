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
        int KEnd = engine.Param.GetParameterInt("KEnd");

        if (TEnd==1)
        {
            SceneManager.LoadScene("05Home");
        }
        if (KEnd == 1)
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }
}
