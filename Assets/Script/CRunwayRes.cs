using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CRunwayRes : MonoBehaviour
{
    [SerializeField] GameObject[] bg;
    void Start()
    {
        int basyo = AkagonohateData.basyo;
        switch (basyo)
        {
            case 1: bg[0].SetActive(true); break;
            case 2: bg[1].SetActive(true); break;
            case 3: bg[2].SetActive(true); break;
            case 4: bg[3].SetActive(true); break;
            case 5: bg[4].SetActive(true); break;
            case 6: bg[5].SetActive(true); break;
            case 7: bg[6].SetActive(true); break;
            case 8: bg[7].SetActive(true); break;
            case 9: bg[8].SetActive(true); break;
        }
    }

    public void mouichido()
    {
        //l‘«‚ª‘O‰ñÝ’è’l>ŠŽ”‚Ìê‡
        int moZen = AkagonohateData.moZen;
        int moNow = AkagonohateData.itemSyojisu[3];
        int yuZen = AkagonohateData.moZen;
        int yuNow = AkagonohateData.itemSyojisu[4];
        int niZen = AkagonohateData.moZen;
        int niNow = AkagonohateData.itemSyojisu[5];
        if (moZen > moNow) {
            moZen = moNow;
        }
        if (yuZen > yuNow)
        {
            yuZen = yuNow;
        }
        if (niZen > niNow)
        {
            niZen = niNow;
        }
        SceneManager.LoadScene("11Runway");
    }
    public void kaete() {
        SceneManager.LoadScene("10RunwaySet");
    }
    public void modoru() {
        SceneManager.LoadScene("05Home");
    }
}
