using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tansakuMove : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject shitaBtn;
    [SerializeField] GameObject ueBtn;

    /// <summary>
    /// �T����ʂ����ɓ���������
    /// </summary>
    public void moveDown()
    {
        shitaBtn.SetActive(false);
        ueBtn.SetActive(true);
    }

    /// <summary>
    /// �T����ʂ���ɓ���������
    /// </summary>
    public void moveUp()
    {
        ueBtn.SetActive(false);
        shitaBtn.SetActive(true);
    }
}
