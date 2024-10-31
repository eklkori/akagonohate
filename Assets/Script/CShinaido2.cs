using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShinaido2 : MonoBehaviour
{
    //�������̕\���e�L�X�g��`
    public Text nameT;
    public Text zokuseiT;
    public Text jyukubunT;
    public Text shinaidoT;
    public Text dateShinchokuT;
    public Text kaiwaT;
    public Text mitsugimonoT;

    //�ߑ��̉摜�f��
    [SerializeField] GameObject naokoClose;
    [SerializeField] GameObject yasukoClose;
    [SerializeField] GameObject yoshikoClose;
    [SerializeField] GameObject hidetaClose;
    [SerializeField] GameObject hideyaClose;
    [SerializeField] GameObject yasuoClose;
    [SerializeField] GameObject[] mikaihous;
    [SerializeField] GameObject mikaihou1;
    [SerializeField] GameObject mikaihou2;
    [SerializeField] GameObject mikaihou3;
    [SerializeField] GameObject mikaihou4;
    [SerializeField] GameObject mikaihou5;
    [SerializeField] GameObject Tachie;
    [SerializeField] Image kyaraTachie;

    [SerializeField] Sprite[] kyaraImage;

    int kyara = AkagonohateData.shinaidoWho;
    void Start()
    {
        //���O�E�ߑ��{�^���̕\��
        if (kyara == 1) {
            //���O�\��
            nameT.text = ("��ɒ��q");
            //�ߑ��ꗗ�\��
            naokoClose.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i].SetActive(true);
                }
            }
            //�����G�\��
            for (int i = 0; i < 5; i++) {
                if (AkagonohateData.isyoSyojiFlg[i] == 1) {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }

        }
        if (kyara == 2)
        {
            nameT.text = ("����N�q");
            yasukoClose.SetActive(true);
            for (int i = 10; i < 15; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-10].SetActive(true);
                }
            }
            //�����G�\��
            for (int i = 10; i < 15; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 3)
        {
            nameT.text = ("�����g�q");
            yoshikoClose.SetActive(true);
            for (int i = 20; i < 25; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-20].SetActive(true);
                }
            }
            //�����G�\��
            for (int i = 20; i < 25; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 4)
        {
            nameT.text = ("����G��");
            hidetaClose.SetActive(true);
            for (int i = 30; i < 35; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-30].SetActive(true);
                }
            }
            //�����G�\��
            for (int i = 30; i < 35; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 5)
        {
            nameT.text = ("����G��");
            hideyaClose.SetActive(true);
            for (int i = 40; i < 45; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-40].SetActive(true);
                }
            }
            //�����G�\��
            for (int i = 40; i < 45; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }
        if (kyara == 6)
        {
            nameT.text = ("�匴�N�j");
            yasuoClose.SetActive(true);
            for (int i = 50; i < 55; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 0)
                {
                    mikaihous[i-50].SetActive(true);
                }
            }
            //�����G�\��
            for (int i = 50; i < 55; i++)
            {
                if (AkagonohateData.isyoSyojiFlg[i] == 1)
                {
                    Tachie.SetActive(true);
                    kyaraTachie.sprite = kyaraImage[i];
                    break;
                }
            }
        }

        //�����̕\��
        if (kyara == 1 || kyara == 6) {
            zokuseiT.text = ("�����F��������㋉�g�p�l");
        }
        if (kyara == 3 || kyara == 4)
        {
            zokuseiT.text = ("�����F�҃m�x�w��������(���k)");
        }
        if (kyara == 5)
        {
            zokuseiT.text = ("�����F�҃m�x�w����w(�w��)");
        }
        if (kyara == 2)
        {
            zokuseiT.text = ("�����F�����������");
        }

        //�Z�敪�̕\��
        if (kyara == 1 || kyara == 2 || kyara == 3 || kyara == 4)
        {
            jyukubunT.text = ("�Z�敪�F���~��");
        }
        else {
            jyukubunT.text = ("�Z�敪�F���~�O");
        }

        //�e��Lv�̕\��
        int shinaiTMP = AkagonohateData.shinaido[kyara - 1];
        shinaidoT.text = ("���݂̐e��Lv�@�@" + shinaiTMP);

        //�f�[�g�i���̕\��
        int dateTMP = AkagonohateData.dateCount[kyara - 1];
        dateShinchokuT.text = ("�f�[�g�i���@�@" + dateTMP + "��");

        //�݌v��b�񐔂̕\��
        int kaiwaTMP = AkagonohateData.kaiwaCount[kyara - 1];
        kaiwaT.text = ("�݌v��b�񐔁@�@" + kaiwaTMP + "��");

        //�݌v�v�����̕\��
        int mitsugiTMP = AkagonohateData.mitsugiCount[kyara - 1];
        mitsugimonoT.text = ("�݌v�v�����@�@" + mitsugiTMP + "��");
    }

    /// <summary>
    /// �����ߑ��{�^��(��ʉE��)�������ꂽ�Ƃ��̏���(�����G�����ւ�)
    /// </summary>
    /// <param name="isyouNo"></param>
    public void pushKyaraBtn(int isyouNo) {
        kyaraTachie.sprite = kyaraImage[isyouNo];
    }

    void Update()
    {
        
    }
}
