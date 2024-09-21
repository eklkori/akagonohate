using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menuCloseS : MonoBehaviour
{
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject batsuS;
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    [SerializeField] GameObject syojidogukakuninT;

    /// <summary>
    /// 
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
        }
    }
}
