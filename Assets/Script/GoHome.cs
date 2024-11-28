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

    [SerializeField] int shichoFlg = -1; //�����t���O(��b)
    [SerializeField] int shichoFlgD = -1;�@//�����t���O(�f�[�g)
    [SerializeField] int shichoFlgD1 = -1;�@//�����t���O(�f�[�g)������1
    [SerializeField] int shichoFlgD2 = -1;�@//�����t���O(�f�[�g)������2

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

        //�p�����[�^�[�̌Ăяo��
        int TEnd = engine.Param.GetParameterInt("TEnd");�@//�`���[�g���A��
        int BEnd = engine.Param.GetParameterInt("BEnd");�@//�������B�`���[�g���A��
        int KEnd = engine.Param.GetParameterInt("KEnd");�@//��b
        int DEnd = engine.Param.GetParameterInt("DEnd");�@//�f�[�g
        shichoFlg = engine.Param.GetParameterInt("shichoFlg");�@//�����t���O(��b)
        shichoFlgD = engine.Param.GetParameterInt("shichoFlgD");�@//�����t���O(�f�[�g)
        shichoFlgD1 = engine.Param.GetParameterInt("shichoFlgD1");�@//�����t���O(�f�[�g)������1
        shichoFlgD2 = engine.Param.GetParameterInt("shichoFlgD2");�@//�����t���O(�f�[�g)������2
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

        //�����ς݃t���O�㏑��
        //���ŏ��ɉ�bNo����1��������f�[�gNo�𒊏o
        if (AkagonohateData.kaiwaNo != "")
        {
            int dateNo = 0;
            char tmp = AkagonohateData.kaiwaNo[AkagonohateData.kaiwaNo.Length - 1];
            dateNo = (int)Char.GetNumericValue(tmp); //char��int�ϊ�
            int tmpFlg = 0;

            //��b�����ς݃t���O�̏㏑��
            if (first != "D")
            {
                if (shichoFlg != -1) //�������t���O�ɂ͉��ŉ�bNo��ݒ�ς�
                {
                    AkagonohateData.kaiwaShichoFlg[shichoFlg] = 1;
                }
            }
            //�f�[�g�����ς݃t���O�̏㏑��
            else
            {
                //�f�[�g(����1)�����ς݃t���O�̏㏑��
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
                //�f�[�g(����2)�����ς݃t���O�̏㏑��
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
                    //�f�[�g(�S��)�����ς݃t���O�̏㏑��
                    AkagonohateData.dateShichoFlg[AkagonohateData.tansakuKyara * 20 + dateNo - 1] = 1;
                    Debug.Log("AkagonohateData.dateShichoFlg[AkagonohateData.tansakuKyara * 20 + dateNo - 1]=" + AkagonohateData.dateShichoFlg[AkagonohateData.tansakuKyara * 20 + dateNo - 1]);
                }
            }
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
