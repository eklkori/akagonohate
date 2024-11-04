using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CRunwayRes : MonoBehaviour
{
    [SerializeField] GameObject[] bg;
    [SerializeField] GameObject mouichidoBtn;

    [SerializeField] Image resRunner;
    [SerializeField] Sprite[] runnerImages;
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
