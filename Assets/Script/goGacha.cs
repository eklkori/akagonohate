using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goGacha : MonoBehaviour
{
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
    public void goGacha1()
    {
        int res = ransusyutoku();
        AkagonohateData.isyoSyojiFlg[res] = 1;
        AkagonohateData.gacha10[0] = res;
        AkagonohateData.gachaFlg = 1;
        SceneManager.LoadScene("14Gacha");
    }

    /// <summary>
    /// 10連ガチャボタン押下時の処理
    /// </summary>
    public void goGacha10()
    {
        for(int i = 0; i < 10; i++)
        {
            int res = ransusyutoku();
            AkagonohateData.isyoSyojiFlg[res] = 1;
            AkagonohateData.gacha10[i] = res;
        }
        AkagonohateData.gachaFlg = 2;
        SceneManager.LoadScene("14Gacha");
    }
}
