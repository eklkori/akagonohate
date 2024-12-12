using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goGacha : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject overPopUp;
    [SerializeField] GameObject konyuPopUp;
    [SerializeField] GameObject goGachaPopUp;
    [SerializeField] GameObject closeBtn;
    [SerializeField] GameObject yes;
    [SerializeField] GameObject no;

    [SerializeField] Text maisu;

    int gachaFlg;

    private void Start()
    {
        //テスト用処理START
        //AkagonohateData.itemSyojisu[1] = 150;
        //テスト用処理END

        //前シーンを強制的に05Homeに変更
        AkagonohateData.maeScene = "05Home";
    }
    public void gachaPopUp(int num) {
        gachaFlg = num;

        //ポップアップの表示
        overPopUp.SetActive(true);
        konyuPopUp.SetActive(false);
        goGachaPopUp.SetActive(true);
        closeBtn.SetActive(false);

        //仕立券の所持数に応じて表示を制御
        int kijun = 0;
        switch (num)
        {
            case 1: kijun = 10; break;
            case 2: kijun = 100; break;
        }
        if (AkagonohateData.itemSyojisu[1] < kijun)
        {
            yes.SetActive(false);
            no.SetActive(true);
        }
        else
        {
            yes.SetActive(true);
            no.SetActive(false);
            //押されたボタンによる表示の制御(num==1：単発、num==2：10連)
            switch (num)
            {
                case 1: maisu.text = "×  10"; break;
                case 2: maisu.text = "×  100"; break;
            }
        }
    }

    /// <summary>
    /// ポップアップで「はい」が押されたときの処理
    /// </summary>
    public void hai() {
        //既存衣装フラグの初期化
        for (int i = 0; i < 10; i++) {
            AkagonohateData.gachaNotNew[i] = 0;
        }
        switch (gachaFlg)
        {
            case 1: goGacha1(); break;
            case 2: goGacha10(); break;
        }
    }

    /// <summary>
    /// ガチャデータセット用の乱数取得
    /// </summary>
    int ransusyutoku() {
        int res = 0;
        int rare = Random.Range(1, 1000);
        //レア度1の分岐
        if (1 <= rare && rare <= 700) {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 <= 1)
                {
                    break;
                }
            }
        }
        //レア度2の分岐
        if (701 <= rare && rare <= 900)
        {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 == 2 || res % 10 == 3)
                {
                    break;
                }
            }
        }
        //レア度3の分岐
        if (901 <= rare && rare < 1000)
        {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 == 4)
                {
                    break;
                }
            }
        }
        return res;
    }

    /// <summary>
    /// 単発ガチャボタン押下時の処理
    /// </summary>
    void goGacha1()
    {
        //仕立券所持数を操作
        AkagonohateData.itemSyojisu[1] -= 10;

        //ガチャ結果作成
        int res = ransusyutoku();
        if (AkagonohateData.isyoSyojiFlg[res] != 0) {
            AkagonohateData.gachaNotNew[0] = 1;
        }
        AkagonohateData.isyoSyojiFlg[res] = 1;
        AkagonohateData.gacha10[0] = res;
        AkagonohateData.gachaFlg = 1;

        SceneManager.LoadScene("14Gacha", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("13Busshi");
    }

    /// <summary>
    /// 10連ガチャボタン押下時の処理
    /// </summary>
    void goGacha10()
    {
        //仕立券所持数を操作
        AkagonohateData.itemSyojisu[1] -= 100;

        //ガチャ結果作成
        for (int i = 0; i < 10; i++)
        {
            int res = ransusyutoku();
            if (AkagonohateData.isyoSyojiFlg[res] != 0)
            {
                AkagonohateData.gachaNotNew[i] = 1;
            }
            AkagonohateData.isyoSyojiFlg[res] = 1;
            AkagonohateData.gacha10[i] = res;
        }
        AkagonohateData.gachaFlg = 2;

        SceneManager.LoadScene("14Gacha", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("13Busshi");
    }
}
