using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menuClose : MonoBehaviour
{
    [SerializeField] GameObject batsu;
    [SerializeField] GameObject credit;
    [SerializeField] GameObject syojidogukakunin;
    [SerializeField] GameObject riyokiyaku;
    [SerializeField] GameObject otoiawase;
    [SerializeField] GameObject popupBase;
    [SerializeField] GameObject koukaonBGM;
    [SerializeField] GameObject kakusyumenu;
    [SerializeField] GameObject riyokiyakuT;

    public void closePopUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //�N���W�b�g���(creditFlg==1)�̎�

            //��������m�F���(syojidogukakuninFlg==1)�̎�

            //���p�K����(riyokiyakuFlg==1)�̎�
            /*if (riyokiyakuFlg == 1) {
            
            }*/
            //���₢���킹���(otoiawaseFlg==1)�̎�

            //���̑�(�e�탁�j���[��ʂ̎�)
            batsu.SetActive(false);
            credit.SetActive(false);
            syojidogukakunin.SetActive(false);
            riyokiyaku.SetActive(false);
            otoiawase.SetActive(false);
            popupBase.SetActive(false);
            koukaonBGM.SetActive(false);
            kakusyumenu.SetActive(false);
        }
    }
}
