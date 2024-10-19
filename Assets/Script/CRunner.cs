using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRunner : MonoBehaviour
{
    //ëfçﬁÇÃíËã`
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject runnersentakuT;
    [SerializeField] GameObject syousaiT;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject kaishiBtn;
    [SerializeField] GameObject popupBase2;
    [SerializeField] GameObject setteishita;
    [SerializeField] GameObject key;
    [SerializeField] GameObject hai;
    [SerializeField] GameObject hai2;
    [SerializeField] GameObject iie;
    [SerializeField] GameObject haiBtn;
    [SerializeField] GameObject hai2Btn;
    [SerializeField] GameObject iieBtn;
    [SerializeField] GameObject now;
    [SerializeField] GameObject after;
    [SerializeField] GameObject sankaku;
    [SerializeField] GameObject tarimasen;
    [SerializeField] GameObject imasugu;

    int wakuNo = 0;
    public void btn1(){
        wakuNo = 1;
        plusBtn(wakuNo);
        }
    public void btn2()
    {
        wakuNo = 2;
        plusBtn(wakuNo);
    }
    public void btn3()
    {
        wakuNo = 3;
        plusBtn(wakuNo);
    }
    public void btn4()
    {
        wakuNo = 4;
        plusBtn(wakuNo);
    }
    public void btn5()
    {
        wakuNo = 5;
        plusBtn(wakuNo);
    }
    public void btn6()
    {
        wakuNo = 6;
        plusBtn(wakuNo);
    }
    public void btn7()
    {
        wakuNo = 7;
        plusBtn(wakuNo);
    }
    public void btn8()
    {
        wakuNo = 8;
        plusBtn(wakuNo);
    }
    public void plusBtn(int wakuNo)
    {
        batsu.SetActive(true);
        runnersentakuT.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        if (AkagonohateData.hyoujimaku == 2) {
            wakuNo += 8;
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            wakuNo += 16;
        }
        Debug.Log(wakuNo);
    }
    public void haikeiBtn()
    {
        batsu.SetActive(false);
        runnersentakuT.SetActive(false);
        haikei.SetActive(false);
        popupBase.SetActive(false);
        popupBase2.SetActive(false);
        setteishita.SetActive(false);
        key.SetActive(false);
        hai.SetActive(false);
        hai2.SetActive(false);
        iie.SetActive(false);
        haiBtn.SetActive(false);
        hai2Btn.SetActive(false);
        iieBtn.SetActive(false);
        now.SetActive(false);
        after.SetActive(false);
        sankaku.SetActive(false);
        tarimasen.SetActive(false);
        imasugu.SetActive(false);
    }
}
