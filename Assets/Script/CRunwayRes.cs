using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CRunwayRes : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject[] bg;
    [SerializeField] GameObject mouichidoBtn;
    [SerializeField] GameObject btns;
    [SerializeField] GameObject[] yuryoka; //第一幕優良可、第二幕優良可、第三幕優良可、総合優良可の順で画像を格納
    [SerializeField] GameObject[] yuryokaT;
    [SerializeField] GameObject firstText;

    [SerializeField] Image resRunner;
    [SerializeField] Sprite[] runnerImages;

    public Text[] plusShinaiPt;
    public Text[] plusDatePt;
    [SerializeField] Text zeni;
    [SerializeField] Text ninsokuBonusT;

    void Start()
    {
        //背景の初期化
        for (int i = 0; i < 9; i++)
        {
            bg[i].SetActive(false);
        }
        //背景の表示
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

        //立ち絵の差し替え処理
        resRunner.sprite = runnerImages[AkagonohateData.runwayMVP[3]];
        //立ち絵のサイズ変更
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

        //その他表示の初期化
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

        //獲得親愛度・獲得デートPtを表示
        for (int i = 0; i < 6; i++)
        {
            plusShinaiPt[i].text = AkagonohateData.KshinaiPt[i].ToString();
            plusDatePt[i].text = AkagonohateData.KdatePt[i].ToString();
        }

        //獲得銭数値を表示
        zeni.text = AkagonohateData.KItem[0].ToString();

        //人足ボーナス(人足によって割り増しされたデートPtの合計値)を表示
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
    /// もう一度同じ設定でランウェイをする時の処理
    /// </summary>
    public void mouichido()
    {
        //鍵の所持数を引く・上書き
        AkagonohateData.itemSyojisu[2]--;

        //人足が前回設定値>所持数の場合
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
    /// 設定を変えてランウェイをするときの処理
    /// </summary>
    public void kaete() {
        SceneManager.LoadScene("10RunwaySet");
    }

    /// <summary>
    /// ランウェイを終了する時の処理
    /// </summary>
    public void modoru() {
        SceneManager.LoadScene("05Home");
    }
}
