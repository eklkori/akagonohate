using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kyaraSyosaiPopUp : MonoBehaviour
{
    //各画面共通で使用
    //使用方法
    //①使用する画面にPrefab「kyaraSyousaiPopUp」を配置
    //②「kyaraSyousaiPopUp」オブジェクトにアタッチされた当該スクリプトで宣言した配列等に、インスペクター上で要素をセット
    //③呼び出し元のボタンのOnClick処理でpushIcon(int)を設定し、引数に衣装Noをセット

    //素材の定義
    [SerializeField] GameObject kyaraSyousaiPopUp;
    [SerializeField] GameObject[] kyaraImages;
    [SerializeField] GameObject[] haikei;
    [SerializeField] GameObject[] hoshi;

    [SerializeField] Text nameT;
    [SerializeField] Text setsumei;
    [SerializeField] Text biT;
    [SerializeField] Text huT;
    [SerializeField] Text eveT;
    void Start()
    {
        kyaraSyousaiPopUp.SetActive(false);
    }

    /// <summary>
    /// キャラ詳細ポップアップ表示処理
    /// ※引数を渡すと、引数に一致するキャラの詳細を表示するメソッド(各画面共通)
    /// </summary>
    /// <param name="num"></param>
    public void pushIcon(int num) {
        kyaraSyousaiPopUp.SetActive(true);

        //表示の初期化
        for (int i = 0; i < 60; i++) {
            kyaraImages[i].SetActive(false);
        }
        for (int i = 0; i < 3; i++) {
            haikei[i].SetActive(false);
            hoshi[i].SetActive(false);
        }

        //キャラ画像の表示
        kyaraImages[num].SetActive(true);

        //キャラ名・レア度の判定
        int kyaraName = num / 10;
        int kyaraRea = num % 10;

        //レアリティーの差による表示分け
        if (kyaraRea == 0 || kyaraRea == 1)
        {
            haikei[0].SetActive(true);
            hoshi[0].SetActive(true);
        }
        else if (kyaraRea == 2 || kyaraRea == 3)
        {
            haikei[1].SetActive(true);
            hoshi[1].SetActive(true);
        }
        else 
        {
            haikei[2].SetActive(true);
            hoshi[2].SetActive(true);
        }

        //キャラ名表示
        switch (kyaraName)
        {
            case 0: nameT.text = "井伊 直子"; break;
            case 1: nameT.text = "徳川 康子"; break;
            case 2: nameT.text = "松平 吉子"; break;
            case 3: nameT.text = "徳川 秀太"; break;
            case 4: nameT.text = "結城 秀也"; break;
            case 5: nameT.text = "榊原 康男"; break;
        }
        //キャラ紹介文差し替え
        //直子
        if (num == 0 || num == 1) 
            setsumei.text = "直子星1のキャラ紹介文";
        if (num == 2 || num == 3) 
            setsumei.text = "直子星2のキャラ紹介文";
        if (num == 4) 
            setsumei.text = "直子星3のキャラ紹介文";
        //康子
        if (num == 10 || num == 11) 
            setsumei.text = "康子星1のキャラ紹介文";
        if (num == 12 || num == 13)
            setsumei.text = "康子星2のキャラ紹介文";
        if (num == 14)
            setsumei.text = "康子星3のキャラ紹介文";
        //吉子
        if (num == 20 || num == 21)
            setsumei.text = "吉子星1のキャラ紹介文";
        if (num == 22 || num == 23)
            setsumei.text = "吉子星2のキャラ紹介文";
        if (num == 24)
            setsumei.text = "吉子星3のキャラ紹介文";
        //秀太
        if (num == 30 || num == 31)
            setsumei.text = "秀太星1のキャラ紹介文";
        if (num == 32 || num == 33)
            setsumei.text = "秀太星2のキャラ紹介文";
        if (num == 34)
            setsumei.text = "秀太星3のキャラ紹介文";
        //秀也
        if (num == 40 || num == 41)
            setsumei.text = "秀也星1のキャラ紹介文";
        if (num == 42 || num == 43)
            setsumei.text = "秀也星2のキャラ紹介文";
        if (num == 44)
            setsumei.text = "秀也星3のキャラ紹介文";
        //康男
        if (num == 50 || num == 51)
            setsumei.text = "康男星1のキャラ紹介文";
        if (num == 52 || num == 53)
            setsumei.text = "康男星2のキャラ紹介文";
        if (num == 54)
            setsumei.text = "康男星3のキャラ紹介文";

        //ステータスの表示
        //美しさ・ユーモア性の固定値取得
        AkagonohateData akagoData = ScriptableObject.CreateInstance<AkagonohateData>();　　//インスタンス化
        int[] bi = akagoData.GetBi;
        int[] hu = akagoData.GetHu;

        biT.text = bi[num].ToString();
        huT.text = hu[num].ToString();

        //イベント特攻はレア度により固定のため、レア度による分岐で処理
        if (kyaraRea == 0 || kyaraRea == 1)
        {
            eveT.text = "1/1";
        }
        else if (kyaraRea == 2 || kyaraRea == 3)
        {
            eveT.text = "2/2";
        }
        else
        {
            eveT.text = "30/12";
        }
    }

    /// <summary>
    /// キャラ詳細ポップアップを閉じる処理
    /// </summary>
    public void closeKyaraPopUp()
    {
        kyaraSyousaiPopUp.SetActive(false);
    }
    void Update()
    {
        
    }
}
