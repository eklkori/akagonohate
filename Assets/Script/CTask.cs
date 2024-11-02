using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTask : MonoBehaviour
{
    public Text hosyuT;
    [SerializeField] GameObject zeni;
    [SerializeField] GameObject ken;

    [SerializeField] GameObject scrollNikka;
    [SerializeField] GameObject scrollSyukan;
    [SerializeField] GameObject scrollEvent;
    [SerializeField] GameObject nikkaNo;
    [SerializeField] GameObject syukanNo;
    [SerializeField] GameObject eventNo;
    [SerializeField] GameObject[] tasseiIcon;
    [SerializeField] GameObject[] kakutokuBtnN;
    [SerializeField] GameObject[] kakutokuBtnS;
    [SerializeField] GameObject[] kakutokuBtnE;
    [SerializeField] GameObject[] kakutokuzumiN;
    [SerializeField] GameObject[] kakutokuzumiS;
    [SerializeField] GameObject[] kakutokuzumiE;
    [SerializeField] GameObject kakutokuPopup;

    /// <summary>
    /// �\�����̃^�X�N(1�F���ہA2�F�T�ԁA3�F�C�x���g)
    /// </summary>
    int hyoujiTask = 0;

    /// <summary>
    /// �l���{�^������󂯎��A�C�e�����K�������𔻒f
    /// </summary>
    int itemFlg = 0;

    /// <summary>
    /// �l�������{�^����No��\��
    /// </summary>
    int btnNo = 0;

    /// <summary>
    /// �^�X�N�̑������i�[��������AkagonohateData.tasseiFlgX�̒l���ҏW����K�v����
    /// </summary>
    [SerializeField] int countN;
    [SerializeField] int countS;
    [SerializeField] int countE;
    void Start()
    {
        //�e�X�g�p����START
        AkagonohateData.tasseiFlgN[0] = 1;
        AkagonohateData.tasseiFlgN[1] = 1;
        //�e�X�g�p����END

        showNikka();
    }

    public void showNikka() {
        hyoujiTask = 1;
        nikkaNo.SetActive(true);
        syukanNo.SetActive(false);
        eventNo.SetActive(false);
        scrollNikka.SetActive(true);
        scrollSyukan.SetActive(false);
        scrollEvent.SetActive(false);
        CBtn();
    }
    public void showSyukan()
    {
        hyoujiTask = 2;
        nikkaNo.SetActive(false);
        syukanNo.SetActive(true);
        eventNo.SetActive(false);
        scrollNikka.SetActive(false);
        scrollSyukan.SetActive(true);
        scrollEvent.SetActive(false);
        CBtn();
    }
    public void showEvent()
    {
        hyoujiTask = 3;
        nikkaNo.SetActive(false);
        syukanNo.SetActive(false);
        eventNo.SetActive(true);
        scrollNikka.SetActive(false);
        scrollSyukan.SetActive(false);
        scrollEvent.SetActive(true);
        CBtn();
    }

    /// <summary>
    /// �l��/���l���{�^���̐���
    /// </summary>
    void CBtn() {
        int forCount = 0;
        switch (hyoujiTask)
        {
            case 1: forCount = countN; break;
            case 2: forCount = countS; break;
            case 3: forCount = countE; break;
        }
        for (int i = 0; i < forCount; i++) {
            if (hyoujiTask==1) {
                switch (AkagonohateData.tasseiFlgN[i])
                {
                    case 0: kakutokuBtnN[i].SetActive(false); kakutokuzumiN[i].SetActive(false); break;
                    case 1: kakutokuBtnN[i].SetActive(true); kakutokuzumiN[i].SetActive(false); break;
                    case 2: kakutokuBtnN[i].SetActive(false); kakutokuzumiN[i].SetActive(true); break;
                }
            }
            if (hyoujiTask == 2)
            {
                switch (AkagonohateData.tasseiFlgS[i])
                {
                    case 0: kakutokuBtnS[i].SetActive(false); kakutokuzumiS[i].SetActive(false); break;
                    case 1: kakutokuBtnS[i].SetActive(true); kakutokuzumiS[i].SetActive(false); break;
                    case 2: kakutokuBtnS[i].SetActive(false); kakutokuzumiS[i].SetActive(true); break;
                }
            }
            if (hyoujiTask == 3)
            {
                switch (AkagonohateData.tasseiFlgE[i])
                {
                    case 0: kakutokuBtnE[i].SetActive(false); kakutokuzumiE[i].SetActive(false); break;
                    case 1: kakutokuBtnE[i].SetActive(true); kakutokuzumiE[i].SetActive(false); break;
                    case 2: kakutokuBtnE[i].SetActive(false); kakutokuzumiE[i].SetActive(true); break;
                }
            }
        }
    }

    /// <summary>
    /// �l���{�^���������̏���
    /// ��hosyu�F�Ⴆ��A�C�e���̌�
    /// ��num�F�\�̈ʁ��{�^��No(0�X�^�[�g)�A��̈ʁ��A�C�e���t���O(=AkagonohateData.itemSyojisu)
    /// </summary>
    public void item(int num) {
        itemFlg = num % 10;
        btnNo = num / 10;
    }
    public void pushBtn(string hosyu) {
        //�|�b�v�A�b�v�\��
        kakutokuPopup.SetActive(true);
        zeni.SetActive(false);
        ken.SetActive(false);
        if (itemFlg == 0)
        {
            zeni.SetActive(true);
        }
        if(itemFlg == 1){
            ken.SetActive(true);
        }
        hosyuT.text = ("�~" + hosyu);


        //�A�C�e���������𑀍�
        AkagonohateData.itemSyojisu[itemFlg] += int.Parse(hosyu);

        //�B���t���O�𑀍�(1��2)
        switch (hyoujiTask)
        {
            case 1: AkagonohateData.tasseiFlgN[btnNo] = 2; break;
            case 2: AkagonohateData.tasseiFlgS[btnNo] = 2; break;
            case 3: AkagonohateData.tasseiFlgE[btnNo] = 2; break;
        }
        CBtn();
    }

    public void pushHaikei() {
        //�|�b�v�A�b�v��\��
        kakutokuPopup.SetActive(false);
    }

    void Update()
    {
        //���l����V����������Ԋۂ�������
        for (int i = 0; i < 3; i++)
        {
            tasseiIcon[i].SetActive(false);
        }
        //���l����V����������Ԋۓ_���𐧌�
        //����
        for (int i = 0; i < countN; i++) {
            if (AkagonohateData.tasseiFlgN[i] == 1) {
                tasseiIcon[0].SetActive(true);
                break;
            }
        }
        //�T��
        for (int i = 0; i < countS; i++)
        {
            if (AkagonohateData.tasseiFlgS[i] == 1)
            {
                tasseiIcon[1].SetActive(true);
                break;
            }
        }
        //�C�x���g(��)
        for (int i = 0; i < countE; i++)
        {
            if (AkagonohateData.tasseiFlgE[i] == 1)
            {
                tasseiIcon[2].SetActive(true);
                break;
            }
        }
    }
}
