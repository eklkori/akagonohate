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
    [SerializeField] GameObject ninsokuAll;

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
        //�e�X�g�p����END

        //�Z�b�e�B���O��ʂ�\�������Ƀ����E�F�C���n�߂Ă��l�����l�����f�����悤�A�ŏ��ɏ����̂ݗ���
        syokisuchi();
    }

    int syokaiFlg = 0;
    int moTMP = 0;
    int yuTMP = 0;
    int niTMP = 0;
    public void syokisuchi()
    {
        ninsokuAll.SetActive(true);

        int moTint = int.Parse(moT.text);
        int yuTint = int.Parse(yuT.text);
        int niTint = int.Parse(niT.text);

        //-------�������l�̐ݒ�--------
        //��syokaiFlg��0�̏ꍇ�͑O�񃉃��E�F�C���̐ݒ�l���Q�ƁA1�̏ꍇ�̓����i�[��ʑJ�ڑO�̐ݒ�l���Q��
        if (syokaiFlg == 0)
        {
            //������̐��l������
            //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
            if (AkagonohateData.moZen > AkagonohateData.itemSyojisu[3])
            {
                moT.text = AkagonohateData.itemSyojisu[3].ToString();
            }
            else
            {
                mogiriPlus.SetActive(true);
                mogiriPlusNo.SetActive(false);
            }

            //�U�����̐��l������
            //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
            if (AkagonohateData.yuZen > AkagonohateData.itemSyojisu[4])
            {
                yuT.text = AkagonohateData.itemSyojisu[4].ToString();
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
            }
            else
            {
                nimotsuPlus.SetActive(true);
                nimotsuPlusNo.SetActive(false);
            }
        }
        else {
            //������̐��l������(2��ڈȍ~)
            //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
                moT.text = moTMP.ToString();
                mogiriPlus.SetActive(true);
                mogiriPlusNo.SetActive(false);

            //�U�����̐��l������(2��ڈȍ~)
            //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
                yuT.text = yuTMP.ToString();
                yudoinPlus.SetActive(true);
                yudoinPlusNo.SetActive(false);

            //�ו������̐��l������(2��ڈȍ~)
            //���O��ݒ�l���������̏ꍇ�A��������D�悵�ĕ\��
                niT.text = niTMP.ToString();
                nimotsuPlus.SetActive(true);
                nimotsuPlusNo.SetActive(false);
        }
        if (syokaiFlg == 0) {
            ninsokuAll.SetActive(false);
            syokaiFlg = 1;
        }
    }

    /// <summary>
    /// �l��0�̎����l��
    /// </summary>
    public void zero() {
        int moTint = int.Parse(moT.text);
        int yuTint = int.Parse(yuT.text);
        int niTint = int.Parse(niT.text);
        //0�̏ꍇ�̏���
        if (moTint == 0)
        {
            mogiriMinus.SetActive(false);
        }
        if (yuTint == 0)
        {
            yudoinMinus.SetActive(false);
        }
        if (niTint == 0)
        {
            nimotsuMinus.SetActive(false);
        }
        //0�ȊO�̏ꍇ�̏���
        if (moTint != 0)
        {
            mogiriMinus.SetActive(true);
        }
        if (yuTint != 0)
        {
            yudoinMinus.SetActive(true);
        }
        if (niTint != 0)
        {
            nimotsuMinus.SetActive(true);
        }
        //�O��ݒ�l���������̏ꍇ
        if (moTint == AkagonohateData.itemSyojisu[3])
        {
            mogiriPlus.SetActive(false);
            mogiriPlusNo.SetActive(true);
        }
        if (yuTint == AkagonohateData.itemSyojisu[4])
        {
            yudoinPlus.SetActive(false);
            yudoinPlusNo.SetActive(true);
        }
        if (niTint == AkagonohateData.itemSyojisu[5])
        {
            nimotsuPlus.SetActive(false);
            nimotsuPlusNo.SetActive(true);
        }
    }
    public void moMinus()
    {
        moTMP = int.Parse(moT.text);
        moTMP--;
        moT.text = moTMP.ToString();
        if (moTMP < AkagonohateData.itemSyojisu[3])
        {
            mogiriPlus.SetActive(true);
            mogiriPlusNo.SetActive(false);
        }
        zero();
    }
    public void moPlus()
    {
        moTMP = int.Parse(moT.text);
        moTMP++;
        moT.text = moTMP.ToString();
        zero();
    }
    public void yuMinus()
    {
        yuTMP = int.Parse(yuT.text);
        yuTMP--;
        yuT.text = yuTMP.ToString();
        if (yuTMP < AkagonohateData.itemSyojisu[4])
        {
            yudoinPlus.SetActive(true);
            yudoinPlusNo.SetActive(false);
        }
        zero();
    }
    public void yuPlus()
    {
        yuTMP = int.Parse(yuT.text);
        yuTMP++;
        yuT.text = yuTMP.ToString();
        zero();
    }
    public void niMinus()
    {
        niTMP = int.Parse(niT.text);
        niTMP--;
        niT.text = niTMP.ToString();
        if (niTMP < AkagonohateData.itemSyojisu[5])
        {
            nimotsuPlus.SetActive(true);
            nimotsuPlusNo.SetActive(false);
        }
        zero();
    }
    public void niPlus()
    {
        niTMP = int.Parse(niT.text);
        niTMP++;
        niT.text = niTMP.ToString();
        zero();
    }
}
