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
        //�߂�{�^���̑J�ڐ�𑀍�
        AkagonohateData.maeScene = "05Home";

        //�L�����̐e��Lv�\��
        for (int i = 0; i < shinaiLv.Length; i++)
        {
            shinaiLv[i].text = AkagonohateData.shinaiLv[i].ToString();
        }
    }

    /// <summary>
    /// �e���x�m�F��ʇA(�L�����ڍ׊m�F���)�ւ̑J�ڏ���
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
    /// ���ʏ���(�e���x�m�F���2�֑J��)
    /// </summary>

        SceneManager.LoadScene("17Shinaido2", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("16Shinaido1");
    }
}
