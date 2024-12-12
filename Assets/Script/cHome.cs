using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    //�C�x���g�J�ڗp�{�^��
    [SerializeField] GameObject eventBtn;

    //���t�擾
    DateTime localDate = DateTime.Now;
    DateTime today;
    DateTime dtLastMonday;
    void Start()
    {
        //�e�X�g�p����START
        AkagonohateData.eventFlg = 1;
        for (int i = 0; i < 6; i++)//�^�X�N(�C�x���g)�̐�����for�ŉ�
        {
            AkagonohateData.tasseiFlgE[i] = 1;
        }
        //�e�X�g�p����END
        today = localDate.Date;

        //�C�x���g�J�Ò��{�^���̕\������
        if (AkagonohateData.eventFlg == 1)
        {
            eventBtn.SetActive(true);
        }
        else
        {
            eventBtn.SetActive(false);
        }

        //�p�[�g�i�[(�z�[����ʗ����G)�����\��
        int kyaraNo = AkagonohateData.partnerNo;
        kyaraBtn(kyaraNo);

        //�^�X�N�̊������聦�B���t���O�̏㏑�������{�@(�����^�X�N������ΐԊۃA�C�R����\��)
        //�ԊۃA�C�R���̏�����
        tsuchiTask.SetActive(false);

        //�B���t���O�̏�����
        //���T�̍ŏ��̓�(���j��)���擾
        dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
        Debug.Log("dtLastMonday "+dtLastMonday);
        Debug.Log("today " + today);
        //����(1���̍ŏ��̂�)
        if (today != AkagonohateData.kaiwaRireki[0].Date && today != AkagonohateData.kaiwaRireki[1] && today != AkagonohateData.kaiwaRireki[2] && today != AkagonohateData.kaiwaRireki[3] && today != AkagonohateData.kaiwaRireki[4] && today != AkagonohateData.kaiwaRireki[5] && today != AkagonohateData.runwayRireki[0])
        {
            for (int i = 0; i < 6; i++)//�^�X�N(����)�̐�����for�ŉ�
            {
                AkagonohateData.tasseiFlgN[i] = 1;
            }
        }
        //�T��(�T�̍ŏ��̂�)
        if (dtLastMonday >= AkagonohateData.kaiwaRireki[0] && dtLastMonday >= AkagonohateData.kaiwaRireki[1] && dtLastMonday >= AkagonohateData.kaiwaRireki[2] && dtLastMonday >= AkagonohateData.kaiwaRireki[3] && dtLastMonday >= AkagonohateData.kaiwaRireki[4] && dtLastMonday >= AkagonohateData.kaiwaRireki[5] && dtLastMonday >= AkagonohateData.runwayRireki[0])
            for (int i = 0; i < 9; i++)//�^�X�N(�T��)�̐�����for�ŉ�
        {
            AkagonohateData.tasseiFlgS[i] = 1;
        }
        //�C�x���g(�C�x���g���Ԃ̂�)
        if (AkagonohateData.eventFlg == 1)
        {
            for (int i = 0; i < 6; i++)//�^�X�N(�C�x���g)�̐�����for�ŉ�
            {
                AkagonohateData.tasseiFlgE[i] = 1;
            }
        }

        //��b�񐔂̎Z�o(��)
        int iconFlg = 0;
        int countDay = 0;
        int countWeek = 0;
        for (int i = 0; i < 6; i++)
        {
            //�N���̍ŏI��b���������ł���΁AcountDay��1�ɂȂ�̂Ŏ���if����ʂ�
            if (AkagonohateData.kaiwaRireki[i] == today.Date)
            {
                countDay++;
                break;
            }
        }
        if (countDay >= 1)
        {
            if (AkagonohateData.countDay[0] >= 1) 
            {
                if (AkagonohateData.tasseiFlgN[0] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgN[0] = 0;
                }
            }
            if (AkagonohateData.countDay[0] >= 3)
            {
                if (AkagonohateData.tasseiFlgN[1] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgN[1] = 0;
                }
            }
            if (AkagonohateData.countDay[0] >= 6)
            {
                if (AkagonohateData.tasseiFlgN[2] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgN[2] = 0;
                }
            }
        }
        //�����E�F�C�񐔂̎Z�o(��)
        if (AkagonohateData.runwayRireki[0].Date == today.Date)
        {
            if (AkagonohateData.countDay[1] >= 1)
            {
                if (AkagonohateData.tasseiFlgN[3] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgN[3] = 0;
                }
            }
            if (AkagonohateData.countDay[1] >= 5)
            {
                if (AkagonohateData.tasseiFlgN[4] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgN[4] = 0;
                }
            }
            if (AkagonohateData.countDay[1] >= 10)
            {
                if (AkagonohateData.tasseiFlgN[5] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgN[5] = 0;
                }
            }
        }

        //��b�񐔂̎Z�o(�T)
        for (int i = 0; i < 6; i++)
        {
            //�N���̍ŏI��b�����T���߂̌��j�ȍ~�ł���΁AcountDayTMP��1�ɂȂ�̂Ŏ���if����ʂ�
            if (AkagonohateData.kaiwaRireki[i].Date >= dtLastMonday.Date)
            {
                countWeek++;
                break;
            }
        }
        if (countWeek >= 1)
        {
            if (AkagonohateData.countDay[3] >= 10)
            {
                if (AkagonohateData.tasseiFlgS[0] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[0] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 20)
            {
                if (AkagonohateData.tasseiFlgS[1] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[1] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 30)
            {
                if (AkagonohateData.tasseiFlgS[2] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[2] = 0;
                }
            }
        }

        //�����E�F�C�񐔂̎Z�o(�T)
        if (AkagonohateData.runwayRireki[0].Date >= dtLastMonday.Date)
        {
            if (AkagonohateData.countDay[3] >= 15)
            {
                if (AkagonohateData.tasseiFlgS[3] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[3] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 25)
            {
                if (AkagonohateData.tasseiFlgS[4] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[4] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 35)
            {
                if (AkagonohateData.tasseiFlgS[5] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[5] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 50)
            {
                if (AkagonohateData.tasseiFlgS[6] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[6] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 60)
            {
                if (AkagonohateData.tasseiFlgS[7] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[7] = 0;
                }
            }
            if (AkagonohateData.countDay[3] >= 70)
            {
                if (AkagonohateData.tasseiFlgS[8] != 2)
                {
                    iconFlg++;
                    AkagonohateData.tasseiFlgS[8] = 0;
                }
            }
        }

        //�Ԋےʒm��\��
        if (iconFlg != 0)
        {
            tsuchiTask.SetActive(true);
        }
        //for (int i = 0; i < 4; i++) {
        //if (countDayTMP[i] != 0) {
        //        tsuchiTask.SetActive(true);
        //        break;
        //    }
        //}
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

    /// <summary>
    /// �C�x���g������ �C�x���g�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void pushEventBtn()
    {
        //��ʑJ��
        SceneManager.LoadScene("20Event", LoadSceneMode.Additive);
        AkagonohateData.maeScene = "20Event";
        SceneManager.UnloadSceneAsync("05Home");
    }
    void Update()
    {
        //�������t�̎擾
        today = localDate.Date;
        dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
    }
}
