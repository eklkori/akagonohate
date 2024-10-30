using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class goRunway : MonoBehaviour
{
    [SerializeField] GameObject kaishiBtn;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject popupBase2;
    [SerializeField] GameObject setteishita;
    [SerializeField] GameObject key;
    [SerializeField] GameObject hai;
    [SerializeField] GameObject hai2;
    [SerializeField] GameObject iie;
    [SerializeField] GameObject sankaku;
    [SerializeField] GameObject haiBtn;
    [SerializeField] GameObject hai2Btn;
    [SerializeField] GameObject iieBtn;
    [SerializeField] GameObject imasugu;
    [SerializeField] GameObject tarimasen;
    [SerializeField] GameObject now;
    [SerializeField] GameObject after;

    //鍵数表示(ポップアップ用)
    public Text nowT;
    public Text afterT;

    //人足設定表示値
    public Text moT;
    public Text yuT;
    public Text niT;


    public void kaishi()
    {
        //テスト用
        //AkagonohateData.itemSyojisu[2] = 3;

        haikei.SetActive(true);
        popupBase2.SetActive(true);
        setteishita.SetActive(true);
        key.SetActive(true);
        hai.SetActive(true);
        iie.SetActive(true);
        haiBtn.SetActive(true);
        iieBtn.SetActive(true);
        sankaku.SetActive(true);

        nowT.text = AkagonohateData.itemSyojisu[2].ToString();
        int tmp = AkagonohateData.itemSyojisu[2]-1;
        afterT.text = tmp.ToString();

        now.SetActive(true);
        after.SetActive(true);

        if (tmp < 0) {
            setteishita.SetActive(false);
            key.SetActive(false);
            hai.SetActive(false);
            iie.SetActive(false);
            sankaku.SetActive(false);
            hai2.SetActive(true);
            imasugu.SetActive(true);
            hai2Btn.SetActive(true);
            tarimasen.SetActive(true);
        }
    }

    public void Hai()
    {
        //鍵の所持数を引く・上書き
        AkagonohateData.itemSyojisu[2]--;
        //人足アイテム所持数を引く・上書き
        int moTMP = int.Parse(moT.text);
        int yuTMP = int.Parse(yuT.text);
        int niTMP = int.Parse(niT.text);
        AkagonohateData.itemSyojisu[3] -= moTMP;
        AkagonohateData.itemSyojisu[4] -= yuTMP;
        AkagonohateData.itemSyojisu[5] -= niTMP;
        AkagonohateData.moZen = moTMP;
        AkagonohateData.yuZen = yuTMP;
        AkagonohateData.niZen = niTMP;

        SceneManager.LoadScene("11Runway");
    }
}
