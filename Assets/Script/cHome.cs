using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class cHome : MonoBehaviour
{
    //���z�[����ʂɂ̂ݒu���Ă������������͊�{���̃X�N���v�g�ɋL��

    //�L���������G�\���n
    [SerializeField] GameObject[] kyaraBtns;
    [SerializeField] Sprite[] kyaraImage;
    [SerializeField] Image kyaraTachie;

    //�ʒm�A�C�R��
    [SerializeField] GameObject tsuchiTask;

    //�I�𒆘g
    [SerializeField] GameObject[] sentakuchu;

    //���t�擾
    DateTime localDate = DateTime.Now;
    DateTime today;
    void Start()
    {
        //�p�[�g�i�[(�z�[����ʗ����G)�����\��
        int kyaraNo = AkagonohateData.partnerNo;
        kyaraBtn(kyaraNo);

        //�^�X�N�̊������聦�B���t���O�̏㏑�������{�@(�����^�X�N������ΐԊۃA�C�R����\��)
        //�ԊۃA�C�R���̏�����
        tsuchiTask.SetActive(false);
        //�B���t���O�̏�����
        //����
        for (int i = 0; i < 6; i++)//�^�X�N(����)�̐�����for�ŉ�
        {
            AkagonohateData.tasseiFlgN[i] = 1;
        }
        //�T��
        for (int i = 0; i < 9; i++)//�^�X�N(�T��)�̐�����for�ŉ�
        {
            AkagonohateData.tasseiFlgN[i] = 1;
        }
        //�C�x���g(�C�x���g���Ԃ̂�)
        if (AkagonohateData.eventFlg == 1)
        {
            for (int i = 0; i < 6; i++)//�^�X�N(�C�x���g)�̐�����for�ŉ�
            {
                AkagonohateData.tasseiFlgN[i] = 1;
            }
        }

        //��b�񐔂̎Z�o(��)
        int iconFlg = 0;
        int[] countDayTMP = new int[4];
        for (int i = 0; i < 6; i++)
        {
            //�N���̍ŏI��b���������ł���΁AcountDayTMP��1�ɂȂ�̂Ŏ���if����ʂ�
            if (AkagonohateData.kaiwaRireki[i] == today)
            {
                countDayTMP[0]++;
                break;
            }
        }
        if (countDayTMP[0] >= 1)
        {
            if (AkagonohateData.countDay[0] >= 1) 
            {
                iconFlg++;
                AkagonohateData.tasseiFlgN[0] = 0;
            }
            if (AkagonohateData.countDay[0] >= 3)
            {
                iconFlg++;
                AkagonohateData.tasseiFlgN[1] = 0;
            }
            if (AkagonohateData.countDay[0] >= 6)
            {
                iconFlg++;
                AkagonohateData.tasseiFlgN[2] = 0;
            }
        }
        //�����E�F�C�񐔂̎Z�o(��)
        if (AkagonohateData.runwayRireki[0].Date == today.Date)
        {
            if (AkagonohateData.countDay[1] >= 1)
            {
                iconFlg++;
                AkagonohateData.tasseiFlgN[3] = 0;
            }
            if (AkagonohateData.countDay[1] >= 5)
            {
                iconFlg++;
                AkagonohateData.tasseiFlgN[4] = 0;
            }
            if (AkagonohateData.countDay[1] >= 10)
            {
                iconFlg++;
                AkagonohateData.tasseiFlgN[5] = 0;
            }
        }

        //��b�񐔂̎Z�o(�T)

        //�����E�F�C�񐔂̎Z�o(�T)

        for (int i = 0; i < 4; i++) {
            if (countDayTMP[i] != 0) {
                tsuchiTask.SetActive(true);
                break;
            }
        }
    }

    /// <summary>
    /// �p�[�g�i�[�I���{�^���������̏����\��
    /// </summary>
    public void syokihyouji() {
        //�ߑ����� / �������ɂ��\���𐧌�
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1)
            {
                kyaraBtns[i].SetActive(true);
            }
            else {
                kyaraBtns[i].SetActive(false);
            }
        }

        //�I�𒆘g�̕\��
        //������
        for (int i = 0; i < 60; i++) {
            sentakuchu[i].SetActive(false);
        }
        //�I�𒆈ߑ��݂̂ɘg��\��
        int syojiCount = -1;
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1) {
                syojiCount++;
            }
            if (AkagonohateData.partnerNo == AkagonohateData.isyoSyojiFlg[i]) {
                sentakuchu[syojiCount].SetActive(true);
                break;
            }
        }

    }

    /// <summary>
    /// �L�����{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void kyaraBtn(int kyaraNo)
    {
        //�摜�����ւ�����
        AkagonohateData.partnerNo = kyaraNo;
        kyaraTachie.sprite = kyaraImage[AkagonohateData.partnerNo];

        //�T�C�Y�ύX
        RectTransform rectTransform = kyaraTachie.GetComponent<RectTransform>();
        int num = kyaraNo / 10;
        //transform.localScale = new Vector3(1400, 2227, 0);
        switch (num)
        {
            case 0: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1830, 1); break;
            case 1: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1850, 1); break;
            case 2: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1730, 1); break;
            case 3: kyaraTachie.rectTransform.sizeDelta  = new Vector3(1500, 1870, 1); break;
            case 4: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1980, 1); break;
            case 5: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1940, 1); break;
        }
        //�T�C�Y�ύX(��蕨�ȂǂŌʐݒ肪�K�v�ɂȂ�ꍇ������΂����ɋL��)

    }
    void Update()
    {
        //�������t�̎擾
        today = localDate.Date;
    }
}
