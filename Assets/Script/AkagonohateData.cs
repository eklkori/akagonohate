using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[SerializeField]

public class AkagonohateData : ScriptableObject
{
    //�ȉ��ADB�Ǘ�����O���static�ϐ�
    //����//
    public static int tutorealFlg = 0;    �@�@ //�`���[�g���A���t���O
    public static int tutorealFlgB = 0;    �@  //�`���[�g���A���t���O(�������B)
    public static string playerNmaeT = "EKL";  //�v���[���[��
    public static int playerLvI = 20;           //�v���C���[Lv
    public static int exp = 270;                 //EXP
    public static int kenSyojiI = 0;           //�d������������
    public static int zeniSyojiI = 0;          //�K��������
    //��b�E�f�[�g�֘A//
    public static int dateFlg = 0;             //�f�[�g�t���O(1�̏ꍇ�̓f�[�g�ɍs����)
    public static int nakanaoriFlg = 0;        //������t���O(�f�[�g�Ō��܂����ꍇ�A�����B����1�ɕύX��������ł���悤�ɂȂ�)
    //�����E�F�C�֘A//
    public static int moZen = 2;               //�O�񃉃��E�F�C���ɐݒ肵��������̐�
    public static int yuZen = 1;               //�O�񃉃��E�F�C���ɐݒ肵���U�����̐�
    public static int niZen = 5;               //�O�񃉃��E�F�C���ɐݒ肵���ו������̐�
    //�������B
    public static int busshiSyokaiFlg = 0;     //�������B����t���O(1�̎��ɕ�������`���[�g���A���Đ�)
    //�������֌W
    public static int[] itemSyojisu = new int[20];
    public static int[] isyoSyojiFlg = new int[60]; 


    //�ȉ��ADB�Ǘ����Ȃ�static�ϐ�
    public static int tansakuKyara = 0;        //�ǂ̃L�����̃C�x���g���J�n�����邩�̔��f��ɂ���
    public static string kaiwaNo = "";         //��bNo(�J�n�������b��No��ۊǁB����Fnaoko1)
    public static int hyoujimaku = 1;     //�����i�[�ݒ��ʂŕ\�����̖����ꎞ�I�ɕۊ�(�Z�b�e�B���O�������i�[�̐؂�ւ����Ɏg�p)
    public static int[] gacha10 = new int[10]; //�K�`�����o�\���p
    public static int gachaFlg = 0;            //�K�`�����P����10�A�����f(�P���̏ꍇ�u1�v�A10�A�̏ꍇ�u2�v)
}
