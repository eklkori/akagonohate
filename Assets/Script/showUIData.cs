using System.Collections;
using System.Collections.Generic;
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
    }
}
