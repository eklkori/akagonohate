using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goGacha : MonoBehaviour
{
    /// <summary>
    /// �K�`���f�[�^�Z�b�g�p�̗����擾
    /// </summary>
    int ransusyutoku() {
        int res = 0;
        int rare = Random.Range(1, 1000);
        //���A�x1�̕���
        if (1 <= rare && rare <= 700) {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 <= 1)
                {
                    break;
                }
            }
        }
        //���A�x2�̕���
        if (701 <= rare && rare <= 900)
        {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 == 2 || res % 10 == 3)
                {
                    break;
                }
            }
        }
        //���A�x3�̕���
        if (901 <= rare && rare < 1000)
        {
            while (true)
            {
                res = Random.Range(1, 55);
                if (res % 10 == 4)
                {
                    break;
                }
            }
        }
        return res;
    }

    /// <summary>
    /// �P���K�`���{�^���������̏���
    /// </summary>
    public void goGacha1()
    {
        int res = ransusyutoku();
        AkagonohateData.isyoSyojiFlg[res] = 1;
        AkagonohateData.gacha10[0] = res;
        AkagonohateData.gachaFlg = 1;
        SceneManager.LoadScene("14Gacha");
    }

    /// <summary>
    /// 10�A�K�`���{�^���������̏���
    /// </summary>
    public void goGacha10()
    {
        for(int i = 0; i < 10; i++)
        {
            int res = ransusyutoku();
            AkagonohateData.isyoSyojiFlg[res] = 1;
            AkagonohateData.gacha10[i] = res;
        }
        AkagonohateData.gachaFlg = 2;
        SceneManager.LoadScene("14Gacha");
    }
}
