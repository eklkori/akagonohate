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
            //���q�̉�b�J�ڏ���
            if (AkagonohateData.tansakuKyara == 1) {
                //��b�̎�ސ����̒l���������ɃZ�b�g���ė����擾
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
