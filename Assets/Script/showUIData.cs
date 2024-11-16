using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class showUIData : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject expBar;
    [SerializeField] GameObject[] keys;

    [SerializeField] Text playerLv;
    [SerializeField] Text playerName;
    [SerializeField] Text kenSyoji;
    [SerializeField] Text zeniSyoji;
    [SerializeField] Text keyHMMSS;

    //���t�̎擾�@
    DateTime localDate = DateTime.Now;
    DateTime now;
    DateTime syouhiStart;
    void Start()
    {
        //�e�X�g�pSTART
        //AkagonohateData.itemSyojisu[2] = 3;
        //�e�X�g�pEND
        syouhiStart = AkagonohateData.runwayRireki[1];
        Debug.Log(syouhiStart);
    }

    //�e�X�g�p����START
    float countH = AkagonohateData.HH; //�v����
    float countM = AkagonohateData.MM; //�v����
    float countS = AkagonohateData.SS; //�v����
    //int keyTMP = 0;
    //�e�X�g�p����END

    public void Update()
    {
        //�e�X�g�p����START
        //�@keyHMMSS.text = countS.ToString();
        //�e�X�g�p����END

        //�{�ԗp����END

        kenSyoji.text = AkagonohateData.itemSyojisu[1].ToString();
        zeniSyoji.text = AkagonohateData.itemSyojisu[0].ToString();
        playerLv.text = AkagonohateData.playerLvI.ToString();
        playerName.text = AkagonohateData.playerNmaeT;

        //���A�C�R���̕\��
        for (int i = 0; i < AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]; i++) {
            keys[i].SetActive(true);
        }

        ExpBar();
        Keys();
    }

    /// <summary>
    /// �v���C���[Lv�EEXP�o�[�̐���
    /// </summary>
    void ExpBar() {
        //�v���C���[Lv�EEXP�o�[�̐���
        float kijyun = 100 + AkagonohateData.playerLvI* AkagonohateData.playerLvI;
        if (kijyun<= AkagonohateData.exp) {
            AkagonohateData.playerLvI++;
        }
        kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
        float par = AkagonohateData.exp / kijyun;
        expBar.GetComponent<Image>().fillAmount = par;
    }

    /// <summary>
    /// ���̐���
    /// </summary>
    void Keys() {
        //�{�ԗp����START
        localDate = DateTime.Now;        //���ݓ����̎擾
        now = localDate;                 //���ݓ����̎擾
        TimeSpan sa = now - syouhiStart;        //���ݓ����ƌ��̏�����Ƃ̍����擾
        TimeSpan kijyun = new TimeSpan(0, 10, 0, 0);
        TimeSpan hour = new TimeSpan(0, 2, 0, 0);
        if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] >= 5)
        {
            //�����t���񕜂��Ă���Ƃ�
            countH = 0;
            countM = 0;
            countS = 0;
        }
        else
        {
            //�����t���񕜂łȂ��Ƃ�
            int saH = sa.Hours;
            int saM = sa.Minutes;
            int saS = sa.Seconds;
            if (saH >= 8)
            {
                kijyun = new TimeSpan(0, 10, 0, 0);
                saH -= 8;
            }
            else if (saH >= 6)
            {
                kijyun = new TimeSpan(0, 8, 0, 0);
                saH -= 6;
            }
            else if (saH >= 4)
            {
                kijyun = new TimeSpan(0, 6, 0, 0);
                saH -= 4;
            }
            else if (saH >= 2)
            {
                kijyun = new TimeSpan(0, 4, 0, 0);
                saH -= 2;
            }
            else
            {
                kijyun = new TimeSpan(0, 2, 0, 0);
            }
            TimeSpan showData = kijyun - sa;
            countH = showData.Hours;
            countM = showData.Minutes;
            countS = showData.Seconds;
        }

        //UI�\��
        keyHMMSS.text = countH.ToString("f0") + ":" + countM.ToString("00") + ":" + countS.ToString("00");

        //�e�X�g�p����(��)
        //if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] < 5)
        //{
        //    countS -= Time.deltaTime;
        //    if (countS.ToString("f0") == "-1")
        //    {
        //        countM--;
        //        countS = 59;
        //        if (countM == -1)
        //        {
        //            countH--;
        //            countM = 59;
        //            if (countH == -1)
        //            {
        //                //����1�񕜂������̏���
        //                countH = 1;
        //                if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] < 5)
        //                {
        //                    AkagonohateData.itemSyojisu[2]++;
        //                    keys[AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] - 1].SetActive(true);
        //                }
        //            }
        //        }
        //    }
        //    //DB�f�[�^�̏㏑��
        //    AkagonohateData.HH = countH;
        //    AkagonohateData.MM = countM;
        //    AkagonohateData.SS = countS;

        //    //UI�\��
        //    keyHMMSS.text = countH.ToString("f0") + ":" + countM.ToString("00") + ":" + countS.ToString("00");
        //}
        //else
        //{
        //    keyHMMSS.text = "0:00:00";
        //}
    }
}
