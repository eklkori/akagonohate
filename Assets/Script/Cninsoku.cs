using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cninsoku : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject mogiriMinus;
    [SerializeField] GameObject mogiriPlus;
    [SerializeField] GameObject mogiriPlusNo;
    [SerializeField] GameObject yudoinMinus;
    [SerializeField] GameObject yudoinPlus;
    [SerializeField] GameObject yudoinPlusNo;
    [SerializeField] GameObject nimotsuMinus;
    [SerializeField] GameObject nimotsuPlus;
    [SerializeField] GameObject nimotsuPlusNo;

    public Text moT;
    public Text yuT;
    public Text niT;
    void Start()
    {
        moT.text = AkagonohateData.moZen.ToString();
        yuT.text = AkagonohateData.yuZen.ToString();
        niT.text = AkagonohateData.niZen.ToString();

        //�e�X�g�p�l����
        AkagonohateData.itemSyojisu[3] = 1;
        AkagonohateData.itemSyojisu[4] = 2;
        AkagonohateData.itemSyojisu[5] = 3;

        //syokisuchi();
    }
    public void syokisuchi()
    {
        int moTint = int.Parse(moT.text);
        int yuTint = int.Parse(yuT.text);
        int niTint = int.Parse(niT.text);

        //������̐��l������
        //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
        if (AkagonohateData.moZen > AkagonohateData.itemSyojisu[3])
        {
            moT.text = AkagonohateData.itemSyojisu[3].ToString();
            mogiriPlus.SetActive(false);
            mogiriPlusNo.SetActive(true);
        }
        else {
            mogiriPlus.SetActive(true);
            mogiriPlusNo.SetActive(false);
        }

        //�U�����̐��l������
        //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
        if (AkagonohateData.yuZen > AkagonohateData.itemSyojisu[4])
        {
            yuT.text = AkagonohateData.itemSyojisu[4].ToString();
            yudoinPlus.SetActive(false);
            yudoinPlusNo.SetActive(true);
        }
        else
        {
            yudoinPlus.SetActive(true);
            yudoinPlusNo.SetActive(false);
        }

        //�ו������̐��l������
        //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
        if (AkagonohateData.niZen > AkagonohateData.itemSyojisu[5])
        {
            niT.text = AkagonohateData.itemSyojisu[5].ToString();
            nimotsuPlus.SetActive(false);
            nimotsuPlusNo.SetActive(true);
        }
        else
        {
            nimotsuPlus.SetActive(true);
            nimotsuPlusNo.SetActive(false);
        }
    }

    public void zero() {
        //0�̏ꍇ�̏���
        if (moT.text == "0")
        {
            mogiriMinus.SetActive(false);
        }
        if (yuT.text == "0")
        {
            yudoinMinus.SetActive(false);
        }
        if (niT.text == "0")
        {
            nimotsuMinus.SetActive(false);
        }
        //0�ȊO�̏ꍇ�̏���
        if (moT.text != "0")
        {
            mogiriMinus.SetActive(true);
        }
        if (yuT.text != "0")
        {
            yudoinMinus.SetActive(true);
        }
        if (niT.text != "0")
        {
            nimotsuMinus.SetActive(true);
        }
    }
    public void moMinus()
    {
        int moTMP = int.Parse(moT.text);
        moTMP--;
        moT.text = moTMP.ToString();
        //AkagonohateData.moZen = moTMP;
        zero();
    }
    public void moPlus()
    {
        int moTMP = int.Parse(moT.text);
        moTMP++;
        moT.text = moTMP.ToString();
        //AkagonohateData.moZen = moTMP;
        zero();
    }
    public void yuMinus()
    {
        int yuTMP = int.Parse(yuT.text);
        yuTMP--;
        yuT.text = yuTMP.ToString();
        //AkagonohateData.yuZen = yuTMP;
        zero();
    }
    public void yuPlus()
    {
        int yuTMP = int.Parse(yuT.text);
        yuTMP++;
        yuT.text = yuTMP.ToString();
        //AkagonohateData.yuZen = yuTMP;
        zero();
    }
    public void niMinus()
    {
        int niTMP = int.Parse(niT.text);
        niTMP--;
        niT.text = niTMP.ToString();
        //AkagonohateData.niZen = niTMP;
        zero();
    }
    public void niPlus()
    {
        int niTMP = int.Parse(niT.text);
        niTMP++;
        niT.text = niTMP.ToString();
        //AkagonohateData.niZen = niTMP;
        zero();
    }
}
