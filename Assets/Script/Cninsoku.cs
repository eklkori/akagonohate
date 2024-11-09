using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cninsoku : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject mogiriMinus;
    [SerializeField] GameObject mogiriPlus;
    [SerializeField] GameObject mogiriPlusNo;
    [SerializeField] GameObject yudoinMinus;
    [SerializeField] GameObject yudoinPlus;
    [SerializeField] GameObject yudoinPlusNo;
    [SerializeField] GameObject nimotsuMinus;
    [SerializeField] GameObject nimotsuPlus;
    [SerializeField] GameObject nimotsuPlusNo;
    [SerializeField] GameObject ninsokuAll;

    [SerializeField] Text moT;
    [SerializeField] Text yuT;
    [SerializeField] Text niT;
    void Start()
    {
        moT.text = AkagonohateData.moZen.ToString();
        yuT.text = AkagonohateData.yuZen.ToString();
        niT.text = AkagonohateData.niZen.ToString();

        //テスト用値操作
        AkagonohateData.itemSyojisu[3] = 1;
        AkagonohateData.itemSyojisu[4] = 2;
        AkagonohateData.itemSyojisu[5] = 3;
        //テスト用処理END

        //セッティング画面を表示せずにランウェイを始めても人足数値が反映されるよう、最初に処理のみ流す
        syokisuchi();
    }

    int syokaiFlg = 0;
    int moTMP = 0;
    int yuTMP = 0;
    int niTMP = 0;
    public void syokisuchi()
    {
        ninsokuAll.SetActive(true);

        int moTint = int.Parse(moT.text);
        int yuTint = int.Parse(yuT.text);
        int niTint = int.Parse(niT.text);

        //-------初期数値の設定--------
        //※syokaiFlgが0の場合は前回ランウェイ時の設定値を参照、1の場合はランナー画面遷移前の設定値を参照
        if (syokaiFlg == 0)
        {
            //もぎりの数値初期化
            //※前回設定値＞所持数の場合、所持数を優先して表示
            if (AkagonohateData.moZen > AkagonohateData.itemSyojisu[3])
            {
                moT.text = AkagonohateData.itemSyojisu[3].ToString();
            }
            else
            {
                mogiriPlus.SetActive(true);
                mogiriPlusNo.SetActive(false);
            }

            //誘導員の数値初期化
            //※前回設定値＞所持数の場合、所持数を優先して表示
            if (AkagonohateData.yuZen > AkagonohateData.itemSyojisu[4])
            {
                yuT.text = AkagonohateData.itemSyojisu[4].ToString();
            }
            else
            {
                yudoinPlus.SetActive(true);
                yudoinPlusNo.SetActive(false);
            }

            //荷物持ちの数値初期化
            //※前回設定値＞所持数の場合、所持数を優先して表示
            if (AkagonohateData.niZen > AkagonohateData.itemSyojisu[5])
            {
                niT.text = AkagonohateData.itemSyojisu[5].ToString();
            }
            else
            {
                nimotsuPlus.SetActive(true);
                nimotsuPlusNo.SetActive(false);
            }
        }
        else {
            //もぎりの数値初期化(2回目以降)
            //※前回設定値＞所持数の場合、所持数を優先して表示
                moT.text = moTMP.ToString();
                mogiriPlus.SetActive(true);
                mogiriPlusNo.SetActive(false);

            //誘導員の数値初期化(2回目以降)
            //※前回設定値＞所持数の場合、所持数を優先して表示
                yuT.text = yuTMP.ToString();
                yudoinPlus.SetActive(true);
                yudoinPlusNo.SetActive(false);

            //荷物持ちの数値初期化(2回目以降)
            //※前回設定値＞所持数の場合、所持数を優先して表示
                niT.text = niTMP.ToString();
                nimotsuPlus.SetActive(true);
                nimotsuPlusNo.SetActive(false);
        }
        if (syokaiFlg == 0) {
            ninsokuAll.SetActive(false);
            syokaiFlg = 1;
        }
    }

    /// <summary>
    /// 値が0の時を考慮
    /// </summary>
    public void zero() {
        int moTint = int.Parse(moT.text);
        int yuTint = int.Parse(yuT.text);
        int niTint = int.Parse(niT.text);
        //0の場合の処理
        if (moTint == 0)
        {
            mogiriMinus.SetActive(false);
        }
        if (yuTint == 0)
        {
            yudoinMinus.SetActive(false);
        }
        if (niTint == 0)
        {
            nimotsuMinus.SetActive(false);
        }
        //0以外の場合の処理
        if (moTint != 0)
        {
            mogiriMinus.SetActive(true);
        }
        if (yuTint != 0)
        {
            yudoinMinus.SetActive(true);
        }
        if (niTint != 0)
        {
            nimotsuMinus.SetActive(true);
        }
        //前回設定値＝所持数の場合
        if (moTint == AkagonohateData.itemSyojisu[3])
        {
            mogiriPlus.SetActive(false);
            mogiriPlusNo.SetActive(true);
        }
        if (yuTint == AkagonohateData.itemSyojisu[4])
        {
            yudoinPlus.SetActive(false);
            yudoinPlusNo.SetActive(true);
        }
        if (niTint == AkagonohateData.itemSyojisu[5])
        {
            nimotsuPlus.SetActive(false);
            nimotsuPlusNo.SetActive(true);
        }
    }
    public void moMinus()
    {
        moTMP = int.Parse(moT.text);
        moTMP--;
        moT.text = moTMP.ToString();
        if (moTMP < AkagonohateData.itemSyojisu[3])
        {
            mogiriPlus.SetActive(true);
            mogiriPlusNo.SetActive(false);
        }
        zero();
    }
    public void moPlus()
    {
        moTMP = int.Parse(moT.text);
        moTMP++;
        moT.text = moTMP.ToString();
        zero();
    }
    public void yuMinus()
    {
        yuTMP = int.Parse(yuT.text);
        yuTMP--;
        yuT.text = yuTMP.ToString();
        if (yuTMP < AkagonohateData.itemSyojisu[4])
        {
            yudoinPlus.SetActive(true);
            yudoinPlusNo.SetActive(false);
        }
        zero();
    }
    public void yuPlus()
    {
        yuTMP = int.Parse(yuT.text);
        yuTMP++;
        yuT.text = yuTMP.ToString();
        zero();
    }
    public void niMinus()
    {
        niTMP = int.Parse(niT.text);
        niTMP--;
        niT.text = niTMP.ToString();
        if (niTMP < AkagonohateData.itemSyojisu[5])
        {
            nimotsuPlus.SetActive(true);
            nimotsuPlusNo.SetActive(false);
        }
        zero();
    }
    public void niPlus()
    {
        niTMP = int.Parse(niT.text);
        niTMP++;
        niT.text = niTMP.ToString();
        zero();
    }
}
