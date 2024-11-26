using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cevent : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject hosyuIchiranPopUp;
    [SerializeField] Text jyouiNpre;
    [SerializeField] Text nowPt;
    [SerializeField] Text[] playerNames;
    [SerializeField] Text[] playerPts;
    [SerializeField] GameObject[] pertnerImages1;
    [SerializeField] GameObject[] pertnerImages2;
    [SerializeField] GameObject[] pertnerImages3;
    [SerializeField] GameObject[] pertnerImages4;
    [SerializeField] GameObject[] pertnerImages5;

    void Start()
    {
        //�E�̃p�[�g�i�[�摜�̏�����
        for (int i = 0; i < 60; i++) {
            pertnerImages1[i].SetActive(false);
            pertnerImages2[i].SetActive(false);
            pertnerImages3[i].SetActive(false);
            pertnerImages4[i].SetActive(false);
            pertnerImages5[i].SetActive(false);
        }

        //�߂�{�^���̑J�ڐ�𑀍�
        AkagonohateData.maeScene = "05Home";
    }

    /// <summary>
    /// ��V�ꗗ�{�^���������ꂽ�Ƃ��̏���
    /// </summary>
    public void pushHosyuIchiran() {
        hosyuIchiranPopUp.SetActive(true);
    }

    /// <summary>
    /// ��V�ꗗ�|�b�v�A�b�v����鏈��
    /// </summary>
    public void closePopUp() {
        hosyuIchiranPopUp.SetActive(false);
    }



    void Update()
    {
        
    }
}
