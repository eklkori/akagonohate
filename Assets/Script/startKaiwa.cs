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
                AkagonohateData.kaiwaNo = "naokoK";
            }

                //康子の会話遷移処理
                if (AkagonohateData.tansakuKyara == 2)
            {
                AkagonohateData.kaiwaNo = "yasukoK";
            }

            //吉子の会話遷移処理
            if (AkagonohateData.tansakuKyara == 3)
            {
                AkagonohateData.kaiwaNo = "yoshikoK";
            }

            //秀太の会話遷移処理
            if (AkagonohateData.tansakuKyara == 4)
            {
                AkagonohateData.kaiwaNo = "hidetaK";
            }

            //秀也の会話遷移処理
            if (AkagonohateData.tansakuKyara == 5)
            {
                AkagonohateData.kaiwaNo = "hideyaK";
            }

            //康男の会話遷移処理
            if (AkagonohateData.tansakuKyara == 6)
            {
                AkagonohateData.kaiwaNo = "yasuoK";
            }
            Debug.Log(AkagonohateData.kaiwaNo);
            SceneManager.LoadScene("04Tutorial");
        }
    }

    public void startMitsugu() {
        SceneManager.LoadScene("08Mitsugu");
    }
}
