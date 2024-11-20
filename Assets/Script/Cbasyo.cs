using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cbasyo : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject[] nLvIjyoude;
    [SerializeField] GameObject[] mikaihou;
    [SerializeField] GameObject[] basyoName;
    [SerializeField] GameObject[] basyoTextBase;
    [SerializeField] GameObject[] sentakuchu;
    [SerializeField] GameObject[] sentakuBtn;

    [SerializeField] int lv = AkagonohateData.playerLvI;
    public void syokihyouji()
    {
        //�I�𒆕\���̏�����
        for (int i = 0; i < sentakuchu.Length; i++)
        {
            sentakuchu[i].SetActive(false);
            sentakuBtn[i].SetActive(true);
            if (i >= 2)
            {
                sentakuBtn[i].SetActive(false);
                nLvIjyoude[i].SetActive(true);
                mikaihou[i].SetActive(true);
                basyoName[i].SetActive(false);
                basyoTextBase[i].SetActive(false);
            }
        }
        sentakuchu[AkagonohateData.basyo - 1].SetActive(true);

        //�v���C���[���x���ɂ��\������
        if (lv >= 5) {
            nLvIjyoude[2].SetActive(false);
            mikaihou[2].SetActive(false);
            basyoName[2].SetActive(true);
            basyoTextBase[2].SetActive(true);
            sentakuBtn[2].SetActive(true);
        }
        if (lv >= 10)
        {
            nLvIjyoude[3].SetActive(false);
            mikaihou[3].SetActive(false);
            basyoName[3].SetActive(true);
            basyoTextBase[3].SetActive(true);
            sentakuBtn[3].SetActive(true);
        }
        if (lv >= 15)
        {
            nLvIjyoude[4].SetActive(false);
            mikaihou[4].SetActive(false);
            basyoName[4].SetActive(true);
            basyoTextBase[4].SetActive(true);
            sentakuBtn[4].SetActive(true);
        }
        if (lv >=20)
        {
            nLvIjyoude[5].SetActive(false);
            mikaihou[5].SetActive(false);
            basyoName[5].SetActive(true);
            basyoTextBase[5].SetActive(true);
            sentakuBtn[5].SetActive(true);
        }
        if (lv >= 25)
        {
            nLvIjyoude[6].SetActive(false);
            mikaihou[6].SetActive(false);
            basyoName[6].SetActive(true);
            basyoTextBase[6].SetActive(true);
            sentakuBtn[6].SetActive(true);
        }
        if (lv >= 30)
        {
            nLvIjyoude[7].SetActive(false);
            mikaihou[7].SetActive(false);
            basyoName[7].SetActive(true);
            basyoTextBase[7].SetActive(true);
            sentakuBtn[7].SetActive(true);
        }
        if (lv >= 35)
        {
            nLvIjyoude[8].SetActive(false);
            mikaihou[8].SetActive(false);
            basyoName[8].SetActive(true);
            basyoTextBase[8].SetActive(true);
            sentakuBtn[8].SetActive(true);
        }
    }

    public void pushBasyo(int basyoNo)
    {
        //DB�f�[�^�㏑���@��basyo��1�n�܂�
        AkagonohateData.basyo = basyoNo+1;

        //�I�𒆃{�^���̕\���؂�ւ�
        for (int i = 0; i < sentakuchu.Length; i++)
        {
            sentakuchu[i].SetActive(false);
        }
        sentakuchu[AkagonohateData.basyo - 1].SetActive(true);
    }
}
