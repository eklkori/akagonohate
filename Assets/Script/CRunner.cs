using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRunner : MonoBehaviour
{
    //ëfçﬁÇÃíËã`
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject runnersentakuT;
    [SerializeField] GameObject syousaiT;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject haikei;

    public void plusBtn()
    {
        batsu.SetActive(true);
        runnersentakuT.SetActive(true);
        haikei.SetActive(true);
        popupBase.SetActive(true);
    }
    public void haikeiBtn()
    {
        batsu.SetActive(false);
        runnersentakuT.SetActive(false);
        haikei.SetActive(false);
        popupBase.SetActive(false);
    }
}
