using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tansakuPopUp : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject naokonoheyaT;
    [SerializeField] GameObject yasukonoheyaT;
    [SerializeField] GameObject yoshikonoheyaT;
    [SerializeField] GameObject hidetanoheyaT;
    [SerializeField] GameObject hideyanoheyaT;
    [SerializeField] GameObject yasuonoheyaT;
    [SerializeField] GameObject tansakuInaoko;
    [SerializeField] GameObject tansakuIyasuko;
    [SerializeField] GameObject tansakuIyoshiko;
    [SerializeField] GameObject tansakuIhideta;
    [SerializeField] GameObject tansakuIhideya;
    [SerializeField] GameObject tansakuIyasuo;
    [SerializeField] GameObject syousaiText;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject dateBtn;
    [SerializeField] GameObject dateBtnNo;
    [SerializeField] GameObject nakanaoriBtn;
    [SerializeField] GameObject nakanaoriBtnNo;
    [SerializeField] GameObject kaiwasuruBtn;
    [SerializeField] GameObject mitsuguBtn;
    [SerializeField] GameObject haikei;

    //-----�\���n-----

    /// <summary>
    /// ���q�̕�����\��
    /// </summary>
    public void showPopUpNaoko()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AkagonohateData.tansakuKyara = 1;
            batsu.SetActive(true);
            popupBase.SetActive(true);
            naokonoheyaT.SetActive(true);
            //tansakuInaoko.SetActive(true);
            //syousaiText.SetActive(true);
            kaiwasuruBtn.SetActive(true);
            mitsuguBtn.SetActive(true);
            haikei.SetActive(true);
            if (AkagonohateData.dateFlg == 1)
            {
                dateBtn.SetActive(true);
            }
            else {
                dateBtnNo.SetActive(true);
            }
            if (AkagonohateData.nakanaoriFlg == 1)
            {
                nakanaoriBtn.SetActive(true);
            }
            else
            {
                nakanaoriBtnNo.SetActive(true);
            }
        }
    }

    /// <summary>
    /// �N�q�̕�����\��
    /// </summary>
    public void showPopUpYasuko()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AkagonohateData.tansakuKyara = 2;
            batsu.SetActive(true);
            popupBase.SetActive(true);
            yasukonoheyaT.SetActive(true);
            //tansakuIyasuko.SetActive(true);
            //syousaiText.SetActive(true);
            kaiwasuruBtn.SetActive(true);
            mitsuguBtn.SetActive(true);
            haikei.SetActive(true);
            if (AkagonohateData.dateFlg == 1)
            {
                dateBtn.SetActive(true);
            }
            else
            {
                dateBtnNo.SetActive(true);
            }
            if (AkagonohateData.nakanaoriFlg == 1)
            {
                nakanaoriBtn.SetActive(true);
            }
            else
            {
                nakanaoriBtnNo.SetActive(true);
            }
        }
    }

    /// <summary>
    /// �g�q�̕�����\��
    /// </summary>
    public void showPopUpYoshiko()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AkagonohateData.tansakuKyara = 3;
            batsu.SetActive(true);
            popupBase.SetActive(true);
            yoshikonoheyaT.SetActive(true);
            //tansakuIyoshiko.SetActive(true);
            //syousaiText.SetActive(true);
            kaiwasuruBtn.SetActive(true);
            mitsuguBtn.SetActive(true);
            haikei.SetActive(true);
            if (AkagonohateData.dateFlg == 1)
            {
                dateBtn.SetActive(true);
            }
            else
            {
                dateBtnNo.SetActive(true);
            }
            if (AkagonohateData.nakanaoriFlg == 1)
            {
                nakanaoriBtn.SetActive(true);
            }
            else
            {
                nakanaoriBtnNo.SetActive(true);
            }
        }
    }

    /// <summary>
    /// �G���̕�����\��
    /// </summary>
    public void showPopUpHideta()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AkagonohateData.tansakuKyara = 4;
            batsu.SetActive(true);
            popupBase.SetActive(true);
            hidetanoheyaT.SetActive(true);
            //tansakuIhideta.SetActive(true);
            //syousaiText.SetActive(true);
            kaiwasuruBtn.SetActive(true);
            mitsuguBtn.SetActive(true);
            haikei.SetActive(true);
            if (AkagonohateData.dateFlg == 1)
            {
                dateBtn.SetActive(true);
            }
            else
            {
                dateBtnNo.SetActive(true);
            }
            if (AkagonohateData.nakanaoriFlg == 1)
            {
                nakanaoriBtn.SetActive(true);
            }
            else
            {
                nakanaoriBtnNo.SetActive(true);
            }
        }
    }

    /// <summary>
    /// �G��̕�����\��
    /// </summary>
    public void showPopUpHideya()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AkagonohateData.tansakuKyara = 5;
            batsu.SetActive(true);
            popupBase.SetActive(true);
            hideyanoheyaT.SetActive(true);
            //tansakuIhideya.SetActive(true);
            //syousaiText.SetActive(true);
            kaiwasuruBtn.SetActive(true);
            mitsuguBtn.SetActive(true);
            haikei.SetActive(true);
            if (AkagonohateData.dateFlg == 1)
            {
                dateBtn.SetActive(true);
            }
            else
            {
                dateBtnNo.SetActive(true);
            }
            if (AkagonohateData.nakanaoriFlg == 1)
            {
                nakanaoriBtn.SetActive(true);
            }
            else
            {
                nakanaoriBtnNo.SetActive(true);
            }
        }
    }

    /// <summary>
    /// �N�j�̕�����\��
    /// </summary>
    public void showPopUpYasuo()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AkagonohateData.tansakuKyara = 6;
            batsu.SetActive(true);
            popupBase.SetActive(true);
            yasuonoheyaT.SetActive(true);
            //tansakuIyasuo.SetActive(true);
            //syousaiText.SetActive(true);
            kaiwasuruBtn.SetActive(true);
            mitsuguBtn.SetActive(true);
            haikei.SetActive(true);
            if (AkagonohateData.dateFlg == 1)
            {
                dateBtn.SetActive(true);
            }
            else
            {
                dateBtnNo.SetActive(true);
            }
            if (AkagonohateData.nakanaoriFlg == 1)
            {
                nakanaoriBtn.SetActive(true);
            }
            else
            {
                nakanaoriBtnNo.SetActive(true);
            }
        }
    }

    //��\���n-------------

    /// <summary>
    /// �|�b�v�A�b�v�ꊇ��\��(����)
    /// </summary>
    public void closePopup() {
        naokonoheyaT.SetActive(false);
        yasukonoheyaT.SetActive(false);
        yoshikonoheyaT.SetActive(false);
        hidetanoheyaT.SetActive(false);
        hideyanoheyaT.SetActive(false);
        yasuonoheyaT.SetActive(false);
        /*tansakuInaoko.SetActive(false);
        tansakuIyasuko.SetActive(false);
        tansakuIyoshiko.SetActive(false);
        tansakuIhideta.SetActive(false);
        tansakuIhideya.SetActive(false);
        tansakuIyasuo.SetActive(false);*/
        //syousaiText.SetActive(false);
        popupBase.SetActive(false);
        batsu.SetActive(false);
        dateBtn.SetActive(false);
        dateBtnNo.SetActive(false);
        nakanaoriBtn.SetActive(false);
        nakanaoriBtnNo.SetActive(false);
        kaiwasuruBtn.SetActive(false);
        mitsuguBtn.SetActive(false);
        haikei.SetActive(false);
    }

}
