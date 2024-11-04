using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CRunwayRes : MonoBehaviour
{
    [SerializeField] GameObject[] bg;
    [SerializeField] GameObject mouichidoBtn;

    [SerializeField] Image resRunner;
    [SerializeField] Sprite[] runnerImages;
    void Start()
    {
        //�w�i�̏�����
        for (int i = 0; i < 9; i++)
        {
            bg[i].SetActive(false);
        }
        //�w�i�̕\��
        int basyo = AkagonohateData.basyo;
        switch (basyo)
        {
            case 1: bg[0].SetActive(true); break;
            case 2: bg[1].SetActive(true); break;
            case 3: bg[2].SetActive(true); break;
            case 4: bg[3].SetActive(true); break;
            case 5: bg[4].SetActive(true); break;
            case 6: bg[5].SetActive(true); break;
            case 7: bg[6].SetActive(true); break;
            case 8: bg[7].SetActive(true); break;
            case 9: bg[8].SetActive(true); break;
        }
        if (AkagonohateData.itemSyojisu[2] == 0) {
            mouichidoBtn.SetActive(false);
        }

        //�����G�̍����ւ�����
        resRunner.sprite = runnerImages[AkagonohateData.runwayMVP[3]];
        //�����G�̃T�C�Y�ύX
        resRunner.GetComponent<RectTransform>();
        int kyara = AkagonohateData.runwayMVP[3] / 10;
        switch (kyara)
        {
            case 0: resRunner.rectTransform.sizeDelta = new Vector3(1800, 2230, 0); break;
            case 1: resRunner.rectTransform.sizeDelta = new Vector3(1800, 2255, 0); break;
            case 2: resRunner.rectTransform.sizeDelta = new Vector3(1800, 2110, 0); break;
            case 3: resRunner.rectTransform.sizeDelta = new Vector3(1800, 2280, 0); break;
            case 4: resRunner.rectTransform.sizeDelta = new Vector3(1800, 2415, 0); break;
            case 5: resRunner.rectTransform.sizeDelta = new Vector3(1800, 2365, 0); break;
        }
    }


    /// <summary>
    /// ������x�����ݒ�Ń����E�F�C�����鎞�̏���
    /// </summary>
    public void mouichido()
    {
        //���̏������������E�㏑��
        AkagonohateData.itemSyojisu[2]--;

        //�l�����O��ݒ�l>�������̏ꍇ
        int moZen = AkagonohateData.moZen;
        int moNow = AkagonohateData.itemSyojisu[3];
        int yuZen = AkagonohateData.moZen;
        int yuNow = AkagonohateData.itemSyojisu[4];
        int niZen = AkagonohateData.moZen;
        int niNow = AkagonohateData.itemSyojisu[5];
        if (moZen > moNow) {
            moZen = moNow;
        }
        if (yuZen > yuNow)
        {
            yuZen = yuNow;
        }
        if (niZen > niNow)
        {
            niZen = niNow;
        }
        SceneManager.LoadScene("11Runway");
    }

    /// <summary>
    /// �ݒ��ς��ă����E�F�C������Ƃ��̏���
    /// </summary>
    public void kaete() {
        SceneManager.LoadScene("10RunwaySet");
    }

    /// <summary>
    /// �����E�F�C���I�����鎞�̏���
    /// </summary>
    public void modoru() {
        SceneManager.LoadScene("05Home");
    }
}
