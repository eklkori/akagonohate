using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTask : MonoBehaviour
{
    [SerializeField] Text hosyuT;
    [SerializeField] GameObject zeni;
    [SerializeField] GameObject ken;

    [SerializeField] GameObject scrollNikka;
    [SerializeField] GameObject scrollSyukan;
    [SerializeField] GameObject scrollEvent;
    [SerializeField] GameObject nikkaNo;
    [SerializeField] GameObject syukanNo;
    [SerializeField] GameObject eventNo;
    [SerializeField] GameObject[] nikkas;
    [SerializeField] GameObject[] syukans;
    [SerializeField] GameObject[] events;
    [SerializeField] GameObject[] tasseiIcon;
    [SerializeField] GameObject[] kakutokuBtnN;
    [SerializeField] GameObject[] kakutokuBtnS;
    [SerializeField] GameObject[] kakutokuBtnE;
    [SerializeField] GameObject[] kakutokuzumiN;
    [SerializeField] GameObject[] kakutokuzumiS;
    [SerializeField] GameObject[] kakutokuzumiE;
    [SerializeField] GameObject kakutokuPopup;

    /// <summary>
    /// 表示中のタスク(1：日課、2：週間、3：イベント)
    /// </summary>
    int hyoujiTask = 0;

    /// <summary>
    /// 獲得ボタンから受け取るアイテムが銭か券かを判断
    /// </summary>
    int itemFlg = 0;

    /// <summary>
    /// 獲得したボタンのNoを表示
    /// </summary>
    int btnNo = 0;

    /// <summary>
    /// タスクの総数を格納※併せてAkagonohateData.tasseiFlgXの値も編集する必要あり
    /// </summary>
    [SerializeField] int countN;
    [SerializeField] int countS;
    [SerializeField] int countE;
    void Start()
    {
        //テスト用処理START
        AkagonohateData.tasseiFlgN[0] = 1;
        AkagonohateData.tasseiFlgN[1] = 1;
        //テスト用処理END

        showNikka();
    }

    public void showNikka() {
        hyoujiTask = 1;
        nikkaNo.SetActive(true);
        syukanNo.SetActive(false);
        eventNo.SetActive(false);
        scrollNikka.SetActive(true);
        scrollSyukan.SetActive(false);
        scrollEvent.SetActive(false);
        CBtn();
    }
    public void showSyukan()
    {
        hyoujiTask = 2;
        nikkaNo.SetActive(false);
        syukanNo.SetActive(true);
        eventNo.SetActive(false);
        scrollNikka.SetActive(false);
        scrollSyukan.SetActive(true);
        scrollEvent.SetActive(false);
        CBtn();
    }
    public void showEvent()
    {
        hyoujiTask = 3;
        nikkaNo.SetActive(false);
        syukanNo.SetActive(false);
        eventNo.SetActive(true);
        scrollNikka.SetActive(false);
        scrollSyukan.SetActive(false);
        scrollEvent.SetActive(true);
        CBtn();
    }

    /// <summary>
    /// 獲得/未獲得ボタンの制御
    /// </summary>
    void CBtn() {
        int forCount = 0;
        switch (hyoujiTask)
        {
            case 1: forCount = countN; break;
            case 2: forCount = countS; break;
            case 3: forCount = countE; break;
        }
        for (int i = 0; i < forCount; i++) {
            if (hyoujiTask==1) {
                switch (AkagonohateData.tasseiFlgN[i])
                {
                    case 1: kakutokuBtnN[i].SetActive(false); kakutokuzumiN[i].SetActive(false); break;
                    case 0: kakutokuBtnN[i].SetActive(true); kakutokuzumiN[i].SetActive(false); break;
                    case 2: kakutokuBtnN[i].SetActive(false); kakutokuzumiN[i].SetActive(true); break;
                }
            }
            if (hyoujiTask == 2)
            {
                switch (AkagonohateData.tasseiFlgS[i])
                {
                    case 1: kakutokuBtnS[i].SetActive(false); kakutokuzumiS[i].SetActive(false); break;
                    case 0: kakutokuBtnS[i].SetActive(true); kakutokuzumiS[i].SetActive(false); break;
                    case 2: kakutokuBtnS[i].SetActive(false); kakutokuzumiS[i].SetActive(true); break;
                }
            }
            if (hyoujiTask == 3)
            {
                switch (AkagonohateData.tasseiFlgE[i])
                {
                    case 1: kakutokuBtnE[i].SetActive(false); kakutokuzumiE[i].SetActive(false); break;
                    case 0: kakutokuBtnE[i].SetActive(true); kakutokuzumiE[i].SetActive(false); break;
                    case 2: kakutokuBtnE[i].SetActive(false); kakutokuzumiE[i].SetActive(true); break;
                }
            }
        }

        //ソート処理
        //各タスクの総件数を取得
        var tmpList = new List<GameObject>();
        int kensu = 0;
        switch (hyoujiTask)
        {
            case 1: kensu = nikkas.Length; break;
            case 2: kensu = syukans.Length; break;
            case 3: kensu = events.Length; break;
        }
        //配列の中身を一時的にListに入れる
        for (int i = 0; i < kensu; i++)
        {
            switch (hyoujiTask)
            {
                case 1: tmpList.Add(nikkas[i]); break;
                case 2: tmpList.Add(syukans[i]); break;
                case 3: tmpList.Add(events[i]); break;
            }
        }
        //ソート


    }

    /// <summary>
    /// 獲得ボタン押下時の処理
    /// ※hosyu：貰えるアイテムの個数
    /// ※num：十の位＝ボタンNo(0スタート)、一の位＝アイテムフラグ(=AkagonohateData.itemSyojisu)
    /// </summary>
    public void item(int num) {
        itemFlg = num % 10;
        btnNo = num / 10;
    }
    public void pushBtn(string hosyu) {
        //ポップアップ表示
        kakutokuPopup.SetActive(true);
        zeni.SetActive(false);
        ken.SetActive(false);
        if (itemFlg == 0)
        {
            zeni.SetActive(true);
        }
        if(itemFlg == 1){
            ken.SetActive(true);
        }
        hosyuT.text = ("×" + hosyu);


        //アイテム所持数を操作
        AkagonohateData.itemSyojisu[itemFlg] += int.Parse(hosyu);

        //達成フラグを操作(0→2)
        switch (hyoujiTask)
        {
            case 1: AkagonohateData.tasseiFlgN[btnNo] = 2; break;
            case 2: AkagonohateData.tasseiFlgS[btnNo] = 2; break;
            case 3: AkagonohateData.tasseiFlgE[btnNo] = 2; break;
        }
        CBtn();
    }

    public void pushHaikei() {
        //ポップアップ非表示
        kakutokuPopup.SetActive(false);
    }

    void Update()
    {
        //未獲得報酬ありを示す赤丸を初期化
        for (int i = 0; i < 3; i++)
        {
            tasseiIcon[i].SetActive(false);
        }
        //未獲得報酬ありを示す赤丸点灯を制御
        //日課
        for (int i = 0; i < countN; i++) {
            if (AkagonohateData.tasseiFlgN[i] == 0) {
                tasseiIcon[0].SetActive(true);
                break;
            }
        }
        //週間
        for (int i = 0; i < countS; i++)
        {
            if (AkagonohateData.tasseiFlgS[i] == 0)
            {
                tasseiIcon[1].SetActive(true);
                break;
            }
        }
        //イベント(仮)
        for (int i = 0; i < countE; i++)
        {
            if (AkagonohateData.tasseiFlgE[i] == 0)
            {
                tasseiIcon[2].SetActive(true);
                break;
            }
        }
    }
}
