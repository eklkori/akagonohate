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
                AkagonohateData.kaiwaNo = "naoko";
                /*//会話の種類数分の値を引数内にセットして乱数取得
                int kaiwaNo = UnityEngine.Random.Range(1,7);
                if (kaiwaNo == 1) {
                    AkagonohateData.kaiwaNo = "naoko1";
                }
                if (kaiwaNo == 2)
                {
                    AkagonohateData.kaiwaNo = "naoko2";
                }
                if (kaiwaNo == 3)
                {
                    AkagonohateData.kaiwaNo = "naoko3";
                }
                if (kaiwaNo == 4)
                {
                    AkagonohateData.kaiwaNo = "naoko4";
                }
                if (kaiwaNo == 5)
                {
                    AkagonohateData.kaiwaNo = "naoko5";
                }
                if (kaiwaNo == 6)
                {
                    AkagonohateData.kaiwaNo = "naoko6";
                }*/
            }

                //康子の会話遷移処理
                if (AkagonohateData.tansakuKyara == 2)
            {
                //会話の種類数分の値を引数内にセットして乱数取得
                int kaiwaNo = UnityEngine.Random.Range(1, 7);
                if (kaiwaNo == 1)
                {
                    AkagonohateData.kaiwaNo = "yasuko1";
                }
                if (kaiwaNo == 2)
                {
                    AkagonohateData.kaiwaNo = "yasuko2";
                }
                if (kaiwaNo == 3)
                {
                    AkagonohateData.kaiwaNo = "yasuko3";
                }
                if (kaiwaNo == 4)
                {
                    AkagonohateData.kaiwaNo = "yasuko4";
                }
                if (kaiwaNo == 5)
                {
                    AkagonohateData.kaiwaNo = "yasuko5";
                }
                if (kaiwaNo == 6)
                {
                    AkagonohateData.kaiwaNo = "yasuko6";
                }
            }

            //吉子の会話遷移処理
            if (AkagonohateData.tansakuKyara == 3)
            {
                //会話の種類数分の値を引数内にセットして乱数取得
                int kaiwaNo = UnityEngine.Random.Range(1, 8);
                if (kaiwaNo == 1)
                {
                    AkagonohateData.kaiwaNo = "yoshiko1";
                }
                if (kaiwaNo == 2)
                {
                    AkagonohateData.kaiwaNo = "yoshiko2";
                }
                if (kaiwaNo == 3)
                {
                    AkagonohateData.kaiwaNo = "yoshiko3";
                }
                if (kaiwaNo == 4)
                {
                    AkagonohateData.kaiwaNo = "yoshiko4";
                }
                if (kaiwaNo == 5)
                {
                    AkagonohateData.kaiwaNo = "yoshiko5";
                }
                if (kaiwaNo == 6)
                {
                    AkagonohateData.kaiwaNo = "yoshiko6";
                }
                if (kaiwaNo == 6)
                {
                    AkagonohateData.kaiwaNo = "yoshiko7";
                }
            }

            //秀太の会話遷移処理
            if (AkagonohateData.tansakuKyara == 4)
            {
                //会話の種類数分の値を引数内にセットして乱数取得
                int kaiwaNo = UnityEngine.Random.Range(1, 6);
                if (kaiwaNo == 1)
                {
                    AkagonohateData.kaiwaNo = "hideta1";
                }
                if (kaiwaNo == 2)
                {
                    AkagonohateData.kaiwaNo = "hideta2";
                }
                if (kaiwaNo == 3)
                {
                    AkagonohateData.kaiwaNo = "hideta3";
                }
                if (kaiwaNo == 4)
                {
                    AkagonohateData.kaiwaNo = "hideta4";
                }
                if (kaiwaNo == 5)
                {
                    AkagonohateData.kaiwaNo = "hideta5";
                }
            }

            //秀也の会話遷移処理
            if (AkagonohateData.tansakuKyara == 5)
            {
                //会話の種類数分の値を引数内にセットして乱数取得
                int kaiwaNo = UnityEngine.Random.Range(1, 7);
                if (kaiwaNo == 1)
                {
                    AkagonohateData.kaiwaNo = "hideya1";
                }
                if (kaiwaNo == 2)
                {
                    AkagonohateData.kaiwaNo = "hideya2";
                }
                if (kaiwaNo == 3)
                {
                    AkagonohateData.kaiwaNo = "hideya3";
                }
                if (kaiwaNo == 4)
                {
                    AkagonohateData.kaiwaNo = "hideya4";
                }
                if (kaiwaNo == 5)
                {
                    AkagonohateData.kaiwaNo = "hideya5";
                }
                if (kaiwaNo == 6)
                {
                    AkagonohateData.kaiwaNo = "hideya6";
                }
            }

            //康男の会話遷移処理
            if (AkagonohateData.tansakuKyara == 6)
            {
                //会話の種類数分の値を引数内にセットして乱数取得
                int kaiwaNo = UnityEngine.Random.Range(1, 6);
                if (kaiwaNo == 1)
                {
                    AkagonohateData.kaiwaNo = "yasuo1";
                }
                if (kaiwaNo == 2)
                {
                    AkagonohateData.kaiwaNo = "yasuo2";
                }
                if (kaiwaNo == 3)
                {
                    AkagonohateData.kaiwaNo = "yasuo3";
                }
                if (kaiwaNo == 4)
                {
                    AkagonohateData.kaiwaNo = "yasuo4";
                }
                if (kaiwaNo == 5)
                {
                    AkagonohateData.kaiwaNo = "yasuo5";
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
