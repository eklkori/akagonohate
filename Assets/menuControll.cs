using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /// <summary>
    /// �N���W�b�g�{�^���̃t���O
    /// </summary>
    int creditFlg = 0;
    int syojidogukakuninFlg = 0;
    int riyokiyakuFlg = 0;
    int otoiawaseFlg = 0;
    /// <summary>
    /// �N���W�b�g�t���O�̕ύX
    /// </summary>
    public void creditFlgCount()
    {
        if (creditFlg == 0)
        {
            creditFlg = 1;
        }
        else if (creditFlg == 1)
        {
            creditFlg = 0;
        }
        //return creditFlg;
    }
    public void riyokiyakuCount()
    {
        if (riyokiyakuFlg == 0)
        {
            riyokiyakuFlg = 1;
        }
        else if (riyokiyakuFlg == 1)
        {
            riyokiyakuFlg = 0;
        }
        Debug.Log(riyokiyakuFlg);
        //return riyokiyakuFlg;
    }
    /*public void riyokiyakuReturn() {
        return riyokiyakuFlg;
    }*/
}
