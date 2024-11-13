using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;


public class goRunway : MonoBehaviour
{
    [SerializeField] GameObject kaishiBtn;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject popupBase2;
    [SerializeField] GameObject setteishita;
    [SerializeField] GameObject key;
    [SerializeField] GameObject hai;
    [SerializeField] GameObject hai2;
    [SerializeField] GameObject iie;
    [SerializeField] GameObject sankaku;
    [SerializeField] GameObject haiBtn;
    [SerializeField] GameObject hai2Btn;
    [SerializeField] GameObject iieBtn;
    [SerializeField] GameObject imasugu;
    [SerializeField] GameObject tarimasen;
    [SerializeField] GameObject now;
    [SerializeField] GameObject after;

    [SerializeField] int pickUp1;  //�s�b�N�A�b�v���̈ߑ�No�@���i�[
    [SerializeField] int pickUp2;  //�s�b�N�A�b�v���̈ߑ�No�A���i�[

    //�����\��(�|�b�v�A�b�v�p)
    [SerializeField] Text nowT;
    [SerializeField] Text afterT;

    //�l���ݒ�\���l
    [SerializeField] Text moT;
    [SerializeField] Text yuT;
    [SerializeField] Text niT;

    //���t�擾
    DateTime localDate = DateTime.Now;
    DateTime today;

    /// <summary>
    /// �����E�F�C�O�̃|�b�v�A�b�v�\��
    /// </summary>
    public void kaishi()
    {
        //�e�X�g�p
        //AkagonohateData.itemSyojisu[2] = 3;
        //�e�X�g�p����END

        haikei.SetActive(true);
        popupBase2.SetActive(true);
        setteishita.SetActive(true);
        key.SetActive(true);
        hai.SetActive(true);
        iie.SetActive(true);
        haiBtn.SetActive(true);
        iieBtn.SetActive(true);
        sankaku.SetActive(true);

        nowT.text = (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]).ToString();
        int tmp = AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] - 1;
        afterT.text = tmp.ToString();

        now.SetActive(true);
        after.SetActive(true);

        if (tmp < 0) {
            setteishita.SetActive(false);
            key.SetActive(false);
            hai.SetActive(false);
            iie.SetActive(false);
            sankaku.SetActive(false);
            hai2.SetActive(true);
            imasugu.SetActive(true);
            hai2Btn.SetActive(true);
            tarimasen.SetActive(true);
            now.SetActive(false);
            after.SetActive(false);
        }
    }

    private AkagonohateData akagoData;

    /// <summary>
    /// �����E�F�C�̊J�n
    /// </summary>
    public void Hai()
    {
        //�ݒ蒆�̐l���l��ϐ��ɃZ�b�g
        int moTMP = int.Parse(moT.text);
        int yuTMP = int.Parse(yuT.text);
        int niTMP = int.Parse(niT.text);

        //�����Ƃ̕]���v�Z
        AkagonohateData akagoData = ScriptableObject.CreateInstance<AkagonohateData>(); //�C���X�^���X������
        //akagoData = FindObjectOfType<AkagonohateData>(); // �C���X�^���X��
        int[] bi = akagoData.GetBi;
        int[] hu = akagoData.GetHu;
        int kijyunBi = 0;
        int kijyunHu = 0;
        //�D�ǉ̔��f��l��ݒ�(�v����)
        switch (AkagonohateData.basyo)
        {
            case 1: kijyunBi = 30; kijyunHu = 30; break;
            case 2: kijyunBi = 70; kijyunHu = 70; break;
            case 3: kijyunBi = 100; kijyunHu = 50; break;
            case 4: kijyunBi = 60; kijyunHu = 120; break;
            case 5: kijyunBi = 140; kijyunHu = 140; break;
            case 6: kijyunBi = 200; kijyunHu = 100; break;
            case 7: kijyunBi = 120; kijyunHu = 200; break;
            case 8: kijyunBi = 170; kijyunHu = 170; break;
            case 9: kijyunBi = 250; kijyunHu = 100; break;
        }
        //�D�ǉ̔���
        //�@�e������
        int forCount = 0;
        for (int i = 0; i < 3; i++)
        {
            int kekkaBi = 0;
            int kekkaHu = 0;
            switch (i)
            {
                case 0: forCount = 0; break;
                case 1: forCount = 8; break;
                case 2: forCount = 16; break;
            }
            for (int j = forCount; j < forCount + 8; j++)
            {
                if (AkagonohateData.runner[j] != -1)
                {
                    kekkaBi += bi[AkagonohateData.runner[j]];
                    kekkaHu += hu[AkagonohateData.runner[j]];
                    //Debug.Log("kekkaBi = " + kekkaBi);
                    //Debug.Log("kekkaHu = " + kekkaHu);

                    //�e��Lv�̕�1����悹
                    int tmp = AkagonohateData.runner[j] / 10;
                    switch (tmp)
                    {
                        case 0: kekkaBi += AkagonohateData.shinaiLv[0]; kekkaHu += AkagonohateData.shinaiLv[0]; break;
                        case 1: kekkaBi += AkagonohateData.shinaiLv[1]; kekkaHu += AkagonohateData.shinaiLv[1]; break;
                        case 2: kekkaBi += AkagonohateData.shinaiLv[2]; kekkaHu += AkagonohateData.shinaiLv[2]; break;
                        case 3: kekkaBi += AkagonohateData.shinaiLv[3]; kekkaHu += AkagonohateData.shinaiLv[3]; break;
                        case 4: kekkaBi += AkagonohateData.shinaiLv[4]; kekkaHu += AkagonohateData.shinaiLv[4]; break;
                        case 5: kekkaBi += AkagonohateData.shinaiLv[5]; kekkaHu += AkagonohateData.shinaiLv[5]; break;
                    }
                }
            }
            //�l���ݒ�l�𔽉f
            kekkaBi += moTMP*5;
            kekkaHu += yuTMP*5;
            //���菈��
            if (kijyunBi <= kekkaBi && kijyunHu <= kekkaHu)
            {
                AkagonohateData.runwayRes[i] = 1;
            }
            else if (kijyunBi * 85 / 100 <= kekkaBi && kijyunHu * 85 / 100 <= kekkaHu)
            {
                AkagonohateData.runwayRes[i] = 2;
            }
            else
            {
                AkagonohateData.runwayRes[i] = 3;
            }
            //���C�x���g���̂�
            //�������E���[���A���̗݌v�l���|�C���g�ɉ��Z
            if (AkagonohateData.eventFlg == 1) {
                AkagonohateData.eventRuikei[1] += kekkaBi;
                AkagonohateData.eventRuikei[2] += kekkaHu;
            }
            //Debug.Log("�]���v�Z���ʁF" + kekkaBi +" "+ kekkaHu);
        }
        //�A����
        if (AkagonohateData.runwayRes[0] == 1 && AkagonohateData.runwayRes[1] == 1 && AkagonohateData.runwayRes[2] == 1)
        {
            AkagonohateData.runwayRes[3] = 1;
        }
        else if 
            (AkagonohateData.runwayRes[0] != 3 && AkagonohateData.runwayRes[1] != 3 && AkagonohateData.runwayRes[2] != 3)
        {
            AkagonohateData.runwayRes[3] = 2;
        }
        else 
        {
            AkagonohateData.runwayRes[3] = 3;
        }

        //MVP�L�����𔻒�
        //�@�e������
        for (int i = 0; i < 3; i++) {
            switch (i)
            {
                case 0: forCount = 0; break;
                case 1: forCount = 8; break;
                case 2: forCount = 16; break;
            }
            int MVP = -1;
            int hikakuTMP = -1;
            for (int j = forCount; j < forCount + 8; j++)
            {
                if (AkagonohateData.runner[j] != -1)
                {
                    int hikaku = bi[AkagonohateData.runner[j]] + hu[AkagonohateData.runner[j]];
                    //���A�x�̈Ⴂ�ɂ�鍷���v�Z����(�C�x���g���̂݁H)
                    if (AkagonohateData.eventFlg == 1)
                    {
                        if (AkagonohateData.runner[j] % 10 == 0 || AkagonohateData.runner[j] % 10 == 1)
                        {
                            hikaku += 1;
                        }
                        else if (AkagonohateData.runner[j] % 10 == 2 || AkagonohateData.runner[j] % 10 == 3)
                        {
                            hikaku += 2;
                        }
                        else
                        {
                            //��3�F�ʏ��12�A�s�b�N�A�b�v�ߑ���30
                            if (AkagonohateData.runner[j] == pickUp1 || AkagonohateData.runner[j] == pickUp2)
                            {
                                hikaku += 30;
                            }
                            else
                            {
                                hikaku += 12;
                            }
                        }
                    }
                    if (hikakuTMP < hikaku) {
                        MVP = AkagonohateData.runner[j];
                        hikakuTMP = hikaku;
                    }
                    //Debug.Log("hikaku = " + hikaku);
                }
            }
            switch (i)
            {
                case 0: AkagonohateData.runwayMVP[0] = MVP; break;
                case 1: AkagonohateData.runwayMVP[1] = MVP; break;
                case 2: AkagonohateData.runwayMVP[2] = MVP; break;
            }
        }

        //�A����
        //�d���`�F�b�N
        int[] chofukuCheck = new int[24];
        for (int i = 0; i < 24; i++) {
            if (AkagonohateData.runner[i] != -1) {
                for (int j = 0; j <= i; j++) 
                {
                    if (AkagonohateData.runner[i] == AkagonohateData.runner[j]) {
                        chofukuCheck[i]++;
                    }
                }
            }
        }
        //�S�����i�[�̃X�e�[�^�X���v�l���v�Z
        int[] totalHikaku = new int[24];
        for (int i = 0; i < 24; i++)
        {
            if (AkagonohateData.runner[i] != -1)
            {
                totalHikaku[i] = bi[AkagonohateData.runner[i]] + hu[AkagonohateData.runner[i]];
                //���A�x�̈Ⴂ�ɂ�鍷���v�Z����(�C�x���g���̂݁H)
                if (AkagonohateData.eventFlg == 1)
                {
                    if (AkagonohateData.runner[i] % 10 == 0 || AkagonohateData.runner[i] % 10 == 1)
                    {
                        totalHikaku[i] += 1;
                    }
                    else if (AkagonohateData.runner[i] % 10 == 2 || AkagonohateData.runner[i] % 10 == 3)
                    {
                        totalHikaku[i] += 2;
                    }
                    else
                    {
                        //��3�F�ʏ��12�A�s�b�N�A�b�v�ߑ���30
                        if (AkagonohateData.runner[i] == pickUp1 || AkagonohateData.runner[i] == pickUp2)
                        {
                            totalHikaku[i] += 30;
                        }
                        else
                        {
                            totalHikaku[i] += 12;
                        }
                    }
                }
                totalHikaku[i] *= chofukuCheck[i];
            }
        }
        //��ԃX�e�[�^�X���v�l�̍����L�����𑍍�MVP�ɑI�o
        int kakunin = totalHikaku.Max();
        for (int i = 0; i < 24; i++) {
            if (totalHikaku[i] == kakunin) {
                AkagonohateData.runwayMVP[3] = AkagonohateData.runner[i];
                break;
            }
        }
        //MVP�L��������END

        //�l���e���x�E�l���f�[�gPt���v�Z
        //�@�l���e���x�F�����i�[2�l���Ƃ�+1(��̏ꍇ�͐؂�̂�)
        //�ϐ��̏�����
        for (int i = 0; i < 6; i++)
        {
            AkagonohateData.KshinaiPt[i] = 0;
        }
        //�v�Z
        for (int i = 0; i < 24; i++)
        {
            if (AkagonohateData.runner[i] != -1)
            {
                int keisan = AkagonohateData.runner[i] / 10;
                switch (keisan)
                {
                    case 0: AkagonohateData.KshinaiPt[0]++; break;
                    case 1: AkagonohateData.KshinaiPt[1]++; break;
                    case 2: AkagonohateData.KshinaiPt[2]++; break;
                    case 3: AkagonohateData.KshinaiPt[3]++; break;
                    case 4: AkagonohateData.KshinaiPt[4]++; break;
                    case 5: AkagonohateData.KshinaiPt[5]++; break;
                }
            }
        }
        //��������̂�1/2���鏈���@�{�e��Pt�f�[�^�ɉ��Z
        for (int i = 0; i < 6; i++)
        {
            AkagonohateData.KshinaiPt[i] = AkagonohateData.KshinaiPt[i]/2;
            AkagonohateData.shinaiPt[i] += AkagonohateData.KshinaiPt[i];
        }

        //�A�l���f�[�gPt�F
        //(�������{���[���A�{�C�x���g���U)*�����E�F�C�����]��(�D�F3�A�ǁF1.5�A�F0.7)��8*3=24�g���@(�v����)
        //���e�L�������Ƃɕ����ĉ��Z
        //��������E�U�����ŏ�悹���ꂽ���́A1�ɂ�5�����Z
        //�ϐ��̏�����
        for (int i = 0; i < 6; i++)
        {
            AkagonohateData.KdatePt[i] = 0;
        }
        //�v�Z
        for (int i = 0; i < 24; i++)
        {
            int Event = 0;
            int res = 0;
            int tmp = 0;
            //�C�x���g���U�X�e�[�^�X�̌v�Z(���A�x�ɂ�蕪��) ���C�x���g���̂�
            if (AkagonohateData.runner[i] != -1)
            {
                if (AkagonohateData.eventFlg == 1)
                {
                    int keisan = AkagonohateData.runner[i] % 10;
                    if (keisan == 0 || keisan == 1)
                    {
                        Event = 1;
                    }
                    else if (keisan == 2 || keisan == 3)
                    {
                        Event = 2;
                    }
                    else if (AkagonohateData.runner[i] == pickUp1 || AkagonohateData.runner[i] == pickUp2)
                    {
                        Event = 30;
                    }
                    else
                    {
                        Event = 12;
                    }
                }
                //Debug.Log(AkagonohateData.runner[i]);
                //Debug.Log("bi=" + bi[AkagonohateData.runner[i]] + "hu=" + hu[AkagonohateData.runner[i]]);
                res = (bi[AkagonohateData.runner[i]] + hu[AkagonohateData.runner[i]] + Event);
                switch (AkagonohateData.runwayRes[3])
                {
                    case 1: tmp = res * 3; break;
                    case 2: tmp = res * 15 / 10; break;
                    case 3: tmp = res * 7 / 10; break;
                }
                //�L�������ƂɐU�蕪��
                int keisan2 = AkagonohateData.runner[i] / 10;
                switch (keisan2)
                {
                    case 0: AkagonohateData.KdatePt[0] += tmp; break;
                    case 1: AkagonohateData.KdatePt[1] += tmp; break;
                    case 2: AkagonohateData.KdatePt[2] += tmp; break;
                    case 3: AkagonohateData.KdatePt[3] += tmp; break;
                    case 4: AkagonohateData.KdatePt[4] += tmp; break;
                    case 5: AkagonohateData.KdatePt[5] += tmp; break;
                }
            }
        }
        //�l���������Z�@���ݒ肳��Ă���L�����ɂ̂�
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 24; j++) {
                Debug.Log("AkagonohateData.runner[j]=" + AkagonohateData.runner[j]+"  i="+i);
                int tmp = AkagonohateData.runner[j] / 10;
                Debug.Log(tmp);
                if (tmp == i && AkagonohateData.runner[j] != -1) {
                    Debug.Log("���@"+moTMP * 5);
                    Debug.Log(AkagonohateData.KdatePt[i]+" moTMP="+moTMP+" yuTMP="+yuTMP);
                    AkagonohateData.KdatePt[i] += moTMP * 5;
                    AkagonohateData.KdatePt[i] += yuTMP * 5;
                    //Debug.Log(AkagonohateData.KdatePt[i]);
                    break;
                }
            }
        }

        //�l���K���㏑��
        AkagonohateData.KItem[0] = 0;
        for (int i = 0; i < 6; i++) {
            AkagonohateData.KItem[0] += AkagonohateData.KdatePt[i];
        }

        //�l���{�[�i�X�l(�l���ɂ���Ċ��葝�����ꂽ�f�[�gPt�̍��v�l)�̏㏑��
        AkagonohateData.KItem[3] = moTMP;
        AkagonohateData.KItem[4] = yuTMP;
        AkagonohateData.KItem[5] = niTMP;
        Debug.Log(AkagonohateData.KItem[3] + " " + AkagonohateData.KItem[4] + " " + AkagonohateData.KItem[5]);

        //���̏������������E�㏑��
        AkagonohateData.itemSyojisu[2]--;
        //�l���A�C�e���������������E�㏑��
        AkagonohateData.itemSyojisu[3] -= moTMP;
        AkagonohateData.itemSyojisu[4] -= yuTMP;
        AkagonohateData.itemSyojisu[5] -= niTMP;
        AkagonohateData.moZen = moTMP;
        AkagonohateData.yuZen = yuTMP;
        AkagonohateData.niZen = niTMP;

        //�����E�F�C�݌v�񐔂̏㏑��
        //���̉񕜃J�E���g���n�܂�ꍇ�A���̏���J�n���Ԃ��㏑��
        if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] >= 4) {
            AkagonohateData.runwayRireki[1] = today;
        }
        //���̓����߂Ẵ����E�F�C�̏ꍇ�A�ϐ��̏�����
        if (AkagonohateData.runwayRireki[0].Date != today.Date) {
            AkagonohateData.countDay[1] = 0;
        }
        AkagonohateData.countDay[1]++;
        //���̏T���߂Ẵ����E�F�C�̏ꍇ�A�ϐ��̏�����
        //���T�̍ŏ��̓�(���j��)���擾
        DateTime dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
        if (dtLastMonday <= today)
        {
            AkagonohateData.countDay[3] = 0;
        }
        AkagonohateData.countDay[3]++;
        AkagonohateData.runwayRireki[0] = today;

        SceneManager.LoadScene("11Runway");
    }

    private void Update()
    {
        //���������̎擾
        today = localDate;
    }
}
