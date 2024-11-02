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
    [SerializeField] GameObject[] keys;

    public Text playerLv;
    public Text playerName;
    public Text kenSyoji;
    public Text zeniSyoji;
    public Text keyHMMSS;
    void Start()
    {
        //テスト用
        AkagonohateData.itemSyojisu[2] = 3;
    }

    float countH = AkagonohateData.HH; //要検討
    float countM = AkagonohateData.MM; //要検討
    float countS = AkagonohateData.SS; //要検討
    public void Update()
    {
        playerLv.text = AkagonohateData.playerLvI.ToString();
        playerName.text = AkagonohateData.playerNmaeT;
        kenSyoji.text = AkagonohateData.itemSyojisu[1].ToString();
        zeniSyoji.text = AkagonohateData.itemSyojisu[0].ToString();
        keyHMMSS.text = countS.ToString();

        for (int i = 0; i < AkagonohateData.itemSyojisu[2]; i++) {
            keys[i].SetActive(true);
        }

        ExpBar();
        Keys();
    }

    /// <summary>
    /// プレイヤーLv・EXPバーの制御
    /// </summary>
    void ExpBar() {
        //プレイヤーLv・EXPバーの制御
        float kijyun = 100 + AkagonohateData.playerLvI* AkagonohateData.playerLvI;
        if (kijyun<= AkagonohateData.exp) {
            AkagonohateData.playerLvI++;
        }
        kijyun = 100 + AkagonohateData.playerLvI * AkagonohateData.playerLvI;
        float par = AkagonohateData.exp / kijyun;
        expBar.GetComponent<Image>().fillAmount = par;
    }

    /// <summary>
    /// 鍵の制御
    /// </summary>
    void Keys() {
        if (AkagonohateData.itemSyojisu[2] != 5)
        {
            countS -= Time.deltaTime;
            if (countS.ToString("f0") == "-1")
            {
                countM--;
                countS = 59;
                if (countM == -1)
                {
                    countH--;
                    countM = 59;
                    if (countH == -1)
                    {
                        //鍵が1つ回復した時の処理
                        countH = 1;
                        AkagonohateData.itemSyojisu[2]++;
                        keys[AkagonohateData.itemSyojisu[2]-1].SetActive(true);
                    }
                }
            }
            //DBデータの上書き
            AkagonohateData.HH = countH;
            AkagonohateData.MM = countM;
            AkagonohateData.SS = countS;

            //UI表示
            keyHMMSS.text = countH.ToString("f0") + ":" + countM.ToString("00") + ":" + countS.ToString("00");
        }
        else
        {
            keyHMMSS.text = "0:00:00";
        }
    }
}
