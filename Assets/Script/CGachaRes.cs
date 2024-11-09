using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGachaRes : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject tapT;
    [SerializeField] GameObject tanpatsu;
    [SerializeField] GameObject jyuren;
    [SerializeField] GameObject newIcon;
    [SerializeField] GameObject[] newIcons;
    [SerializeField] Image kyara;
    [SerializeField] Image[] kyaras;
    [SerializeField] Sprite[] kyaraImages;

    int tenmetsuFlg = 0;
    void Start()
    {
        if (AkagonohateData.gachaFlg == 1)
        {
            Tanpatsu();
        }
        else {
            Jyuren();
        }
    }

    /// <summary>
    /// 単発の結果画面表示
    /// </summary>
    void Tanpatsu() {
        tanpatsu.SetActive(true);
        jyuren.SetActive(false);

        //キャラ画像差し替え
        kyara.sprite = kyaraImages[AkagonohateData.gacha10[0]];

        //未獲得キャラの場合、new!を表示
        newIcon.SetActive(false);
        if (AkagonohateData.gachaNotNew[0] == 0) {
            newIcon.SetActive(true);
        }
    }

    /// <summary>
    /// 10連の結果画面表示
    /// </summary>
    void Jyuren(){
        tanpatsu.SetActive(false);
        jyuren.SetActive(true);

        //キャラ画像差し替え
        for (int i = 0; i < 10; i++) {
            kyaras[i].sprite = kyaraImages[AkagonohateData.gacha10[i]];
        }

        //未獲得キャラの場合、new!を表示
        for (int i = 0; i < 10; i++)
        {
            newIcons[i].SetActive(false);
            if (AkagonohateData.gachaNotNew[i] == 0)
            {
                newIcons[i].SetActive(true);
            }
        }
    }

    void Update()
    {
        //「-TAP-」を点滅させる処理
        Color colorTap = tapT.GetComponent<Image>().color;
        if (tenmetsuFlg == 0)
        {
            colorTap.a -= 0.02f;
            tapT.GetComponent<Image>().color = colorTap;
        }
        else if (tenmetsuFlg == 1)
        {
            colorTap.a += 0.02f;
            tapT.GetComponent<Image>().color = colorTap;
        }
        if (colorTap.a < 0)
        {
            tenmetsuFlg = 1;
        }
        else if (colorTap.a > 1)
        {
            tenmetsuFlg = 0;
        }
    }
}
