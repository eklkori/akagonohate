using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;

public class Csyouhin : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject syouhinPopUp;
    [SerializeField] GameObject[] syouhinImages;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject batsu;

    public Text syouhinmei;
    public Text kaisetsu;
    public Text zeniBefore;
    public Text zeniAfter;
    public Text kosu;
    void Start()
    {
        haikeiSyouhin();
    }

    public void showSyouhinPopUp(int kyaraNo) {
        //表示の初期化
        for (int i = 0; i < 6; i++) {
            syouhinImages[i].SetActive(false);
        }

        syouhinPopUp.SetActive(true);

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

    }

    /// <summary>
    /// 商品ポップアップのクローズ
    /// </summary>
    public void haikeiSyouhin() {
        syouhinPopUp.SetActive(false);
    }
    void Update()
    {
        
    }
}
