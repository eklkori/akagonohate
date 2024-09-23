using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tansakuMove : MonoBehaviour
{
    //素材の定義
    [SerializeField] GameObject shitaBtn;
    [SerializeField] GameObject ueBtn;

    /// <summary>
    /// 探索画面を下に動かす処理
    /// </summary>
    public void moveDown()
    {
        shitaBtn.SetActive(false);
        ueBtn.SetActive(true);
    }

    /// <summary>
    /// 探索画面を上に動かす処理
    /// </summary>
    public void moveUp()
    {
        ueBtn.SetActive(false);
        shitaBtn.SetActive(true);
    }
}
