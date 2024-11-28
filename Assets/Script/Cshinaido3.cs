using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cshinaido3 : MonoBehaviour
{
    [SerializeField] GameObject dateBtn;
    [SerializeField] GameObject kaiwaBtn;
    [SerializeField] GameObject dates;
    [SerializeField] GameObject kaiwas;
    [SerializeField] GameObject[] miruBtnsK;
    [SerializeField] GameObject[] miruBtnsD;
    [SerializeField] GameObject[] mikakutokuAri;
    [SerializeField] Text[] DKaihou;

    int who = 0;
    int No = 0;
    string labelName = "";
    string Dhantei = "";
    private void Start()
    {
        //テスト用仮置き
        //AkagonohateData.kaiwaShichoFlg[1] = 1;
        //AkagonohateData.kaiwaShichoFlg[103] = 1;
        //AkagonohateData.dateShichoFlg[2] = 1;
        //AkagonohateData.dateShichoFlg[44] = 1;
        //テスト用仮置きEND

        //戻るボタンの遷移先を操作
        AkagonohateData.maeScene = "17Shinaido2";

        //変数の準備
        who = AkagonohateData.shinaidoWho;

        switch (who)
        {
            case 1: labelName = "naoko"; break;
            case 2: labelName = "yasuko"; break;
            case 3: labelName = "yoshiko"; break;
            case 4: labelName = "hideta"; break;
            case 5: labelName = "hideya"; break;
            case 6: labelName = "yasuo"; break;
        }

        //会話/デート一覧の表示
        if (AkagonohateData.kakuninchuFlg == 2)
        {
            showDate();
        }
        else
        {
            showKaiwas();
        }
        AkagonohateData.kakuninchuFlg = 0;  //確認中フラグはgoUtageメソッドで操作(1か2に上書き)
    }

    /// <summary>
    /// デートボタンが押されたときの処理
    /// </summary>
    public void showDate()
    {
        dateBtn.SetActive(false);
        kaiwaBtn.SetActive(true);
        dates.SetActive(true);
        kaiwas.SetActive(false);
        showDates();
    }

    /// <summary>
    /// 会話ボタンが押されたときの処理
    /// </summary>
    public void showKaiwa()
    {
        dateBtn.SetActive(true);
        kaiwaBtn.SetActive(false);
        dates.SetActive(false);
        kaiwas.SetActive(true);
        showKaiwas();
    }

    /// <summary>
    /// デート視聴済み/未視聴による「見る」ボタンの表示非表示等の制御
    /// </summary>
    void showDates()
    {
        //dateCountには各キャラのデートシナリオ総数を格納(デート×5＋仲直り1=6)
        int dateCount = 0;
        //dateNoにはシナリオNoを格納(各キャラ20ずつで仮作成)
        int dateNo = 0;
        switch (who)
        {
            case 1: dateCount = 6; break;
            case 2: dateCount = 6; dateNo = 20; break;
            case 3: dateCount = 6; dateNo = 40; break;
            case 4: dateCount = 6; dateNo = 60; break;
            case 5: dateCount = 6; dateNo = 80; break;
            case 6: dateCount = 6; dateNo = 100; break;
        }
        for (int i = 0; i < dateCount; i++)
        {
            if (AkagonohateData.dateShichoFlg[dateNo + i] == 1) {
                miruBtnsD[i].SetActive(true);
            }
        }
        Debug.Log("AkagonohateData.dateShichoFlg[200 + (who-1) * 20 + i]=" + AkagonohateData.dateShichoFlg[200 + (who - 1) * 20]);
        //未獲得報酬がある場合は文字アイコンを表示
        for (int i = 0; i < mikakutokuAri.Length; i++)
        {
            if (AkagonohateData.dateShichoFlg[200 + (who-1) * 20 + i] == 1 && AkagonohateData.dateShichoFlg[400 + (who - 1) * 20 + i] == 1)
            {
                //2/2視聴済み
                mikakutokuAri[i].SetActive(false);
                DKaihou[i].text = "分岐：2/2閲覧済み";
                Debug.Log("あ");
            }
            else if (AkagonohateData.dateShichoFlg[200 + (who-1) * 20 + i] == 1 || AkagonohateData.dateShichoFlg[400 + (who - 1) * 20 + i] == 1)
            {
                //1/2視聴済み
                mikakutokuAri[i].SetActive(true);
                DKaihou[i].text = "分岐：1/2閲覧済み";
                Debug.Log("い");
            }
            else
            {
                //0/2視聴済み
                mikakutokuAri[i].SetActive(false);
                DKaihou[i].text = "未開放";
                Debug.Log("う");
            }
        }
    }


    /// <summary>
    /// 会話視聴済み/未視聴による「見る」ボタンの表示非表示等の制御
    /// </summary>
    void showKaiwas() {
        //kaiwaCountには各キャラの会話シナリオ総数を格納
        int kaiwaCount = 0;
        //kaiwaNoにはシナリオNoを格納(各キャラ50ずつで仮作成)
        int kaiwaNo = 0;
        switch (who)
        {
            case 1: kaiwaCount = 10; break;
            case 2: kaiwaCount = 10; kaiwaNo = 50; break;
            case 3: kaiwaCount = 10; kaiwaNo = 100; break;
            case 4: kaiwaCount = 10; kaiwaNo = 150; break;
            case 5: kaiwaCount = 10; kaiwaNo = 200; break;
            case 6: kaiwaCount = 10; kaiwaNo = 250; break;
        }
        for (int i = 0; i < kaiwaCount; i++)
        {
            if (AkagonohateData.kaiwaShichoFlg[kaiwaNo + i] == 1)
            {
                miruBtnsK[i].SetActive(true);
            }
        }
    }

    //以下、各種「見る」ボタンが押されたときの処理

    //シナリオラベル設定用変数
    string label = "";

    /// <summary>
    /// 会話 見るボタン押下時の処理
    /// </summary>
    /// <param name="kaiwaNo"></param>
    public void Kbtn(int kaiwaNo) {
        No = kaiwaNo;
        goUtage();
    }

    /// <summary>
    /// デート 見るボタン押下時の処理
    /// </summary>
    /// <param name="dateNo"></param>
    public void Dbtn(int dateNo)
    {
        No = dateNo;
        Dhantei = "D";
        goUtage();
    }

    /// <summary>
    /// 宴に遷移してシナリオを開始させる処理
    /// </summary>
    void goUtage() {
        //ラベルの作成
        label = Dhantei + labelName + No;
        Debug.Log(label);

        AkagonohateData.kaiwaNo = label;
        string first = label.Substring(0, 1);
        if (first == "D")
        {
            AkagonohateData.kakuninchuFlg = 2;
        }
        else
        {
            AkagonohateData.kakuninchuFlg = 1;
        }
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("18Shinaido3");
    }
}
