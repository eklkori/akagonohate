using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRunway : MonoBehaviour
{
    [SerializeField] GameObject okujyo;
    [SerializeField] GameObject syoten;
    [SerializeField] GameObject dobutsuen;
    [SerializeField] GameObject umi;
    [SerializeField] GameObject tanbo;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject yama;
    [SerializeField] GameObject densya;
    [SerializeField] GameObject onsen;
    [SerializeField] GameObject makus;
    [SerializeField] GameObject daiichimaku;
    [SerializeField] GameObject dainimaku;
    [SerializeField] GameObject daisanmaku;

    public RectTransform Runners;
    Image[] RunnerImages;
    [SerializeField] Image RunnerImage1;
    [SerializeField] Image RunnerImage2;
    [SerializeField] Image RunnerImage3;
    [SerializeField] Image RunnerImage4;
    [SerializeField] Image RunnerImage5;
    [SerializeField] Image RunnerImage6;
    [SerializeField] Image RunnerImage7;
    [SerializeField] Image RunnerImage8;

    //↓フォルダ内の画像(スプライト)を配列化したいのに上手くいかない、何で？
    //Sprite[] ImagesNaoko = Resources.LoadAll<Sprite>; ("04Tutorial/Resources/04Tutorial/Texture/Character/naoko");

    int makuCount = 0;
    int moveFlg = 1;

    /// <summary>
    /// ランナー画像差し替え用
    /// </summary>
    public Sprite newSprite;
    [SerializeField]private Image image1;

    /// <summary>
    /// ランウェイ開始時の処理(第一幕のみ)
    /// </summary>
    void Start()
    {
        makus.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        daiichimaku.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);

        RunnerImages = new Image[] { RunnerImage1, RunnerImage2, RunnerImage3,RunnerImage4, RunnerImage5, RunnerImage6, RunnerImage7, RunnerImage8 };
        image1 = GetComponent<Image>();


        int basyo = AkagonohateData.basyo;
        switch (basyo) {
            case 1: okujyo.SetActive(true);break;
            case 2: syoten.SetActive(true); break;
            case 3: dobutsuen.SetActive(true); break;
            case 4: umi.SetActive(true); break;
            case 5: tanbo.SetActive(true); break;
            case 6: shop.SetActive(true); break;
            case 7: yama.SetActive(true); break;
            case 8: densya.SetActive(true); break;
            case 9: onsen.SetActive(true); break;
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
            case 1: daiichimaku.SetActive(true); break;
            case 2: dainimaku.SetActive(true); break;
            case 3: daisanmaku.SetActive(true); break;
        }

        //②フェードアウトさせる処理


        //-------ランナー画像差し替え処理--------
        //①ランナーNoを設定
        int[] kakunin = { 1, 2, 3, 4, 5, 6, 7, 8 };
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
            if (who < 10) {
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
        RunnerImages[count].transform.localScale = new Vector3(1400,2227,0);
        int random = Random.Range(0,10);
        if (who == 0)
        {
            RunnerImages[count].sprite = ImagesNaoko[random];
        }
        if (who == 1)
        {
            RunnerImages[count].sprite = ImagesNaoko[random+8];
        }
        if (who == 2)
        {
            RunnerImages[count].sprite = ImagesNaoko[random + 16];
        }
        if (who == 3)
        {
            RunnerImages[count].sprite = ImagesNaoko[random + 24];
        }
        if (who == 4)
        {
            RunnerImages[count].sprite = ImagesNaoko[random + 32];
        }
    }
    void showYasuko(int count, int who)
    {

    }
    void showYoshiko(int count, int who)
    {

    }
    void showHideta(int count, int who)
    {

    }
    void showHideya(int count, int who)
    {

    }
    void showYasuo(int count, int who)
    {

    }


    /// <summary>
    /// ランナーの移動速度
    /// </summary>
    [SerializeField] private float speed;
    void Update()
    {
        //「第n幕」をフェードアウトさせる処理
        //フェードアウトされない
        makus.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.1f);
        daiichimaku.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.1f);
        Debug.Log(makus.GetComponent<SpriteRenderer>().color);

        //ランナーたちを右から左へ動かす処理(moveFlg==1の時のみ動く)
        if (moveFlg == 1)
        {
            Runners.position -= new Vector3(speed, 0, 0);
            if (Runners.position.x <= -5420) {
                Runners.position = new Vector3(1480, 0, 0);
                moveFlg = 0;
            }
        }
    }
}
