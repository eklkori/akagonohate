using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRunwaySet : MonoBehaviour
{
    //素材の定義
    //ランナー
    [SerializeField] GameObject daiichimakuBtn;
    [SerializeField] GameObject dainimakuBtn;
    [SerializeField] GameObject daisanmakuBtn;
    [SerializeField] GameObject settingBtn;
    [SerializeField] GameObject dainmakuBtnBase;
    [SerializeField] GameObject runners;
    [SerializeField] GameObject runnerWakus;
    [SerializeField] GameObject hazusuBtns;
    [SerializeField] GameObject plusRunnerBtn;
    //セッティング
    [SerializeField] GameObject runnerBtn;
    [SerializeField] GameObject mogiri;
    [SerializeField] GameObject yudoin;
    [SerializeField] GameObject nimotsu;
    [SerializeField] GameObject ninsokuT;
    [SerializeField] GameObject mogiriMinus;
    [SerializeField] GameObject mogiriPlus;
    [SerializeField] GameObject mogiriPlusNo;
    [SerializeField] GameObject yudoinMinus;
    [SerializeField] GameObject yudoinPlus;
    [SerializeField] GameObject yudoinPlusNo;
    [SerializeField] GameObject nimotsuMinus;
    [SerializeField] GameObject nimotsuPlus;
    [SerializeField] GameObject nimotsuPlusNo;
    [SerializeField] GameObject mogirisu;
    [SerializeField] GameObject yudoinsu;
    [SerializeField] GameObject nimotsusu;
    [SerializeField] GameObject basyos;
    [SerializeField] GameObject cRunwaySet;

    /// <summary>
    /// セッティングボタン押下時の処理
    /// </summary>
    public void goSetting()
    {
        daiichimakuBtn.SetActive(false);
        dainimakuBtn.SetActive(false);
        daisanmakuBtn.SetActive(false);
        dainmakuBtnBase.SetActive(false);
        settingBtn.SetActive(false);
        runners.SetActive(false);
        runnerWakus.SetActive(false);
        hazusuBtns.SetActive(false);
        plusRunnerBtn.SetActive(false);

        runnerBtn.SetActive(true);
        mogiri.SetActive(true);
        yudoin.SetActive(true);
        nimotsu.SetActive(true);
        ninsokuT.SetActive(true);
        mogiriMinus.SetActive(true);
        mogiriPlus.SetActive(true);
        mogiriPlusNo.SetActive(true);
        yudoinMinus.SetActive(true);
        yudoinPlus.SetActive(true);
        yudoinPlusNo.SetActive(true);
        nimotsuMinus.SetActive(true);
        nimotsuPlus.SetActive(true);
        nimotsuPlusNo.SetActive(true);
        mogirisu.SetActive(true);
        yudoinsu.SetActive(true);
        nimotsusu.SetActive(true);
        basyos.SetActive(true);

        cRunwaySet.GetComponent<Cninsoku>().syokisuchi();
        cRunwaySet.GetComponent<Cninsoku>().zero();
        cRunwaySet.GetComponent<Cbasyo>().syokihyouji();
    }

    /// <summary>
    /// ランナーボタン押下時の処理
    /// </summary>
    public void goRunner() {
        runnerBtn.SetActive(false);
        mogiri.SetActive(false);
        yudoin.SetActive(false);
        nimotsu.SetActive(false);
        ninsokuT.SetActive(false);
        mogiriMinus.SetActive(false);
        mogiriPlus.SetActive(false);
        mogiriPlusNo.SetActive(false);
        yudoinMinus.SetActive(false);
        yudoinPlus.SetActive(false);
        yudoinPlusNo.SetActive(false);
        nimotsuMinus.SetActive(false);
        nimotsuPlus.SetActive(false);
        nimotsuPlusNo.SetActive(false);
        mogirisu.SetActive(false);
        yudoinsu.SetActive(false);
        nimotsusu.SetActive(false);
        basyos.SetActive(false);

        settingBtn.SetActive(true);
        dainmakuBtnBase.SetActive(true);
        runnerWakus.SetActive(true);
        hazusuBtns.SetActive(true);
        plusRunnerBtn.SetActive(true);
        runners.SetActive(true);

        //セッティング→ランナー切り替え時に、セッティング切り替え前に表示していた
        //幕を表示できるようにする
        if (AkagonohateData.hyoujimaku == 1) {
            dainimakuBtn.SetActive(true);
            daisanmakuBtn.SetActive(true);
        }
        if (AkagonohateData.hyoujimaku == 2)
        {
            daiichimakuBtn.SetActive(true);
            daisanmakuBtn.SetActive(true);
        }
        if (AkagonohateData.hyoujimaku == 3)
        {
            daiichimakuBtn.SetActive(true);
            dainimakuBtn.SetActive(true);
        }
    }

    /// <summary>
    /// ランナー画面　第一幕ボタン押下時の処理
    /// </summary>
    public void goDaiichimaku() {
        daiichimakuBtn.SetActive(false);
        dainimakuBtn.SetActive(true);
        daisanmakuBtn.SetActive(true);
        AkagonohateData.hyoujimaku = 1;
    }

    /// <summary>
    /// ランナー画面　第二幕ボタン押下時の処理
    /// </summary>
    public void goDainimaku()
    {
        daiichimakuBtn.SetActive(true);
        dainimakuBtn.SetActive(false);
        daisanmakuBtn.SetActive(true);
        AkagonohateData.hyoujimaku = 2;
    }

    /// <summary>
    /// ランナー画面　第三幕ボタン押下時の処理
    /// </summary>
    public void goDaisanmaku()
    {
        daiichimakuBtn.SetActive(true);
        dainimakuBtn.SetActive(true);
        daisanmakuBtn.SetActive(false);
        AkagonohateData.hyoujimaku = 3;
    }
}
