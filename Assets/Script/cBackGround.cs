using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cBackGround : MonoBehaviour
{
    void Start()
    {
        //�{�ԗp����(�e�X�g���̓R�����g�A�E�g)START
        //SceneManager.LoadScene("01Title", LoadSceneMode.Additive);
        //�{�ԗp����(�e�X�g���̓R�����g�A�E�g)END
    }

    void Update()
    {
        //���ݎ������펞�擾
        AkagonohateData.now = DateTime.Now;
    }
}
