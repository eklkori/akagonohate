using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CRunner : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject runnersentakuT;
    [SerializeField] GameObject syousaiT;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject scroll;
    //[SerializeField] GameObject kyaras;

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

    //ポップアップで表示される各種ランナーボタン
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
    [SerializeField] GameObject kari;


    [SerializeField] GameObject[] isyouAll = new GameObject[60];// = { naoko01W, naoko01S, naoko02W, naoko02S, naoko03furisode, yasuko01W, yasuko01S, yasuko02W, yasuko02S, yasuko03XX, yoshiko01W, yoshiko01S, yoshiko02W, yoshiko02S, yoshiko03XX, hideta01W, hideta01S, hideta02W, hideta02S, hideta03syougatsu1, hideya01W, hideya01S, hideya02W, hideya02S, hideya03syougatsu1, yasuo01W, yasuo01S, yasuo02W, yasuo02S, yasuo03XXs };

    int wakuNo = 0;

    private void Start()
    {
        GameObject[] isyouAll = { naoko01W, naoko01S, naoko02W, naoko02S, naoko03furisode,kari,kari,kari,kari,kari, yasuko01W, yasuko01S, yasuko02W, yasuko02S, yasuko03XX, kari, kari, kari, kari, kari, yoshiko01W, yoshiko01S, yoshiko02W, yoshiko02S, yoshiko03XX, kari, kari, kari, kari, kari, hideta01W, hideta01S, hideta02W, hideta02S, hideta03syougatsu1, kari, kari, kari, kari, kari, hideya01W, hideya01S, hideya02W, hideya02S, hideya03syougatsu1, kari, kari, kari, kari, kari, yasuo01W, yasuo01S, yasuo02W, yasuo02S, yasuo03XX ,kari, kari, kari, kari, kari };
    }
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

    /// <summary>
    /// ランナー画面でのランナー追加「＋」ボタン押下時の処理
    /// (所持衣装一覧表示を含む)
    /// </summary>
    /// <param name="wakuNo"></param>
    public void plusBtn(int wakuNo)
    {
        batsu.SetActive(true);
        runnersentakuT.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        scroll.SetActive(true);
        //kyaras.SetActive(true);
        if (AkagonohateData.hyoujimaku == 2) {
            wakuNo += 8;
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            wakuNo += 16;
        }
        Debug.Log(wakuNo);
        isyouAll[2].SetActive(true);
        //所持衣装の一覧を取得
        var syojiList = new List<int>();
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i]==1) {
                syojiList.Add(i);
                isyouAll[2].SetActive(true);
            }
        }
    }

    /// <summary>
    /// ポップアップを閉じる
    /// </summary>
    public void haikeiBtn()
    {
        scroll.SetActive(false);
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
