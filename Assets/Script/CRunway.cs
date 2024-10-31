using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CRunway : MonoBehaviour
{
    [SerializeField] GameObject[] bg;
    [SerializeField] GameObject nextBtn;
    [SerializeField] GameObject[] dainmaku;
    [SerializeField] GameObject[] runners;

    public RectTransform Runners;
    [SerializeField] Image[] RunnerImages;

    //フォルダ内の画像(スプライト)を配列化
    [SerializeField] Sprite[] ImagesNaoko;
    [SerializeField] Sprite[] ImagesYasuko;
    [SerializeField] Sprite[] ImagesYoshiko;
    [SerializeField] Sprite[] ImagesHideta;
    [SerializeField] Sprite[] ImagesHideya;
    [SerializeField] Sprite[] ImagesYasuo;
    [SerializeField] Sprite[] ResRunnerImages;

    int makuCount = 0;
    int moveFlg = 0;
    int fadeFlg = 0;

    /// <summary>
    /// ランウェイ開始時の処理(第一幕のみ)
    /// </summary>
    void Start()
    {
        /// <summary>
        /// ランナー画像差し替えテスト用
        /// </summary>
        int forCount = 0;
        int ten = 0;
        for (int i = 0; i < 24; i++)
        {
            if (forCount == 4) {
                forCount = 0;
                ten++;
            }
            AkagonohateData.runner[i] = ten * 10 + forCount;
            forCount++;
        }
        //テスト用処理END

        nextBtn.SetActive(false);

        int basyo = AkagonohateData.basyo;
        switch (basyo) {
            case 1: bg[0].SetActive(true);break;
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

        int count = 0;
        for (int i = 0; i < 8; i++) {
    　　    count++;

            //②ランナー衣装Noを取得
            int who = AkagonohateData.runner[kakunin[i]];

            //③キャラ個別の処理(メソッド「void showXX(int count,int who)」で実施)
            //※画像差し替え・画像サイズ調整を実施
            if (who == -1)
            {
                runners[i].SetActive(false);
            }
            else {
                runners[i].SetActive(true);
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
            RunnerImages[count].sprite = ImagesYasuko[random];
        }
        if (who == 21)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 10];
        }
        if (who == 22)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 20];
        }
        if (who == 23)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 30];
        }
    }
    void showHideta(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2280, 0);
        int random = Random.Range(0, 3);
        if (who == 30)
        {
            RunnerImages[count].sprite = ImagesYasuko[random];
        }
        if (who == 31)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 10];
        }
        if (who == 32)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 20];
        }
        if (who == 33)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 30];
        }
        if (who == 34)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 40];
        }
    }
    void showHideya(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2415, 0);
        int random = Random.Range(0, 4);
        if (who == 40)
        {
            RunnerImages[count].sprite = ImagesYasuko[random];
        }
        if (who == 41)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 10];
        }
        if (who == 42)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 20];
        }
        if (who == 43)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 30];
        }
        if (who == 44)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 40];
        }
    }
    void showYasuo(int count, int who)
    {
        RunnerImages[count].GetComponent<RectTransform>();
        RunnerImages[count].rectTransform.sizeDelta = new Vector3(1800, 2365, 0);
        int random = Random.Range(0, 3);
        if (who == 50)
        {
            RunnerImages[count].sprite = ImagesYasuko[random];
        }
        if (who == 51)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 10];
        }
        if (who == 52)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 20];
        }
        if (who == 53)
        {
            RunnerImages[count].sprite = ImagesYasuko[random + 30];
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
            Color color = dainmaku[makuCount-1].GetComponent<Image>().color;
            //-= new Color(0, 0, 0, 0.01f);
            color.a -= 0.01f;
            dainmaku[makuCount-1].GetComponent<Image>().color = color;
            Debug.Log(color.a);
            if (color.a <= 0) {
                fadeFlg = 0;
                dainmaku[makuCount-1].SetActive(false);
                color.a = 1;
                dainmaku[makuCount-1].GetComponent<Image>().color = color;
            }
            if (0.6f <= color.a && color.a <= 0.7f)
            {
                moveFlg = 1;
            }
            Debug.Log(fadeFlg);
        }

        //ランナーたちを右から左へ動かす処理(moveFlg==1の時のみ動く)
        if (moveFlg == 1)
        {
            Runners.position -= new Vector3(speed, 0, 0);
            if (Runners.position.x <= -5420) {
                Runners.position = new Vector3(1480, 720, 0);
                moveFlg = 0;
                Result();
            }
        }
    }

    /// <summary>
    /// 第n幕フェードアウト前に1秒待つだけの処理
    /// </summary>
    void wait() {
        fadeFlg = 1;
    }

    /// <summary>
    /// 結果表示処理
    /// </summary>
    private void Result()
    {
        nextBtn.SetActive(true);
    }
    public void next() {
        if (makuCount == 3)
        {
            SceneManager.LoadScene("12RunwayRes");
        }
        else {
            makuStart();
        }
    }
}
