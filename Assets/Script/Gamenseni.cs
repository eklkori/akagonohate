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
                AkagonohateData.tutorealFlg = 1;
                SceneManager.LoadScene("02Kiyaku");
            }
            else
            {
                SceneManager.LoadScene("05Home");
            }
        }
    }

    /// <summary>
    /// 利用規約→名前設定への遷移
    /// </summary>
    public void GoNaming()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("03Naming");
        }
    }


    /// <summary>
    /// 名前設定→全体チュートリアルへの遷移
    /// </summary>
    public void goTutorial()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("04Tutorial");
        }
    }

    /// <summary>
    /// 探索画面への遷移
    /// </summary>
    public void goTansaku()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }

    /// <summary>
    /// ランウェイ準備画面への遷移
    /// </summary>
    public void goRunwaySet()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("10RunwaySet");
        }
    }

    /// <summary>
    /// タスク画面への遷移
    /// </summary>
    public void goTask()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("XXTask");
        }
    }

    /// <summary>
    /// 物資調達画面への遷移
    /// </summary>
    public void goBusshi()
    {
        if (AkagonohateData.tutorealFlgB==0)
        {
            //チュートリアル遷移用処理
        }
        else
        {
            SceneManager.LoadScene("13Busshi");
        }
        SceneManager.LoadScene("13Busshi");
    }

    /// <summary>
    /// 親愛度確認画面への遷移
    /// </summary>
    public void goShinaido()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("XXShinaido");
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
