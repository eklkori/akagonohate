using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cshinaido3 : MonoBehaviour
{
    [SerializeField] GameObject dateBtn;
    [SerializeField] GameObject kaiwaBtn;
    [SerializeField] GameObject dates;
    [SerializeField] GameObject kaiwas;
    [SerializeField] GameObject[] miruBtnsK;
    [SerializeField] GameObject[] miruBtnsD;

    int who = 0;
    int No = 0;
    string labelName = "";
    string Dhantei = "";
    private void Start()
    {
        //�e�X�g�p���u��
        AkagonohateData.kaiwaShichoFlg[1] = 1;
        AkagonohateData.kaiwaShichoFlg[103] = 1;
        AkagonohateData.dateShichoFlg[2] = 1;
        AkagonohateData.dateShichoFlg[44] = 1;
        //�e�X�g�p���u��END

        //�߂�{�^���̑J�ڐ�𑀍�
        AkagonohateData.maeScene = "17Shinaido2";

        //�ϐ��̏���
        who = AkagonohateData.shinaidoWho;

        switch (who)
        {
            case 1: labelName = "naoko"; break;
            case 2: labelName = "yasuko"; break;
            case 3: labelName = "yoshiko"; break;
            case 4: labelName = "hideta"; break;
            case 5: labelName = "hideya"; break;
            case 6: labelName = "yasuo"; break;
        }

        //��b/�f�[�g�ꗗ�̕\��
        if (AkagonohateData.kakuninchuFlg == 2)
        {
            showDate();
        }
        else
        {
            showKaiwas();
        }
        AkagonohateData.kakuninchuFlg = 0;  //�m�F���t���O��goUtage���\�b�h�ő���(1��2�ɏ㏑��)
    }

    /// <summary>
    /// �f�[�g�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void showDate()
    {
        dateBtn.SetActive(false);
        kaiwaBtn.SetActive(true);
        dates.SetActive(true);
        kaiwas.SetActive(false);
        showDates();
    }

    /// <summary>
    /// ��b�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void showKaiwa()
    {
        dateBtn.SetActive(true);
        kaiwaBtn.SetActive(false);
        dates.SetActive(false);
        kaiwas.SetActive(true);
        showKaiwas();
    }

    /// <summary>
    /// �f�[�g�����ς�/�������ɂ��u����v�{�^���̕\����\�����̐���
    /// </summary>
    void showDates()
    {
        //dateCount�ɂ͊e�L�����̃f�[�g�V�i���I�������i�[(�f�[�g�~5�{������1=6)
        int dateCount = 0;
        //dateNo�ɂ̓V�i���INo���i�[(�e�L����20���ŉ��쐬)
        int dateNo = 0;
        switch (who)
        {
            case 1: dateCount = 6; break;
            case 2: dateCount = 6; dateNo = 20; break;
            case 3: dateCount = 6; dateNo = 40; break;
            case 4: dateCount = 6; dateNo = 60; break;
            case 5: dateCount = 6; dateNo = 80; break;
            case 6: dateCount = 6; dateNo = 100; break;
        }
        for (int i = 0; i < dateCount; i++)
        {
            if (AkagonohateData.dateShichoFlg[dateNo + i] == 1) {
                miruBtnsD[i].SetActive(true);
            }
        }
    }


    /// <summary>
    /// ��b�����ς�/�������ɂ��u����v�{�^���̕\����\�����̐���
    /// </summary>
    void showKaiwas() {
        //kaiwaCount�ɂ͊e�L�����̉�b�V�i���I�������i�[
        int kaiwaCount = 0;
        //kaiwaNo�ɂ̓V�i���INo���i�[(�e�L����50���ŉ��쐬)
        int kaiwaNo = 0;
        switch (who)
        {
            case 1: kaiwaCount = 10; break;
            case 2: kaiwaCount = 10; kaiwaNo = 50; break;
            case 3: kaiwaCount = 10; kaiwaNo = 100; break;
            case 4: kaiwaCount = 10; kaiwaNo = 150; break;
            case 5: kaiwaCount = 10; kaiwaNo = 200; break;
            case 6: kaiwaCount = 10; kaiwaNo = 250; break;
        }
        for (int i = 0; i < kaiwaCount; i++)
        {
            if (AkagonohateData.kaiwaShichoFlg[kaiwaNo + i] == 1)
            {
                miruBtnsK[i].SetActive(true);
            }
        }
    }

    //�ȉ��A�e��u����v�{�^���������ꂽ�Ƃ��̏���

    //�V�i���I���x���ݒ�p�ϐ�
    string label = "";

    /// <summary>
    /// ��b ����{�^���������̏���
    /// </summary>
    /// <param name="kaiwaNo"></param>
    public void Kbtn(int kaiwaNo) {
        No = kaiwaNo;
        goUtage();
    }

    /// <summary>
    /// �f�[�g ����{�^���������̏���
    /// </summary>
    /// <param name="dateNo"></param>
    public void Dbtn(int dateNo)
    {
        No = dateNo;
        Dhantei = "D";
        goUtage();
    }

    /// <summary>
    /// ���ɑJ�ڂ��ăV�i���I���J�n�����鏈��
    /// </summary>
    void goUtage() {
        //���x���̍쐬
        label = Dhantei + labelName + No;
        Debug.Log(label);

        AkagonohateData.kaiwaNo = label;
        string first = label.Substring(0, 1);
        if (first == "D")
        {
            AkagonohateData.kakuninchuFlg = 2;
        }
        else
        {
            AkagonohateData.kakuninchuFlg = 1;
        }
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("18Shinaido3");
    }
}
