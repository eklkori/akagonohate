using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utage;

public class tansakuMoveDown: MonoBehaviour
{
    //ëfçﬁÇÃíËã`
    [SerializeField] GameObject shitaBtn;
    [SerializeField] GameObject ueBtn;

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

    
    public void shitaBtnOn()
    {
        if (gamenFlgD == 1)
        {
            gamenFlgD = 0;
            shitaBtn.SetActive(false);
        }
    }

    public void ueBtnOn()
    {
        if (gamenFlgD == 0)
        {
            gamenFlgD = 1;
            ueBtn.SetActive(false);
        }
    }
    /// <summary>
    /// íTçıâÊñ Çâ∫Ç…ìÆÇ©Ç∑èàóù
    /// </summary>
    public void Update()
    {
        //â∫Ç…à⁄ìÆÇ∑ÇÈèàóù
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
        }


        //è„Ç…à⁄ìÆÇ∑ÇÈèàóù
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
        }


    }
}
