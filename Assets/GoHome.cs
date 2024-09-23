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

        if (TEnd==1)
        {
            SceneManager.LoadScene("05Home");
        }
    }
}
