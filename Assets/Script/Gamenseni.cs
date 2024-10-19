using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UtageExtensions;

public class Gamenseni : MonoBehaviour
{
    /// <summary>
    /// タイトル画面からの遷移
    /// </summary>
    public void startGame()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (AkagonohateData.tutorealFlg == 0)
            {
                SceneManager.LoadScene("02Kiyaku");
            }
            else
            {
                SceneManager.LoadScene("05Home");
            }
        }
    }

    /// <summary>
    /// 利用規約に同意する/しないの制御
    /// </summary>
    [SerializeField] GameObject douisuruBtn;
    [SerializeField] GameObject douisuruBtnNo;
    [SerializeField] GameObject check;
    [SerializeField] int douiFlg = 0;
    public void douisuru()
    {
        //int douiFlg = 0;
        if (Input.GetMouseButtonUp(0))
        {
            if (douiFlg == 0)
            {
                douiFlg = 1;
                douisuruBtn.SetActive(true);
                douisuruBtnNo.SetActive(false);
                check.SetActive(true);
            }
            else
            {
                douiFlg = 0;
                douisuruBtn.SetActive(false);
                douisuruBtnNo.SetActive(true);
                check.SetActive(false);
            }
        }
    }
    /// <summary>
    /// 利用規約→名前設定への遷移
    /// </summary>
    public void GoNaming()
    {
            SceneManager.LoadScene("03Naming");
    }


    /// <summary>
    /// 名前設定→全体チュートリアルへの遷移
    /// </summary>
    public void goTutorial()
    {
            SceneManager.LoadScene("04Tutorial");
    }

    /// <summary>
    /// 探索画面への遷移
    /// </summary>
    public void goTansaku()
    {
            SceneManager.LoadScene("06Tansaku");
    }

    /// <summary>
    /// ランウェイ準備画面への遷移
    /// </summary>
    public void goRunwaySet()
    {
            SceneManager.LoadScene("10RunwaySet");
    }

    /// <summary>
    /// タスク画面への遷移
    /// </summary>
    public void goTask()
    {
            SceneManager.LoadScene("19Task");
    }

    /// <summary>
    /// 物資調達画面への遷移
    /// </summary>
    public void goBusshi()
    {
        if (AkagonohateData.busshiSyokaiFlg == 0)
        {
            SceneManager.LoadScene("04Tutorial");
        }
        else
        {
            SceneManager.LoadScene("13Busshi");
        }
    }

    /// <summary>
    /// 親愛度確認画面への遷移
    /// </summary>
    public void goShinaido()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("16Shinaido1");
        }
    }

    /// <summary>
    /// 親愛度確認画面2への遷移
    /// </summary>
    public void goShinaido2()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("17Shinaido2");
        }
    }

    /// <summary>
    /// 親愛度確認画面3への遷移
    /// </summary>
    public void goShinaido3()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("18Shinaido3");
        }
    }

    /// <summary>
    /// ホーム画面への遷移　※戻るボタンなど　※ゲーム起動初回の遷移は別メソッドで処理
    /// </summary>
    public void modoru()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("05Home");
        }
    }
}
