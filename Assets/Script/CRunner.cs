using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] GameObject[] isyouBtnAll;
    //ランナー画面で表示されるボタンの画像差し替え用
    [SerializeField] Sprite[] runnerImages;
    [SerializeField] GameObject[] Btns;
    [SerializeField] Image[] BtnImages;

    private void Start()
    {
        //テスト用処理(仮置き)START
        AkagonohateData.isyoSyojiFlg[0] = 1;
        AkagonohateData.isyoSyojiFlg[13] = 1;
        AkagonohateData.isyoSyojiFlg[21] = 1;
        for (int i = 0; i < 24; i++)
        {
            AkagonohateData.runner[i] = -1;　//runer[]==0の場合を考慮して、初期値を-1に変更する処理(gamenseni.csで実装済み)
        }
        //テスト用処理(仮置き)END
        for (int i = 0; i < 8; i++) {
            if (AkagonohateData.runner[i] == -1)
            {
                Btns[i].SetActive(false);
            }
        }
        AkagonohateData.hyoujimaku = 1;
    }

    int wakuNo = 0;

    /// <summary>
    /// ランナー画面でのランナー追加「＋」ボタン押下時の処理
    /// (所持衣装一覧表示)
    /// </summary>
    /// <param name="WakuNo"></param>
    public void plusBtn(int WakuNo)
    {
        wakuNo = WakuNo;
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
        //isyouBtnAll[2].SetActive(true);
        //所持衣装の一覧を取得
        //var syojiList = new List<int>();
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i]==1) {
                //syojiList.Add(i);
                isyouBtnAll[i].SetActive(true);
            }
        }
    }

    /// <summary>
    /// ポップアップ上のアイコンボタンを押されたときの処理
    /// </summary>
    /// <param name="num"></param>
    public void popupKyaraBtn(int num)
    {
        int wakuNoTMP = wakuNo;
        if (AkagonohateData.hyoujimaku == 2)
        {
            wakuNoTMP -= 8;
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            wakuNoTMP -= 16;
        }
        //ボタンを表示
        Btns[wakuNoTMP].SetActive(true);

        //ランナー配列に衣装Noをセット
        AkagonohateData.runner[wakuNo] = num;

        //画像の差し替え
        BtnImages[wakuNoTMP].sprite = runnerImages[num];
        Debug.Log(num);

        //ポップアップを閉じる
        haikeiBtn();
    }

    /// <summary>
    /// 外すボタン押下時の処理
    /// </summary>
    /// <param name="num"></param>
    public void hazusu(int num) {
        Btns[num].SetActive(false);
        if (AkagonohateData.hyoujimaku == 2)
        {
            num += 8;
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            num += 16;
        }
        AkagonohateData.runner[num] = -1;
    }

    /// <summary>
    /// 第一～三幕ボタンが押されたときのランナー初期表示
    /// </summary>
    public void syokiRunner() {
        int makuNo = AkagonohateData.hyoujimaku;
        int[] kakunin = { 0, 1, 2, 3, 4, 5, 6, 7 };
        for (int i = 0; i < 8; i++)
        {
            if (makuNo == 2)
            {
                kakunin[i] += 8;
            }
            if (makuNo == 3)
            {
                kakunin[i] += 16;
            }
            //設定値があればボタンを表示させた上で画像の差し替え、無ければ非表示
            if (AkagonohateData.runner[kakunin[i]] == -1)
            {
                Btns[i].SetActive(false);
            }
            else {
                Btns[i].SetActive(true);
                BtnImages[i].sprite = runnerImages[AkagonohateData.runner[kakunin[i]]];
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
