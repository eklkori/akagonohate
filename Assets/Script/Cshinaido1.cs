using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cshinaido1 : MonoBehaviour
{
    [SerializeField] Text[] shinaiLv;
    private void Start()
    {
        //戻るボタンの遷移先を操作
        AkagonohateData.maeScene = "05Home";

        //キャラの親愛Lv表示
        for (int i = 0; i < shinaiLv.Length; i++)
        {
            shinaiLv[i].text = AkagonohateData.shinaiLv[i].ToString();
        }
    }

    /// <summary>
    /// 親愛度確認画面②(キャラ詳細確認画面)への遷移処理
    /// </summary>
    public void goShinaido2(int num)
    {
        AkagonohateData.shinaidoWho = num;

    //public void goShinaido2_2()
    //{
    //    AkagonohateData.shinaidoWho = 2;
    //    kyoutsu();
    //}
    //public void goShinaido2_3()
    //{
    //    AkagonohateData.shinaidoWho = 3;
    //    kyoutsu();
    //}
    //public void goShinaido2_4()
    //{
    //    AkagonohateData.shinaidoWho = 4;
    //    kyoutsu();
    //}
    //public void goShinaido2_5()
    //{
    //    AkagonohateData.shinaidoWho = 5;
    //    kyoutsu();
    //}
    //public void goShinaido2_6()
    //{
    //    AkagonohateData.shinaidoWho = 6;
    //    kyoutsu();
    //}

    /// <summary>
    /// 共通処理(親愛度確認画面2へ遷移)
    /// </summary>

        SceneManager.LoadScene("17Shinaido2", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("16Shinaido1");
    }
}
