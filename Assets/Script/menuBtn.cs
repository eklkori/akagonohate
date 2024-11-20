using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
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
    [SerializeField] GameObject zeni;
    [SerializeField] GameObject key;
    [SerializeField] GameObject ken;
    //プレゼント
    [SerializeField] GameObject giftBtnBase;　//切り替え用ボタン素材
    [SerializeField] GameObject giftBtnSumi;　//切り替え用ボタン素材
    [SerializeField] GameObject giftBtnMi;　//切り替え用ボタン素材
    //[SerializeField] GameObject giftBase;　//使われていない？cHomeをアタッチしていた
    [SerializeField] GameObject giftItems;//未獲得・獲得済みのプレゼント全て(スクロールバーごと)
    [SerializeField] GameObject giftMis;　//未獲得のプレゼント全て(スクロールバーごと)
    [SerializeField] GameObject giftSumis;//獲得済みのプレゼント全て(スクロールバーごと)
    [SerializeField] GameObject[] giftMi;  //プレゼント(未獲得)のオブジェクト(長さ≒現在用意しているプレゼントの総数)
    [SerializeField] GameObject[] giftSumi;//プレゼント(獲得済み)のオブジェクト(長さ≒現在用意しているプレゼントの総数)
    [SerializeField] Text[] giftKigenMi;  //プレゼント(未獲得)受け取り期限(長さ≒現在用意しているプレゼントの総数)
    [SerializeField] Text[] giftKigenSumi;//プレゼント(獲得済み)受取日履歴(長さ≒現在用意しているプレゼントの総数)
    [SerializeField] GameObject tuchi;　//通知の赤丸
    [SerializeField] GameObject[] arimasenT; //ありませんテキスト(0：未獲得、1；獲得履歴)

    [SerializeField] GameObject childObjectPrefab;
    [SerializeField] Transform parent;
    [SerializeField] Transform childObjectP;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject kazuP;
    [SerializeField] GameObject titleP;
    [SerializeField] GameObject rirekiP;
    [SerializeField] Text kazuPrefab;
    [SerializeField] Text titlePrefab;
    [SerializeField] Text rirekiPrefab;
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

    /// <summary>
    /// プレゼント右上の赤丸通知を制御するフラグ
    /// </summary>
    int hyoujiFlg = 0;

    //日付取得
    DateTime localDate = DateTime.Now;
    DateTime today;

    private void Start()
    {
        //当日日付の取得
        today = localDate.Date;

        //（プレゼント用）giftFlgの初期化
        for (int i = 0; i < 10; i++) {
            AkagonohateData.giftFlg[0] = -1;
        }
        //ログイン日時を取得
        today = localDate.Date;
        if (AkagonohateData.loginRireki[0].Date != today.Date) {
            AkagonohateData.giftFlg[0] = 0;
        }
        cGift();
        //プレゼントの赤丸通知制御
        if (hyoujiFlg != 0)
        {
            tuchi.SetActive(true);
        }
        else
        {
            tuchi.SetActive(false);
        }
    }

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

        cGift();
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

        //履歴表示の制御
        //※30日前までの履歴を保管
        TimeSpan month30 = new TimeSpan(0, 30, 0, 0);
        DateTime kijyunbi = today - month30;
        int count = AkagonohateData.giftTitle.Count;
        int num = 0;
        for (int i = 0; i < count; i++)
        {
            if (AkagonohateData.giftTime[i] >= kijyunbi)
            {
                //基準日(30日前)より後に受け取ったプレゼントであれば表示
                Instantiate(childObjectPrefab, new Vector3(50, -150, 0), Quaternion.identity, parent);
                Instantiate(kazuP, new Vector3(280, -90, 0), Quaternion.identity, parent);
                Instantiate(titleP, new Vector3(846, 27, 0), Quaternion.identity, parent);
                Instantiate(rirekiP, new Vector3(765, -65, 0), Quaternion.identity, parent);

                //獲得数の上書き
                Text kazu = Instantiate(kazuPrefab);
                kazu.text = "×"+(AkagonohateData.giftKosu[i] / 10).ToString();

                //プレゼント名の上書き
                Text title = Instantiate(titlePrefab);
                title.text = AkagonohateData.giftTitle[i];

                //獲得日の上書き
                Text time = Instantiate(rirekiPrefab);
                int year = AkagonohateData.giftTime[i].Year;
                int month = AkagonohateData.giftTime[i].Month;
                int day = AkagonohateData.giftTime[i].Day;
                title.text = "獲得日：" + year + "/" + month + "/" + day;

                num++;
            }
            else
            {
                //基準日(30日前)より前に受け取ったプレゼントであればデータを削除
                AkagonohateData.giftTime.Remove(AkagonohateData.giftTime[i]);
                AkagonohateData.giftTitle.Remove(AkagonohateData.giftTitle[i]);
                AkagonohateData.giftKosu.Remove(AkagonohateData.giftKosu[i]);
            }
        }

        //ありませんテキストの表示制御
        if (num == 0)
        {
            arimasenT[1].SetActive(true);
        }
        else
        {
            arimasenT[1].SetActive(false);
        }
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
        zeni.SetActive(false);
        ken.SetActive(false);
        key.SetActive(false);

        //アイテム表示の切り替え
        //引数の下1桁で商品画像を判別
        int syouhinIMG = num % 10;
        switch (syouhinIMG)
        {
            case 0: zeni.SetActive(true); break; //銭
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
                AkagonohateData.itemSyojisu[6] += syouhinKosu - (5 - (AkagonohateData.itemSyojisu[2] - AkagonohateData.itemSyojisu[6]));
            }
            else
            {
                AkagonohateData.itemSyojisu[6] += syouhinKosu;
            }
        }

        //購入数の上書き(データ)
        switch (syouhinIMG)
        {
            case 0: AkagonohateData.itemSyojisu[0] += syouhinKosu; break; //銭
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

    /// <summary>
    /// プレゼント表示
    /// </summary>
    public void cGift() {
        //通知アイコン・ありませんテキストの初期化
        tuchi.SetActive(false);
        arimasenT[0].SetActive(false);

        //全プレゼント表示の初期化
        for (int i = 0; i < 10; i++)
        {
            giftMi[i].SetActive(false);
        }

        //フラグが0の場合、プレゼントを表示
        //ログインボーナス　(giftFlg：0番目)
        if (AkagonohateData.giftFlg[0] == 0) {
            //プレゼント表示
            giftMi[0].SetActive(true);

            //獲得期限の上書き(今日中)
            int year = today.Year;
            int month = today.Month;
            int day = today.Day;
            giftKigenMi[0].text = "獲得期限："+ year + "/" + month + "/" + day;
            hyoujiFlg++;
        }

        //その他プレゼントは獲得期限が流動するため、下のfor文で処理
        DateTime[] fuyobi = new DateTime[10];
        //プレゼント付与開始日から1週間後を取得
        TimeSpan week = new TimeSpan(7, 0, 0, 0);

        //プレゼント付与開始日 ※プレゼントを付与したい時に都度修正 ※fuyobi[]の値の上書きは必ず1週間以上時間をおいてから実施
        //【参考】
        //不具合のお詫び①　(giftFlg：1番目)
        //不具合のお詫び②　(giftFlg：2番目)　//不具合が多重に発生したとき用
        //不具合のお詫び③　(giftFlg：3番目)　//不具合が多重に発生したとき用
        //イベント参加記念プレゼント　(giftFlg：4番目)
        //紅鬼の果最新話公開記念プレゼント　(giftFlg：5番目)
        //未定　(giftFlg：6～9番目)
        fuyobi[1] = new DateTime(2024, 11, 10, 0, 0, 0);
        fuyobi[2] = new DateTime(2024, 11, 11, 0, 0, 0);
        fuyobi[3] = new DateTime(2024, 11, 12, 0, 0, 0);
        fuyobi[4] = new DateTime(2024, 11, 13, 0, 0, 0);
        fuyobi[5] = new DateTime(2024, 11, 19, 0, 0, 0);
        fuyobi[6] = new DateTime(2024, 11, 19, 0, 0, 0);
        fuyobi[7] = new DateTime(2024, 10, 19, 0, 0, 0);
        fuyobi[8] = new DateTime(2024, 11, 19, 0, 0, 0);
        fuyobi[9] = new DateTime(2024, 11, 19, 0, 0, 0);

        for (int i = 1; i < 10; i++)
        {
            if (AkagonohateData.giftFlg[i] == 0)
            {
                //プレゼント表示
                giftMi[i].SetActive(true);

                //獲得期限の上書き(1週間くらい？)
                //プレゼント付与開始日
                if (AkagonohateData.uketoriKigen[i] == null || AkagonohateData.uketoriKigen[i] < fuyobi[i])
                {
                    Debug.Log(i);
                    Debug.Log(AkagonohateData.uketoriKigen[i]);
                    AkagonohateData.uketoriKigen[i] = fuyobi[i].Date + week;
                    //受け取り期限を過ぎていたら非表示にする
                    if (AkagonohateData.uketoriKigen[i].Date >= today.Date)
                    {
                        //受け取り期限内の場合
                        int year = AkagonohateData.uketoriKigen[i].Year;
                        int month = AkagonohateData.uketoriKigen[i].Month;
                        int day = AkagonohateData.uketoriKigen[i].Day;
                        giftKigenMi[i].text = "獲得期限：" + year + "/" + month + "/" + day;
                        hyoujiFlg++;
                    }
                    else
                    {
                        //受け取り期限後の場合
                        giftMi[i].SetActive(false);
                    }
                }
            }
        }
        //赤丸通知・ありませんテキスト表示非表示判定
        if (hyoujiFlg != 0)
        {
            tuchi.SetActive(true);
        }
        else
        {
            tuchi.SetActive(false);
            arimasenT[0].SetActive(true);
        }
    }

    /// <summary>
    /// プレゼント獲得ボタン押下時の処理① ※引数：獲得数(上n桁)＋アイテム種類(下1桁)
    /// </summary>
    public void giftKakutoku1(int giftNo) {
        //引数の下1桁で商品画像(種類)を判別
        int itemIMG = giftNo % 10;

        //引数の上n桁で購入数を判別
        int itemKosu = giftNo / 10;

        //履歴をリストに格納　※タイトルは下のメソッドで追加(ボタン押下時の引数にタイトル名を指定)
        AkagonohateData.giftKosu.Add(giftNo);
        AkagonohateData.giftTime.Add(today);

        //ポップアップ表示処理に飛ばす
        konyu(giftNo);
    }

    /// <summary>
    /// プレゼント獲得ボタン押下時の処理② ※引数：プレゼント通し番号(0～9)+プレゼント名
    /// </summary>
    /// <param name="title"></param>
    public void giftKakutoku2(string title)
    {
        //タイトルの最初の1文字(プレゼント通し番号数字)を切り分け
        int giftNo = int.Parse(title.Substring(0, 1));

        //タイトルから通し番号を削除
        string titleAfter = title.Remove(0, 1);

        //ギフトフラグの書き換え(0→2)
        AkagonohateData.giftFlg[giftNo] = 2;

        //履歴をリストに格納　※タイトルのみ
        AkagonohateData.giftTitle.Add(title);

        //プレゼント受け取りポップアップ表示の更新
        cGift();
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

    private void Update()
    {
        //当日日付の取得
        today = localDate.Date;
    }
}
