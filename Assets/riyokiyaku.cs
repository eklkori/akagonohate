using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riyokiyaku : MonoBehaviour
{
    [SerializeField] GameObject credit;
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyakuBtn;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    [SerializeField] GameObject riyokiyakuT;


    public void showRiyokiyaku()
    {
        if (Input.GetMouseButtonUp(0))
        {
            credit.SetActive(false);
            syojidogukakunin.SetActive(false);
            riyokiyakuBtn.SetActive(false);
            otoiawase.SetActive(false);
            koukaonBGM.SetActive(false);
            kakusyumenu.SetActive(false);
            riyokiyakuT.SetActive(true);
            //gameObject.SetActive(false);

            batsu.GetComponent<menuControll>().riyokiyakuCount();
        }
    }
}
