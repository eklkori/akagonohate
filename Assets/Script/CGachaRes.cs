using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGachaRes : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject tapT;
    [SerializeField] GameObject tanpatsu;
    [SerializeField] GameObject jyuren;
    [SerializeField] Image kyara;
    [SerializeField] Image[] kyaras;
    [SerializeField] Sprite[] kyaraImages;

    int tenmetsuFlg = 0;
    void Start()
    {
        if (AkagonohateData.gachaFlg == 1)
        {
            Tanpatsu();
        }
        else {
            Jyuren();
        }
    }

    /// <summary>
    /// �P���̌��ʉ�ʕ\��
    /// </summary>
    void Tanpatsu() {
        tanpatsu.SetActive(true);
        jyuren.SetActive(false);

        //�L�����摜�����ւ�
        kyara.sprite = kyaraImages[AkagonohateData.gacha10[0]];
    }

    /// <summary>
    /// 10�A�̌��ʉ�ʕ\��
    /// </summary>
    void Jyuren(){
        tanpatsu.SetActive(false);
        jyuren.SetActive(true);

        //�L�����摜�����ւ�
        for (int i = 0; i < 10; i++) {
            kyara.sprite = kyaraImages[AkagonohateData.gacha10[i]];
        }
    }

    void Update()
    {
        //�u-TAP-�v��_�ł����鏈��
        Color colorTap = tapT.GetComponent<Image>().color;
        //tapT.GetComponent<Image>().color = colorTap;
        if (tenmetsuFlg == 0)
        {
            colorTap.a -= 0.02f;
            tapT.GetComponent<Image>().color = colorTap;
        }
        else if (tenmetsuFlg == 1)
        {
            colorTap.a += 0.02f;
            tapT.GetComponent<Image>().color = colorTap;
        }
        if (colorTap.a < 0)
        {
            tenmetsuFlg = 1;
        }
        else if (colorTap.a > 1)
        {
            tenmetsuFlg = 0;
        }
    }
}
