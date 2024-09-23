using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UtageExtensions;

public class Gamenseni : MonoBehaviour
{
    /// <summary>
    /// �^�C�g����ʂ���̑J��
    /// </summary>
    public void startGame()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (AkagonohateData.tutorealFlg == 0)
            {
                AkagonohateData.tutorealFlg = 1;
                SceneManager.LoadScene("02Kiyaku");
            }
            else
            {
                SceneManager.LoadScene("05Home");
            }
        }
    }

    /// <summary>
    /// ���p�K�񁨖��O�ݒ�ւ̑J��
    /// </summary>
    public void GoNaming()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("03Naming");
        }
    }


    /// <summary>
    /// ���O�ݒ聨�S�̃`���[�g���A���ւ̑J��
    /// </summary>
    public void goTutorial()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("04Tutorial");
        }
    }

    /// <summary>
    /// �T����ʂւ̑J��
    /// </summary>
    public void goTansaku()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }

    /// <summary>
    /// �����E�F�C������ʂւ̑J��
    /// </summary>
    public void goRunwaySet()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("10RunwaySet");
        }
    }

    /// <summary>
    /// �^�X�N��ʂւ̑J��
    /// </summary>
    public void goTask()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("XXTask");
        }
    }

    /// <summary>
    /// �������B��ʂւ̑J��
    /// </summary>
    public void goBusshi()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("XXBusshi");
        }
    }

    /// <summary>
    /// �e���x�m�F��ʂւ̑J��
    /// </summary>
    public void goShinaido()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("XXShinaido");
        }
    }

    /// <summary>
    /// �z�[����ʂւ̑J�ځ@���߂�{�^���Ȃǁ@���Q�[���N������̑J�ڂ͕ʃ��\�b�h�ŏ���
    /// </summary>
    public void modoru()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("05Home");
        }
    }
}
