using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuBtn : MonoBehaviour
{
    //素材の定義
    //×印
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject batsuC;
    [SerializeField] GameObject batsuS;
    [SerializeField] GameObject batsuR;
    [SerializeField] GameObject batsuO;
    [SerializeField] GameObject batsuSe;
    //中サイズボタン
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject serialBtn;
    //メニューのタイトル文字(ポップアップ上部)
    [SerializeField] GameObject titleText;
    [SerializeField] Text titleTextT;
    //メインメニュー
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    //所持道具確認
    [SerializeField] Text[] syojisus;
    [SerializeField] GameObject[] items;
    [SerializeField] GameObject arimasen;
    //アイテム購入
    [SerializeField] GameObject popupBase2;
    [SerializeField] Text konyusu;
    [SerializeField] GameObject key;
    [SerializeField] GameObject ken;
    //プレゼント
    [SerializeField] GameObject giftBtnBase;
    [SerializeField] GameObject giftBtnSumi;
    [SerializeField] GameObject giftBtnMi;
    [SerializeField] GameObject giftBase;
    [SerializeField] GameObject giftItems;
    [SerializeField] GameObject giftMis;
    [SerializeField] GameObject giftSumis;
    //紅鬼の果
    [SerializeField] GameObject akaoninohate;
    [SerializeField] GameObject yondemiru;
    [SerializeField] GameObject textA;
    //有料アイテムメニュー
    [SerializeField] GameObject yuryoItemAll;
    [SerializeField] GameObject kakutoku;
    //鍵の追加メニュー
    [SerializeField] GameObject kaginotsuikaAll;
    [SerializeField] Text kagigaT;
    [SerializeField] Text kosu;
    [SerializeField] Text kaifukuT;
    [SerializeField] GameObject plusBtn;
    [SerializeField] GameObject minusBtn;
    [SerializeField] GameObject kaifukuBtn;
    [SerializeField] GameObject kaihuku;
    //背景
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject haikeiC;
    [SerializeField] GameObject haikeiS;
    [SerializeField] GameObject haikeiR;
    [SerializeField] GameObject haikeiO;
    [SerializeField] GameObject haikeiSe;
    //お問い合わせ
    [SerializeField] GameObject otoiawaseAll;
    [SerializeField] GameObject soushinBtn;
    [SerializeField] GameObject uketamawarimashita;
    [SerializeField] GameObject popUpMenu;
    //シリアルコード入力画面
    [SerializeField] GameObject serialCodeAll;
    //スクロール
    [SerializeField] GameObject ScrollCredit;
    [SerializeField] GameObject ScrollRiyokiyaku;
    [SerializeField] GameObject ScrollIsyou;
    [SerializeField] GameObject ScrollGifts;
    [SerializeField] GameObject ScrollSyojiItem;

    /// <summary>
    /// 鍵回復ポップアップで鍵の回復数に使用
    /// </summary>
    int kaifukusu = 1;

    //-----表示系-----

    /// <summary>
    /// メニュー全体を表示
    /// </summary>
    public void showPopUp()
    {
        batsu.SetActive(true);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        serialBtn.SetActive(true);
        otoiawase.SetActive(true);
        popupBase.SetActive(true);
        koukaonBGM.SetActive(true);
        titleText.SetActive(true);
        haikei.SetActive(true);
        titleTextT.text = "各　種　メ　ニ　ュ　ー";
    }

    /// <summary>
    /// クレジットメニュー表示
    /// </summary>
    public void showPopUpC()
    {
        batsu.SetActive(false);
        batsuC.SetActive(true);
        credit.SetActive(false);
        titleText.SetActive(true);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiC.SetActive(true);
        ScrollCredit.SetActive(true);
        titleTextT.text = "ク　レ　ジ　ッ　ト";
    }

    /// <summary>
    /// 所持道具確認メニュー表示
    /// </summary>
    public void showPopUpS()
    {
        batsu.SetActive(false);
        batsuS.SetActive(true);
        credit.SetActive(false);
        titleText.SetActive(true);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiS.SetActive(true);

        ScrollSyojiItem.SetActive(true);
        titleTextT.text = "所　持　道　具　確　認";

        //アイテム所持数の表示
        //初期化
        for (int i = 0; i < 9; i++)
        {
            items[i].SetActive(true);
        }

        //各キャラの固有アイテム
        for (int i = 0; i < 6; i++) {
            syojisus[i].text = AkagonohateData.itemSyojisu[i + 10].ToString();
        }
        //その他アイテムは個別に設定
        syojisus[6].text = AkagonohateData.itemSyojisu[3].ToString();　//もぎり
        syojisus[7].text = AkagonohateData.itemSyojisu[4].ToString();　//誘導員
        syojisus[8].text = AkagonohateData.itemSyojisu[5].ToString();　//荷物持ち
        syojisus[9].text = AkagonohateData.itemSyojisu[2].ToString();　//鍵

        //所持数0だった場合、オブジェクト非表示
        int count = 0; 
        for (int i = 0; i < 9; i++) {
            if (syojisus[i].text == "0") {
                items[i].SetActive(false);
                count++;
            }
        }
        if (count == 0)
        {
            arimasen.SetActive(true);
        }
        else
        {
            arimasen.SetActive(false);
        }
    }

    /// <summary>
    /// 利用規約メニュー表示
    /// </summary>
    public void showPopUpR()
    {
        batsu.SetActive(false);
        batsuR.SetActive(true);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        titleText.SetActive(true);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiR.SetActive(true);
        ScrollRiyokiyaku.SetActive(true);

        titleTextT.text = "利　用　規　約";
    }

    /// <summary>
    /// お問い合わせメニュー表示
    /// </summary>
    public void showPopUpO()
    {
        batsu.SetActive(false);
        batsuO.SetActive(true);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        otoiawase.SetActive(false);
        titleText.SetActive(true);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiO.SetActive(true);
        otoiawaseAll.SetActive(true);
        popUpMenu.GetComponent<sendMail>().BtnFlg();
        titleTextT.text = "お　問　い　合　わ　せ";
    }

    /// <summary>
    /// パートナー入れ替えメニュー表示
    /// </summary>
    public void showPopUpP()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        ScrollIsyou.SetActive(true);
        popUpMenu.GetComponent<cHome>().syokihyouji();
        titleTextT.text = "パ　ー　ト　ナ　ー　選　択";
    }

    /// <summary>
    /// 紅鬼の果メニュー表示
    /// </summary>
    public void showPopUpA()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        akaoninohate.SetActive(true);
        textA.SetActive(true);
        yondemiru.SetActive(true);
        titleTextT.text = "紅　鬼　の　果";
    }

    /// <summary>
    /// プレゼントメニュー(未獲得)表示　※初期表示
    /// </summary>
    public void showPopUpGMi()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        giftBtnBase.SetActive(true);
        giftMis.SetActive(true);
        giftSumis.SetActive(false);
        giftItems.SetActive(true);
        giftBtnSumi.SetActive(true);
        giftBtnMi.SetActive(false);
        haikei.SetActive(true);
        popupBase.SetActive(true);
        titleTextT.text = "プ　レ　ゼ　ン　ト";
    }

    /// <summary>
    /// プレゼントメニュー(獲得済)表示
    /// </summary>
    public void showPopUpGSumi()
    {
        giftBtnBase.SetActive(true);
        giftBtnSumi.SetActive(false);
        giftBtnMi.SetActive(true);
        giftMis.SetActive(false);
        giftSumis.SetActive(true);
    }

    /// <summary>
    /// 鍵の追加メニュー表示
    /// </summary>
    public void showPopUpK()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        kaginotsuikaAll.SetActive(true);
        popupBase.SetActive(true);
        haikei.SetActive(true);
        minusBtn.SetActive(false);
        titleTextT.text = "鍵　の　追　加";
        kagigaT.text = "回復に使用できる鍵があります！";

        //回復できる鍵が無い場合は回復ボタンを非表示
        int tmp = 5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]);
        if (tmp == 0 || AkagonohateData.itemSyojisu[6] == 0)
        {
            kosu.text = "1";
            kagigaT.text = "回復に使用できる鍵がありません";
            minusBtn.SetActive(false);
            plusBtn.SetActive(false);
            kaifukuBtn.SetActive(false);
        }
        //回復できる鍵が1個のみの場合は＋ボタンを非表示
        if (tmp == 1 || AkagonohateData.itemSyojisu[6] == 1)
        {
            plusBtn.SetActive(false);
        }
    }

    /// <summary>
    /// 有料課金メニュー表示
    /// </summary>
    public void showPopUpY()
    {
        batsu.SetActive(true);
        titleText.SetActive(true);
        yuryoItemAll.SetActive(true);
        popupBase.SetActive(true);
        haikei.SetActive(true);
        titleTextT.text = "有　料　商　品";
        kaginotsuikaAll.SetActive(false);
    }

    /// <summary>
    /// シリアルコードメニュー表示
    /// </summary>
    public void showPopUpSe()
    {
        batsu.SetActive(false);
        batsuSe.SetActive(true);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        serialBtn.SetActive(false);
        serialCodeAll.SetActive(true);
        otoiawase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        haikeiSe.SetActive(true);

        titleTextT.text = "シ　リ　ア　ル　コ　ー　ド　入　力";
    }

    //-----非表示系-----

    /// <summary>
    /// メニュー全体を非表示 ※共通
    /// </summary>
    public void closePopUp()
    {
        batsu.SetActive(false);
        credit.SetActive(false);
        syojidogukakunin.SetActive(false);
        riyokiyaku.SetActive(false);
        otoiawase.SetActive(false);
        popupBase.SetActive(false);
        koukaonBGM.SetActive(false);
        kakusyumenu.SetActive(false);
        haikei.SetActive(false);
        titleText.SetActive(false);
        akaoninohate.SetActive(false);
        textA.SetActive(false);
        yondemiru.SetActive(false);
        giftBtnBase.SetActive(false);
        giftBtnMi.SetActive(false);
        giftBtnSumi.SetActive(false);
        yuryoItemAll.SetActive(false);
        kaginotsuikaAll.SetActive(false);
        serialBtn.SetActive(false);
        ScrollIsyou.SetActive(false);
        giftItems.SetActive(false);
    }

    /// <summary>
    /// クレジットメニュー非表示
    /// </summary>
    public void closePopUpC()
    {
        batsu.SetActive(true);
        batsuC.SetActive(false);
        credit.SetActive(true);
        titleText.SetActive(false);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
        serialBtn.SetActive(true);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiC.SetActive(false);
        ScrollCredit.SetActive(false);
    }

    /// <summary>
    /// 所持道具確認メニュー非表示
    /// </summary>
    public void closePopUpS()
    {
        batsu.SetActive(true);
        batsuS.SetActive(false);
        credit.SetActive(true);
        titleText.SetActive(false);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
        serialBtn.SetActive(true);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiS.SetActive(false);

        ScrollSyojiItem.SetActive(false);
    }

    /// <summary>
    /// 利用規約メニュー非表示
    /// </summary>
    public void closePopUpR()
    {
        batsu.SetActive(true);
        batsuR.SetActive(false);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        serialBtn.SetActive(true);
        titleText.SetActive(false);
        otoiawase.SetActive(true);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiR.SetActive(false);
        ScrollRiyokiyaku.SetActive(false);
    }

    /// <summary>
    /// お問い合わせメニュー非表示
    /// </summary>
    public void closePopUpO()
    {
        batsu.SetActive(true);
        batsuO.SetActive(false);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        serialBtn.SetActive(true);
        otoiawase.SetActive(true);
        titleText.SetActive(false);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiO.SetActive(false);
        otoiawaseAll.SetActive(false);
        soushinBtn.SetActive(false);
        uketamawarimashita.SetActive(false);
    }

    /// <summary>
    /// シリアルコードメニュー非表示
    /// </summary>
    public void closePopUpSe()
    {
        batsu.SetActive(true);
        batsuSe.SetActive(false);
        credit.SetActive(true);
        syojidogukakunin.SetActive(true);
        riyokiyaku.SetActive(true);
        otoiawase.SetActive(true);
        serialBtn.SetActive(true);
        titleText.SetActive(false);
        koukaonBGM.SetActive(true);
        kakusyumenu.SetActive(true);
        haikei.SetActive(true);
        haikeiSe.SetActive(false);
        serialCodeAll.SetActive(false);
    }

    /// <summary>
    /// 外部リンク(紅鬼の果)への遷移
    /// </summary>
    public void goAkaoninohate() {
        Application.OpenURL("https://www.amazon.co.jp/dp/B09MP8RCTP?binding=kindle_edition&searchxofy=true&ref_=dbs_s_aps_series_rwt_tkin&qid=1729922059&sr=8-4");
    }

    /// <summary>
    /// 購入ボタンが押されたときの処理①
    /// </summary>
    public void store()
    {
        //ストアに飛ばす処理をここに追記

    }

    /// <summary>
    /// 購入ボタンが押されたときの処理②
    /// </summary>
    public void konyu(int num) {
        //ポップアップの表示の初期化
        popupBase2.SetActive(true);
        kakutoku.SetActive(true);
        kaihuku.SetActive(false);
        ken.SetActive(false);
        key.SetActive(false);

        //アイテム表示の切り替え
        //引数の下1桁で商品画像を判別
        int syouhinIMG = num % 10;
        switch (syouhinIMG)
        {
            case 1: ken.SetActive(true); break; //仕立券
            case 2: key.SetActive(true); break; //鍵
        }

        //購入数の上書き(表示)
        //引数の上n桁で購入数を判別
        int syouhinKosu = num / 10;
        konyusu.text = "×  " + syouhinKosu;

        //鍵を購入した場合は、余剰分を考慮
        if (syouhinIMG == 2)
        {
            if (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6] < 5)
            {
                AkagonohateData.itemSyojisu[6] += syouhinKosu - (5-(AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]));
            }
            else 
            {
                AkagonohateData.itemSyojisu[6] += syouhinKosu;
            }
        }

        //購入数の上書き(データ)
        switch (syouhinIMG)
        {
            case 1: AkagonohateData.itemSyojisu[1] += syouhinKosu; break; //仕立券
            case 2: AkagonohateData.itemSyojisu[2] += syouhinKosu; break; //鍵
        }

        Debug.Log(AkagonohateData.itemSyojisu[2]);
        Debug.Log(AkagonohateData.itemSyojisu[6]);
    }

    /// <summary>
    /// 購入後のポップアップを消す処理
    /// </summary>
    public void konyuEnd() {
        popupBase2.SetActive(false);
        kakutoku.SetActive(false);
        kaihuku.SetActive(false);
    }

    //以下、鍵の追加メニュー関連

    /// <summary>
    /// +ボタン押下時の処理
    /// </summary>
    public void pushPlus() {
        //回復数を操作
        kaifukusu++;
        kosu.text = kaifukusu.ToString();

        //UI操作
        int tmp = 5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]);
        if (kaifukusu >= tmp)
        {
            plusBtn.SetActive(false);
        }
        minusBtn.SetActive(true);
        kaifukuBtn.SetActive(true);

        //上限の場合は+ボタンを非表示
        //int tmp2 = 5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]);
        Debug.Log(AkagonohateData.itemSyojisu[2]);
        Debug.Log(AkagonohateData.itemSyojisu[6]);
        Debug.Log(tmp);
        //if (tmp2 == kaifukusu)
        //{
        //    plusBtn.SetActive(false);
        //}
    }

    public void pushMinus() {
        //回復数を操作
        kaifukusu--;
        kosu.text = kaifukusu.ToString();

        //UI操作
        plusBtn.SetActive(true);

        //回復数==1の場合の操作
        if (kaifukusu == 1)
        {
            minusBtn.SetActive(false);
        }
    }

    /// <summary>
    /// 鍵の「回復」ボタン押下時の処理
    /// </summary>
    public void kaifuku() {
        //計算(余剰鍵→消費鍵)
        AkagonohateData.itemSyojisu[6] -= kaifukusu;

        //UI操作
        popupBase2.SetActive(true);
        kakutoku.SetActive(false);
        kaihuku.SetActive(true);
        kaifukuT.text = "鍵を"+kaifukusu+"つ回復しました！";
    }
}
