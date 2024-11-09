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
    //���T�C�Y�{�^��
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    //���j���[�̃^�C�g������(�|�b�v�A�b�v�㕔)
    [SerializeField] GameObject creditT;
    [SerializeField] GameObject syojidogukakuninT;
    [SerializeField] GameObject riyokiyakuT;
    [SerializeField] GameObject otoiawaseT;
    [SerializeField] GameObject partnersentakuT;
    [SerializeField] GameObject akaoninohateT;
    [SerializeField] GameObject yuryoT;
    [SerializeField] GameObject giftT;
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
    [SerializeField] GameObject yuryoItemAll;
    //�w�i
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject haikeiC;
    [SerializeField] GameObject haikeiS;
    [SerializeField] GameObject haikeiR;
    [SerializeField] GameObject haikeiO;
    //���₢���킹
    [SerializeField] GameObject otoiawaseText;
    [SerializeField] GameObject setsumeibun;
    [SerializeField] GameObject soushinBtn;
    [SerializeField] GameObject uketamawarimashita;
    [SerializeField] GameObject cHome;
    //�X�N���[��
    [SerializeField] GameObject ScrollCredit;
    [SerializeField] GameObject ScrollRiyokiyaku;
    [SerializeField] GameObject ScrollIsyou;
    [SerializeField] GameObject ScrollGifts;
    [SerializeField] GameObject ScrollSyojiItem;


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
        otoiawase.SetActive(true);
        popupBase.SetActive(true);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
    }

    /// <summary>
    /// �N���W�b�g���j���[�\��
    /// </summary>
    public void showPopUpC()
    {
        batsu.SetActive(false);
        batsuC.SetActive(true);
        credit.SetActive(false);
        creditT.SetActive(true);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiC.SetActive(true);
        ScrollCredit.SetActive(true);
    }

    /// <summary>
    /// ��������m�F���j���[�\��
    /// </summary>
    public void showPopUpS()
    {
        batsu.SetActive(false);
        batsuS.SetActive(true);
        credit.SetActive(false);
        syojidogukakuninT.SetActive(true);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiS.SetActive(true);

        ScrollSyojiItem.SetActive(true);

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
        riyokiyakuT.SetActive(true);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiR.SetActive(true);
        ScrollRiyokiyaku.SetActive(true);
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
        otoiawase.SetActive(false);
        otoiawaseT.SetActive(true);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiO.SetActive(true);
        otoiawaseText.SetActive(true);
        setsumeibun.SetActive(true);
        cHome.GetComponent<sendMail>().BtnFlg();
    }

    /// <summary>
    /// �p�[�g�i�[����ւ����j���[�\��
    /// </summary>
    public void showPopUpP()
    {
        batsu.SetActive(true);
        partnersentakuT.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        ScrollIsyou.SetActive(true);
        cHome.GetComponent<cHome>().syokihyouji();
    }

    /// <summary>
    /// �g�S�̉ʃ��j���[�\��
    /// </summary>
    public void showPopUpA()
    {
        batsu.SetActive(true);
        akaoninohateT.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        akaoninohate.SetActive(true);
        textA.SetActive(true);
        yondemiru.SetActive(true);
    }

    /// <summary>
    /// �v���[���g���j���[(���l��)�\���@�������\��
    /// </summary>
    public void showPopUpGMi()
    {
        batsu.SetActive(true);
        giftT.SetActive(true);
        giftBtnBase.SetActive(true);
        giftBtnSumi.SetActive(true);
        giftBtnMi.SetActive(false);
        haikei.SetActive(true);
        popupBase.SetActive(true);
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
    /// �L���ۋ����j���[�\��
    /// </summary>
    public void showPopUpY()
    {
        batsu.SetActive(true);
        yuryoT.SetActive(true);
        yuryoItemAll.SetActive(true);
        popupBase.SetActive(true);
        haikei.SetActive(true);
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
        partnersentakuT.SetActive(false);
        akaoninohateT.SetActive(false);
        akaoninohate.SetActive(false);
        textA.SetActive(false);
        yondemiru.SetActive(false);
        giftT.SetActive(false);
        giftBtnBase.SetActive(false);
        giftBtnMi.SetActive(false);
        giftBtnSumi.SetActive(false);
        yuryoItemAll.SetActive(false);
        yuryoT.SetActive(false);
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
        creditT.SetActive(false);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
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
        syojidogukakuninT.SetActive(false);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
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
        riyokiyakuT.SetActive(false);
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
        otoiawase.SetActive(true);
        otoiawaseT.SetActive(false);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiO.SetActive(false);
        otoiawaseText.SetActive(false);
        setsumeibun.SetActive(false);
        soushinBtn.SetActive(false);
        uketamawarimashita.SetActive(false);
    }

    /// <summary>
    /// �O�������N(�g�S�̉�)�ւ̑J��
    /// </summary>
    public void goAkaoninohate() {
        Application.OpenURL("https://www.amazon.co.jp/dp/B09MP8RCTP?binding=kindle_edition&searchxofy=true&ref_=dbs_s_aps_series_rwt_tkin&qid=1729922059&sr=8-4");
    }

    /// <summary>
    /// �w���{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void konyu(int num) {
        //�X�g�A�ɔ�΂������������ɒǋL

        //�|�b�v�A�b�v�̕\���̏�����
        popupBase2.SetActive(true);
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

        //�w�����̏㏑��(�f�[�^)
        switch (syouhinIMG)
        {
            case 1: AkagonohateData.itemSyojisu[1] += syouhinKosu; break; //�d����
            case 2: AkagonohateData.itemSyojisu[2] += syouhinKosu; break; //��
        }
    }

    /// <summary>
    /// �w����̃|�b�v�A�b�v����������
    /// </summary>
    public void konyuEnd() {
        popupBase2.SetActive(false);
    }
}
