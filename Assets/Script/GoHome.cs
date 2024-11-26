using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Utage;
using UnityEngine.UI;
using System.Reflection.Emit;

public class GoHome : MonoBehaviour
{
    [SerializeField] GameObject popUp;
    [SerializeField] Text shinaiPt;

    public AdvEngine engine;

    [SerializeField] int shichoFlg = -1; //�����t���O(��b)
    [SerializeField] int shichoFlgD = -1;�@//�����t���O(�f�[�g)

    private void Start()
    {
        //�e�X�g�p����START
        AkagonohateData.shinaiLv[0] = 10;
        Debug.Log("AkagonohateData.kaiwaNo=" + AkagonohateData.kaiwaNo);
        //�e�X�g�p����END

        popUp.SetActive(false);

    }

    void Update()
    {
        //AdvEngine�̏����� �����֘A
        if (!engine.Param.IsInit) return;

        //���f�[�g�̏ꍇ�̂�
        //�e��Lv����l�ȏ�̏ꍇ�A���̃t���O�𑀍삵�đI��������2��\������悤�ɂ���
        string first = "";
        if (AkagonohateData.kaiwaNo != "")
        {
            first = AkagonohateData.kaiwaNo.Substring(0, 1);
        }
        if (first == "D")
        {
            //��l�̐ݒ�
            int kijyun = 0;
            switch (AkagonohateData.dateCount[AkagonohateData.tansakuKyara])
            {
                case 1: kijyun = 3; break;
                case 2: kijyun = 8; break;
                case 3: kijyun = 15; break;
                case 4: kijyun = 25; break;
                case 5: kijyun = 40; break;
            }
            Debug.Log("kijyun=" + kijyun + " AkagonohateData.tansakuKyara=" + AkagonohateData.tansakuKyara);
            Debug.Log("AkagonohateData.shinaiLv[AkagonohateData.tansakuKyara]=" + AkagonohateData.shinaiLv[AkagonohateData.tansakuKyara]);
            if (kijyun <= AkagonohateData.shinaiLv[AkagonohateData.tansakuKyara])
            {
                engine.Param.SetParameterInt("sentakuFlg", 1);
            }
            else
            {
                engine.Param.SetParameterInt("sentakuFlg", 0);
            }
        }

        //�p�����[�^�[�̌Ăяo��
        int TEnd = engine.Param.GetParameterInt("TEnd");�@//�`���[�g���A��
        int BEnd = engine.Param.GetParameterInt("BEnd");�@//�������B�`���[�g���A��
        int KEnd = engine.Param.GetParameterInt("KEnd");�@//��b
        int DEnd = engine.Param.GetParameterInt("DEnd");�@//�f�[�g
        shichoFlg = engine.Param.GetParameterInt("shichoFlg");�@//�����t���O(��b)
        shichoFlgD = engine.Param.GetParameterInt("shichoFlgD");�@//�����t���O(�f�[�g)
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
                    SceneManager.LoadScene("06Tansaku", LoadSceneMode.Additive);
                    deleteNowScene();
                }
            }
        }

        //�����t���O�㏑��
        if (shichoFlg != -1)
        {
            AkagonohateData.kaiwaShichoFlg[shichoFlg] = 1;
        }
        else if (shichoFlgD != -1)
        {
            AkagonohateData.dateShichoFlg[shichoFlgD] = 1;
        }
    }

    /// <summary>
    /// �V�i���I�I����̃|�b�v�A�b�v�\����̉�ʑJ��
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
