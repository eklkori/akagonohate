using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startUtage : MonoBehaviour
{
    [SerializeField] GameObject CKaiwa;
    [SerializeField] private Button btn;
    void Start()
    {
        btn.onClick.Invoke();
    }

    /// <summary>
    /// ランダムに通常会話をスタートさせる処理
    /// </summary>
    public void kaiwaStart()
    {
        Debug.Log(AkagonohateData.kaiwaNo);
        CKaiwa.GetComponent<SampleAdvEngineController2>().JumpScenario(AkagonohateData.kaiwaNo);
    }
}
