using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;
using UtageExtensions;

public class Gamenseni : MonoBehaviour
{
    /// <summary>
    /// �t���[�����[�g��60�ɌŒ�
    /// </summary>
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
 
    /// <summary>
    /// �^�C�g����ʂ���̑J��
    /// </summary>
    public void startGame()
    {

        if (AkagonohateData.tutorealFlg == 0)
        {
            for (int i = 0; i < 24; i++) {
                AkagonohateData.runner[i] = -1;
            }
        //SceneManager.LoadScene("02Kiyaku");
        Debug.Log("��");
        SceneManager.LoadScene("02Kiyaku", LoadSceneMode.Additive);
        Debug.Log("��");
        }
        else
        {
            SceneManager.LoadScene("05Home", LoadSceneMode.Additive);
        }
        deleteNowScene();
        Debug.Log("��");
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
    /// <summary>
    /// ���p�K�񁨖��O�ݒ�ւ̑J��
    /// </summary>
    public void GoNaming()
    {
        SceneManager.LoadScene("03Naming", LoadSceneMode.Additive);
        deleteNowScene();
    }


    /// <summary>
    /// ���O�ݒ聨�S�̃`���[�g���A���ւ̑J��
    /// </summary>
    public void goTutorial()
    {
        SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// �T����ʂւ̑J��
    /// </summary>
    public void goTansaku()
    {
        Debug.Log("tansaku");
        SceneManager.LoadScene("06Tansaku", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// �����E�F�C������ʂւ̑J��
    /// </summary>
    public void goRunwaySet()
    {
        SceneManager.LoadScene("10RunwaySet", LoadSceneMode.Additive);
        Debug.Log("runway");
        deleteNowScene();
    }

    /// <summary>
    /// �^�X�N��ʂւ̑J��
    /// </summary>
    public void goTask()
    {
        SceneManager.LoadScene("19Task", LoadSceneMode.Additive);
        Debug.Log("task");
        deleteNowScene();
    }

    /// <summary>
    /// �������B��ʂւ̑J��
    /// </summary>
    public void goBusshi()
    {
        if (AkagonohateData.busshiSyokaiFlg == 0)
        {
            SceneManager.LoadScene("04Tutorial", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("13Busshi", LoadSceneMode.Additive);
        }
        deleteNowScene();
    }

    /// <summary>
    /// �e���x�m�F��ʂւ̑J��
    /// </summary>
    public void goShinaido()
    {
        Debug.Log("shinaido");
        SceneManager.LoadScene("16Shinaido1", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// �e���x�m�F���2�ւ̑J��
    /// </summary>
    public void goShinaido2()
    {
        SceneManager.LoadScene("17Shinaido2", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// �e���x�m�F���3�ւ̑J��
    /// </summary>
    public void goShinaido3()
    {
        SceneManager.LoadScene("18Shinaido3", LoadSceneMode.Additive);
        deleteNowScene();
    }

    /// <summary>
    /// �z�[����ʂւ̑J�ځ@���߂�{�^���Ȃǁ@���Q�[���N������̑J�ڂ͕ʃ��\�b�h�ŏ���
    /// </summary>
    public void modoru()
    {
        SceneManager.LoadScene(AkagonohateData.maeScene, LoadSceneMode.Additive);
        deleteNowScene();
    }


    void deleteNowScene() {
        string sceneName = "";
        //���ݓǂݍ��܂�Ă���V�[�����������[�v
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        {
            //�ǂݍ��܂�Ă���V�[�����擾���A���̖��O�����O�ɕ\��
            string sceneName2 = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;
            Debug.Log(sceneName2);

            if (i==1) {
                sceneName = sceneName2;
                break;
            }
        }

        //���ݕ\�����̃V�[�������擾
        AkagonohateData.maeScene = sceneName;

        //�A�����[�h����
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
