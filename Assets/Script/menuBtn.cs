using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuBtn : MonoBehaviour
{
    //�f�ނ̒�`
    //�~��
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject batsuC;
    [SerializeField] GameObject batsuS;
    [SerializeField] GameObject batsuR;
    [SerializeField] GameObject batsuO;
    [SerializeField] GameObject batsuSe;
    //���T�C�Y�{�^��
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject serialBtn;
    //���j���[�̃^�C�g������(�|�b�v�A�b�v�㕔)
    [SerializeField] GameObject titleText;
    [SerializeField] Text titleTextT;
    //���C�����j���[
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    //��������m�F
    [SerializeField] Text[] syojisus;
    [SerializeField] GameObject[] items;
    [SerializeField] GameObject arimasen;
    //�A�C�e���w��
    [SerializeField] GameObject popupBase2;
    [SerializeField] Text konyusu;
    [SerializeField] GameObject zeni;
    [SerializeField] GameObject key;
    [SerializeField] GameObject ken;
    //�v���[���g
    [SerializeField] GameObject giftBtnBase;�@//�؂�ւ��p�{�^���f��
    [SerializeField] GameObject giftBtnSumi;�@//�؂�ւ��p�{�^���f��
    [SerializeField] GameObject giftBtnMi;�@//�؂�ւ��p�{�^���f��
    //[SerializeField] GameObject giftBase;�@//�g���Ă��Ȃ��HcHome���A�^�b�`���Ă���
    [SerializeField] GameObject giftItems;//���l���E�l���ς݂̃v���[���g�S��(�X�N���[���o�[����)
    [SerializeField] GameObject giftMis;�@//���l���̃v���[���g�S��(�X�N���[���o�[����)
    [SerializeField] GameObject giftSumis;//�l���ς݂̃v���[���g�S��(�X�N���[���o�[����)
    [SerializeField] GameObject[] giftMi;  //�v���[���g(���l��)�̃I�u�W�F�N�g(���������ݗp�ӂ��Ă���v���[���g�̑���)
    [SerializeField] GameObject[] giftSumi;//�v���[���g(�l���ς�)�̃I�u�W�F�N�g(���������ݗp�ӂ��Ă���v���[���g�̑���)
    [SerializeField] Text[] giftKigenMi;  //�v���[���g(���l��)�󂯎�����(���������ݗp�ӂ��Ă���v���[���g�̑���)
    [SerializeField] Text[] giftKigenSumi;//�v���[���g(�l���ς�)��������(���������ݗp�ӂ��Ă���v���[���g�̑���)
    [SerializeField] GameObject tuchi;�@//�ʒm�̐Ԋ�
    [SerializeField] GameObject[] arimasenT; //����܂���e�L�X�g(0�F���l���A1�G�l������)

    [SerializeField] GameObject childObjectPrefab;
    [SerializeField] Transform parent;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Text kazuPrefab;
    [SerializeField] Text titlePrefab;
    [SerializeField] Text rirekiPrefab;
    //�g�S�̉�
    [SerializeField] GameObject akaoninohate;
    [SerializeField] GameObject yondemiru;
    [SerializeField] GameObject textA;
    //�L���A�C�e�����j���[
    [SerializeField] GameObject yuryoItemAll;
    [SerializeField] GameObject kakutoku;
    //���̒ǉ����j���[
    [SerializeField] GameObject kaginotsuikaAll;
    [SerializeField] Text kagigaT;
    [SerializeField] Text kosu;
    [SerializeField] Text kaifukuT;
    [SerializeField] GameObject plusBtn;
    [SerializeField] GameObject minusBtn;
    [SerializeField] GameObject kaifukuBtn;
    [SerializeField] GameObject kaihuku;
    //�w�i
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject haikeiC;
    [SerializeField] GameObject haikeiS;
    [SerializeField] GameObject haikeiR;
    [SerializeField] GameObject haikeiO;
    [SerializeField] GameObject haikeiSe;
    //���₢���킹
    [SerializeField] GameObject otoiawaseAll;
    [SerializeField] GameObject soushinBtn;
    [SerializeField] GameObject uketamawarimashita;
    [SerializeField] GameObject popUpMenu;
    //�V���A���R�[�h���͉��
    [SerializeField] GameObject serialCodeAll;
    //�X�N���[��
    [SerializeField] GameObject ScrollCredit;
    [SerializeField] GameObject ScrollRiyokiyaku;
    [SerializeField] GameObject ScrollIsyou;
    [SerializeField] GameObject ScrollGifts;
    [SerializeField] GameObject ScrollSyojiItem;

    /// <summary>
    /// ���񕜃|�b�v�A�b�v�Ō��̉񕜐��Ɏg�p
    /// </summary>
    int kaifukusu = 1;

    /// <summary>
    /// �v���[���g�E��̐Ԋےʒm�𐧌䂷��t���O
    /// </summary>
    int hyoujiFlg = 0;

    //���t�擾
    DateTime localDate = DateTime.Now;
    DateTime today;

    private void Start()
    {
        //�������t�̎擾
        today = localDate.Date;

        //�i�v���[���g�p�jgiftFlg�̏�����
        for (int i = 0; i < 10; i++) {
            AkagonohateData.giftFlg[0] = -1;
        }
        //���O�C���������擾
        today = localDate.Date;
        if (AkagonohateData.loginRireki[0].Date != today.Date) {
            AkagonohateData.giftFlg[0] = 0;
        }
        cGift();
        //�v���[���g�̐Ԋےʒm����
        if (hyoujiFlg != 0)
        {
            tuchi.SetActive(true);
        }
        else
        {
            tuchi.SetActive(false);
        }
    }

    //-----�\���n-----

    /// <summary>
    /// ���j���[�S�̂�\��
    /// </summary>
    public void showPopUp()
    {
        batsu.SetActive(true);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        serialBtn.SetActive(true);
        otoiawase.SetActive(true);
        popupBase.SetActive(true);
        koukaonBGM.SetActive(true);
        titleText.SetActive(true);
        haikei.SetActive(true);
        titleTextT.text = "�e�@��@���@�j�@���@�[";
    }

    /// <summary>
    /// �N���W�b�g���j���[�\��
    /// </summary>
    public void showPopUpC()
    {
        batsu.SetActive(false);
        batsuC.SetActive(true);
        credit.SetActive(false);
        titleText.SetActive(true);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiC.SetActive(true);
        ScrollCredit.SetActive(true);
        titleTextT.text = "�N�@���@�W�@�b�@�g";
    }

    /// <summary>
    /// ��������m�F���j���[�\��
    /// </summary>
    public void showPopUpS()
    {
        batsu.SetActive(false);
        batsuS.SetActive(true);
        credit.SetActive(false);
        titleText.SetActive(true);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiS.SetActive(true);

        ScrollSyojiItem.SetActive(true);
        titleTextT.text = "���@���@���@��@�m�@�F";

        //�A�C�e���������̕\��
        //������
        for (int i = 0; i < 9; i++)
        {
            items[i].SetActive(true);
        }

        //�e�L�����̌ŗL�A�C�e��
        for (int i = 0; i < 6; i++) {
            syojisus[i].text = AkagonohateData.itemSyojisu[i + 10].ToString();
        }
        //���̑��A�C�e���͌ʂɐݒ�
        syojisus[6].text = AkagonohateData.itemSyojisu[3].ToString();�@//������
        syojisus[7].text = AkagonohateData.itemSyojisu[4].ToString();�@//�U����
        syojisus[8].text = AkagonohateData.itemSyojisu[5].ToString();�@//�ו�����
        syojisus[9].text = AkagonohateData.itemSyojisu[2].ToString();�@//��

        //������0�������ꍇ�A�I�u�W�F�N�g��\��
        int count = 0;
        for (int i = 0; i < 9; i++) {
            if (syojisus[i].text == "0") {
                items[i].SetActive(false);
                count++;
            }
        }
        if (count == 0)
        {
            arimasen.SetActive(true);
        }
        else
        {
            arimasen.SetActive(false);
        }
    }

    /// <summary>
    /// ���p�K�񃁃j���[�\��
    /// </summary>
    public void showPopUpR()
    {
        batsu.SetActive(false);
        batsuR.SetActive(true);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        titleText.SetActive(true);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiR.SetActive(true);
        ScrollRiyokiyaku.SetActive(true);

        titleTextT.text = "���@�p�@�K�@��";
    }

    /// <summary>
    /// ���₢���킹���j���[�\��
    /// </summary>
    public void showPopUpO()
    {
        batsu.SetActive(false);
        batsuO.SetActive(true);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        otoiawase.SetActive(false);
        titleText.SetActive(true);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiO.SetActive(true);
        otoiawaseAll.SetActive(true);
        popUpMenu.GetComponent<sendMail>().BtnFlg();
        titleTextT.text = "���@��@���@���@��@��";
    }

    /// <summary>
    /// �p�[�g�i�[����ւ����j���[�\��
    /// </summary>
    public void showPopUpP()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        ScrollIsyou.SetActive(true);
        popUpMenu.GetComponent<cHome>().syokihyouji();
        titleTextT.text = "�p�@�[�@�g�@�i�@�[�@�I�@��";
    }

    /// <summary>
    /// �g�S�̉ʃ��j���[�\��
    /// </summary>
    public void showPopUpA()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        akaoninohate.SetActive(true);
        textA.SetActive(true);
        yondemiru.SetActive(true);
        titleTextT.text = "�g�@�S�@�́@��";
    }

    /// <summary>
    /// �v���[���g���j���[(���l��)�\���@�������\��
    /// </summary>
    public void showPopUpGMi()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        giftBtnBase.SetActive(true);
        giftMis.SetActive(true);
        giftSumis.SetActive(false);
        giftItems.SetActive(true);
        giftBtnSumi.SetActive(true);
        giftBtnMi.SetActive(false);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        titleTextT.text = "�v�@���@�[�@���@�g";
    }

    /// <summary>
    /// �v���[���g���j���[(�l����)�\��
    /// </summary>
    public void showPopUpGSumi()
    {
        giftBtnBase.SetActive(true);
        giftBtnSumi.SetActive(false);
        giftBtnMi.SetActive(true);
        giftMis.SetActive(false);
        giftSumis.SetActive(true);

        //����\���̐���
        //��30���O�܂ł̗�����ۊ�
        TimeSpan month30 = new TimeSpan(0, 30, 0, 0);
        DateTime kijyunbi = today - month30;
        int count = AkagonohateData.giftTitle.Count;
        for (int i = 0; i < count; i++)
        {
            if (AkagonohateData.giftTime[i] >= kijyunbi)
            {
                //���(30���O)����Ɏ󂯎�����v���[���g�ł���Ε\��
                Instantiate(childObjectPrefab, new Vector3(50, -150, 0), Quaternion.identity, parent);

                //�l�����̏㏑��
                Text kazu = Instantiate(kazuPrefab);
                kazu.text = "�~"+(AkagonohateData.giftKosu[i] / 10).ToString();

                //�v���[���g���̏㏑��
                Text title = Instantiate(titlePrefab);
                title.text = AkagonohateData.giftTitle[i];

                //�l�����̏㏑��
                Text time = Instantiate(rirekiPrefab);
                int year = AkagonohateData.giftTime[i].Year;
                int month = AkagonohateData.giftTime[i].Month;
                int day = AkagonohateData.giftTime[i].Day;
                title.text = "�l�����F" + year + "/" + month + "/" + day;
            }
            else
            {
                //���(30���O)���O�Ɏ󂯎�����v���[���g�ł���΃f�[�^���폜
                AkagonohateData.giftTime.Remove(AkagonohateData.giftTime[i]);
                AkagonohateData.giftTitle.Remove(AkagonohateData.giftTitle[i]);
                AkagonohateData.giftKosu.Remove(AkagonohateData.giftKosu[i]);
            }
        }
    }

    /// <summary>
    /// ���̒ǉ����j���[�\��
    /// </summary>
    public void showPopUpK()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        kaginotsuikaAll.SetActive(true);
        popupBase.SetActive(true);
        haikei.SetActive(true);
        minusBtn.SetActive(false);
        titleTextT.text = "���@�́@�ǁ@��";
        kagigaT.text = "�񕜂Ɏg�p�ł��錮������܂��I";

        //�񕜂ł��錮�������ꍇ�͉񕜃{�^�����\��
        int tmp = 5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]);
        if (tmp == 0 || AkagonohateData.itemSyojisu[6] == 0)
        {
            kosu.text = "1";
            kagigaT.text = "�񕜂Ɏg�p�ł��錮������܂���";
            minusBtn.SetActive(false);
            plusBtn.SetActive(false);
            kaifukuBtn.SetActive(false);
        }
        //�񕜂ł��錮��1�݂̂̏ꍇ�́{�{�^�����\��
        if (tmp == 1 || AkagonohateData.itemSyojisu[6] == 1)
        {
            plusBtn.SetActive(false);
        }
    }

    /// <summary>
    /// �L���ۋ����j���[�\��
    /// </summary>
    public void showPopUpY()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        yuryoItemAll.SetActive(true);
        popupBase.SetActive(true);
        haikei.SetActive(true);
        titleTextT.text = "�L�@���@���@�i";
        kaginotsuikaAll.SetActive(false);
    }

    /// <summary>
    /// �V���A���R�[�h���j���[�\��
    /// </summary>
    public void showPopUpSe()
    {
        batsu.SetActive(false);
        batsuSe.SetActive(true);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        serialCodeAll.SetActive(true);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiSe.SetActive(true);

        titleTextT.text = "�V�@���@�A�@���@�R�@�[�@�h�@���@��";
    }

    //-----��\���n-----

    /// <summary>
    /// ���j���[�S�̂��\�� ������
    /// </summary>
    public void closePopUp()
    {
        batsu.SetActive(false);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        otoiawase.SetActive(false);
        popupBase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        titleText.SetActive(false);
        akaoninohate.SetActive(false);
        textA.SetActive(false);
        yondemiru.SetActive(false);
        giftBtnBase.SetActive(false);
        giftBtnMi.SetActive(false);
        giftBtnSumi.SetActive(false);
        yuryoItemAll.SetActive(false);
        kaginotsuikaAll.SetActive(false);
        serialBtn.SetActive(false);
        ScrollIsyou.SetActive(false);
        giftItems.SetActive(false);
    }

    /// <summary>
    /// �N���W�b�g���j���[��\��
    /// </summary>
    public void closePopUpC()
    {
        batsu.SetActive(true);
        batsuC.SetActive(false);
        credit.SetActive(true);
        titleText.SetActive(false);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
        serialBtn.SetActive(true);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiC.SetActive(false);
        ScrollCredit.SetActive(false);
    }

    /// <summary>
    /// ��������m�F���j���[��\��
    /// </summary>
    public void closePopUpS()
    {
        batsu.SetActive(true);
        batsuS.SetActive(false);
        credit.SetActive(true);
        titleText.SetActive(false);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
        serialBtn.SetActive(true);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiS.SetActive(false);

        ScrollSyojiItem.SetActive(false);
    }

    /// <summary>
    /// ���p�K�񃁃j���[��\��
    /// </summary>
    public void closePopUpR()
    {
        batsu.SetActive(true);
        batsuR.SetActive(false);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        serialBtn.SetActive(true);
        titleText.SetActive(false);
        otoiawase.SetActive(true);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiR.SetActive(false);
        ScrollRiyokiyaku.SetActive(false);
    }

    /// <summary>
    /// ���₢���킹���j���[��\��
    /// </summary>
    public void closePopUpO()
    {
        batsu.SetActive(true);
        batsuO.SetActive(false);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        serialBtn.SetActive(true);
        otoiawase.SetActive(true);
        titleText.SetActive(false);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiO.SetActive(false);
        otoiawaseAll.SetActive(false);
        soushinBtn.SetActive(false);
        uketamawarimashita.SetActive(false);
    }

    /// <summary>
    /// �V���A���R�[�h���j���[��\��
    /// </summary>
    public void closePopUpSe()
    {
        batsu.SetActive(true);
        batsuSe.SetActive(false);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
        serialBtn.SetActive(true);
        titleText.SetActive(false);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiSe.SetActive(false);
        serialCodeAll.SetActive(false);
    }

    /// <summary>
    /// �O�������N(�g�S�̉�)�ւ̑J��
    /// </summary>
    public void goAkaoninohate() {
        Application.OpenURL("https://www.amazon.co.jp/dp/B09MP8RCTP?binding=kindle_edition&searchxofy=true&ref_=dbs_s_aps_series_rwt_tkin&qid=1729922059&sr=8-4");
    }

    /// <summary>
    /// �w���{�^���������ꂽ�Ƃ��̏����@
    /// </summary>
    public void store()
    {
        //�X�g�A�ɔ�΂������������ɒǋL

    }

    /// <summary>
    /// �w���{�^���������ꂽ�Ƃ��̏����A
    /// </summary>
    public void konyu(int num) {
        //�|�b�v�A�b�v�̕\���̏�����
        popupBase2.SetActive(true);
        kakutoku.SetActive(true);
        kaihuku.SetActive(false);
        zeni.SetActive(false);
        ken.SetActive(false);
        key.SetActive(false);

        //�A�C�e���\���̐؂�ւ�
        //�����̉�1���ŏ��i�摜�𔻕�
        int syouhinIMG = num % 10;
        switch (syouhinIMG)
        {
            case 0: zeni.SetActive(true); break; //�K
            case 1: ken.SetActive(true); break; //�d����
            case 2: key.SetActive(true); break; //��
        }

        //�w�����̏㏑��(�\��)
        //�����̏�n���ōw�����𔻕�
        int syouhinKosu = num / 10;
        konyusu.text = "�~  " + syouhinKosu;

        //�����w�������ꍇ�́A�]�蕪���l��
        if (syouhinIMG == 2)
        {
            if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] < 5)
            {
                AkagonohateData.itemSyojisu[6] += syouhinKosu - (5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]));
            }
            else
            {
                AkagonohateData.itemSyojisu[6] += syouhinKosu;
            }
        }

        //�w�����̏㏑��(�f�[�^)
        switch (syouhinIMG)
        {
            case 0: AkagonohateData.itemSyojisu[0] += syouhinKosu; break; //�K
            case 1: AkagonohateData.itemSyojisu[1] += syouhinKosu; break; //�d����
            case 2: AkagonohateData.itemSyojisu[2] += syouhinKosu; break; //��
        }

        Debug.Log(AkagonohateData.itemSyojisu[2]);
        Debug.Log(AkagonohateData.itemSyojisu[6]);
    }

    /// <summary>
    /// �w����̃|�b�v�A�b�v����������
    /// </summary>
    public void konyuEnd() {
        popupBase2.SetActive(false);
        kakutoku.SetActive(false);
        kaihuku.SetActive(false);
    }

    /// <summary>
    /// �v���[���g�\��
    /// </summary>
    public void cGift() {
        //�ʒm�A�C�R���̏�����
        tuchi.SetActive(false);

        //�S�v���[���g�\���̏�����
        for (int i = 0; i < 10; i++)
        {
            giftMi[i].SetActive(false);
        }

        //�t���O��0�̏ꍇ�A�v���[���g��\��
        //���O�C���{�[�i�X�@(giftFlg�F0�Ԗ�)
        if (AkagonohateData.giftFlg[0] == 0) {
            //�v���[���g�\��
            giftMi[0].SetActive(true);

            //�l�������̏㏑��(������)
            int year = today.Year;
            int month = today.Month;
            int day = today.Day;
            giftKigenMi[0].text = "�l�������F"+ year + "/" + month + "/" + day;
            hyoujiFlg++;
        }

        //���̑��v���[���g�͊l���������������邽�߁A����for���ŏ���
        DateTime[] fuyobi = new DateTime[10];
        //�v���[���g�t�^�J�n������1�T�Ԍ���擾
        TimeSpan week = new TimeSpan(7, 0, 0, 0);

        //�v���[���g�t�^�J�n�� ���v���[���g��t�^���������ɓs�x�C�� ��fuyobi[]�̒l�̏㏑���͕K��1�T�Ԉȏ㎞�Ԃ������Ă�����{
        //�y�Q�l�z
        //�s��̂��l�ч@�@(giftFlg�F1�Ԗ�)
        //�s��̂��l�чA�@(giftFlg�F2�Ԗ�)�@//�s������d�ɔ��������Ƃ��p
        //�s��̂��l�чB�@(giftFlg�F3�Ԗ�)�@//�s������d�ɔ��������Ƃ��p
        //�C�x���g�Q���L�O�v���[���g�@(giftFlg�F4�Ԗ�)
        //�g�S�̉ʍŐV�b���J�L�O�v���[���g�@(giftFlg�F5�Ԗ�)
        //����@(giftFlg�F6�`9�Ԗ�)
        fuyobi[1] = new DateTime(2024, 11, 10, 0, 0, 0);
        fuyobi[2] = new DateTime(2024, 11, 11, 0, 0, 0);
        fuyobi[3] = new DateTime(2024, 11, 12, 0, 0, 0);
        fuyobi[4] = new DateTime(2024, 11, 13, 0, 0, 0);
        fuyobi[5] = new DateTime(2024, 11, 19, 0, 0, 0);
        fuyobi[6] = new DateTime(2024, 11, 19, 0, 0, 0);
        fuyobi[7] = new DateTime(2024, 10, 19, 0, 0, 0);
        fuyobi[8] = new DateTime(2024, 11, 19, 0, 0, 0);
        fuyobi[9] = new DateTime(2024, 11, 19, 0, 0, 0);

        for (int i = 1; i < 10; i++)
        {
            if (AkagonohateData.giftFlg[i] == 0)
            {
                //�v���[���g�\��
                giftMi[i].SetActive(true);

                //�l�������̏㏑��(1�T�Ԃ��炢�H)
                //�v���[���g�t�^�J�n��
                if (AkagonohateData.uketoriKigen[i] == null || AkagonohateData.uketoriKigen[i] < fuyobi[i])
                {
                    Debug.Log(i);
                    Debug.Log(AkagonohateData.uketoriKigen[i]);
                    AkagonohateData.uketoriKigen[i] = fuyobi[i].Date + week;
                    //�󂯎��������߂��Ă������\���ɂ���
                    if (AkagonohateData.uketoriKigen[i].Date >= today.Date)
                    {
                        //�󂯎��������̏ꍇ
                        int year = AkagonohateData.uketoriKigen[i].Year;
                        int month = AkagonohateData.uketoriKigen[i].Month;
                        int day = AkagonohateData.uketoriKigen[i].Day;
                        giftKigenMi[i].text = "�l�������F" + year + "/" + month + "/" + day;
                        hyoujiFlg++;
                    }
                    else
                    {
                        //�󂯎�������̏ꍇ
                        giftMi[i].SetActive(false);
                    }
                }
            }
        }
        //�Ԋےʒm�\����\������
        if (hyoujiFlg != 0)
        {
            tuchi.SetActive(true);
        }
        else
        {
            tuchi.SetActive(false);
        }
    }

    /// <summary>
    /// �v���[���g�l���{�^���������̏����@ �������F�l����(��n��)�{�A�C�e�����(��1��)
    /// </summary>
    public void giftKakutoku1(int giftNo) {
        //�����̉�1���ŏ��i�摜(���)�𔻕�
        int itemIMG = giftNo % 10;

        //�����̏�n���ōw�����𔻕�
        int itemKosu = giftNo / 10;

        //���������X�g�Ɋi�[�@���^�C�g���͉��̃��\�b�h�Œǉ�(�{�^���������̈����Ƀ^�C�g�������w��)
        AkagonohateData.giftKosu.Add(giftNo);
        AkagonohateData.giftTime.Add(today);

        //�|�b�v�A�b�v�\�������ɔ�΂�
        konyu(giftNo);
    }

    /// <summary>
    /// �v���[���g�l���{�^���������̏����A �������F�v���[���g�ʂ��ԍ�(0�`9)+�v���[���g��
    /// </summary>
    /// <param name="title"></param>
    public void giftKakutoku2(string title)
    {
        //�^�C�g���̍ŏ���1����(�v���[���g�ʂ��ԍ�����)��؂蕪��
        int giftNo = int.Parse(title.Substring(0, 1));

        //�^�C�g������ʂ��ԍ����폜
        string titleAfter = title.Remove(0, 1);

        //�M�t�g�t���O�̏�������(0��2)
        AkagonohateData.giftFlg[giftNo] = 2;

        //���������X�g�Ɋi�[�@���^�C�g���̂�
        AkagonohateData.giftTitle.Add(title);

        //�v���[���g�󂯎��|�b�v�A�b�v�\���̍X�V
        cGift();
    }

    //�ȉ��A���̒ǉ����j���[�֘A

    /// <summary>
    /// +�{�^���������̏���
    /// </summary>
    public void pushPlus() {
        //�񕜐��𑀍�
        kaifukusu++;
        kosu.text = kaifukusu.ToString();

        //UI����
        int tmp = 5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]);
        if (kaifukusu >= tmp)
        {
            plusBtn.SetActive(false);
        }
        minusBtn.SetActive(true);
        kaifukuBtn.SetActive(true);

        //����̏ꍇ��+�{�^�����\��
        //int tmp2 = 5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]);
        Debug.Log(AkagonohateData.itemSyojisu[2]);
        Debug.Log(AkagonohateData.itemSyojisu[6]);
        Debug.Log(tmp);
        //if (tmp2 == kaifukusu)
        //{
        //    plusBtn.SetActive(false);
        //}
    }

    public void pushMinus() {
        //�񕜐��𑀍�
        kaifukusu--;
        kosu.text = kaifukusu.ToString();

        //UI����
        plusBtn.SetActive(true);

        //�񕜐�==1�̏ꍇ�̑���
        if (kaifukusu == 1)
        {
            minusBtn.SetActive(false);
        }
    }

    /// <summary>
    /// ���́u�񕜁v�{�^���������̏���
    /// </summary>
    public void kaifuku() {
        //�v�Z(�]�茮�����)
        AkagonohateData.itemSyojisu[6] -= kaifukusu;

        //UI����
        popupBase2.SetActive(true);
        kakutoku.SetActive(false);
        kaihuku.SetActive(true);
        kaifukuT.text = "����"+kaifukusu+"�񕜂��܂����I";
    }

    private void Update()
    {
        //�������t�̎擾
        today = localDate.Date;
    }
}
