using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShinaido2 : MonoBehaviour
{
    //àëàëÌ\¦eLXgè`
    public Text nameT;
    public Text zokuseiT;
    public Text jyukubunT;
    public Text shinaidoT;
    public Text dateShinchokuT;
    public Text kaiwaT;
    public Text mitsugimonoT;

    //ßÌæfÞ
    [SerializeField] GameObject naokoClose;
    [SerializeField] GameObject yasukoClose;
    [SerializeField] GameObject yoshikoClose;
    [SerializeField] GameObject hidetaClose;
    [SerializeField] GameObject hideyaClose;
    [SerializeField] GameObject yasuoClose;
    [SerializeField] GameObject mikaihou1;
    [SerializeField] GameObject mikaihou2;
    [SerializeField] GameObject mikaihou3;
    [SerializeField] GameObject mikaihou4;
    [SerializeField] GameObject mikaihou5;

    int kyara = AkagonohateData.shinaidoWho;
    void Start()
    {
        //¼OEß{^Ì\¦
        if (kyara == 1) {
            nameT.text = ("äÉ¼q");
            naokoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[0] == 0) {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[1] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[2] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[3] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[4] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 2)
        {
            nameT.text = ("¿ìNq");
            yasukoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[10] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[11] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[12] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[13] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[14] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 3)
        {
            nameT.text = ("¼½gq");
            yoshikoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[20] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[21] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[22] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[23] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[24] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 4)
        {
            nameT.text = ("¿ìG¾");
            hidetaClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[30] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[31] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[32] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[33] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[34] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 5)
        {
            nameT.text = ("éGç");
            hideyaClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[40] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[41] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[42] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[43] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[44] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }
        if (kyara == 6)
        {
            nameT.text = ("å´Nj");
            yasuoClose.SetActive(true);
            if (AkagonohateData.isyoSyojiFlg[50] == 0)
            {
                mikaihou1.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[51] == 0)
            {
                mikaihou2.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[52] == 0)
            {
                mikaihou3.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[53] == 0)
            {
                mikaihou4.SetActive(true);
            }
            if (AkagonohateData.isyoSyojiFlg[54] == 0)
            {
                mikaihou5.SetActive(true);
            }
        }

        //®«Ì\¦
        if (kyara == 1 || kyara == 6) {
            zokuseiT.text = ("®«F¿ìà´ãgpl");
        }
        if (kyara == 3 || kyara == 4)
        {
            zokuseiT.text = ("®«FÒmxw(¶k)");
        }
        if (kyara == 5)
        {
            zokuseiT.text = ("®«FÒmxwåw(w¶)");
        }
        if (kyara == 2)
        {
            zokuseiT.text = ("®«F¿ìà´Ù");
        }

        //ZæªÌ\¦
        if (kyara == 1 || kyara == 2 || kyara == 3 || kyara == 4)
        {
            jyukubunT.text = ("ZæªF®~à");
        }
        else {
            jyukubunT.text = ("ZæªF®~O");
        }

        //e¤LvÌ\¦
        int shinaiTMP = AkagonohateData.shinaido[kyara - 1];
        shinaidoT.text = ("»ÝÌe¤Lv@@" + shinaiTMP);

        //f[gi»Ì\¦
        int dateTMP = AkagonohateData.dateCount[kyara - 1];
        dateShinchokuT.text = ("f[gi»@@" + dateTMP + "ñ");

        //ÝvïbñÌ\¦
        int kaiwaTMP = AkagonohateData.kaiwaCount[kyara - 1];
        kaiwaT.text = ("Ývïbñ@@" + kaiwaTMP + "ñ");

        //Ývv¨ÂÌ\¦
        int mitsugiTMP = AkagonohateData.mitsugiCount[kyara - 1];
        mitsugimonoT.text = ("Ývv¨Â@@" + mitsugiTMP + "Â");
    }


    void Update()
    {
        
    }
}
