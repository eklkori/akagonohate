using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utage.UtageEditorPrefs;
using System;

public class tansakuPopUp : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] Text XXnoheyaT;
    [SerializeField] Text shinaiT;
    [SerializeField] Text dateShinchoku;
    [SerializeField] Text nextShinaiPt;
    [SerializeField] Text koChuTe;
    [SerializeField] GameObject kyaraPopUp;
    [SerializeField] GameObject PtBar;
    [SerializeField] GameObject[] kyaraImages;
    [SerializeField] GameObject dateBtn;
    [SerializeField] GameObject dateKanou;
    [SerializeField] GameObject nakanaoriBtn;
    [SerializeField] GameObject nakanaoriKanou;

    //-----�\���n-----

    public void showKyaraPopUp(int kyara) {
        AkagonohateData.tansakuKyara = kyara;
        Debug.Log(AkagonohateData.tansakuKyara);

        //UI�\��
        kyaraPopUp.SetActive(true);

        //�^�C�g�������uXX�̕����v�̍����ւ�
        switch (kyara)
        {
            case 0: XXnoheyaT.text = "���@�q�@�́@���@��"; break;
            case 1: XXnoheyaT.text = "�N�@�q�@�́@���@��"; break;
            case 2: XXnoheyaT.text = "�g�@�q�@�́@���@��"; break;
            case 3: XXnoheyaT.text = "�G�@���@�́@���@��"; break;
            case 4: XXnoheyaT.text = "�G�@��@�́@���@��"; break;
            case 5: XXnoheyaT.text = "�N�@�j�@�́@���@��"; break;
        }

        //�L�����摜�̍����ւ�
        for (int i = 0; i < 6; i++) {
            if (i == kyara)
            {
                kyaraImages[i].SetActive(true);
            }
            else 
            {
                kyaraImages[i].SetActive(false);
            }
        }

        //�f�[�g�E������{�^���̕\������
        //���f�[�g�̊�l�͉���1000�ɐݒ�(�v����)
        if (AkagonohateData.datePt[kyara] >= 1000)
        {
            AkagonohateData.dateFlg[kyara] = 1;
        }
        else 
        {
            AkagonohateData.dateFlg[kyara] = 0;
        }
        if (AkagonohateData.dateFlg[kyara] == 1)
        {
            Debug.Log(AkagonohateData.dateFlg[kyara]);
            Debug.Log(AkagonohateData.datePt[kyara]);
            dateBtn.SetActive(true);
            dateKanou.SetActive(true);
        }
        else
        {
            Debug.Log("��");
            dateBtn.SetActive(false);
            dateKanou.SetActive(false);
        }
        if (AkagonohateData.nakanaoriFlg[kyara] == 1)
        {
            nakanaoriBtn.SetActive(true);
            nakanaoriKanou.SetActive(true);
        }
        else
        {
            nakanaoriBtn.SetActive(false);
            nakanaoriKanou.SetActive(false);
        }

        //�e��Lv(����)�����ւ�
        shinaiT.text = AkagonohateData.shinaiLv[kyara].ToString();

        //�f�[�g�i���񐔍����ւ�
        dateShinchoku.text = AkagonohateData.dateCount[kyara].ToString();

        //���̐e��Lv�A�b�v�܂łɕK�v�Ȑe��Pt�̏㏑��
        //��l���v�Z(���x���A�b�v���Ƃɏオ��Â炭����݌v�ɂ���)
        int kijyun = 50 + AkagonohateData.shinaiLv[kyara] * AkagonohateData.shinaiLv[kyara];
        if (kijyun <= AkagonohateData.shinaiPt[kyara]) {
            AkagonohateData.shinaiLv[kyara]++;
            AkagonohateData.shinaiPt[kyara] = AkagonohateData.shinaiPt[kyara] - kijyun;
            kijyun = 50 + AkagonohateData.shinaiLv[kyara] * AkagonohateData.shinaiLv[kyara];
        }
        nextShinaiPt.text = (kijyun - AkagonohateData.shinaiPt[kyara]).ToString();

        //�e��Pt�o�[�̏�������
        //�v���C���[Lv�EEXP�o�[�̐���
          //float kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
          //if (kijyun <= AkagonohateData.exp)
          //{
          //    AkagonohateData.playerLvI++;
          //}
          //kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
        float par = AkagonohateData.shinaiPt[kyara] / kijyun;
        PtBar.GetComponent<Image>().fillAmount = par;

        //�ؖ��ւ̑z�������ւ�
        //��3���A����b����Ɓu���v�A5���A����b����Ɓu���v�ɏオ��
        //1����b���Ȃ����Ƃ�1�����N��������
        int kimata = 0;

        //�����̓��t�擾
        DateTime localDate = DateTime.Now;
        DateTime day = localDate.Date;

        if (AkagonohateData.kaiwaRireki[kyara] != null) {
            //�O���b������̌o�ߓ������擾
            int sa = day.Subtract(AkagonohateData.kaiwaRireki[kyara]).Days;

            //���t�v�Z�p(���ԁF"1��"��ϐ��ɃZ�b�g)
            TimeSpan ts = new TimeSpan(1, 0, 0, 0);

            //�����N���グ�鏈��
            if (AkagonohateData.kaiwaRireki[kyara + 10] != null && AkagonohateData.kaiwaRireki[kyara + 20] != null)
            {
                //�ၨ��
                if (AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 10] + ts && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 20] + ts * 2 && sa <= 1)
                {
                    kimata = 2;
                }
                if (AkagonohateData.kaiwaRireki[kyara + 30] != null && AkagonohateData.kaiwaRireki[kyara + 40] != null)
                {
                    //������
                    if (AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 10] + ts && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 20] + ts * 2 && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 30] + ts * 3 && AkagonohateData.kaiwaRireki[kyara] == AkagonohateData.kaiwaRireki[kyara + 40] + ts * 4 && sa <= 1)
                    {
                        kimata = 1;
                    }
                }
            }
            //�����N�������鏈��
            if (sa == 2)
            {
                kimata = 2;
            }
            else�@if(sa >= 3)
            {
                kimata = 3;
            }
        }
        switch (kimata)
        {
            case 1: koChuTe.text = "��"; break;
            case 2: koChuTe.text = "��"; break;
            case 3: koChuTe.text = "��"; break;
        }

        //�f�[�^���㏑��
        AkagonohateData.kimata[kyara] = kimata;
    }


    //��\���n-------------

    /// <summary>
    /// �|�b�v�A�b�v�ꊇ��\��(����)
    /// </summary>
    public void closePopup() {
        kyaraPopUp.SetActive(false);
    }

}
