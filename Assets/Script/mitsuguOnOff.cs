using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utage;

public class mitsuguOnOff : MonoBehaviour
{
    //�v����ʁ@�m��{�^�������O���UI�\��/��\���؂�ւ�
    //�f�ނ̒�`
    [SerializeField] GameObject mitsuguItem;
    [SerializeField] GameObject itemBase;
    [SerializeField] GameObject modoru;
    [SerializeField] GameObject kakutei;
    [SerializeField] GameObject naniwoT;
    [SerializeField] GameObject underBg;


    public void mitsuguOff()
    {
        mitsuguItem.SetActive(false);
        itemBase.SetActive(false);
        modoru.SetActive(false);
        kakutei.SetActive(false);
        naniwoT.SetActive(false);
        underBg.SetActive(false);
    }

    //�v���I����̏���
    public AdvEngine engine;
    void Update()
    {
        //AdvEngine�̏�����
        if (!engine.Param.IsInit) return;

        //�p�����[�^�[�̌Ăяo��
        int mitsuguEnd = engine.Param.GetParameterInt("mitsuguEnd");

        if (mitsuguEnd == 1)
        {
            SceneManager.LoadScene("06Tansaku");
        }
    }
}
