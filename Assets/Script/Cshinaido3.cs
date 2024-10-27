using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cshinaido3 : MonoBehaviour
{
    [SerializeField] GameObject dateBtn;
    [SerializeField] GameObject kaiwaBtn;
    [SerializeField] GameObject dates;
    [SerializeField] GameObject kaiwas;
    [SerializeField] GameObject[] miruBtns;

    int who = 0;
    private void Start()
    {
        //�e�X�g�p���u��
        AkagonohateData.kaiwaShichoFlg[1] = 1;
        AkagonohateData.kaiwaShichoFlg[103] = 1;

        //�ϐ��̏���
        who = AkagonohateData.shinaidoWho;

        //��b�ꗗ�̕\��
        showKaiwas();
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
        int dateCount = 0;
        int dateNo = 0;
        switch (who)
        {
            case 1: dateCount = 10;break;
            case 2: dateCount = 10; dateNo = 10; break;
            case 3: dateCount = 10; dateNo = 20; break;
            case 4: dateCount = 10; dateNo = 30; break;
            case 5: dateCount = 10; dateNo = 40; break;
            case 6: dateCount = 10; dateNo = 50; break;
        }
        for (int i = 0; i < dateCount; i++)
        {
            if (AkagonohateData.dateShichoFlg[dateNo + i] == 1) {
                miruBtns[i].SetActive(true);
            }
        }
    }


    /// <summary>
    /// ��b�����ς�/�������ɂ��u����v�{�^���̕\����\�����̐���
    /// </summary>
    void showKaiwas() {
        int kaiwaCount = 0;
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
                miruBtns[i].SetActive(true);
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
        Debug.Log(label);
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
        Debug.Log(label);
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
        Debug.Log(label);
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
        Debug.Log(label);
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
        Debug.Log(label);
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
        Debug.Log(label);
    }
}
