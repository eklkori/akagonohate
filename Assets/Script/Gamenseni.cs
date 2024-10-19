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
                SceneManager.LoadScene("02Kiyaku");
            }
            else
            {
                SceneManager.LoadScene("05Home");
            }
        }
    }

    /// <summary>
    /// ���p�K��ɓ��ӂ���/���Ȃ��̐���
    /// </summary>
    [SerializeField] GameObject douisuruBtn;
    [SerializeField] GameObject douisuruBtnNo;
    [SerializeField] GameObject check;
    [SerializeField] int douiFlg = 0;
    public void douisuru()
    {
        //int douiFlg = 0;
        if (Input.GetMouseButtonUp(0))
        {
            if (douiFlg == 0)
            {
                douiFlg = 1;
                douisuruBtn.SetActive(true);
                douisuruBtnNo.SetActive(false);
                check.SetActive(true);
            }
            else
            {
                douiFlg = 0;
                douisuruBtn.SetActive(false);
                douisuruBtnNo.SetActive(true);
                check.SetActive(false);
            }
        }
    }
    /// <summary>
    /// ���p�K�񁨖��O�ݒ�ւ̑J��
    /// </summary>
    public void GoNaming()
    {
            SceneManager.LoadScene("03Naming");
    }


    /// <summary>
    /// ���O�ݒ聨�S�̃`���[�g���A���ւ̑J��
    /// </summary>
    public void goTutorial()
    {
            SceneManager.LoadScene("04Tutorial");
    }

    /// <summary>
    /// �T����ʂւ̑J��
    /// </summary>
    public void goTansaku()
    {
            SceneManager.LoadScene("06Tansaku");
    }

    /// <summary>
    /// �����E�F�C������ʂւ̑J��
    /// </summary>
    public void goRunwaySet()
    {
            SceneManager.LoadScene("10RunwaySet");
    }

    /// <summary>
    /// �^�X�N��ʂւ̑J��
    /// </summary>
    public void goTask()
    {
            SceneManager.LoadScene("19Task");
    }

    /// <summary>
    /// �������B��ʂւ̑J��
    /// </summary>
    public void goBusshi()
    {
        if (AkagonohateData.busshiSyokaiFlg == 0)
        {
            SceneManager.LoadScene("04Tutorial");
        }
        else
        {
            SceneManager.LoadScene("13Busshi");
        }
    }

    /// <summary>
    /// �e���x�m�F��ʂւ̑J��
    /// </summary>
    public void goShinaido()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("16Shinaido1");
        }
    }

    /// <summary>
    /// �e���x�m�F���2�ւ̑J��
    /// </summary>
    public void goShinaido2()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("17Shinaido2");
        }
    }

    /// <summary>
    /// �e���x�m�F���3�ւ̑J��
    /// </summary>
    public void goShinaido3()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("18Shinaido3");
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
