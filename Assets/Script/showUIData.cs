using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class showUIData : MonoBehaviour
{
    /*[SerializeField] private AkagoDB akagoDB;

    public void AddAkagoData(AkagonohateData akago)
    {
        akagoDB.akagoList.Add(akago);
    }*/

    [SerializeField] GameObject expBar;

    public Text playerLv;
    public Text playerName;
    public Text kenSyoji;
    public Text zeniSyoji;
    void Start()
    {
    }

    public void Update()
    {
        playerLv.text = AkagonohateData.playerLvI.ToString();
        playerName.text = AkagonohateData.playerNmaeT;
        kenSyoji.text = AkagonohateData.kenSyojiI.ToString();
        zeniSyoji.text = AkagonohateData.zeniSyojiI.ToString();
        ExpBar();
    }
    void ExpBar() {
        float kijyun = 100 + AkagonohateData.playerLvI* AkagonohateData.playerLvI;
        if (kijyun<= AkagonohateData.exp) {
            AkagonohateData.playerLvI++;
        }
        kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
        float par = AkagonohateData.exp / kijyun;
        expBar.GetComponent<Image>().fillAmount = par;
    }
}
