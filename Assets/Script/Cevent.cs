using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cevent : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject hosyuIchiranPopUp;
    [SerializeField] Text jyouiNpre;
    [SerializeField] Text nowPt;
    [SerializeField] Text[] playerNames;
    [SerializeField] Text[] playerPts;
    [SerializeField] GameObject[] pertnerImages1;
    [SerializeField] GameObject[] pertnerImages2;
    [SerializeField] GameObject[] pertnerImages3;
    [SerializeField] GameObject[] pertnerImages4;
    [SerializeField] GameObject[] pertnerImages5;

    void Start()
    {
        //右のパートナー画像の初期化
        for (int i = 0; i < 60; i++) {
            pertnerImages1[i].SetActive(false);
            pertnerImages2[i].SetActive(false);
            pertnerImages3[i].SetActive(false);
            pertnerImages4[i].SetActive(false);
            pertnerImages5[i].SetActive(false);
        }


    }

    /// <summary>
    /// 報酬一覧ボタンが押されたときの処理
    /// </summary>
    public void pushHosyuIchiran() {
        hosyuIchiranPopUp.SetActive(true);
    }

    /// <summary>
    /// 報酬一覧ポップアップを閉じる処理
    /// </summary>
    public void closePopUp() {
        hosyuIchiranPopUp.SetActive(false);
    }



    void Update()
    {
        
    }
}
