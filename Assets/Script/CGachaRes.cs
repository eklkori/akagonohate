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
    [SerializeField] GameObject newIcon;
    [SerializeField] GameObject[] newIcons;
    [SerializeField] Image kyara;
    [SerializeField] Image[] kyaras;
    [SerializeField] Sprite[] kyaraImages;

    [SerializeField] GameObject kyaraSyousaiPopUp;

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

        //���l���L�����̏ꍇ�Anew!��\��
        newIcon.SetActive(false);
        if (AkagonohateData.gachaNotNew[0] == 0) {
            newIcon.SetActive(true);
        }
    }

    /// <summary>
    /// 10�A�̌��ʉ�ʕ\��
    /// </summary>
    void Jyuren(){
        tanpatsu.SetActive(false);
        jyuren.SetActive(true);

        //�L�����摜�����ւ�
        for (int i = 0; i < 10; i++) {
            kyaras[i].sprite = kyaraImages[AkagonohateData.gacha10[i]];
        }

        //���l���L�����̏ꍇ�Anew!��\��
        for (int i = 0; i < 10; i++)
        {
            newIcons[i].SetActive(false);
            if (AkagonohateData.gachaNotNew[i] == 0)
            {
                newIcons[i].SetActive(true);
            }
        }
    }

    void Update()
    {
        //�u-TAP-�v��_�ł����鏈��
        Color colorTap = tapT.GetComponent<Image>().color;
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

    /// <summary>
    /// �L�����ڍ׃|�b�v�A�b�v�̕\�������ɔ�΂�
    /// </summary>
    public void showPopUp(int num) {
        kyaraSyousaiPopUp.GetComponent<kyaraSyosaiPopUp>().pushIcon(AkagonohateData.gacha10[num]);
    } 
}
