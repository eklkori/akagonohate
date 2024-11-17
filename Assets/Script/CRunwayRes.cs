using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CRunwayRes : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject[] bg;
    [SerializeField] GameObject mouichidoBtn;
    [SerializeField] GameObject btns;
    [SerializeField] GameObject[] yuryoka; //��ꖋ�D�ǉA��񖋗D�ǉA��O���D�ǉA�����D�ǉ̏��ŉ摜���i�[
    [SerializeField] GameObject[] yuryokaT;
    [SerializeField] GameObject firstText;
    [SerializeField] GameObject cRunwayRes;

    [SerializeField] Image resRunner;
    [SerializeField] Sprite[] runnerImages;

    [SerializeField] Text[] plusShinaiPt;
    [SerializeField] Text[] plusDatePt;
    [SerializeField] Text zeni;
    [SerializeField] Text ninsokuBonusT;

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
        if (AkagonohateData.runwayMVP[3] != -1)//�����i�[��1�l�ȏア��ꍇ�̂ݎ��s
        {
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

        //���̑��\���̏�����
        firstText.SetActive(false);
        for (int i = 0; i < 4; i++) {
            yuryokaT[i].SetActive(false);
        }
        for (int i = 0; i < 12; i++) {
            yuryoka[i].SetActive(false);
        }

        Invoke("showKekka", 0.5f);
    }

    void showKekka() {
        firstText.SetActive(true);

        //�l���e���x�E�l���f�[�gPt��\��
        for (int i = 0; i < 6; i++)
        {
            plusShinaiPt[i].text = AkagonohateData.KshinaiPt[i].ToString();
            plusDatePt[i].text = AkagonohateData.KdatePt[i].ToString();
        }

        //�l���K���l��\��
        zeni.text = AkagonohateData.KItem[0].ToString();

        //�l���{�[�i�X(�l���ɂ���Ċ��葝�����ꂽ�f�[�gPt�̍��v�l)��\��
        int tmp = (AkagonohateData.KItem[3] + AkagonohateData.KItem[4])*5 + AkagonohateData.KItem[5];
        ninsokuBonusT.text = tmp.ToString();


        Invoke("showMakuRes", 0.5f);
    }

    void showMakuResZen() {
        i++;
        Invoke("showMakuRes", 0.5f);
    }

    int i = 0;
    void showMakuRes()
    {
        int maku = 0;
        switch (i)
        {
            case 0: maku = 0; break;
            case 1: maku = 3; break;
            case 2: maku = 6; break;
        }
        if (AkagonohateData.runwayRes[i] == 2)
        {
            maku += 1;
        }
        if (AkagonohateData.runwayRes[i] == 3)
        {
            maku += 2;
        }
        yuryokaT[i].SetActive(true);
        yuryoka[maku].SetActive(true);
        if (i == 2) {
            Invoke("showSougou", 0.8f);
        }
        else
        { 
            showMakuResZen(); 
        }
    }

    void showSougou() {
        yuryokaT[3].SetActive(true);
        Invoke("showSougouImage", 1f);
    }

    void showSougouImage() {
        switch (AkagonohateData.runwayRes[3])
        {
            case 1: yuryoka[9].SetActive(true); break;
            case 2: yuryoka[10].SetActive(true); break;
            case 3: yuryoka[11].SetActive(true); break;
        }
        Invoke("showBtn", 1f);
    }

    void showBtn() {
        btns.SetActive(true);
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
        if (moZen > moNow)
        {
            int saTMP = moZen - moNow;
            datePtGensan(saTMP);
            moZen = moNow;
        }
        if (yuZen > yuNow)
        {
            int saTMP = yuZen - yuNow;
            datePtGensan(saTMP);
            yuZen = yuNow;
        }
        if (niZen > niNow)
        {
            niZen = niNow;
        }

        //�����ƁE�����̕]���l��������
        cRunwayRes.GetComponent<goRunway>().hyouka(moZen,yuZen,niZen);

        //�l���{�[�i�X�l(�l���ɂ���Ċ��葝�����ꂽ�f�[�gPt�̍��v�l)�̏㏑��
        AkagonohateData.KItem[3] = moZen;
        AkagonohateData.KItem[4] = yuZen;
        AkagonohateData.KItem[5] = niZen;

        //�l���A�C�e���������������E�㏑��
        AkagonohateData.itemSyojisu[3] -= moZen;
        AkagonohateData.itemSyojisu[4] -= yuZen;
        AkagonohateData.itemSyojisu[5] -= niZen;
        AkagonohateData.moZen = moZen;
        AkagonohateData.yuZen = yuZen;
        AkagonohateData.niZen = niZen;

        //�l���K���㏑��
        //�l����̑K���z��9999999(���)�𒴂���ꍇ�A���Z
        if (AkagonohateData.itemSyojisu[0] + AkagonohateData.KItem[0] > 9999999)
        {
            AkagonohateData.KItem[0] = 9999999 - AkagonohateData.itemSyojisu[0];
        }
        //�����K�ɉ��Z
        AkagonohateData.itemSyojisu[0] += AkagonohateData.KItem[0];

        //��ʑJ��
        SceneManager.LoadScene("11Runway");
    }

    /// <summary>
    /// �O��ݒ�l>�������̏ꍇ�̂݁A���̕������l���������Z�@���ݒ肳��Ă���L�����ɂ̂�
    /// </summary>
    /// <param name="saTMP"></param>
    void datePtGensan(int saTMP) {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                Debug.Log("AkagonohateData.runner[j]=" + AkagonohateData.runner[j] + "  i=" + i);
                int kyara = AkagonohateData.runner[j] / 10;
                Debug.Log("kyara="+kyara);
                if (kyara == i && AkagonohateData.runner[j] != -1)
                {
                    Debug.Log(AkagonohateData.KdatePt[i] + " saTMP=" + saTMP);
                    Debug.Log("���@" + saTMP * 5);
                    AkagonohateData.KdatePt[i] -= saTMP * 5;
                    break;
                }
            }
        }
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
