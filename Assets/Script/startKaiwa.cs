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
            //’¼q‚Ì‰ï˜b‘JˆÚˆ—
            if (AkagonohateData.tansakuKyara == 1) {
                AkagonohateData.kaiwaNo = "naokoK";
            }

                //Nq‚Ì‰ï˜b‘JˆÚˆ—
                if (AkagonohateData.tansakuKyara == 2)
            {
                AkagonohateData.kaiwaNo = "yasukoK";
            }

            //‹gq‚Ì‰ï˜b‘JˆÚˆ—
            if (AkagonohateData.tansakuKyara == 3)
            {
                AkagonohateData.kaiwaNo = "yoshikoK";
            }

            //G‘¾‚Ì‰ï˜b‘JˆÚˆ—
            if (AkagonohateData.tansakuKyara == 4)
            {
                AkagonohateData.kaiwaNo = "hidetaK";
            }

            //G–ç‚Ì‰ï˜b‘JˆÚˆ—
            if (AkagonohateData.tansakuKyara == 5)
            {
                AkagonohateData.kaiwaNo = "hideyaK";
            }

            //N’j‚Ì‰ï˜b‘JˆÚˆ—
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
