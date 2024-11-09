using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kyaraSyosaiPopUp : MonoBehaviour
{
    //�e��ʋ��ʂŎg�p
    //�g�p���@
    //�@�g�p�����ʂ�Prefab�ukyaraSyousaiPopUp�v��z�u
    //�A�ukyaraSyousaiPopUp�v�I�u�W�F�N�g�ɃA�^�b�`���ꂽ���Y�X�N���v�g�Ő錾�����z�񓙂ɁA�C���X�y�N�^�[��ŗv�f���Z�b�g
    //�B�Ăяo�����̃{�^����OnClick������pushIcon(int)��ݒ肵�A�����Ɉߑ�No���Z�b�g

    //�f�ނ̒�`
    [SerializeField] GameObject kyaraSyousaiPopUp;
    [SerializeField] GameObject[] kyaraImages;
    [SerializeField] GameObject[] haikei;
    [SerializeField] GameObject[] hoshi;

    [SerializeField] Text nameT;
    [SerializeField] Text setsumei;
    [SerializeField] Text biT;
    [SerializeField] Text huT;
    [SerializeField] Text eveT;
    void Start()
    {
        kyaraSyousaiPopUp.SetActive(false);
    }

    /// <summary>
    /// �L�����ڍ׃|�b�v�A�b�v�\������
    /// ��������n���ƁA�����Ɉ�v����L�����̏ڍׂ�\�����郁�\�b�h(�e��ʋ���)
    /// </summary>
    /// <param name="num"></param>
    public void pushIcon(int num) {
        kyaraSyousaiPopUp.SetActive(true);

        //�\���̏�����
        for (int i = 0; i < 60; i++) {
            kyaraImages[i].SetActive(false);
        }
        for (int i = 0; i < 3; i++) {
            haikei[i].SetActive(false);
            hoshi[i].SetActive(false);
        }

        //�L�����摜�̕\��
        kyaraImages[num].SetActive(true);

        //�L�������E���A�x�̔���
        int kyaraName = num / 10;
        int kyaraRea = num % 10;

        //���A���e�B�[�̍��ɂ��\������
        if (kyaraRea == 0 || kyaraRea == 1)
        {
            haikei[0].SetActive(true);
            hoshi[0].SetActive(true);
        }
        else if (kyaraRea == 2 || kyaraRea == 3)
        {
            haikei[1].SetActive(true);
            hoshi[1].SetActive(true);
        }
        else 
        {
            haikei[2].SetActive(true);
            hoshi[2].SetActive(true);
        }

        //�L�������\��
        switch (kyaraName)
        {
            case 0: nameT.text = "��� ���q"; break;
            case 1: nameT.text = "���� �N�q"; break;
            case 2: nameT.text = "���� �g�q"; break;
            case 3: nameT.text = "���� �G��"; break;
            case 4: nameT.text = "���� �G��"; break;
            case 5: nameT.text = "�匴 �N�j"; break;
        }
        //�L�����Љ�����ւ�
        //���q
        if (num == 0 || num == 1) 
            setsumei.text = "���q��1�̃L�����Љ";
        if (num == 2 || num == 3) 
            setsumei.text = "���q��2�̃L�����Љ";
        if (num == 4) 
            setsumei.text = "���q��3�̃L�����Љ";
        //�N�q
        if (num == 10 || num == 11) 
            setsumei.text = "�N�q��1�̃L�����Љ";
        if (num == 12 || num == 13)
            setsumei.text = "�N�q��2�̃L�����Љ";
        if (num == 14)
            setsumei.text = "�N�q��3�̃L�����Љ";
        //�g�q
        if (num == 20 || num == 21)
            setsumei.text = "�g�q��1�̃L�����Љ";
        if (num == 22 || num == 23)
            setsumei.text = "�g�q��2�̃L�����Љ";
        if (num == 24)
            setsumei.text = "�g�q��3�̃L�����Љ";
        //�G��
        if (num == 30 || num == 31)
            setsumei.text = "�G����1�̃L�����Љ";
        if (num == 32 || num == 33)
            setsumei.text = "�G����2�̃L�����Љ";
        if (num == 34)
            setsumei.text = "�G����3�̃L�����Љ";
        //�G��
        if (num == 40 || num == 41)
            setsumei.text = "�G�琯1�̃L�����Љ";
        if (num == 42 || num == 43)
            setsumei.text = "�G�琯2�̃L�����Љ";
        if (num == 44)
            setsumei.text = "�G�琯3�̃L�����Љ";
        //�N�j
        if (num == 50 || num == 51)
            setsumei.text = "�N�j��1�̃L�����Љ";
        if (num == 52 || num == 53)
            setsumei.text = "�N�j��2�̃L�����Љ";
        if (num == 54)
            setsumei.text = "�N�j��3�̃L�����Љ";

        //�X�e�[�^�X�̕\��
        //�������E���[���A���̌Œ�l�擾
        AkagonohateData akagoData = ScriptableObject.CreateInstance<AkagonohateData>();�@�@//�C���X�^���X��
        int[] bi = akagoData.GetBi;
        int[] hu = akagoData.GetHu;

        biT.text = bi[num].ToString();
        huT.text = hu[num].ToString();

        //�C�x���g���U�̓��A�x�ɂ��Œ�̂��߁A���A�x�ɂ�镪��ŏ���
        if (kyaraRea == 0 || kyaraRea == 1)
        {
            eveT.text = "1/1";
        }
        else if (kyaraRea == 2 || kyaraRea == 3)
        {
            eveT.text = "2/2";
        }
        else
        {
            eveT.text = "30/12";
        }
    }

    /// <summary>
    /// �L�����ڍ׃|�b�v�A�b�v����鏈��
    /// </summary>
    public void closeKyaraPopUp()
    {
        kyaraSyousaiPopUp.SetActive(false);
    }
    void Update()
    {
        
    }
}
