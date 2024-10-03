using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UtageExtensions;
//���g�q�̉ʗp�ɒǉ�
using UnityEngine.UI;

public class SampleAdvEngineController : MonoBehaviour
{
    //�g�q�̉ʗp�V�K�ǉ������@START

    //���V�[���J�ڂƓ����ɃV�i���I���X�^�[�g�����鏈��
    [SerializeField]
    private Button btn;
    void Start()
    {
        btn.onClick.Invoke();
    }

    //�g�q�̉ʗp�V�K�ǉ������@END

    // ADV�G���W��
    public AdvEngine AdvEngine { get { return advEngine; } }
    [SerializeField]
    protected AdvEngine advEngine;

    //�Đ������ǂ���
    public bool IsPlaying { get; private set; }

    float defaultSpeed = -1;

    //�w��̃��x���̃V�i���I���Đ�����
    public void JumpScenario(string label)
    {
        StartCoroutine(JumpScenarioAsync(label, null));
    }

    //�w��̃��x���̃V�i���I���Đ�����
    //�I����������onComplete���Ă΂��
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
            IsPlaying = false;
            yield return null;
        }
        if (onComplete != null) onComplete();
    }

    //�w��̃��x���̃V�i���I���Đ�����
    //���x�����Ȃ������ꍇ��z��
    public void JumpScenario(string label, Action onComplete, Action onFailed)
    {
        JumpScenario(label, null, onComplete, onFailed);
    }

    //�w��̃��x���̃V�i���I���Đ�����
    //���x�����Ȃ������ꍇ��z��
    public void JumpScenario(string label, Action onStart, Action onComplete, Action onFailed)
    {
        if (string.IsNullOrEmpty(label))
        {
            if (onFailed != null) onFailed();
            Debug.LogErrorFormat("�V�i���I���x������ł�");
            return;
        }
        if (label[0] == '*')
        {
            label = label.Substring(1);
        }
        if (AdvEngine.DataManager.FindScenarioData(label) == null)
        {
            if (onFailed != null) onFailed();
            Debug.LogErrorFormat("{0}�͂܂����[�h����Ă��Ȃ����A���݂��Ȃ��V�i���I�ł�", label);
            return;
        }

        if (onStart != null) onStart();
        JumpScenario(
        label,
        onComplete);
    }
    //�V�i���I�̌Ăяo���ȊO�ɁA
    //AdvEngine�𑀍삷�鏈�����܂Ƃ߂Ă����ƁA�֗�
    //�����K�v���̓v���W�F�N�g�ɂ��̂ŁA�ꍇ�ɂ���đ��₵�Ă���

    //�ȉ��A���b�Z�[�W�E�B���h�̃e�L�X�g�\�����x�𑀍삷�鏈���̃T���v��

    //���b�Z�[�W�E�B���h�̃e�L�X�g�\���̑��x���w��̃X�s�[�h��
    public void ChangeMessageSpeed(float speed)
    {
        if (defaultSpeed < 0)
        {
            defaultSpeed = AdvEngine.Config.MessageSpeed;
        }
        AdvEngine.Config.MessageSpeed = speed;
    }
    //���b�Z�[�W�E�B���h�̃e�L�X�g�\���̑��x�����ɖ߂�
    public void ResetMessageSpeed()
    {
        if (defaultSpeed >= 0)
        {
            AdvEngine.Config.MessageSpeed = defaultSpeed;
        }
    }
}