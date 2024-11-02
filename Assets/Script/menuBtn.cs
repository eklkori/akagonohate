using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuBtn : MonoBehaviour
{
    //素材の定義
    //×印
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject batsuC;
    [SerializeField] GameObject batsuS;
    [SerializeField] GameObject batsuR;
    [SerializeField] GameObject batsuO;
    //中サイズボタン
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    //メニューのタイトル文字(ポップアップ上部)
    [SerializeField] GameObject creditT;
    [SerializeField] GameObject syojidogukakuninT;
    [SerializeField] GameObject riyokiyakuT;
    [SerializeField] GameObject otoiawaseT;
    [SerializeField] GameObject partnersentakuT;
    [SerializeField] GameObject akaoninohateT;
    [SerializeField] GameObject yuryoT;
    [SerializeField] GameObject giftT;
    //メインメニュー
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    //プレゼント
    [SerializeField] GameObject giftBtnBase;
    [SerializeField] GameObject giftBtnSumi;
    [SerializeField] GameObject giftBtnMi;
    [SerializeField] GameObject giftBase;
    //紅鬼の果
    [SerializeField] GameObject akaoninohate;
    [SerializeField] GameObject yondemiru;
    [SerializeField] GameObject textA;
    [SerializeField] GameObject yuryoItemAll;
    //背景
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject haikeiC;
    [SerializeField] GameObject haikeiS;
    [SerializeField] GameObject haikeiR;
    [SerializeField] GameObject haikeiO;
    //お問い合わせ
    [SerializeField] GameObject otoiawaseText;
    [SerializeField] GameObject setsumeibun;
    [SerializeField] GameObject soushinBtn;
    [SerializeField] GameObject uketamawarimashita;
    [SerializeField] GameObject cHome;
    //スクロール
    [SerializeField] GameObject ScrollCredit;
    [SerializeField] GameObject ScrollRiyokiyaku;
    [SerializeField] GameObject ScrollIsyou;
    [SerializeField] GameObject ScrollGifts;


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
            otoiawase.SetActive(true);
            popupBase.SetActive(true);
            koukaonBGM.SetActive(true);
            kakusyumenu.SetActive(true);
            haikei.SetActive(true);
    }

    /// <summary>
    /// クレジットメニュー表示
    /// </summary>
    public void showPopUpC()
    {
            batsu.SetActive(false);
            batsuC.SetActive(true);
            credit.SetActive(false);
            creditT.SetActive(true);
            syojidogukakunin.SetActive(false);
            riyokiyaku.SetActive(false);
            otoiawase.SetActive(false);
            koukaonBGM.SetActive(false);
            kakusyumenu.SetActive(false);
            haikei.SetActive(false);
            haikeiC.SetActive(true);
            ScrollCredit.SetActive(true);
    }

    /// <summary>
    /// 所持道具確認メニュー表示
    /// </summary>
    public void showPopUpS()
    {
            batsu.SetActive(false);
            batsuS.SetActive(true);
            credit.SetActive(false);
            syojidogukakuninT.SetActive(true);
            syojidogukakunin.SetActive(false);
            riyokiyaku.SetActive(false);
            otoiawase.SetActive(false);
            koukaonBGM.SetActive(false);
            kakusyumenu.SetActive(false);
            haikei.SetActive(false);
            haikeiS.SetActive(true);
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
            riyokiyakuT.SetActive(true);
            otoiawase.SetActive(false);
            koukaonBGM.SetActive(false);
            kakusyumenu.SetActive(false);
            haikei.SetActive(false);
            haikeiR.SetActive(true);
            ScrollRiyokiyaku.SetActive(true);
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
            otoiawase.SetActive(false);
            otoiawaseT.SetActive(true);
            koukaonBGM.SetActive(false);
            kakusyumenu.SetActive(false);
            haikei.SetActive(false);
            haikeiO.SetActive(true);
            otoiawaseText.SetActive(true);
            setsumeibun.SetActive(true);
            cHome.GetComponent<sendMail>().BtnFlg();
    }

    /// <summary>
    /// パートナー入れ替えメニュー表示
    /// </summary>
    public void showPopUpP()
    {
            batsu.SetActive(true);
            partnersentakuT.SetActive(true);
            haikei.SetActive(true);
            popupBase.SetActive(true);
            ScrollIsyou.SetActive(true);
            cHome.GetComponent<cHome>().syokihyouji();
    }

    /// <summary>
    /// 紅鬼の果メニュー表示
    /// </summary>
    public void showPopUpA()
    {
            batsu.SetActive(true);
            akaoninohateT.SetActive(true);
            haikei.SetActive(true);
            popupBase.SetActive(true);
            akaoninohate.SetActive(true);
            textA.SetActive(true);
            yondemiru.SetActive(true);
    }

    /// <summary>
    /// プレゼントメニュー(未獲得)表示　※初期表示
    /// </summary>
    public void showPopUpGMi()
    {
            batsu.SetActive(true);
            giftT.SetActive(true);
            giftBtnBase.SetActive(true);
            giftBtnSumi.SetActive(true);
            giftBtnMi.SetActive(false);
            haikei.SetActive(true);
            popupBase.SetActive(true);
    }

    /// <summary>
    /// プレゼントメニュー(獲得済)表示
    /// </summary>
    public void showPopUpGSumi()
    {
            giftBtnBase.SetActive(true);
            giftBtnSumi.SetActive(false);
            giftBtnMi.SetActive(true);
        　　ScrollGifts.SetActive(true);
    }

    /// <summary>
    /// 有料課金メニュー表示
    /// </summary>
    public void showPopUpY()
    {
            batsu.SetActive(true);
            yuryoT.SetActive(true);
            yuryoItemAll.SetActive(true);
            popupBase.SetActive(true);
            haikei.SetActive(true);
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
            partnersentakuT.SetActive(false);
            akaoninohateT.SetActive(false);
            akaoninohate.SetActive(false);
            textA.SetActive(false);
            yondemiru.SetActive(false);
            giftT.SetActive(false);
            giftBtnBase.SetActive(false);
            giftBtnMi.SetActive(false);
            giftBtnSumi.SetActive(false);
            yuryoItemAll.SetActive(false);
            yuryoT.SetActive(false);
            ScrollIsyou.SetActive(false);
            ScrollGifts.SetActive(false);
    }

    /// <summary>
    /// クレジットメニュー非表示
    /// </summary>
    public void closePopUpC()
    {
            batsu.SetActive(true);
            batsuC.SetActive(false);
            credit.SetActive(true);
            creditT.SetActive(false);
            syojidogukakunin.SetActive(true);
            riyokiyaku.SetActive(true);
            otoiawase.SetActive(true);
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
            syojidogukakuninT.SetActive(false);
            syojidogukakunin.SetActive(true);
            riyokiyaku.SetActive(true);
            otoiawase.SetActive(true);
            koukaonBGM.SetActive(true);
            kakusyumenu.SetActive(true);
            haikei.SetActive(true);
            haikeiS.SetActive(false);
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
            riyokiyakuT.SetActive(false);
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
            otoiawase.SetActive(true);
            otoiawaseT.SetActive(false);
            koukaonBGM.SetActive(true);
            kakusyumenu.SetActive(true);
            haikei.SetActive(true);
            haikeiO.SetActive(false);
            otoiawaseText.SetActive(false);
            setsumeibun.SetActive(false);
            soushinBtn.SetActive(false);
            uketamawarimashita.SetActive(false);
    }

    /// <summary>
    /// 外部リンク(紅鬼の果)への遷移
    /// </summary>
    public void goAkaoninohate() {
        Application.OpenURL("https://www.amazon.co.jp/dp/B09MP8RCTP?binding=kindle_edition&searchxofy=true&ref_=dbs_s_aps_series_rwt_tkin&qid=1729922059&sr=8-4");
    }


}
