using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cbasyo : MonoBehaviour
{
    //‘fÞ‚Ì’è‹`
    [SerializeField] GameObject nLvIjyoude3;
    [SerializeField] GameObject mikaihou3;
    [SerializeField] GameObject basyoName3;
    [SerializeField] GameObject basyoTextBase3;
    [SerializeField] GameObject nLvIjyoude4;
    [SerializeField] GameObject mikaihou4;
    [SerializeField] GameObject basyoName4;
    [SerializeField] GameObject basyoTextBase4;
    [SerializeField] GameObject nLvIjyoude5;
    [SerializeField] GameObject mikaihou5;
    [SerializeField] GameObject basyoName5;
    [SerializeField] GameObject basyoTextBase5;
    [SerializeField] GameObject nLvIjyoude6;
    [SerializeField] GameObject mikaihou6;
    [SerializeField] GameObject basyoName6;
    [SerializeField] GameObject basyoTextBase6;
    [SerializeField] GameObject nLvIjyoude7;
    [SerializeField] GameObject mikaihou7;
    [SerializeField] GameObject basyoName7;
    [SerializeField] GameObject basyoTextBase7;
    [SerializeField] GameObject nLvIjyoude8;
    [SerializeField] GameObject mikaihou8;
    [SerializeField] GameObject basyoName8;
    [SerializeField] GameObject basyoTextBase8;
    [SerializeField] GameObject nLvIjyoude9;
    [SerializeField] GameObject mikaihou9;
    [SerializeField] GameObject basyoName9;
    [SerializeField] GameObject basyoTextBase9;

    [SerializeField] int lv = AkagonohateData.playerLvI;
    public void syokihyouji()
    {
        if (lv >= 5) {
            nLvIjyoude3.SetActive(false);
            mikaihou3.SetActive(false);
            basyoName3.SetActive(true);
            basyoTextBase3.SetActive(true);
        }
        if (lv >= 10)
        {
            nLvIjyoude4.SetActive(false);
            mikaihou4.SetActive(false);
            basyoName4.SetActive(true);
            basyoTextBase4.SetActive(true);
        }
        if (lv >= 15)
        {
            nLvIjyoude5.SetActive(false);
            mikaihou5.SetActive(false);
            basyoName5.SetActive(true);
            basyoTextBase5.SetActive(true);
        }
        if (lv >=20)
        {
            nLvIjyoude6.SetActive(false);
            mikaihou6.SetActive(false);
            basyoName6.SetActive(true);
            basyoTextBase6.SetActive(true);
        }
        if (lv >= 25)
        {
            nLvIjyoude7.SetActive(false);
            mikaihou7.SetActive(false);
            basyoName7.SetActive(true);
            basyoTextBase7.SetActive(true);
        }
        if (lv >= 30)
        {
            nLvIjyoude8.SetActive(false);
            mikaihou8.SetActive(false);
            basyoName8.SetActive(true);
            basyoTextBase8.SetActive(true);
        }
        if (lv >= 35)
        {
            nLvIjyoude9.SetActive(false);
            mikaihou9.SetActive(false);
            basyoName9.SetActive(true);
            basyoTextBase9.SetActive(true);
        }
    }
}
