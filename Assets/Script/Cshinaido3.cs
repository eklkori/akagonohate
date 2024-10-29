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
    private void Start()
    {
        //�e�X�g�p���u��
        AkagonohateData.kaiwaShichoFlg[1] = 1;
        AkagonohateData.kaiwaShichoFlg[103] = 1;
        AkagonohateData.dateShichoFlg[2] = 1;
        AkagonohateData.dateShichoFlg[44] = 1;

        //�ϐ��̏���
        who = AkagonohateData.shinaidoWho;

        //��b/�f�[�g�ꗗ�̕\��
        if (AkagonohateData.kakuninchuFlg == 2)
        {
            showDate();
        }
        else
        {
            showKaiwas();
        }
        AkagonohateData.kakuninchuFlg = 0;
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
            case 1: dateCount = 6;break;
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

    //��b
    public void Kbtn1() {
        switch (who) {
            case 1: label = "naoko1";break;
            case 2: label = "yasuko1"; break;
            case 3: label = "yoshiko1"; break;
            case 4: label = "hideta1"; break;
            case 5: label = "hideya1"; break;
            case 6: label = "yasuo1"; break;
        }
        goUtage();
    }
    public void Kbtn2()
    {
        switch (who)
        {
            case 1: label = "naoko2"; break;
            case 2: label = "yasuko2"; break;
            case 3: label = "yoshiko2"; break;
            case 4: label = "hideta2"; break;
            case 5: label = "hideya2"; break;
            case 6: label = "yasuo2"; break;
        }
        goUtage();
    }
    public void Kbtn3()
    {
        switch (who)
        {
            case 1: label = "naoko3"; break;
            case 2: label = "yasuko3"; break;
            case 3: label = "yoshiko3"; break;
            case 4: label = "hideta3"; break;
            case 5: label = "hideya3"; break;
            case 6: label = "yasuo3"; break;
        }
        goUtage();
    }
    public void Kbtn4()
    {
        switch (who)
        {
            case 1: label = "naoko4"; break;
            case 2: label = "yasuko4"; break;
            case 3: label = "yoshiko4"; break;
            case 4: label = "hideta4"; break;
            case 5: label = "hideya4"; break;
            case 6: label = "yasuo4"; break;
        }
        goUtage();
    }
    public void Kbtn5()
    {
        switch (who)
        {
            case 1: label = "naoko5"; break;
            case 2: label = "yasuko5"; break;
            case 3: label = "yoshiko5"; break;
            case 4: label = "hideta5"; break;
            case 5: label = "hideya5"; break;
            case 6: label = "yasuo5"; break;
        }
        goUtage();
    }
    public void Kbtn6()
    {
        switch (who)
        {
            case 1: label = "naoko6"; break;
            case 2: label = "yasuko6"; break;
            case 3: label = "yoshiko6"; break;
            case 4: label = "hideta6"; break;
            case 5: label = "hideya6"; break;
            case 6: label = "yasuo6"; break;
        }
        goUtage();
    }

    //�f�[�g
    public void Dbtn1()
    {
        switch (who)
        {
            case 1: label = "Dnaoko1"; break;
            case 2: label = "Dyasuko1"; break;
            case 3: label = "Dyoshiko1"; break;
            case 4: label = "Dhideta1"; break;
            case 5: label = "Dhideya1"; break;
            case 6: label = "Dyasuo1"; break;
        }
        goUtage();
    }
    public void Dbtn2()
    {
        switch (who)
        {
            case 1: label = "Dnaoko2"; break;
            case 2: label = "Dyasuko2"; break;
            case 3: label = "Dyoshiko2"; break;
            case 4: label = "Dhideta2"; break;
            case 5: label = "Dhideya2"; break;
            case 6: label = "Dyasuo2"; break;
        }
        goUtage();
    }
    public void Dbtn3()
    {
        switch (who)
        {
            case 1: label = "Dnaoko3"; break;
            case 2: label = "Dyasuko3"; break;
            case 3: label = "Dyoshiko3"; break;
            case 4: label = "Dhideta3"; break;
            case 5: label = "Dhideya3"; break;
            case 6: label = "Dyasuo3"; break;
        }
        goUtage();
    }
    public void Dbtn4()
    {
        switch (who)
        {
            case 1: label = "Dnaoko4"; break;
            case 2: label = "Dyasuko4"; break;
            case 3: label = "Dyoshiko4"; break;
            case 4: label = "Dhideta4"; break;
            case 5: label = "Dhideya4"; break;
            case 6: label = "Dyasuo4"; break;
        }
        goUtage();
    }
    public void Dbtn5()
    {
        switch (who)
        {
            case 1: label = "Dnaoko5"; break;
            case 2: label = "Dyasuko5"; break;
            case 3: label = "Dyoshiko5"; break;
            case 4: label = "Dhideta5"; break;
            case 5: label = "Dhideya5"; break;
            case 6: label = "Dyasuo5"; break;
        }
        goUtage();
    }
    public void Dbtn6()
    {
        switch (who)
        {
            case 1: label = "Dnaoko6"; break;
            case 2: label = "Dyasuko6"; break;
            case 3: label = "Dyoshiko6"; break;
            case 4: label = "Dhideta6"; break;
            case 5: label = "Dhideya6"; break;
            case 6: label = "Dyasuo6"; break;
        }
        goUtage();
    }

    /// <summary>
    /// ���ɑJ�ڂ��ăV�i���I���J�n�����鏈��
    /// </summary>
    void goUtage() {
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
        SceneManager.LoadScene("04Tutorial");
    }
}
