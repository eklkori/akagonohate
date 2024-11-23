using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cBackGround : MonoBehaviour
{
    void Start()
    {
        //本番用処理(テスト中はコメントアウト)START
        //SceneManager.LoadScene("01Title", LoadSceneMode.Additive);
        //本番用処理(テスト中はコメントアウト)END
    }

    void Update()
    {
        //現在時刻を常時取得
        AkagonohateData.now = DateTime.Now;
    }
}
