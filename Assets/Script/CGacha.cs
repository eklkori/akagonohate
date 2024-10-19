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
    public Text isyouName;

    //�L���������G�̒�`(�L�����𑝂₵���Ƃ��ɐ����ǉ�)
    [SerializeField] GameObject naoko01W;
    [SerializeField] GameObject naoko01S;
    [SerializeField] GameObject naoko02W;
    [SerializeField] GameObject naoko02S;
    [SerializeField] GameObject naoko03furisode;
    [SerializeField] GameObject yasuko01W;
    [SerializeField] GameObject yasuko01S;
    [SerializeField] GameObject yasuko02W;
    [SerializeField] GameObject yasuko02S;
    [SerializeField] GameObject yasuko03XX;
    [SerializeField] GameObject yoshiko01W;
    [SerializeField] GameObject yoshiko01S;
    [SerializeField] GameObject yoshiko02W;
    [SerializeField] GameObject yoshiko02S;
    [SerializeField] GameObject yoshiko03XX;
    [SerializeField] GameObject hideta01W;
    [SerializeField] GameObject hideta01S;
    [SerializeField] GameObject hideta02W;
    [SerializeField] GameObject hideta02S;
    [SerializeField] GameObject hideta03syougatsu1;
    [SerializeField] GameObject hideya01W;
    [SerializeField] GameObject hideya01S;
    [SerializeField] GameObject hideya02W;
    [SerializeField] GameObject hideya02S;
    [SerializeField] GameObject hideya03syougatsu1;
    [SerializeField] GameObject yasuo01W;
    [SerializeField] GameObject yasuo01S;
    [SerializeField] GameObject yasuo02W;
    [SerializeField] GameObject yasuo02S;
    [SerializeField] GameObject yasuo03XX;
    //�L�������e�L�X�g
    [SerializeField] GameObject naokoT;
    [SerializeField] GameObject yasukoT;
    [SerializeField] GameObject yoshikoT;
    [SerializeField] GameObject hidetaT;
    [SerializeField] GameObject hideyaT;
    [SerializeField] GameObject yasuoT;

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
            naoko01W.SetActive(false);
            naoko01S.SetActive(false);
            naoko02W.SetActive(false);
            naoko02S.SetActive(false);
            naoko03furisode.SetActive(false);
            yasuko01W.SetActive(false);
            yasuko01S.SetActive(false);
            yasuko02W.SetActive(false);
            yasuko02S.SetActive(false);
            yasuko03XX.SetActive(false);
            yoshiko01W.SetActive(false);
            yoshiko01S.SetActive(false);
            yoshiko02W.SetActive(false);
            yoshiko02S.SetActive(false);
            yoshiko03XX.SetActive(false);
            hideta01W.SetActive(false);
            hideta01S.SetActive(false);
            hideta02W.SetActive(false);
            hideta02S.SetActive(false);
            hideta03syougatsu1.SetActive(false);
            hideya01W.SetActive(false);
            hideya01S.SetActive(false);
            hideya02W.SetActive(false);
            hideya02S.SetActive(false);
            hideya03syougatsu1.SetActive(false);
            yasuo01W.SetActive(false);
            yasuo01S.SetActive(false);
            yasuo02W.SetActive(false);
            yasuo02S.SetActive(false);
            yasuo03XX.SetActive(false);
            naokoT.SetActive(false);
            yasukoT.SetActive(false);
            yoshikoT.SetActive(false);
            hidetaT.SetActive(false);
            hideyaT.SetActive(false);
            yasuoT.SetActive(false);

            //�L�����̈Ⴂ�ɂ��L�������\������
            if (hyouji <= 9)
            {
                naokoT.SetActive(true);
            }
            if (10 <= hyouji && hyouji <= 19)
            {
                yasukoT.SetActive(true);
            }
            if (20 <= hyouji && hyouji <= 29)
            {
                yoshikoT.SetActive(true);
            }
            if (30 <= hyouji && hyouji <= 39)
            {
                hidetaT.SetActive(true);
            }
            if (40 <= hyouji && hyouji <= 49)
            {
                hideyaT.SetActive(true);
            }
            if (50 <= hyouji && hyouji <= 59)
            {
                yasuoT.SetActive(true);
            }

            //�L�����̈Ⴂ�ɂ�闧���G�\������
            if (hyouji == 0)
            {
                naoko01W.SetActive(true);
            }
            if (hyouji == 1)
            {
                naoko01S.SetActive(true);
            }
            if (hyouji == 2)
            {
                naoko02W.SetActive(true);
            }
            if (hyouji == 3)
            {
                naoko02S.SetActive(true);
            }
            if (hyouji == 4)
            {
                naoko03furisode.SetActive(true);
            }
            if (hyouji == 10)
            {
                yasuko01W.SetActive(true);
            }
            if (hyouji == 11)
            {
                yasuko01S.SetActive(true);
            }
            if (hyouji == 12)
            {
                yasuko02W.SetActive(true);
            }
            if (hyouji == 13)
            {
                yasuko02S.SetActive(true);
            }
            if (hyouji == 20)
            {
                yoshiko01W.SetActive(true);
            }
            if (hyouji == 21)
            {
                yoshiko01S.SetActive(true);
            }
            if (hyouji == 22)
            {
                yoshiko02W.SetActive(true);
            }
            if (hyouji == 23)
            {
                yoshiko02S.SetActive(true);
            }
            if (hyouji == 30)
            {
                hideta01W.SetActive(true);
            }
            if (hyouji == 31)
            {
                hideta01S.SetActive(true);
            }
            if (hyouji == 32)
            {
                hideta02W.SetActive(true);
            }
            if (hyouji == 33)
            {
                hideta02S.SetActive(true);
            }
            if (hyouji == 34)
            {
                hideta03syougatsu1.SetActive(true);
            }
            if (hyouji == 40)
            {
                hideya01W.SetActive(true);
            }
            if (hyouji == 41)
            {
                hideya01S.SetActive(true);
            }
            if (hyouji == 42)
            {
                hideya02W.SetActive(true);
            }
            if (hyouji == 43)
            {
                hideya02S.SetActive(true);
            }
            if (hyouji == 44)
            {
                hideya03syougatsu1.SetActive(true);
            }
            if (hyouji == 50)
            {
                yasuo01W.SetActive(true);
            }
            if (hyouji == 51)
            {
                yasuo01S.SetActive(true);
            }
            if (hyouji == 52)
            {
                yasuo02W.SetActive(true);
            }
            if (hyouji == 53)
            {
                yasuo02S.SetActive(true);
            }

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
