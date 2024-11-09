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
    void Start()
    {
        //�e�X�g�pSTART
        AkagonohateData.itemSyojisu[2] = 3;
        //�e�X�g�pEND
    }

    float countH = AkagonohateData.HH; //�v����
    float countM = AkagonohateData.MM; //�v����
    float countS = AkagonohateData.SS; //�v����
    int keyTMP = 0;

    public void Update()
    {
        playerLv.text = AkagonohateData.playerLvI.ToString();
        playerName.text = AkagonohateData.playerNmaeT;
        kenSyoji.text = AkagonohateData.itemSyojisu[1].ToString();
        zeniSyoji.text = AkagonohateData.itemSyojisu[0].ToString();
        keyHMMSS.text = countS.ToString();

        //���̏�������6�ȏ�̏ꍇ���l��
        if (5 < AkagonohateData.itemSyojisu[2])
        {
            keyTMP = 5;
        }
        else {
            keyTMP = AkagonohateData.itemSyojisu[2];
        }
        for (int i = 0; i < keyTMP; i++) {
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
        if (AkagonohateData.itemSyojisu[2] < 5)
        {
            countS -= Time.deltaTime;
            if (countS.ToString("f0") == "-1")
            {
                countM--;
                countS = 59;
                if (countM == -1)
                {
                    countH--;
                    countM = 59;
                    if (countH == -1)
                    {
                        //����1�񕜂������̏���
                        countH = 1;
                        if (AkagonohateData.itemSyojisu[2] < 5)
                        {
                            AkagonohateData.itemSyojisu[2]++;
                            keys[AkagonohateData.itemSyojisu[2] - 1].SetActive(true);
                        }
                    }
                }
            }
            //DB�f�[�^�̏㏑��
            AkagonohateData.HH = countH;
            AkagonohateData.MM = countM;
            AkagonohateData.SS = countS;

            //UI�\��
            keyHMMSS.text = countH.ToString("f0") + ":" + countM.ToString("00") + ":" + countS.ToString("00");
        }
        else
        {
            keyHMMSS.text = "0:00:00";
        }
    }
}
