using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuBtn : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject batsuC;
    [SerializeField] GameObject batsuS;
    [SerializeField] GameObject batsuR;
    [SerializeField] GameObject batsuO;
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject creditT;
    [SerializeField] GameObject syojidogukakuninT;
    [SerializeField] GameObject riyokiyakuT;
    [SerializeField] GameObject otoiawaseT;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    [SerializeField] GameObject partnersentakuT;
    [SerializeField] GameObject akaoninohateT;
    [SerializeField] GameObject yuryoT;
    [SerializeField] GameObject akaoninohate;
    [SerializeField] GameObject giftT;
    [SerializeField] GameObject giftBtnBase;
    [SerializeField] GameObject giftBtnSumi;
    [SerializeField] GameObject giftBtnMi;
    [SerializeField] GameObject giftBase;
    [SerializeField] GameObject ScrollCredit;
    [SerializeField] GameObject ScrollRiyokiyaku;
    [SerializeField] GameObject yondemiru;
    [SerializeField] GameObject textA;
    [SerializeField] GameObject yuryoItemAll;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject haikeiC;
    [SerializeField] GameObject haikeiS;
    [SerializeField] GameObject haikeiR;
    [SerializeField] GameObject haikeiO;
    [SerializeField] GameObject otoiawaseText;
    [SerializeField] GameObject setsumeibun;
    [SerializeField] GameObject soushinBtn;
    [SerializeField] GameObject uketamawarimashita;
    [SerializeField] GameObject cHome;


    //-----表示系-----

    /// <summary>
    /// メニュー全体を表示
    /// </summary>
    public void showPopUp()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// クレジットメニュー表示
    /// </summary>
    public void showPopUpC()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// 所持道具確認メニュー表示
    /// </summary>
    public void showPopUpS()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// 利用規約メニュー表示
    /// </summary>
    public void showPopUpR()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// お問い合わせメニュー表示
    /// </summary>
    public void showPopUpO()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// パートナー入れ替えメニュー表示
    /// </summary>
    public void showPopUpP()
    {
        if (Input.GetMouseButtonUp(0))
        {
            batsu.SetActive(true);
            partnersentakuT.SetActive(true);
            haikei.SetActive(true);
            popupBase.SetActive(true);
        }
    }

    /// <summary>
    /// 紅鬼の果メニュー表示
    /// </summary>
    public void showPopUpA()
    {
        if (Input.GetMouseButtonUp(0))
        {
            batsu.SetActive(true);
            akaoninohateT.SetActive(true);
            haikei.SetActive(true);
            popupBase.SetActive(true);
            akaoninohate.SetActive(true);
            textA.SetActive(true);
            yondemiru.SetActive(true);
        }
    }

    /// <summary>
    /// プレゼントメニュー(未獲得)表示　※初期表示
    /// </summary>
    public void showPopUpGMi()
    {
        if (Input.GetMouseButtonUp(0))
        {
            batsu.SetActive(true);
            giftT.SetActive(true);
            giftBtnBase.SetActive(true);
            giftBtnSumi.SetActive(true);
            giftBtnMi.SetActive(false);
            //giftBase.SetActive(true);
            haikei.SetActive(true);
            popupBase.SetActive(true);
        }
    }

    /// <summary>
    /// プレゼントメニュー(獲得済)表示
    /// </summary>
    public void showPopUpGSumi()
    {
        if (Input.GetMouseButtonUp(0))
        {
            giftBtnBase.SetActive(true);
            giftBtnSumi.SetActive(false);
            giftBtnMi.SetActive(true);
            //giftBase.SetActive(true);
        }
    }

    /// <summary>
    /// 有料課金メニュー表示
    /// </summary>
    public void showPopUpY()
    {
        if (Input.GetMouseButtonUp(0))
        {
            batsu.SetActive(true);
            yuryoT.SetActive(true);
            yuryoItemAll.SetActive(true);
            popupBase.SetActive(true);
            haikei.SetActive(true);
        }
    }


    //-----非表示系-----

    /// <summary>
    /// メニュー全体を非表示 ※共通
    /// </summary>
    public void closePopUp()
    {
        if (Input.GetMouseButtonUp(0))
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
            //giftBase.SetActive(false);
            yuryoItemAll.SetActive(false);
            yuryoT.SetActive(false);
        }
    }

    /// <summary>
    /// クレジットメニュー非表示
    /// </summary>
    public void closePopUpC()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// 所持道具確認メニュー非表示
    /// </summary>
    public void closePopUpS()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// 利用規約メニュー非表示
    /// </summary>
    public void closePopUpR()
    {
        if (Input.GetMouseButtonUp(0))
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
    }

    /// <summary>
    /// お問い合わせメニュー非表示
    /// </summary>
    public void closePopUpO()
    {
        if (Input.GetMouseButtonUp(0))
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
    }
}
