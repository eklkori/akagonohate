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

    [SerializeField] int gamenFlgD = 0;

    
    void Start()
    {
        if (gamenFlgD == 0 && Input.GetMouseButtonUp(0))
        {
            //gamenFlgD = 1;
            shitaBtn.SetActive(false);
        }
    }
    /// <summary>
    /// íTçıâÊñ Çâ∫Ç…ìÆÇ©Ç∑èàóù
    /// </summary>
    public void Update()
    {
        /*
            if (gamenFlgD == 0 && backGround.position.y <= 1500)
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

        

        //è„Ç…à⁄ìÆÇ∑ÇÈèàóù
        if (gamenFlgD == 1 && Input.GetMouseButtonUp(0))
        {
            //gamenFlgD = 0;
            shitaBtn.SetActive(false);
        }
        if (gamenFlgD == 1 && backGround.position.y >= 720)
        {
            naoko_kao.position -= new Vector3(0, moveUIy, 0);
            yoshiko_kao.position -= new Vector3(0, moveUIy, 0);
            yasuko_kao.position -= new Vector3(0, moveUIy, 0);
            hideta_kao.position -= new Vector3(0, moveUIy, 0);
            hideya_kao.position -= new Vector3(0, moveUIy, 0);
            yasuo_kao.position -= new Vector3(0, moveUIy, 0);
            backGround.position -= new Vector3(0, moveUIy, 0);
            Debug.Log("Ç†");
        }

        if (gamenFlgD == 0 && backGround.position.y >= 1500)
        {
            gamenFlgD = 1;
            ueBtn.SetActive(true);
            Debug.Log("Ç¢");
            
        }

        if (gamenFlgD == 1 && backGround.position.y <= 720)
        {
            gamenFlgD = 0;
            shitaBtn.SetActive(true);
            Debug.Log("Ç§");
        }
*/

    }
}
