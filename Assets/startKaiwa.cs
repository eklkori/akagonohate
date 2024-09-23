using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startKaiwa : MonoBehaviour
{
    public void startKaiwas()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //直子の会話遷移処理
            if (AkagonohateData.tansakuKyara == 1) {
                //会話の種類数分の値を引数内にセットして乱数取得
                int kaiwaNo = UnityEngine.Random.Range(1,3);
                if (kaiwaNo == 1) {
                    AkagonohateData.kaiwaNo = "naoko1";
                }
                if (kaiwaNo == 2)
                {
                    AkagonohateData.kaiwaNo = "naoko2";
                }
            }
            Debug.Log(AkagonohateData.kaiwaNo);
            SceneManager.LoadScene("07Kaiwa");
        }
    }

    public void startMitsugu() {
        SceneManager.LoadScene("08Mitsugu");
    }
}
