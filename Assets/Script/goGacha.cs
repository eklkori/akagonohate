using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goGacha : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject overPopUp;
    [SerializeField] GameObject konyuPopUp;
    [SerializeField] GameObject goGachaPopUp;
    [SerializeField] GameObject closeBtn;
    [SerializeField] GameObject yes;
    [SerializeField] GameObject no;

    [SerializeField] Text maisu;

    int gachaFlg;

    private void Start()
    {
        //�e�X�g�p����START
        //AkagonohateData.itemSyojisu[1] = 150;
        //�e�X�g�p����END
    }
    public void gachaPopUp(int num) {
        gachaFlg = num;

        //�|�b�v�A�b�v�̕\��
        overPopUp.SetActive(true);
        konyuPopUp.SetActive(false);
        goGachaPopUp.SetActive(true);
        closeBtn.SetActive(false);

        //�d�����̏������ɉ����ĕ\���𐧌�
        int kijun = 0;
        switch (num)
        {
            case 1: kijun = 10; break;
            case 2: kijun = 100; break;
        }
        if (AkagonohateData.itemSyojisu[1] < kijun)
        {
            yes.SetActive(false);
            no.SetActive(true);
        }
        else
        {
            yes.SetActive(true);
            no.SetActive(false);
            //�����ꂽ�{�^���ɂ��\���̐���(num==1�F�P���Anum==2�F10�A)
            switch (num)
            {
                case 1: maisu.text = "�~  10"; break;
                case 2: maisu.text = "�~  100"; break;
            }
        }
    }

    /// <summary>
    /// �|�b�v�A�b�v�Łu�͂��v�������ꂽ�Ƃ��̏���
    /// </summary>
    public void hai() {
        //�����ߑ��t���O�̏�����
        for (int i = 0; i < 10; i++) {
            AkagonohateData.gachaNotNew[i] = 0;
        }
        switch (gachaFlg)
        {
            case 1: goGacha1(); break;
            case 2: goGacha10(); break;
        }
    }

    /// <summary>
    /// �K�`���f�[�^�Z�b�g�p�̗����擾
    /// </summary>
    int ransusyutoku() {
        int res = 0;
        int rare = Random.Range(1, 1000);
        //���A�x1�̕���
        if (1 <= rare && rare <= 700) {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 <= 1)
                {
                    break;
                }
            }
        }
        //���A�x2�̕���
        if (701 <= rare && rare <= 900)
        {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 == 2 || res % 10 == 3)
                {
                    break;
                }
            }
        }
        //���A�x3�̕���
        if (901 <= rare && rare < 1000)
        {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 == 4)
                {
                    break;
                }
            }
        }
        return res;
    }

    /// <summary>
    /// �P���K�`���{�^���������̏���
    /// </summary>
    void goGacha1()
    {
        //�d�����������𑀍�
        AkagonohateData.itemSyojisu[1] -= 10;

        //�K�`�����ʍ쐬
        int res = ransusyutoku();
        if (AkagonohateData.isyoSyojiFlg[res] != 0) {
            AkagonohateData.gachaNotNew[0] = 1;
        }
        AkagonohateData.isyoSyojiFlg[res] = 1;
        AkagonohateData.gacha10[0] = res;
        AkagonohateData.gachaFlg = 1;

        SceneManager.LoadScene("14Gacha");
    }

    /// <summary>
    /// 10�A�K�`���{�^���������̏���
    /// </summary>
    void goGacha10()
    {
        //�d�����������𑀍�
        AkagonohateData.itemSyojisu[1] -= 100;

        //�K�`�����ʍ쐬
        for (int i = 0; i < 10; i++)
        {
            int res = ransusyutoku();
            if (AkagonohateData.isyoSyojiFlg[res] != 0)
            {
                AkagonohateData.gachaNotNew[i] = 1;
            }
            AkagonohateData.isyoSyojiFlg[res] = 1;
            AkagonohateData.gacha10[i] = res;
        }
        AkagonohateData.gachaFlg = 2;

        SceneManager.LoadScene("14Gacha");
    }
}
