using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startKaiwa : MonoBehaviour
{
    //------------------------------------
    //��b�E�f�[�g�E�v���J�n���̏������L��
    //
    //���e���x�m�F��ʂ���̏�����Cshinaido3.cs�Ŏ����ς�
    //------------------------------------

    //���t�擾
    DateTime localDate = DateTime.Now;
    DateTime today;
    private void Start()
    {
        //�e�X�g�p����START
        AkagonohateData.datePt[0] = 1000;
        AkagonohateData.datePt[1] = 1000;
        //�e�X�g�p����END
    }
    /// <summary>
    /// kyaraNo��0�n�܂�
    /// </summary>
    int kyaraNo = AkagonohateData.tansakuKyara;
    public void startKaiwas()
    {
        kyaraNo = AkagonohateData.tansakuKyara;

        Debug.Log("kyaraNo=" + kyaraNo);
        switch (kyaraNo)
        {
            //kaiwaNo�ɃV�i���I���x�����i�[
            case 0: AkagonohateData.kaiwaNo = "naokoK"; break;
            case 1: AkagonohateData.kaiwaNo = "yasukoK"; break;
            case 2: AkagonohateData.kaiwaNo = "yoshikoK"; break;
            case 3: AkagonohateData.kaiwaNo = "hidetaK"; break;
            case 4: AkagonohateData.kaiwaNo = "hideyaK"; break;
            case 5: AkagonohateData.kaiwaNo = "yasuoK"; break;
        }

        //�e��Pt�̏㏑���F1���̏���̂݊e�L����5���オ��
        if (today != AkagonohateData.kaiwaRireki[kyaraNo])
        {
            Debug.Log(today);
            Debug.Log(AkagonohateData.kaiwaRireki[kyaraNo]);
            //�l���e��Pt�̌v�Z(�ؖ��ւ̑z���𔽉f������)
            int shinaiTMP = 0;
            switch (AkagonohateData.kimata[kyaraNo])
            {
                case 1: shinaiTMP = 1; break;
                case 2: shinaiTMP = 3; break;
                case 3: shinaiTMP = 5; break;
            }
            AkagonohateData.shinaiPt[kyaraNo] += shinaiTMP;
            AkagonohateData.KshinaiPt[kyaraNo] = shinaiTMP;

            //����t���O�̍X�V
            AkagonohateData.KSyokaiFlg[kyaraNo] = 1;

            //��b�����̏㏑��
            //1�����z��v�f�����ɂ��炷
            for (int i = 3; i >= 0; i--)
            {
                AkagonohateData.kaiwaRireki[kyaraNo + i * 10] = AkagonohateData.kaiwaRireki[kyaraNo + i * 10 + 10];
            }
            //�z���0�ԑ�ɍ����̓��t���i�[
            AkagonohateData.kaiwaRireki[kyaraNo] = today;

            //���S�L������ʂ��Ă��̓����߂Ẳ�b�������ꍇ�A�����Ƃ̍��Z��b�񐔂�������
            int tmp = 0;
            for (int i = 0; i < 6; i++) {
                if (AkagonohateData.kaiwaRireki[i] == today) {
                    tmp++;
                    break;
                }
            }
            if (tmp == 0) {
                AkagonohateData.countDay[0] = 0;
            }
            //���S�L������ʂ��Ă��̏T���߂Ẳ�b�������ꍇ�A�T���Ƃ̍��Z��b�񐔂�������
            //���T�̍ŏ��̓�(���j��)���擾
            DateTime dtLastMonday = today.AddDays((7 - (int)today.DayOfWeek) % 7 - 6);
            int tmp2 = 0;
            for (int i = 0; i < 6; i++)
            {
                if (AkagonohateData.kaiwaRireki[i] >= dtLastMonday.Date)
                {
                    tmp2++;
                    break;
                }
            }
            if (tmp2 == 0)
            {
                AkagonohateData.countDay[2] = 0;
            }
        }
        else 
        {
            //����t���O�̍X�V
            AkagonohateData.KSyokaiFlg[kyaraNo] = 0;
        }

        //�݌v��b�񐔂̏㏑��
        AkagonohateData.kaiwaCount[kyaraNo]++;

        //�����Ƃ̍��Z��b�񐔂̏㏑��
        AkagonohateData.countDay[0]++;

        //�T���Ƃ̍��Z��b�񐔂̏㏑��
        AkagonohateData.countDay[2]++;

        Debug.Log(AkagonohateData.kaiwaNo);
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("06Tansaku");
    }

    public void startMitsugu() {
        SceneManager.LoadScene("08Mitsugu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("06Tansaku");
    }

    /// <summary>
    /// �f�[�g�J�n����
    /// </summary>
    public void startDate() {
        kyaraNo = AkagonohateData.tansakuKyara;

        //�V�i���I���x���̍쐬
        string kyaraName = "";
        Debug.Log(AkagonohateData.dateCount[kyaraNo] + 1);
        Debug.Log(kyaraNo);
        string dateShinchoku = (AkagonohateData.dateCount[kyaraNo] +1).ToString();
        switch (kyaraNo)
        {
            case 0: kyaraName = "naoko"; break;
            case 1: kyaraName = "yasuko"; break;
            case 2: kyaraName = "yoshiko"; break;
            case 3: kyaraName = "hideta"; break;
            case 4: kyaraName = "hideya"; break;
            case 5: kyaraName = "yasuo"; break;
        }
        AkagonohateData.kaiwaNo = ("D" + kyaraName + dateShinchoku);

        //�݌v�f�[�g�񐔂̏㏑��
        AkagonohateData.dateCount[kyaraNo]++;

        //�f�[�gPt�̏�����
        AkagonohateData.datePt[kyaraNo] = 0;
        Debug.Log(kyaraNo);
        Debug.Log(AkagonohateData.datePt[kyaraNo]);

        Debug.Log(AkagonohateData.kaiwaNo);
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("06Tansaku");
    }

    void Update()
    {
        //�������t�̎擾
        today = localDate.Date;
    }
}
