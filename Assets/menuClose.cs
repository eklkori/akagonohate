using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menuClose : MonoBehaviour
{
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    [SerializeField] GameObject riyokiyakuT;

    public void closePopUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //クレジット画面(creditFlg==1)の時

            //所持道具確認画面(syojidogukakuninFlg==1)の時

            //利用規約画面(riyokiyakuFlg==1)の時
            /*if (riyokiyakuFlg == 1) {
            
            }*/
            //お問い合わせ画面(otoiawaseFlg==1)の時

            //その他(各種メニュー画面の時)
            batsu.SetActive(false);
            credit.SetActive(false);
            syojidogukakunin.SetActive(false);
            riyokiyaku.SetActive(false);
            otoiawase.SetActive(false);
            popupBase.SetActive(false);
            koukaonBGM.SetActive(false);
            kakusyumenu.SetActive(false);
        }
    }
}
