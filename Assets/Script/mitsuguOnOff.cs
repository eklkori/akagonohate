using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UnityEngine.UI;

public class mitsuguOnOff : MonoBehaviour
{
    //�v����ʁ@�m��{�^�������O���UI�\��/��\���؂�ւ�
    //�f�ނ̒�`
    [SerializeField] GameObject[] plusBtn;
    [SerializeField] GameObject[] minusBtn;
    [SerializeField] GameObject kakutei;
    [SerializeField] GameObject off;
    [SerializeField] Text[] syojisuT;
    [SerializeField] Text[] mitsugisuT;
    [SerializeField] Image kyaraTachie;
    [SerializeField] Sprite[] kyaraImages;
    [SerializeField] GameObject advEngine;

    int[] mitsugisu = new int[6];
    int kyara = 0;

    //���p
    public AdvEngine engine;

    private void Start()
    {
        //�e�X�g�p����START
        AkagonohateData.itemSyojisu[10] = 5;
        AkagonohateData.itemSyojisu[11] = 130;
        AkagonohateData.itemSyojisu[14] = 10;
        //�e�X�g�p����END

        //�����A�C�e������\���E-�{�^���̔�\��
        for (int i = 0; i < 6; i++)
        {
            syojisuT[i].text = AkagonohateData.itemSyojisu[10+i].ToString();
            minusBtn[i].SetActive(false);

            //�A�C�e����������0�̏ꍇ�́A�{�{�^������\��
            if (AkagonohateData.itemSyojisu[10 + i] == 0) {
                plusBtn[i].SetActive(false);
            }
        }
        kakutei.SetActive(false);

        //�L�����摜�̍����ւ�
        //�����G�̍����ւ�����
        kyaraTachie.sprite = kyaraImages[AkagonohateData.tansakuKyara];  //���ߑ������_���ɂ���ꍇ�͂��̕ӂ�ɏ�����ǉ�
        //�����G�̃T�C�Y�ύX
        kyaraTachie.GetComponent<RectTransform>();
        switch (AkagonohateData.tansakuKyara)
        {
            case 0: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2230, 0); break;
            case 1: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2255, 0); break;
            case 2: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2110, 0); break;
            case 3: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2280, 0); break;
            case 4: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2415, 0); break;
            case 5: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2365, 0); break;
        }
    }

    /// <summary>
    /// �{�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void pushPlusBtn(int kyaraNo) {
        kyara = kyaraNo;

        //�v�����𑀍�
        mitsugisu[kyara]++;
        mitsugisuT[kyara].text = mitsugisu[kyara].ToString();

        //UI����
        if (mitsugisu[kyara] == 99 || AkagonohateData.itemSyojisu[10 + kyara] == mitsugisu[kyara])
        {
            plusBtn[kyara].SetActive(false);
        }
        minusBtn[kyara].SetActive(true);
        kakutei.SetActive(true);
    }

    /// <summary>
    /// -�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void pushMinus(int kyaraNo)
    {
        kyara = kyaraNo;

        //�v�����𑀍�
        mitsugisu[kyara]--;
        mitsugisuT[kyara].text = mitsugisu[kyara].ToString();

        //UI����
        plusBtn[kyara].SetActive(true);

        //�v����1�����������ꍇ�A�m��{�^�����\���ɂ���
        if (mitsugisu[kyara] == 0)
        {
            minusBtn[kyara].SetActive(false);
            int tmp = 0;
            for (int i = 0; i < 6; i++)
            {
                if (mitsugisu[i] != 0)
                {
                    tmp++;
                    break;
                }
            }
            if (tmp == 0)
            {
                kakutei.SetActive(false);
            }
        }
    }

    /// <summary>
    /// �m��{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void mitsuguOff()
    {
        //UI��\��
        off.SetActive(false);

        //�l���e��Pt�E�A�C�e���������̌v�Z
        AkagonohateData.KshinaiPt[kyara] = 0;
        for (int i = 0; i < 6; i++) {
            //�A�C�e���������̏㏑��
            AkagonohateData.itemSyojisu[i+10] -= mitsugisu[i];

            //�l���e��Pt�̌v�Z
            int tmp = mitsugisu[i]*10;
            if (i == AkagonohateData.tansakuKyara) {
                tmp *= 5;
            }
            AkagonohateData.KshinaiPt[kyara] += tmp;
        }

        //���ɒl��n��
          //�p�����[�^�[�̎擾
          //int point = engine.Param.GetParameterInt("shinaido");
        //�^�w��ς݂̐ݒ���@
        engine.Param.SetParameterInt("shinaido", AkagonohateData.KshinaiPt[kyara]);

        //�V�i���I���x���̃Z�b�g
        string No = "";
        switch (AkagonohateData.tansakuKyara)
        {
            case 0: No = "naoko"; break;
            case 1: No = "yasuko"; break;
            case 2: No = "yoshiko"; break;
            case 3: No = "hideta"; break;
            case 4: No = "hideya"; break;
            case 5: No = "yasuo"; break;
        }
        //1�`2�̃����_���Ȑ��� �͈͂��w��
        string random = Random.Range(1, 3).ToString();
        AkagonohateData.kaiwaNo = No+random;

        advEngine.GetComponent<SampleAdvEngineController2>().JumpScenario(AkagonohateData.kaiwaNo);
    }

    /// <summary>
    /// �v���I����̏���
    /// </summary>
    void Update()
    {
        //AdvEngine�̏�����
        if (!engine.Param.IsInit) return;

        //�p�����[�^�[�̌Ăяo��
        int mitsuguEnd = engine.Param.GetParameterInt("mitsuguEnd");

        if (mitsuguEnd == 1)
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }
}
