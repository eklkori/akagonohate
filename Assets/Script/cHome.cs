using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cHome : MonoBehaviour
{

    //�L���������G�\���n
    [SerializeField] GameObject[] kyaraBtns;
    [SerializeField] Sprite[] kyaraImage;
    [SerializeField] Image kyaraTachie;

    //�I�𒆘g
    [SerializeField] GameObject[] sentakuchu;
    void Start()
    {
        int kyaraNo = AkagonohateData.partnerNo;
        kyaraBtn(kyaraNo);
    }

    /// <summary>
    /// �p�[�g�i�[�I���{�^���������̏����\��
    /// </summary>
    public void syokihyouji() {
        //�ߑ����� / �������ɂ��\���𐧌�
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1)
            {
                kyaraBtns[i].SetActive(true);
            }
            else {
                kyaraBtns[i].SetActive(false);
            }
        }

        //�I�𒆘g�̕\��
        //������
        for (int i = 0; i < 60; i++) {
            sentakuchu[i].SetActive(false);
        }
        //�I�𒆈ߑ��݂̂ɘg��\��
        int syojiCount = -1;
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1) {
                syojiCount++;
            }
            if (AkagonohateData.partnerNo == AkagonohateData.isyoSyojiFlg[i]) {
                sentakuchu[syojiCount].SetActive(true);
                break;
            }
        }

    }

    /// <summary>
    /// �L�����{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void kyaraBtn(int kyaraNo)
    {
        //�摜�����ւ�����
        AkagonohateData.partnerNo = kyaraNo;
        kyaraTachie.sprite = kyaraImage[AkagonohateData.partnerNo];

        //�T�C�Y�ύX
        RectTransform rectTransform = kyaraTachie.GetComponent<RectTransform>();
        int num = kyaraNo / 10;
        //transform.localScale = new Vector3(1400, 2227, 0);
        switch (num)
        {
            case 0: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1830, 1); break;
            case 1: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1850, 1); break;
            case 2: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1730, 1); break;
            case 3: kyaraTachie.rectTransform.sizeDelta  = new Vector3(1500, 1870, 1); break;
            case 4: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1980, 1); break;
            case 5: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1940, 1); break;
        }
        //�T�C�Y�ύX(��蕨�ȂǂŌʐݒ肪�K�v�ɂȂ�ꍇ������΂����ɋL��)

    }
    void Update()
    {
        
    }
}
