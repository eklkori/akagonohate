using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UtageExtensions;

public class Gamenseni : MonoBehaviour
{
    /// <summary>
    /// フレームレートを60に固定
    /// </summary>
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
 
    /// <summary>
    /// タイトル画面からの遷移
    /// </summary>
    public void startGame()
    {

        if (AkagonohateData.tutorealFlg == 0)
        {
            for (int i = 0; i < 24; i++) {
                AkagonohateData.runner[i] = -1;
            }
        //SceneManager.LoadScene("02Kiyaku");
        Debug.Log("あ");
        SceneManager.LoadScene("02Kiyaku", LoadSceneMode.Additive);
        Debug.Log("い");
        }
        else
        {
            SceneManager.LoadScene("05Home", LoadSceneMode.Additive);
        }
        deleteNowScene();
        Debug.Log("う");
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
    /// <summary>
    /// 利用規約→名前設定への遷移
    /// </summary>
    public void GoNaming()
    {
        SceneManager.LoadScene("03Naming", LoadSceneMode.Additive);
        deleteNowScene();
    }


    /// <summary>
    /// 名前設定→全体チュートリアルへの遷移
    /// </summary>
    public void goTutorial()
    {
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// 探索画面への遷移
    /// </summary>
    public void goTansaku()
    {
        Debug.Log("tansaku");
        SceneManager.LoadScene("06Tansaku", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// ランウェイ準備画面への遷移
    /// </summary>
    public void goRunwaySet()
    {
        SceneManager.LoadScene("10RunwaySet", LoadSceneMode.Additive);
        Debug.Log("runway");
        deleteNowScene();
    }

    /// <summary>
    /// タスク画面への遷移
    /// </summary>
    public void goTask()
    {
        SceneManager.LoadScene("19Task", LoadSceneMode.Additive);
        Debug.Log("task");
        deleteNowScene();
    }

    /// <summary>
    /// 物資調達画面への遷移
    /// </summary>
    public void goBusshi()
    {
        if (AkagonohateData.busshiSyokaiFlg == 0)
        {
            SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("13Busshi", LoadSceneMode.Additive);
        }
        deleteNowScene();
    }

    /// <summary>
    /// 親愛度確認画面への遷移
    /// </summary>
    public void goShinaido()
    {
        Debug.Log("shinaido");
        SceneManager.LoadScene("16Shinaido1", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// 親愛度確認画面2への遷移
    /// </summary>
    public void goShinaido2()
    {
        SceneManager.LoadScene("17Shinaido2", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// 親愛度確認画面3への遷移
    /// </summary>
    public void goShinaido3()
    {
        SceneManager.LoadScene("18Shinaido3", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// ホーム画面への遷移　※戻るボタンなど　※ゲーム起動初回の遷移は別メソッドで処理
    /// </summary>
    public void modoru()
    {
        SceneManager.LoadScene(AkagonohateData.maeScene, LoadSceneMode.Additive);
        deleteNowScene();
    }


    void deleteNowScene() {
        string sceneName = "";
        //現在読み込まれているシーン数だけループ
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        {
            //読み込まれているシーンを取得し、その名前をログに表示
            string sceneName2 = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;
            Debug.Log(sceneName2);

            if (i==1) {
                sceneName = sceneName2;
                break;
            }
        }

        //現在表示中のシーン名を取得
        AkagonohateData.maeScene = sceneName;

        //アンロード処理
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
