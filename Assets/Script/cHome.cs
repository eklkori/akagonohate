using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cHome : MonoBehaviour
{

    //キャラ立ち絵表示系
    [SerializeField] GameObject[] kyaraBtns;
    [SerializeField] Sprite[] kyaraImage;
    [SerializeField] Image kyaraTachie;

    //選択中枠
    [SerializeField] GameObject[] sentakuchu;
    void Start()
    {
        int kyaraNo = AkagonohateData.partnerNo;
        kyaraBtn(kyaraNo);
    }

    /// <summary>
    /// パートナー選択ボタン押下時の初期表示
    /// </summary>
    public void syokihyouji() {
        //衣装所持 / 未所持により表示を制御
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1)
            {
                kyaraBtns[i].SetActive(true);
            }
            else {
                kyaraBtns[i].SetActive(false);
            }
        }

        //選択中枠の表示
        //初期化
        for (int i = 0; i < 60; i++) {
            sentakuchu[i].SetActive(false);
        }
        //選択中衣装のみに枠を表示
        int syojiCount = -1;
        for (int i = 0; i < 60; i++) {
            if (AkagonohateData.isyoSyojiFlg[i] == 1) {
                syojiCount++;
            }
            if (AkagonohateData.partnerNo == AkagonohateData.isyoSyojiFlg[i]) {
                sentakuchu[syojiCount].SetActive(true);
                break;
            }
        }

    }

    /// <summary>
    /// キャラボタンが押されたときの処理
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void kyaraBtn(int kyaraNo)
    {
        //画像差し替え処理
        AkagonohateData.partnerNo = kyaraNo;
        kyaraTachie.sprite = kyaraImage[AkagonohateData.partnerNo];

        //サイズ変更
        RectTransform rectTransform = kyaraTachie.GetComponent<RectTransform>();
        int num = kyaraNo / 10;
        //transform.localScale = new Vector3(1400, 2227, 0);
        switch (num)
        {
            case 0: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1830, 1); break;
            case 1: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1850, 1); break;
            case 2: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1730, 1); break;
            case 3: kyaraTachie.rectTransform.sizeDelta  = new Vector3(1500, 1870, 1); break;
            case 4: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1980, 1); break;
            case 5: kyaraTachie.rectTransform.sizeDelta = new Vector3(1500, 1940, 1); break;
        }
        //サイズ変更(被り物などで個別設定が必要になる場合があればここに記載)

    }
    void Update()
    {
        
    }
}
