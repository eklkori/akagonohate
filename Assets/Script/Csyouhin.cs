using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;

public class Csyouhin : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject syouhinPopUp;
    [SerializeField] GameObject overPopUp;
    [SerializeField] GameObject konyuPopUp;
    [SerializeField] GameObject goGachaPopUp;
    [SerializeField] GameObject[] syouhinImages;
    [SerializeField] GameObject[] smallImages;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject minusBtn;
    [SerializeField] GameObject plusBtn;
    [SerializeField] GameObject konyuBtn;
    //[SerializeField] GameObject closeBtn;

    [SerializeField] Text syouhinmei;
    [SerializeField] Text kaisetsu;
    [SerializeField] Text zeniBefore;
    [SerializeField] Text zeniAfter;
    [SerializeField] Text kosu;
    [SerializeField] Text konyuKosu;

    int konyusu;
    int No;
    void Start()
    {
        //�e�X�g�p����START
        AkagonohateData.itemSyojisu[0] = 4000;
        //�e�X�g�p����END
        haikeiSyouhin();
    }

    /// <summary>
    /// ���i�|�b�v�A�b�v�̕\������
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void showSyouhinPopUp(int kyaraNo) {
        //�\���̏�����
        for (int i = 0; i < 6; i++) {
            syouhinImages[i].SetActive(false);
        }

        syouhinPopUp.SetActive(true);
        konyusu = 1;
        minusBtn.SetActive(false);

        No = kyaraNo;

        //�L�������Ƃ̕\������
        switch (kyaraNo)
        {
            case 0: 
                syouhinImages[0].SetActive(true);
                syouhinmei.text = "�n�G���";
                kaisetsu.text = "�����ڂ̊��Ɍ����L����������c�c�����������̂́A�����ƒ��q����ɓn���ׂ����낤�B";
                break;
            case 1: 
                syouhinImages[1].SetActive(true);
                syouhinmei.text = "�K�̃I�u�W�F";
                kaisetsu.text = "������c�c�������̈��|�I�������́B���������Ȃ��łق����B�N�q���قɓn��������ł���邩�ȁB";
                break;
            case 2: 
                syouhinImages[2].SetActive(true);
                syouhinmei.text = "�O�F�c�q";
                kaisetsu.text = "�S�Ȃ�����������f�J���B�X�傪������ɋ����Ă���̂��낤���B�g�q����l�ɓn���Ă��������Ȃ�ȁB";
                break;
            case 3: 
                syouhinImages[3].SetActive(true);
                syouhinmei.text = "����";
                kaisetsu.text = "�������Ƃ̂Ȃ��F�̋������ȁB�łƂ������Ă��Ȃ���Ηǂ����ǁc�c�B�G�����V����܂Ȃ�m���m���ŐA���������B";
                break;
            case 4: 
                syouhinImages[4].SetActive(true);
                syouhinmei.text = "�z�O�K�j";
                kaisetsu.text = "�Ƃ��Ă�����������������N���u���Ă���̂��C�ɂȂ�c�c�����ƗⓀ�Ȃ̂��낤�B�z�O�I�^�N�̏G�炨�V����܂ɂ����悤�B";
                break;
            case 5: 
                syouhinImages[5].SetActive(true);
                syouhinmei.text = "�����M";
                kaisetsu.text = "���̕M�ŕ����������΁A�N�ł��\�M�ƂɂȂꂿ�Ⴂ�����I�����}�j�A�̍匴��y�ɐ���I";
                break;
        }

        //�K�E�w�����̌v�Z����
        zeniBefore.text = AkagonohateData.itemSyojisu[0].ToString();
        zeniAfter.text = (AkagonohateData.itemSyojisu[0]-1000).ToString();
        kosu.text = konyusu.ToString();

        nedanMiman();
    }

    /// <summary>
    /// ���i�|�b�v�A�b�v�̃N���[�Y
    /// </summary>
    public void haikeiSyouhin() {
        syouhinPopUp.SetActive(false);
        overPopUp.SetActive(false);
    }

    /// <summary>
    /// �{�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void pushPlus() {
        //�w�����𑀍�
        konyusu++;
        kosu.text = konyusu.ToString();

        //�K�������̕\���𑀍�
        int zeniA = int.Parse(zeniAfter.text);
        zeniAfter.text = (zeniA-1000).ToString();

        //UI����
        if (konyusu == 99) {
            plusBtn.SetActive(false);
        }
        minusBtn.SetActive(true);
        konyuBtn.SetActive(true);
        nedanMiman();
    }

    /// <summary>
    /// -�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void pushMinus() {
        //�w�����𑀍�
        konyusu--;
        kosu.text = konyusu.ToString();

        //�K�������̕\���𑀍�
        int zeniA = int.Parse(zeniAfter.text);
        zeniAfter.text = (zeniA+1000).ToString();

        //UI����
        plusBtn.SetActive(true);
        nedanMiman();
    }

    /// <summary>
    /// �����K���A�C�e���̒l�i(1000)�����̂Ƃ�
    /// </summary>
    void nedanMiman() {
        int zeniAfterTMP = int.Parse(zeniAfter.text);
        if (zeniAfterTMP < 1000)
        {
            plusBtn.SetActive(false);
            if (zeniAfterTMP < 0)
            {
                konyuBtn.SetActive(false);
            }
        }
        if (kosu.text == "1")
        {
            minusBtn.SetActive(false);
        }
    }

    /// <summary>
    /// �w���{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void konyu() {
        //��ʕ\��
        konyuKosu.text = "�~ " + konyusu.ToString() ;
        syouhinPopUp.SetActive(false);
        overPopUp.SetActive(true);
        konyuPopUp.SetActive(true);
        goGachaPopUp.SetActive(false);
        //closeBtn.SetActive(true);

        //�A�C�e���摜�̏�����
        for (int i = 0; i < 6; i++) {
            smallImages[i].SetActive(false);
        }

        //�������̍X�V+�A�C�e���摜�̍����ւ�
        AkagonohateData.itemSyojisu[0] -= konyusu * 1000;
        switch (No)
        {
            case 0: AkagonohateData.itemSyojisu[10] += konyusu; smallImages[0].SetActive(true); break;
            case 1: AkagonohateData.itemSyojisu[11] += konyusu; smallImages[1].SetActive(true); break;
            case 2: AkagonohateData.itemSyojisu[12] += konyusu; smallImages[2].SetActive(true); break;
            case 3: AkagonohateData.itemSyojisu[13] += konyusu; smallImages[3].SetActive(true); break;
            case 4: AkagonohateData.itemSyojisu[14] += konyusu; smallImages[4].SetActive(true); break;
            case 5: AkagonohateData.itemSyojisu[15] += konyusu; smallImages[5].SetActive(true); break;
        }
    }
    void Update()
    {
        
    }
}
