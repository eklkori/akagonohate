using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuBtn : MonoBehaviour
{
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    //[SerializeField] GameObject batsu;

    // Update is called once per frame
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
        }
    }
}
