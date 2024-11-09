using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGacha : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] GameObject haikei1;
    [SerializeField] GameObject haikei2;
    [SerializeField] GameObject haikei3;
    [SerializeField] GameObject hoshi1;
    [SerializeField] GameObject hoshi2;
    [SerializeField] GameObject hoshi3;
    [SerializeField] Text isyouName;

    //�L���������G�̒�`(�L�����𑝂₵���Ƃ��ɐ����ǉ�)
    [SerializeField] GameObject[] kyaras;
    //[SerializeField] GameObject naoko01W;
    //[SerializeField] GameObject naoko01S;
    //[SerializeField] GameObject naoko02W;
    //[SerializeField] GameObject naoko02S;
    //[SerializeField] GameObject naoko03furisode;
    //[SerializeField] GameObject yasuko01W;
    //[SerializeField] GameObject yasuko01S;
    //[SerializeField] GameObject yasuko02W;
    //[SerializeField] GameObject yasuko02S;
    //[SerializeField] GameObject yasuko03XX;
    //[SerializeField] GameObject yoshiko01W;
    //[SerializeField] GameObject yoshiko01S;
    //[SerializeField] GameObject yoshiko02W;
    //[SerializeField] GameObject yoshiko02S;
    //[SerializeField] GameObject yoshiko03XX;
    //[SerializeField] GameObject hideta01W;
    //[SerializeField] GameObject hideta01S;
    //[SerializeField] GameObject hideta02W;
    //[SerializeField] GameObject hideta02S;
    //[SerializeField] GameObject hideta03syougatsu1;
    //[SerializeField] GameObject hideya01W;
    //[SerializeField] GameObject hideya01S;
    //[SerializeField] GameObject hideya02W;
    //[SerializeField] GameObject hideya02S;
    //[SerializeField] GameObject hideya03syougatsu1;
    //[SerializeField] GameObject yasuo01W;
    //[SerializeField] GameObject yasuo01S;
    //[SerializeField] GameObject yasuo02W;
    //[SerializeField] GameObject yasuo02S;
    //[SerializeField] GameObject yasuo03XX;
    //�L�������e�L�X�g
    [SerializeField] GameObject[] kyaraNames;
    [SerializeField] GameObject[] kyaraNamesBg;
    //[SerializeField] GameObject naokoT;
    //[SerializeField] GameObject yasukoT;
    //[SerializeField] GameObject yoshikoT;
    //[SerializeField] GameObject hidetaT;
    //[SerializeField] GameObject hideyaT;
    //[SerializeField] GameObject yasuoT;

    int goResFlg = 0;
    void Start()
    {
        Debug.Log(AkagonohateData.gachaFlg);
        btn.onClick.Invoke();
        if (AkagonohateData.gachaFlg == 1) {
            Invoke("goGachaRes", 0.5f);
        }
    }

    int count = 0;
    public void gachaTap()
    {
        if (goResFlg == 0)
        {
            int hyouji = AkagonohateData.gacha10[count];
            Debug.Log(hyouji);

            //���A�x�̈Ⴂ�ɂ��UI�\������
            if (hyouji % 10 <= 1)
            {
                haikei1.SetActive(true);
                haikei2.SetActive(false);
                haikei3.SetActive(false);
                hoshi1.SetActive(true);
                hoshi2.SetActive(false);
                hoshi3.SetActive(false);
                if (hyouji % 10 == 0)
                {
                    isyouName.text = ("�ʏ�E�~");
                }
                else
                {
                    isyouName.text = ("�ʏ�E��");
                }
            }
            if (hyouji % 10 == 2 || hyouji % 10 == 3)
            {
                haikei1.SetActive(false);
                haikei2.SetActive(true);
                haikei3.SetActive(false);
                hoshi1.SetActive(false);
                hoshi2.SetActive(true);
                hoshi3.SetActive(false);
                if (hyouji % 10 == 2)
                {
                    isyouName.text = ("�����E�~");
                }
                else
                {
                    isyouName.text = ("�����E��");
                }
            }
            if (hyouji % 10 >= 4)
            {
                haikei1.SetActive(false);
                haikei2.SetActive(false);
                haikei3.SetActive(true);
                hoshi1.SetActive(false);
                hoshi2.SetActive(false);
                hoshi3.SetActive(true);
            }

            //�L�����\���̏�����
            for (int i = 0; i < 60; i++) {
                kyaras[i].SetActive(false);
            }

            //�L�������\���̏�����
            for (int i = 0; i < 6; i++) {
                kyaraNames[i].SetActive(false);
            }

            //�L�������w�i�\���̏�����
            for (int i = 0; i < 6; i++)
            {
                kyaraNamesBg[i].SetActive(false);
            }

            //�L�����̈Ⴂ�ɂ��L�������E���O�w�i�̕\������
            int who = hyouji / 10;
            kyaraNames[who].SetActive(true);
            kyaraNamesBg[who].SetActive(true);
            Debug.Log("who=" + who);

            //�L�����̈Ⴂ�ɂ�闧���G�\������
            kyaras[hyouji].SetActive(true);
            

            //���Ƀ{�^���������ꂽ�Ƃ��̋����𐧌�
            if (count == 9)
            {
                Invoke("goGachaRes", 0.1f);
            }
            else
            {
                count++;
            }
        }
    }

    /// <summary>
    /// �K�`�����ʉ�ʂւ̑J��(�V�[���̍Ō�Ɏ��{)
    /// </summary>
    void Update() {
        if (goResFlg == 1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene("15GachaRes");
            }
        }
    }

    /// <summary>
    /// goResFlg�̏�������(���ԍ��Ŏ��s���Ȃ��ƍŌシ���ɉ�ʑJ�ڂ��Ă��܂�)
    /// </summary>
    void goGachaRes() {
        goResFlg = 1;
        Debug.Log("goResFlg="+ goResFlg);
    }
}
