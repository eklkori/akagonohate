using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utage;
using UnityEngine.UI;

public class tansakuMoveDown: MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject shitaBtn;
    [SerializeField] GameObject ueBtn;
    [SerializeField] GameObject naoko_kao2;
    [SerializeField] GameObject yasuko_kao2;
    [SerializeField] GameObject yoshiko_kao2;
    [SerializeField] GameObject hideta_kao2;
    [SerializeField] GameObject hideya_kao2;
    [SerializeField] GameObject yasuo_kao2;
    [SerializeField] GameObject tapT;

    public RectTransform shitaBtnMove;
    public RectTransform ueBtnMove;
    public RectTransform CanvasMove1;
    public RectTransform CanvasMove2;
    public RectTransform naoko_kao;
    public RectTransform yoshiko_kao;
    public RectTransform yasuko_kao;
    public RectTransform hideta_kao;
    public RectTransform hideya_kao;
    public RectTransform yasuo_kao;
    public RectTransform backGround;

    [SerializeField] private float moveUIy;

    [SerializeField] int gamenFlgD = 1;

    //�㉺�{�^������p
    [SerializeField] private float moveBtn;
    int count = 0;
    int flg = 0;

    //��ʂ�TAP�_�ŗp
    int tenmetsuFlg = 0;

    public void shitaBtnOn()
    {
        if (gamenFlgD == 1)
        {
            gamenFlgD = 0;
            shitaBtn.SetActive(false);
            naoko_kao2.SetActive(false);
            yasuko_kao2.SetActive(false);
            yoshiko_kao2.SetActive(false);
            hideta_kao2.SetActive(false);
            hideya_kao2.SetActive(false);
            yasuo_kao2.SetActive(false);
        }
    }

    public void ueBtnOn()
    {
        if (gamenFlgD == 0)
        {
            gamenFlgD = 1;
            ueBtn.SetActive(false);
            naoko_kao2.SetActive(false);
            yasuko_kao2.SetActive(false);
            yoshiko_kao2.SetActive(false);
            hideta_kao2.SetActive(false);
            hideya_kao2.SetActive(false);
            yasuo_kao2.SetActive(false);
        }
    }
    /// <summary>
    /// �T����ʂ����ɓ���������
    /// </summary>
    public void Update()
    {
        //���Ɉړ����鏈��
            if (gamenFlgD == 0 && backGround.position.y <= 1475)
            {
                naoko_kao.position += new Vector3(0, moveUIy, 0);
                yoshiko_kao.position += new Vector3(0, moveUIy, 0);
                yasuko_kao.position += new Vector3(0, moveUIy, 0);
                hideta_kao.position += new Vector3(0, moveUIy, 0);
                hideya_kao.position += new Vector3(0, moveUIy, 0);
                yasuo_kao.position += new Vector3(0, moveUIy, 0);
                backGround.position += new Vector3(0, moveUIy, 0);
                Debug.Log(backGround.position.y);
            }

        if (gamenFlgD == 0 && backGround.position.y >= 1475)
        {
            ueBtn.SetActive(true);
            naoko_kao2.SetActive(true);
            yasuko_kao2.SetActive(true);
            yoshiko_kao2.SetActive(true);
            hideta_kao2.SetActive(true);
            hideya_kao2.SetActive(true);
            yasuo_kao2.SetActive(true);
        }


        //��Ɉړ����鏈��
        if (gamenFlgD == 1 && backGround.position.y >= -35)
        {
            naoko_kao.position -= new Vector3(0, moveUIy, 0);
            yoshiko_kao.position -= new Vector3(0, moveUIy, 0);
            yasuko_kao.position -= new Vector3(0, moveUIy, 0);
            hideta_kao.position -= new Vector3(0, moveUIy, 0);
            hideya_kao.position -= new Vector3(0, moveUIy, 0);
            yasuo_kao.position -= new Vector3(0, moveUIy, 0);
            backGround.position -= new Vector3(0, moveUIy, 0);
            Debug.Log(backGround.position.y);
        }

        if (gamenFlgD == 1 && backGround.position.y <= -35)
        {
            shitaBtn.SetActive(true);
            naoko_kao2.SetActive(true);
            yasuko_kao2.SetActive(true);
            yoshiko_kao2.SetActive(true);
            hideta_kao2.SetActive(true);
            hideya_kao2.SetActive(true);
            yasuo_kao2.SetActive(true);
        }

        //�{�^�����㉺�����鏈��
        //int count = 0;
        //int flg = 0;
        if (flg==0) {
            shitaBtnMove.position -= new Vector3(0,moveBtn , 0);
            ueBtnMove.position -= new Vector3(0, moveBtn, 0);
            count++;
            if (count == 35) {
                flg = 1;
            }
        }
        if (flg == 1)
        {
            shitaBtnMove.position += new Vector3(0, moveBtn, 0);
            ueBtnMove.position += new Vector3(0, moveBtn, 0);
            count--;
            if (count == 0)
            {
                flg = 0;
            }
        }

        //�u��ʂ�TAP�v��_�ł����鏈��
        Color tap = tapT.GetComponent<Image>().color;
        if (tenmetsuFlg == 0)
        {
            tap.a -= 0.02f;
            tapT.GetComponent<Image>().color = tap;
        }
        else if (tenmetsuFlg == 1)
        {
            tap.a += 0.02f;
            tapT.GetComponent<Image>().color = tap;
        }
        if (tap.a < 0)
        {
            tenmetsuFlg = 1;
        }
        else if (tap.a > 1)
        {
            tenmetsuFlg = 0;
        }
    }
}
