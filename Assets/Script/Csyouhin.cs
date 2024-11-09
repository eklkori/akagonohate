using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;

public class Csyouhin : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject syouhinPopUp;
    [SerializeField] GameObject overPopUp;
    [SerializeField] GameObject konyuPopUp;
    [SerializeField] GameObject goGachaPopUp;
    [SerializeField] GameObject[] syouhinImages;
    [SerializeField] GameObject[] smallImages;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject minusBtn;
    [SerializeField] GameObject plusBtn;
    [SerializeField] GameObject konyuBtn;
    //[SerializeField] GameObject closeBtn;

    [SerializeField] Text syouhinmei;
    [SerializeField] Text kaisetsu;
    [SerializeField] Text zeniBefore;
    [SerializeField] Text zeniAfter;
    [SerializeField] Text kosu;
    [SerializeField] Text konyuKosu;

    int konyusu;
    int No;
    void Start()
    {
        //テスト用処理START
        AkagonohateData.itemSyojisu[0] = 4000;
        //テスト用処理END
        haikeiSyouhin();
    }

    /// <summary>
    /// 商品ポップアップの表示処理
    /// </summary>
    /// <param name="kyaraNo"></param>
    public void showSyouhinPopUp(int kyaraNo) {
        //表示の初期化
        for (int i = 0; i < 6; i++) {
            syouhinImages[i].SetActive(false);
        }

        syouhinPopUp.SetActive(true);
        konyusu = 1;
        minusBtn.SetActive(false);

        No = kyaraNo;

        //キャラごとの表示分け
        switch (kyaraNo)
        {
            case 0: 
                syouhinImages[0].SetActive(true);
                syouhinmei.text = "ハエ取り";
                kaisetsu.text = "見た目の割に血生臭さを感じる……こういうものは、きっと直子さんに渡すべきだろう。";
                break;
            case 1: 
                syouhinImages[1].SetActive(true);
                syouhinmei.text = "狸のオブジェ";
                kaisetsu.text = "うっわ……何だこの圧倒的既視感は。こっち見ないでほしい。康子総裁に渡したら喜んでくれるかな。";
                break;
            case 2: 
                syouhinImages[2].SetActive(true);
                syouhinmei.text = "三色団子";
                kaisetsu.text = "心なしかよもぎがデカい。店主がよもぎに狂っているのだろうか。吉子お嬢様に渡してあげたくなるな。";
                break;
            case 3: 
                syouhinImages[3].SetActive(true);
                syouhinmei.text = "球根";
                kaisetsu.text = "見たことのない色の球根だな。毒とか入っていなければ良いけど……。秀太お坊ちゃまならノリノリで植えそうだ。";
                break;
            case 4: 
                syouhinImages[4].SetActive(true);
                syouhinmei.text = "越前ガニ";
                kaisetsu.text = "とっても美味しそうだが一年中置いているのが気になる……きっと冷凍なのだろう。越前オタクの秀也お坊ちゃまにあげよう。";
                break;
            case 5: 
                syouhinImages[5].SetActive(true);
                syouhinmei.text = "高級筆";
                kaisetsu.text = "この筆で文字を書けば、誰でも能筆家になれちゃいそう！書道マニアの榊原先輩に是非！";
                break;
        }

        //銭・購入個数の計算処理
        zeniBefore.text = AkagonohateData.itemSyojisu[0].ToString();
        zeniAfter.text = (AkagonohateData.itemSyojisu[0]-1000).ToString();
        kosu.text = konyusu.ToString();

        nedanMiman();
    }

    /// <summary>
    /// 商品ポップアップのクローズ
    /// </summary>
    public void haikeiSyouhin() {
        syouhinPopUp.SetActive(false);
        overPopUp.SetActive(false);
    }

    /// <summary>
    /// ＋ボタンが押されたときの処理
    /// </summary>
    public void pushPlus() {
        //購入数を操作
        konyusu++;
        kosu.text = konyusu.ToString();

        //銭所持数の表示を操作
        int zeniA = int.Parse(zeniAfter.text);
        zeniAfter.text = (zeniA-1000).ToString();

        //UI操作
        if (konyusu == 99) {
            plusBtn.SetActive(false);
        }
        minusBtn.SetActive(true);
        konyuBtn.SetActive(true);
        nedanMiman();
    }

    /// <summary>
    /// -ボタンが押されたときの処理
    /// </summary>
    public void pushMinus() {
        //購入数を操作
        konyusu--;
        kosu.text = konyusu.ToString();

        //銭所持数の表示を操作
        int zeniA = int.Parse(zeniAfter.text);
        zeniAfter.text = (zeniA+1000).ToString();

        //UI操作
        plusBtn.SetActive(true);
        nedanMiman();
    }

    /// <summary>
    /// 所持銭がアイテムの値段(1000)未満のとき
    /// </summary>
    void nedanMiman() {
        int zeniAfterTMP = int.Parse(zeniAfter.text);
        if (zeniAfterTMP < 1000)
        {
            plusBtn.SetActive(false);
            if (zeniAfterTMP < 0)
            {
                konyuBtn.SetActive(false);
            }
        }
        if (kosu.text == "1")
        {
            minusBtn.SetActive(false);
        }
    }

    /// <summary>
    /// 購入ボタンが押されたときの処理
    /// </summary>
    public void konyu() {
        //画面表示
        konyuKosu.text = "× " + konyusu.ToString() ;
        syouhinPopUp.SetActive(false);
        overPopUp.SetActive(true);
        konyuPopUp.SetActive(true);
        goGachaPopUp.SetActive(false);
        //closeBtn.SetActive(true);

        //アイテム画像の初期化
        for (int i = 0; i < 6; i++) {
            smallImages[i].SetActive(false);
        }

        //所持数の更新+アイテム画像の差し替え
        AkagonohateData.itemSyojisu[0] -= konyusu * 1000;
        switch (No)
        {
            case 0: AkagonohateData.itemSyojisu[10] += konyusu; smallImages[0].SetActive(true); break;
            case 1: AkagonohateData.itemSyojisu[11] += konyusu; smallImages[1].SetActive(true); break;
            case 2: AkagonohateData.itemSyojisu[12] += konyusu; smallImages[2].SetActive(true); break;
            case 3: AkagonohateData.itemSyojisu[13] += konyusu; smallImages[3].SetActive(true); break;
            case 4: AkagonohateData.itemSyojisu[14] += konyusu; smallImages[4].SetActive(true); break;
            case 5: AkagonohateData.itemSyojisu[15] += konyusu; smallImages[5].SetActive(true); break;
        }
    }
    void Update()
    {
        
    }
}
