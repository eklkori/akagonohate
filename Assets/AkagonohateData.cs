using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[SerializeField]

public class AkagonohateData : ScriptableObject
{
    //�ȉ��ADB�Ǘ�����O���static�ϐ�
    public static int tutorealFlg = 0;    �@�@ //�`���[�g���A���t���O
    public static string playerNmaeT = "EKL";   //�v���[���[��
    public static int playerLvI = 1;           //�v���C���[Lv
    public static int kenSyojiI = 0;           //�d������������
    public static int zeniSyojiI = 0;          //�K��������
    public static int dateFlg = 0;             //�f�[�g�t���O(1�̏ꍇ�̓f�[�g�ɍs����)
    public static int nakanaoriFlg = 0;        //������t���O(�f�[�g�Ō��܂����ꍇ�A�����B����1�ɕύX��������ł���悤�ɂȂ�)

    //�ȉ��ADB�Ǘ����Ȃ�static�ϐ�
    public static int tansakuKyara = 0;        //�ǂ̃L�����̃C�x���g���J�n�����邩�̔��f��ɂ���
    public static string kaiwaNo = "";         //��bNo(�J�n�������b��No��ۊǁB����Fnaoko1)
}
