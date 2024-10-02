using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;

public class mitsuguOnOff : MonoBehaviour
{
    //貢ぐ画面　確定ボタン押下前後のUI表示/非表示切り替え
    //素材の定義
    [SerializeField] GameObject mitsuguItem;
    [SerializeField] GameObject itemBase;
    [SerializeField] GameObject modoru;
    [SerializeField] GameObject kakutei;
    [SerializeField] GameObject naniwoT;
    [SerializeField] GameObject underBg;


    public void mitsuguOff()
    {
        mitsuguItem.SetActive(false);
        itemBase.SetActive(false);
        modoru.SetActive(false);
        kakutei.SetActive(false);
        naniwoT.SetActive(false);
        underBg.SetActive(false);
    }

    //貢ぐ終了後の処理
    public AdvEngine engine;
    void Update()
    {
        //AdvEngineの初期化
        if (!engine.Param.IsInit) return;

        //パラメーターの呼び出し
        int mitsuguEnd = engine.Param.GetParameterInt("mitsuguEnd");

        if (mitsuguEnd == 1)
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }
}
