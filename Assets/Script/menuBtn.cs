using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject key;
    [SerializeField] GameObject ken;
    //�v���[���g
    [SerializeField] GameObject giftBtnBase;
    [SerializeField] GameObject giftBtnSumi;
    [SerializeField] GameObject giftBtnMi;
    [SerializeField] GameObject giftBase;
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
        ScrollGifts.SetActive(true);
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
        ScrollGifts.SetActive(false);
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
        ken.SetActive(false);
        key.SetActive(false);

        //�A�C�e���\���̐؂�ւ�
        //�����̉�1���ŏ��i�摜�𔻕�
        int syouhinIMG = num % 10;
        switch (syouhinIMG)
        {
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
                AkagonohateData.itemSyojisu[6] += syouhinKosu - (5-(AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]));
            }
            else 
            {
                AkagonohateData.itemSyojisu[6] += syouhinKosu;
            }
        }

        //�w�����̏㏑��(�f�[�^)
        switch (syouhinIMG)
        {
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
        AkagonohateData.itemSyojisu[2] += kaifukusu;
        AkagonohateData.itemSyojisu[6] -= kaifukusu;

        //UI����
        popupBase2.SetActive(true);
        kakutoku.SetActive(false);
        kaihuku.SetActive(true);
        kaifukuT.text = "����"+kaifukusu+"�񕜂��܂����I";
    }
}
