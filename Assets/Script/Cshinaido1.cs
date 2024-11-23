using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cshinaido1 : MonoBehaviour
{
    public void goShinaido2_1()
    {
        AkagonohateData.shinaidoWho = 1;
        kyoutsu();
    }
    public void goShinaido2_2()
    {
        AkagonohateData.shinaidoWho = 2;
        kyoutsu();
    }
    public void goShinaido2_3()
    {
        AkagonohateData.shinaidoWho = 3;
        kyoutsu();
    }
    public void goShinaido2_4()
    {
        AkagonohateData.shinaidoWho = 4;
        kyoutsu();
    }
    public void goShinaido2_5()
    {
        AkagonohateData.shinaidoWho = 5;
        kyoutsu();
    }
    public void goShinaido2_6()
    {
        AkagonohateData.shinaidoWho = 6;
        kyoutsu();
    }

    /// <summary>
    /// 共通処理(親愛度確認画面2へ遷移)
    /// </summary>
    void kyoutsu()
    {
        SceneManager.LoadScene("17Shinaido2", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("16Shinaido1");
    }
}
