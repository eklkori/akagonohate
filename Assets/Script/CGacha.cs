using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGacha : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] GameObject haikei1;
    [SerializeField] GameObject haikei2;
    [SerializeField] GameObject haikei3;
    [SerializeField] GameObject hoshi1;
    [SerializeField] GameObject hoshi2;
    [SerializeField] GameObject hoshi3;
    public Text isyouName;

    //キャラ立ち絵の定義(キャラを増やしたときに随時追加)
    [SerializeField] GameObject[] kyaras;
    //[SerializeField] GameObject naoko01W;
    //[SerializeField] GameObject naoko01S;
    //[SerializeField] GameObject naoko02W;
    //[SerializeField] GameObject naoko02S;
    //[SerializeField] GameObject naoko03furisode;
    //[SerializeField] GameObject yasuko01W;
    //[SerializeField] GameObject yasuko01S;
    //[SerializeField] GameObject yasuko02W;
    //[SerializeField] GameObject yasuko02S;
    //[SerializeField] GameObject yasuko03XX;
    //[SerializeField] GameObject yoshiko01W;
    //[SerializeField] GameObject yoshiko01S;
    //[SerializeField] GameObject yoshiko02W;
    //[SerializeField] GameObject yoshiko02S;
    //[SerializeField] GameObject yoshiko03XX;
    //[SerializeField] GameObject hideta01W;
    //[SerializeField] GameObject hideta01S;
    //[SerializeField] GameObject hideta02W;
    //[SerializeField] GameObject hideta02S;
    //[SerializeField] GameObject hideta03syougatsu1;
    //[SerializeField] GameObject hideya01W;
    //[SerializeField] GameObject hideya01S;
    //[SerializeField] GameObject hideya02W;
    //[SerializeField] GameObject hideya02S;
    //[SerializeField] GameObject hideya03syougatsu1;
    //[SerializeField] GameObject yasuo01W;
    //[SerializeField] GameObject yasuo01S;
    //[SerializeField] GameObject yasuo02W;
    //[SerializeField] GameObject yasuo02S;
    //[SerializeField] GameObject yasuo03XX;
    //キャラ名テキスト
    [SerializeField] GameObject[] kyaraNames;
    [SerializeField] GameObject[] kyaraNamesBg;
    //[SerializeField] GameObject naokoT;
    //[SerializeField] GameObject yasukoT;
    //[SerializeField] GameObject yoshikoT;
    //[SerializeField] GameObject hidetaT;
    //[SerializeField] GameObject hideyaT;
    //[SerializeField] GameObject yasuoT;

    int goResFlg = 0;
    void Start()
    {
        Debug.Log(AkagonohateData.gachaFlg);
        btn.onClick.Invoke();
        if (AkagonohateData.gachaFlg == 1) {
            Invoke("goGachaRes", 0.5f);
        }
    }

    int count = 0;
    public void gachaTap()
    {
        if (goResFlg == 0)
        {
            int hyouji = AkagonohateData.gacha10[count];
            Debug.Log(hyouji);

            //レア度の違いによるUI表示制御
            if (hyouji % 10 <= 1)
            {
                haikei1.SetActive(true);
                haikei2.SetActive(false);
                haikei3.SetActive(false);
                hoshi1.SetActive(true);
                hoshi2.SetActive(false);
                hoshi3.SetActive(false);
                if (hyouji % 10 == 0)
                {
                    isyouName.text = ("通常・冬");
                }
                else
                {
                    isyouName.text = ("通常・夏");
                }
            }
            if (hyouji % 10 == 2 || hyouji % 10 == 3)
            {
                haikei1.SetActive(false);
                haikei2.SetActive(true);
                haikei3.SetActive(false);
                hoshi1.SetActive(false);
                hoshi2.SetActive(true);
                hoshi3.SetActive(false);
                if (hyouji % 10 == 2)
                {
                    isyouName.text = ("私服・冬");
                }
                else
                {
                    isyouName.text = ("私服・夏");
                }
            }
            if (hyouji % 10 >= 4)
            {
                haikei1.SetActive(false);
                haikei2.SetActive(false);
                haikei3.SetActive(true);
                hoshi1.SetActive(false);
                hoshi2.SetActive(false);
                hoshi3.SetActive(true);
            }

            //キャラ表示の初期化
            for (int i = 0; i < 60; i++) {
                kyaras[i].SetActive(false);
            }

            //キャラ名表示の初期化
            for (int i = 0; i < 6; i++) {
                kyaraNames[i].SetActive(false);
            }

            //キャラ名背景表示の初期化
            for (int i = 0; i < 6; i++)
            {
                kyaraNamesBg[i].SetActive(false);
            }

            //キャラの違いによるキャラ名・名前背景の表示制御
            int who = hyouji / 10;
            kyaraNames[who].SetActive(true);
            kyaraNamesBg[who].SetActive(true);
            Debug.Log("who=" + who);

            //キャラの違いによる立ち絵表示制御
            kyaras[hyouji].SetActive(true);
            

            //次にボタンが押されたときの挙動を制御
            if (count == 9)
            {
                Invoke("goGachaRes", 0.1f);
            }
            else
            {
                count++;
            }
        }
    }

    /// <summary>
    /// ガチャ結果画面への遷移(シーンの最後に実施)
    /// </summary>
    void Update() {
        if (goResFlg == 1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene("15GachaRes");
            }
        }
    }

    /// <summary>
    /// goResFlgの書き換え(時間差で実行しないと最後すぐに画面遷移してしまう)
    /// </summary>
    void goGachaRes() {
        goResFlg = 1;
        Debug.Log("goResFlg="+ goResFlg);
    }
}
