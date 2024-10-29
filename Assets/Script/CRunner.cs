using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CRunner : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject runnersentakuT;
    [SerializeField] GameObject syousaiT;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject scroll;
    //[SerializeField] GameObject kyaras;

    [SerializeField] GameObject kaishiBtn;

    [SerializeField] GameObject popupBase2;
    [SerializeField] GameObject setteishita;
    [SerializeField] GameObject key;
    [SerializeField] GameObject hai;
    [SerializeField] GameObject hai2;
    [SerializeField] GameObject iie;
    [SerializeField] GameObject haiBtn;
    [SerializeField] GameObject hai2Btn;
    [SerializeField] GameObject iieBtn;
    [SerializeField] GameObject now;
    [SerializeField] GameObject after;
    [SerializeField] GameObject sankaku;
    [SerializeField] GameObject tarimasen;
    [SerializeField] GameObject imasugu;

    //�|�b�v�A�b�v�ŕ\�������e�탉���i�[�{�^��
    [SerializeField] GameObject[] isyouBtnAll;
    //�����i�[��ʂŕ\�������{�^���̉摜�����ւ��p
    [SerializeField] Sprite[] runnerImages;
    [SerializeField] GameObject[] Btns;
    [SerializeField] Image[] BtnImages;

    private void Start()
    {
        //�e�X�g�p����(���u��)START
        AkagonohateData.isyoSyojiFlg[0] = 1;
        AkagonohateData.isyoSyojiFlg[13] = 1;
        AkagonohateData.isyoSyojiFlg[21] = 1;
        for (int i = 0; i < 24; i++)
        {
            AkagonohateData.runner[i] = -1;�@//runer[]==0�̏ꍇ���l�����āA�����l��-1�ɕύX���鏈��(gamenseni.cs�Ŏ����ς�)
        }
        //�e�X�g�p����(���u��)END
        for (int i = 0; i < 8; i++) {
            if (AkagonohateData.runner[i] == -1)
            {
                Btns[i].SetActive(false);
            }
        }
        AkagonohateData.hyoujimaku = 1;
    }

    int wakuNo = 0;

    /// <summary>
    /// �����i�[��ʂł̃����i�[�ǉ��u�{�v�{�^���������̏���
    /// (�����ߑ��ꗗ�\��)
    /// </summary>
    /// <param name="WakuNo"></param>
    public void plusBtn(int WakuNo)
    {
        wakuNo = WakuNo;
        batsu.SetActive(true);
        runnersentakuT.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        scroll.SetActive(true);
        //kyaras.SetActive(true);
        if (AkagonohateData.hyoujimaku == 2) {
            wakuNo += 8;
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            wakuNo += 16;
        }
        Debug.Log(wakuNo);
        //isyouBtnAll[2].SetActive(true);
        //�����ߑ��̈ꗗ���擾
        //var syojiList = new List<int>();
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i]==1) {
                //syojiList.Add(i);
                isyouBtnAll[i].SetActive(true);
            }
        }
    }

    /// <summary>
    /// �|�b�v�A�b�v��̃A�C�R���{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    /// <param name="num"></param>
    public void popupKyaraBtn(int num)
    {
        int wakuNoTMP = wakuNo;
        if (AkagonohateData.hyoujimaku == 2)
        {
            wakuNoTMP -= 8;
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            wakuNoTMP -= 16;
        }
        //�{�^����\��
        Btns[wakuNoTMP].SetActive(true);

        //�����i�[�z��Ɉߑ�No���Z�b�g
        AkagonohateData.runner[wakuNo] = num;

        //�摜�̍����ւ�
        BtnImages[wakuNoTMP].sprite = runnerImages[num];
        Debug.Log(num);

        //�|�b�v�A�b�v�����
        haikeiBtn();
    }

    /// <summary>
    /// �O���{�^���������̏���
    /// </summary>
    /// <param name="num"></param>
    public void hazusu(int num) {
        Btns[num].SetActive(false);
        if (AkagonohateData.hyoujimaku == 2)
        {
            num += 8;
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            num += 16;
        }
        AkagonohateData.runner[num] = -1;
    }

    /// <summary>
    /// ���`�O���{�^���������ꂽ�Ƃ��̃����i�[�����\��
    /// </summary>
    public void syokiRunner() {
        int makuNo = AkagonohateData.hyoujimaku;
        int[] kakunin = { 0, 1, 2, 3, 4, 5, 6, 7 };
        for (int i = 0; i < 8; i++)
        {
            if (makuNo == 2)
            {
                kakunin[i] += 8;
            }
            if (makuNo == 3)
            {
                kakunin[i] += 16;
            }
            //�ݒ�l������΃{�^����\����������ŉ摜�̍����ւ��A������Δ�\��
            if (AkagonohateData.runner[kakunin[i]] == -1)
            {
                Btns[i].SetActive(false);
            }
            else {
                Btns[i].SetActive(true);
                BtnImages[i].sprite = runnerImages[AkagonohateData.runner[kakunin[i]]];
            }
        }
    }

    /// <summary>
    /// �|�b�v�A�b�v�����
    /// </summary>
    public void haikeiBtn()
    {
        scroll.SetActive(false);
        batsu.SetActive(false);
        runnersentakuT.SetActive(false);
        haikei.SetActive(false);
        popupBase.SetActive(false);
        popupBase2.SetActive(false);
        setteishita.SetActive(false);
        key.SetActive(false);
        hai.SetActive(false);
        hai2.SetActive(false);
        iie.SetActive(false);
        haiBtn.SetActive(false);
        hai2Btn.SetActive(false);
        iieBtn.SetActive(false);
        now.SetActive(false);
        after.SetActive(false);
        sankaku.SetActive(false);
        tarimasen.SetActive(false);
        imasugu.SetActive(false);
    }
}
