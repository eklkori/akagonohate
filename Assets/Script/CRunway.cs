using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utage;

public class CRunway : MonoBehaviour
{
    [SerializeField] GameObject[] bg;
    [SerializeField] GameObject nextBtn;
    [SerializeField] GameObject[] dainmaku;
    [SerializeField] GameObject[] runners;
    [SerializeField] GameObject res;
    [SerializeField] GameObject yu;
    [SerializeField] GameObject ryo;
    [SerializeField] GameObject ka;
    [SerializeField] GameObject nextT;
    [SerializeField] GameObject resRunnerImages;

    public RectTransform Runners;
    public RectTransform move;
    [SerializeField] Image[] RunnerImages;
    [SerializeField] Image RunnerRes;

    //フォルダ内の画像(スプライト)を配列化
    [SerializeField] Sprite[] ImagesNaoko;
    [SerializeField] Sprite[] ImagesYasuko;
    [SerializeField] Sprite[] ImagesYoshiko;
    [SerializeField] Sprite[] ImagesHideta;
    [SerializeField] Sprite[] ImagesHideya;
    [SerializeField] Sprite[] ImagesYasuo;
    [SerializeField] Sprite[] ResRunnerImages;

    int basyo = 0;

    int makuCount = 0;
    int moveFlg = 0;
    int fadeFlg = 0;
    int tenmetsuFlg = 0;
    int moveNmakuFlg = 0;

    [SerializeField] Text hyouteiT;

    /// <summary>
    /// ランウェイ開始時の処理(第一幕のみ)
    /// </summary>
    void Start()
    {
        //テスト用処理START
        /// < summary >
        /// ランナー画像差し替えテスト用
        /// </ summary >
        //int forCount = 0;
        //int ten = 0;
        //for (int i = 0; i < 24; i++)
        //{
        //    if (forCount == 4)
        //    {
        //        forCount = 0;
        //        ten++;
        //    }
        //    AkagonohateData.runner[i] = ten * 10 + forCount;
        //    forCount++;
        //}
        AkagonohateData.basyo = 1;
        //テスト用処理END

        nextBtn.SetActive(false);
        res.SetActive(false);

        //背景の初期化
        for (int i = 0; i < 9; i++) {
            bg[i].SetActive(false);
        }
        //背景の表示
        basyo = AkagonohateData.basyo;
        switch (basyo) {
            case 1: bg[0].SetActive(true); break;
            case 2: bg[1].SetActive(true); break;
            case 3: bg[2].SetActive(true); break;
            case 4: bg[3].SetActive(true); break;
            case 5: bg[4].SetActive(true); break;
            case 6: bg[5].SetActive(true); break;
            case 7: bg[6].SetActive(true); break;
            case 8: bg[7].SetActive(true); break;
            case 9: bg[8].SetActive(true); break;
        }
        makuStart();
    }

    /// <summary>
    /// ランウェイ各幕の開始処理
    /// </summary>
    public void makuStart() {

        //-------「n幕目」のnを設定----------
        makuCount++;

        //-------「n幕目」の表示処理--------
        //①該当の素材を表示
        switch (makuCount) {
            case 1: dainmaku[0].SetActive(true); break;
            case 2: dainmaku[1].SetActive(true); break;
            case 3: dainmaku[2].SetActive(true); break;
        }

        //②フェードアウトさせる処理
        Invoke("wait", 1);

        //-------ランナー画像差し替え処理--------
        //①ランナーNoを設定
        int[] kakunin = { 0, 1, 2, 3, 4, 5, 6, 7 };
        for (int i = 0; i < 8; i++) {
            if (makuCount == 2) {
                kakunin[i] += 8;
            }
            if (makuCount == 3)
            {
                kakunin[i] += 16;
            }
        }


        for (int count = 0; count < 8; count++) {

            //②ランナー衣装Noを取得
            int who = AkagonohateData.runner[kakunin[count]];
            Debug.Log(who);

            //③キャラ個別の処理(メソッド「void showXX(int count,int who)」で実施)
            //※画像差し替え・画像サイズ調整を実施
            if (who == -1)
            {
                runners[count].SetActive(false);
            }
            else {
                runners[count].SetActive(true);
            }
            if (0 <= who && who < 10) {
                showNaoko(count,who);
            }
            if (10 <= who && who <20)
            {
                showYasuko(count, who);
            }
            if (20 <= who && who < 30)
            {
                showYoshiko(count, who);
            }
            if (30 <= who && who < 40)
            {
                showHideta(count, who);
            }
            if (40 <= who && who < 50)
            {
                showHideya(count, who);
            }
            if (50 <= who && who < 60)
            {
                showYasuo(count, who);
            }
            if (count == 8) {
                moveFlg = 1;
            }
        }

    }

    void showNaoko(int count,int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800,2230,0);
        int random = Random.Range(0,8);
        if (who == 0)
        {
            RunnerImages[count].sprite = ImagesNaoko[random];
        }
        if (who == 1)
        {
            RunnerImages[count].sprite = ImagesNaoko[random + 10];
        }
        if (who == 2)
        {
            RunnerImages[count].sprite = ImagesNaoko[random + 20];
        }
        if (who == 3)
        {
            RunnerImages[count].sprite = ImagesNaoko[random + 30];
        }
        if (who == 4)
        {
            RunnerImages[count].sprite = ImagesNaoko[random + 40];
        }
    }
    void showYasuko(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2255, 0);
        int random = Random.Range(0, 5);
        if (who == 10)
        {
            RunnerImages[count].sprite = ImagesYasuko[random];
        }
        if (who == 11)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 10];
        }
        if (who == 12)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 20];
        }
        if (who == 13)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 30];
        }
        //if (who == 14)
        //{
        //    RunnerImages[count].sprite = ImagesYasuko[random + 40];
        //}
    }
    void showYoshiko(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2110, 0);
        int random = Random.Range(0, 4);
        if (who == 20)
        {
            RunnerImages[count].sprite = ImagesYoshiko[random];
        }
        if (who == 21)
        {
            RunnerImages[count].sprite = ImagesYoshiko[random + 10];
        }
        if (who == 22)
        {
            RunnerImages[count].sprite = ImagesYoshiko[random + 20];
        }
        if (who == 23)
        {
            RunnerImages[count].sprite = ImagesYoshiko[random + 30];
        }
    }
    void showHideta(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2280, 0);
        int random = Random.Range(0, 3);
        if (who == 30)
        {
            RunnerImages[count].sprite = ImagesHideta[random];
        }
        if (who == 31)
        {
            RunnerImages[count].sprite = ImagesHideta[random + 10];
        }
        if (who == 32)
        {
            RunnerImages[count].sprite = ImagesHideta[random + 20];
        }
        if (who == 33)
        {
            RunnerImages[count].sprite = ImagesHideta[random + 30];
        }
        if (who == 34)
        {
            RunnerImages[count].sprite = ImagesHideta[random + 40];
        }
    }
    void showHideya(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2415, 0);
        int random = Random.Range(0, 4);
        if (who == 40)
        {
            RunnerImages[count].sprite = ImagesHideya[random];
        }
        if (who == 41)
        {
            RunnerImages[count].sprite = ImagesHideya[random + 10];
        }
        if (who == 42)
        {
            RunnerImages[count].sprite = ImagesHideya[random + 20];
        }
        if (who == 43)
        {
            RunnerImages[count].sprite = ImagesHideya[random + 30];
        }
        if (who == 44)
        {
            RunnerImages[count].sprite = ImagesHideya[random + 40];
        }
    }
    void showYasuo(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2365, 0);
        int random = Random.Range(0, 3);
        if (who == 50)
        {
            RunnerImages[count].sprite = ImagesYasuo[random];
        }
        if (who == 51)
        {
            RunnerImages[count].sprite = ImagesYasuo[random + 10];
        }
        if (who == 52)
        {
            RunnerImages[count].sprite = ImagesYasuo[random + 20];
        }
        if (who == 53)
        {
            RunnerImages[count].sprite = ImagesYasuo[random + 30];
        }
    }


    /// <summary>
    /// ランナーの移動速度
    /// </summary>
    [SerializeField] private float speed;

    void Update()
    {
        //「第n幕」をフェードアウトさせる処理
        if (fadeFlg == 1)
        {
            Color colorMaku = dainmaku[makuCount-1].GetComponent<Image>().color;
            colorMaku.a -= 0.02f;
            dainmaku[makuCount-1].GetComponent<Image>().color = colorMaku;
            if (colorMaku.a <= 0) {
                fadeFlg = 0;
                dainmaku[makuCount-1].SetActive(false);
                colorMaku.a = 1;
                dainmaku[makuCount-1].GetComponent<Image>().color = colorMaku;
            }
            if (0.8f <= colorMaku.a && colorMaku.a <= 0.9f)
            {
                moveFlg = 1;
            }
        }

        //ランナーたちを右から左へ動かす処理(moveFlg==1の時のみ動く)
        if (moveFlg == 1)
        {
            Runners.position -= new Vector3(speed, 0, 0);
            if (Runners.position.x <= -6420) {
                Runners.position = new Vector3(1480, 720, 0);
                moveFlg = 0;
                Result();
            }
        }

        //「-next-」を点滅させる処理
        Color colorNext = nextT.GetComponent<Image>().color;
        //nextT.GetComponent<Image>().color = colorNext;
        if (tenmetsuFlg == 0)
        {
            colorNext.a -= 0.02f;
            nextT.GetComponent<Image>().color = colorNext;
        }
        else if (tenmetsuFlg == 1)
        {
            colorNext.a += 0.02f;
            nextT.GetComponent<Image>().color = colorNext;
        }
        if (colorNext.a < 0) 
        {
            tenmetsuFlg = 1;
        }
        else if (colorNext.a > 1)
        {
            tenmetsuFlg = 0;
        }

        //第n幕をスライドさせる処理
        if (moveNmakuFlg == 1) {
            Debug.Log("move.position.y=" + move.position.y);
            move.position += new Vector3(speed+40, 0, 0);
            if (move.position.x >= 2700) {
                Debug.Log(move.position.x);
                moveNmakuFlg = 0;
                //幕ごとの評価表示
                switch (AkagonohateData.runwayRes[makuCount - 1])
                {
                    //テスト用処理START
                    case 0:
                        yu.SetActive(true);
                        ryo.SetActive(false);
                        ka.SetActive(false);
                        break;
                    //テスト用処理END
                    case 1:
                        yu.SetActive(true);
                        ryo.SetActive(false);
                        ka.SetActive(false);
                        break;
                    case 2:
                        yu.SetActive(false);
                        ryo.SetActive(true);
                        ka.SetActive(false);
                        break;
                    case 3:
                        yu.SetActive(false);
                        ryo.SetActive(false);
                        ka.SetActive(true);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 第n幕フェードアウト前に1秒待つだけの処理
    /// </summary>
    void wait() {
        fadeFlg = 1;
    }

    private AkagonohateData akagoData;

    /// <summary>
    /// 結果表示処理
    /// </summary>
    private void Result()
    {
        moveNmakuFlg = 1;

        //オブジェクトの表示
        nextBtn.SetActive(true);
        res.SetActive(true);

        yu.SetActive(false);
        ryo.SetActive(false);
        ka.SetActive(false);
        //幕ごとの評価表示
        //switch (AkagonohateData.runwayRes[makuCount-1])
        //{
        //    case 1:
        //        yu.SetActive(true);
        //        ryo.SetActive(false);
        //        ka.SetActive(false); 
        //        break;
        //    case 2:
        //        yu.SetActive(false);
        //        ryo.SetActive(true);
        //        ka.SetActive(false); 
        //        break;
        //    case 3:
        //        yu.SetActive(false);
        //        ryo.SetActive(false);
        //        ka.SetActive(true); 
        //        break;
        //}

        //評定テキストの書き換え
        hyouteiT.text = ("第" + makuCount + "幕評定");

        //キャラ画像の差し替え
        RunnerRes.GetComponent<RectTransform>();
        int kyara = AkagonohateData.runwayMVP[makuCount - 1]/10;
        switch (kyara)
        {
            case 0: RunnerRes.rectTransform.sizeDelta = new Vector3(1800, 2230, 0); break;
            case 1: RunnerRes.rectTransform.sizeDelta = new Vector3(1800, 2255, 0); break;
            case 2: RunnerRes.rectTransform.sizeDelta = new Vector3(1800, 2110, 0); break;
            case 3: RunnerRes.rectTransform.sizeDelta = new Vector3(1800, 2280, 0); break;
            case 4: RunnerRes.rectTransform.sizeDelta = new Vector3(1800, 2415, 0); break;
            case 5: RunnerRes.rectTransform.sizeDelta = new Vector3(1800, 2365, 0); break;
        }
        //被り物などで個別処理あれば以下に追記

        //Debug.Log("AkagonohateData.runwayMVP[makuCount - 1] = " + AkagonohateData.runwayMVP[makuCount - 1]);
        if (AkagonohateData.runwayMVP[makuCount - 1] == -1)
        {
            resRunnerImages.SetActive(false);
        }
        else
        {
            resRunnerImages.SetActive(true);
            RunnerRes.sprite = ResRunnerImages[AkagonohateData.runwayMVP[makuCount - 1]];
        }
    }
    public void next() {
        if (makuCount == 3)
        {
            SceneManager.LoadScene("12RunwayRes");
        }
        else {
            move.position = new Vector3(1480, 720, 0);
            //オブジェクトの表示
            nextBtn.SetActive(false);
            res.SetActive(false);
            nextBtn.SetActive(false);
            makuStart();
        }
    }
}
