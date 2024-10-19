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
        //AdvEngine�̏�����
        if (!engine.Param.IsInit) return;

        //�p�����[�^�[�̌Ăяo��
        int TEnd = engine.Param.GetParameterInt("TEnd");
        int BEnd = engine.Param.GetParameterInt("BEnd");
        int KEnd = engine.Param.GetParameterInt("KEnd");
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
        if (KEnd == 1)
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }
}
