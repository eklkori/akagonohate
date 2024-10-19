using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cshinaido3 : MonoBehaviour
{
    [SerializeField] GameObject dateBtn;
    [SerializeField] GameObject kaiwaBtn;

    public void showDate()
    {
        dateBtn.SetActive(false);
        kaiwaBtn.SetActive(true);
    }
    public void showKaiwa()
    {
        dateBtn.SetActive(true);
        kaiwaBtn.SetActive(false);
    }

}
