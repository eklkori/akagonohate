using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UnityEngine.UI;

public class mitsuguOnOff : MonoBehaviour
{
    //貢ぐ画面　確定ボタン押下前後のUI表示/非表示切り替え
    //素材の定義
    [SerializeField] GameObject[] plusBtn;
    [SerializeField] GameObject[] minusBtn;
    [SerializeField] GameObject kakutei;
    [SerializeField] GameObject off;
    [SerializeField] Text[] syojisuT;
    [SerializeField] Text[] mitsugisuT;
    [SerializeField] Image kyaraTachie;
    [SerializeField] Sprite[] kyaraImages;
    [SerializeField] GameObject advEngine;

    int[] mitsugisu = new int[6];
    int kyara = 0;

    //宴用
    public AdvEngine engine;

    private void Start()
    {
        //テスト用処理START
        AkagonohateData.itemSyojisu[10] = 5;
        AkagonohateData.itemSyojisu[11] = 130;
        AkagonohateData.itemSyojisu[14] = 10;
        //テスト用処理END

        //所持アイテム個数を表示・-ボタンの非表示
        for (int i = 0; i < 6; i++)
        {
            syojisuT[i].text = AkagonohateData.itemSyojisu[10+i].ToString();
            minusBtn[i].SetActive(false);

            //アイテム所持数が0の場合は、＋ボタンも非表示
            if (AkagonohateData.itemSyojisu[10 + i] == 0) {
                plusBtn[i].SetActive(false);
            }
        }
        kakutei.SetActive(false);

        //キャラ画像の差し替え
        //立ち絵の差し替え処理
        kyaraTachie.sprite = kyaraImages[AkagonohateData.tansakuKyara];  //※衣装ランダムにする場合はこの辺りに処理を追加
        //立ち絵のサイズ変更
        kyaraTachie.GetComponent<RectTransform>();
        switch (AkagonohateData.tansakuKyara)
        {
            case 0: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2230, 0); break;
            case 1: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2255, 0); break;
            case 2: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2110, 0); break;
            case 3: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2280, 0); break;
            case 4: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2415, 0); break;
            case 5: kyaraTachie.rectTransform.sizeDelta = new Vector3(1800, 2365, 0); break;
        }
    }

    /// <summary>
    /// ＋ボタンが押されたときの処理
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void pushPlusBtn(int kyaraNo) {
        kyara = kyaraNo;

        //貢ぎ数を操作
        mitsugisu[kyara]++;
        mitsugisuT[kyara].text = mitsugisu[kyara].ToString();

        //UI操作
        if (mitsugisu[kyara] == 99 || AkagonohateData.itemSyojisu[10 + kyara] == mitsugisu[kyara])
        {
            plusBtn[kyara].SetActive(false);
        }
        minusBtn[kyara].SetActive(true);
        kakutei.SetActive(true);
    }

    /// <summary>
    /// -ボタンが押されたときの処理
    /// </summary>
    public void pushMinus(int kyaraNo)
    {
        kyara = kyaraNo;

        //貢ぎ数を操作
        mitsugisu[kyara]--;
        mitsugisuT[kyara].text = mitsugisu[kyara].ToString();

        //UI操作
        plusBtn[kyara].SetActive(true);

        //貢物が1個も無かった場合、確定ボタンを非表示にする
        if (mitsugisu[kyara] == 0)
        {
            minusBtn[kyara].SetActive(false);
            int tmp = 0;
            for (int i = 0; i < 6; i++)
            {
                if (mitsugisu[i] != 0)
                {
                    tmp++;
                    break;
                }
            }
            if (tmp == 0)
            {
                kakutei.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 確定ボタンが押されたときの処理
    /// </summary>
    public void mitsuguOff()
    {
        //UI非表示
        off.SetActive(false);

        //獲得親愛Pt・アイテム所持数の計算
        AkagonohateData.KshinaiPt[kyara] = 0;
        for (int i = 0; i < 6; i++) {
            //アイテム所持数の上書き
            AkagonohateData.itemSyojisu[i+10] -= mitsugisu[i];

            //獲得親愛Ptの計算
            int tmp = mitsugisu[i]*10;
            if (i == AkagonohateData.tansakuKyara) {
                tmp *= 5;
            }
            AkagonohateData.KshinaiPt[kyara] += tmp;
        }

        //宴に値を渡す
          //パラメーターの取得
          //int point = engine.Param.GetParameterInt("shinaido");
        //型指定済みの設定方法
        engine.Param.SetParameterInt("shinaido", AkagonohateData.KshinaiPt[kyara]);

        //シナリオラベルのセット
        string No = "";
        switch (AkagonohateData.tansakuKyara)
        {
            case 0: No = "naoko"; break;
            case 1: No = "yasuko"; break;
            case 2: No = "yoshiko"; break;
            case 3: No = "hideta"; break;
            case 4: No = "hideya"; break;
            case 5: No = "yasuo"; break;
        }
        //1～2のランダムな整数 範囲を指定
        string random = Random.Range(1, 3).ToString();
        AkagonohateData.kaiwaNo = No+random;

        advEngine.GetComponent<SampleAdvEngineController2>().JumpScenario(AkagonohateData.kaiwaNo);
    }

    /// <summary>
    /// 貢ぐ終了後の処理
    /// </summary>
    void Update()
    {
        //AdvEngineの初期化
        if (!engine.Param.IsInit) return;

        //パラメーターの呼び出し
        int mitsuguEnd = engine.Param.GetParameterInt("mitsuguEnd");

        if (mitsuguEnd == 1)
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }
}
