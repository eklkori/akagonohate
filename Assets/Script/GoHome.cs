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
        //AdvEngine�̏����� �����֘A
        if (!engine.Param.IsInit) return;

        //�p�����[�^�[�̌Ăяo��
        int TEnd = engine.Param.GetParameterInt("TEnd");�@//�`���[�g���A��
        int BEnd = engine.Param.GetParameterInt("BEnd");�@//�������B�`���[�g���A��
        int KEnd = engine.Param.GetParameterInt("KEnd");�@//��b
        int DEnd = engine.Param.GetParameterInt("DEnd");�@//�f�[�g
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
                //�{�������b�������ꍇ(�������̓f�[�g�̏ꍇ)�̓|�b�v�A�b�v���o���Ă���I��
                if (AkagonohateData.KSyokaiFlg[AkagonohateData.tansakuKyara] == 1 || DEnd == 1)
                {
                    //UI�X�V
                    popUp.SetActive(true);
                    shinaiPt.text = AkagonohateData.KshinaiPt[AkagonohateData.tansakuKyara].ToString();

                    //����t���O�̍X�V
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
    /// �V�i���I�I����̃|�b�v�A�b�v�\����̉�ʑJ��
    /// </summary>
    public void end()
    {
        SceneManager.LoadScene("06Tansaku");
    }
}
