using System;
using System.Collections;
using UnityEngine;
using Utage;
using UtageExtensions;
using UnityEngine.UI;

public class SampleAdvEngineController : MonoBehaviour
{
    //紅子の果用新規追加処理　START
    [SerializeField] private Button btn;
    [SerializeField] GameObject CTutorial;
    [SerializeField] int Flg = AkagonohateData.tutorealFlg;
    void Start()
    {
        //チュートリアルフラグが0の場合、シナリオラベル「Start」でチュートリアル開始
        //その他の場合、会話Noを引数にシナリオを開始(要検討)
        if (AkagonohateData.tutorealFlg == 0)
        {
            btn.onClick.Invoke();
        }
        else if (AkagonohateData.tutorealFlg == 1 && AkagonohateData.busshiSyokaiFlg == 0)
        {
            Debug.Log(AkagonohateData.tutorealFlg);
            JumpScenario("busshiT");
        }
        else {
            JumpScenario(AkagonohateData.kaiwaNo);
        }
    }
    //紅子の果用新規追加処理　END

    // ADVエンジン
    public AdvEngine AdvEngine { get { return advEngine; } }
    [SerializeField]
    protected AdvEngine advEngine;

    //再生中かどうか
    public bool IsPlaying { get; private set; }

    float defaultSpeed = -1;

    //指定のラベルのシナリオを再生する
    public void JumpScenario(string label)
    {
        StartCoroutine(JumpScenarioAsync(label, null));
    }

    //指定のラベルのシナリオを再生する
    //終了した時にonCompleteが呼ばれる
    public void JumpScenario(string label, Action onComplete)
    {
        StartCoroutine(JumpScenarioAsync(label, onComplete));
    }

    IEnumerator JumpScenarioAsync(string label, Action onComplete)
    {
        IsPlaying = true;
        AdvEngine.JumpScenario(label);
        while (!AdvEngine.IsEndOrPauseScenario)
        {
            yield return null;
        }
        IsPlaying = false;
        if (onComplete != null) onComplete();
    }

    //指定のラベルのシナリオを再生する
    //ラベルがなかった場合を想定
    public void JumpScenario(string label, Action onComplete, Action onFailed)
    {
        JumpScenario(label, null, onComplete, onFailed);
    }

    //指定のラベルのシナリオを再生する
    //ラベルがなかった場合を想定
    public void JumpScenario(string label, Action onStart, Action onComplete, Action onFailed)
    {
        if (string.IsNullOrEmpty(label))
        {
            if (onFailed != null) onFailed();
            Debug.LogErrorFormat("シナリオラベルが空です");
            return;
        }
        if (label[0] == '*')
        {
            label = label.Substring(1);
        }
        if (AdvEngine.DataManager.FindScenarioData(label) == null)
        {
            if (onFailed != null) onFailed();
            Debug.LogErrorFormat("{0}はまだロードされていないか、存在しないシナリオです", label);
            return;
        }

        if (onStart != null) onStart();
        JumpScenario(
            label,
            onComplete);
    }

    //シナリオの呼び出し以外に、
    //AdvEngineを操作する処理をまとめておくと、便利
    //何が必要かはプロジェクトによるので、場合によって増やしていく

    //以下、メッセージウィンドのテキスト表示速度を操作する処理のサンプル

    //メッセージウィンドのテキスト表示の速度を指定のスピードに
    public void ChangeMessageSpeed(float speed)
    {
        if (defaultSpeed < 0)
        {
            defaultSpeed = AdvEngine.Config.MessageSpeed;
        }
        AdvEngine.Config.MessageSpeed = speed;
    }
    //メッセージウィンドのテキスト表示の速度を元に戻す
    public void ResetMessageSpeed()
    {
        if (defaultSpeed >= 0)
        {
            AdvEngine.Config.MessageSpeed = defaultSpeed;
        }
    }
}