using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tansakuMoveUp: MonoBehaviour
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

    [SerializeField] int gamenFlgU = 1;

    /// <summary>
    /// íTçıâÊñ Çè„Ç…ìÆÇ©Ç∑èàóù
    /// </summary>
    public void Update()
    {
        if (gamenFlgU==1 && Input.GetMouseButtonUp(0))
        {
            gamenFlgU = 0;
            ueBtn.SetActive(false);
        }
            if (gamenFlgU == 0 && backGround.position.y >= 720)
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

        if (backGround.position.y <= 720)
        {
            shitaBtn.SetActive(true);
        }
    }
}
