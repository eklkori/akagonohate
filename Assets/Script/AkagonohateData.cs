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
    public static int tutorealFlgB = 0;    �@  //�`���[�g���A���t���O(�������B)
    public static string playerNmaeT = "EKL";  //�v���[���[��
    public static int playerLvI = 1;           //�v���C���[Lv
    public static int kenSyojiI = 0;           //�d������������
    public static int zeniSyojiI = 0;          //�K��������
    public static int dateFlg = 0;             //�f�[�g�t���O(1�̏ꍇ�̓f�[�g�ɍs����)
    public static int nakanaoriFlg = 0;        //������t���O(�f�[�g�Ō��܂����ꍇ�A�����B����1�ɕύX��������ł���悤�ɂȂ�)
    //�������֌W
    public static int[] itemSyojisu = new int[20];
    public static int[] isyoSyojiFlg = new int[30];  //���̈ߑ������t���O�A���̔z��ŊǗ����������y����ˁH
    //�ߑ������t���O(0/1�ŊǗ�)
    public static int naoko01Ws = 0;�@�@�@�@�@ //���q��1�~��
    public static int naoko01Ss = 0;�@�@�@�@�@ //���q��1�ĕ�
    public static int naoko02Ws = 0;�@�@�@�@�@ //���q��2�~��
    public static int naoko02Ss = 0;�@�@�@�@�@ //���q��2�ĕ�
    public static int naoko03furisodes = 0;�@�@//���q��3�U��
    public static int yasuko01Ws = 0;�@�@�@�@�@ //�N�q��1�~��
    public static int yasuko01Ss = 0;�@�@�@�@�@ //�N�q��1�ĕ�
    public static int yasuko02Ws = 0;�@�@�@�@�@ //�N�q��2�~��
    public static int yasuko02Ss = 0;�@�@�@�@�@ //�N�q��2�ĕ�
    public static int yasuko03XXs = 0;�@�@�@�@�@//�N�q��3
    public static int yoshiko01Ws = 0;�@�@�@�@�@ //�g�q��1�~��
    public static int yoshiko01Ss = 0;�@�@�@�@�@ //�g�q��1�ĕ�
    public static int yoshiko02Ws = 0;�@�@�@�@�@ //�g�q��2�~��
    public static int yoshiko02Ss = 0;�@�@�@�@�@ //�g�q��2�ĕ�
    public static int yoshiko03XXs = 0;�@�@�@�@�@//�g�q��3
    public static int hideta01Ws = 0;�@�@�@�@�@ //�G����1�~��
    public static int hideta01Ss = 0;�@�@�@�@�@ //�G����1�ĕ�
    public static int hideta02Ws = 0;�@�@�@�@�@ //�G����2�~��
    public static int hideta02Ss = 0;�@�@�@�@�@ //�G����2�ĕ�
    public static int hideta03syougatsu1s = 0;�@//�G����3����1
    public static int hideya01Ws = 0;�@�@�@�@�@ //�G�琯1�~��
    public static int hideya01Ss = 0;�@�@�@�@�@ //�G�琯1�ĕ�
    public static int hideya02Ws = 0;�@�@�@�@�@ //�G�琯2�~��
    public static int hideya02Ss = 0;�@�@�@�@�@ //�G�琯2�ĕ�
    public static int hideya03syougatsu1s = 0;�@//�G�琯3����1
    public static int yasuo01Ws = 0;�@�@�@�@�@ //�N�j��1�~��
    public static int yasuo01Ss = 0;�@�@�@�@�@ //�N�j��1�ĕ�
    public static int yasuo02Ws = 0;�@�@�@�@�@ //�N�j��2�~��
    public static int yasuo02Ss = 0;�@�@�@�@�@ //�N�j��2�ĕ�
    public static int yasuo03XXs = 0;�@�@ �@�@ //�N�j��3


    //�ȉ��ADB�Ǘ����Ȃ�static�ϐ�
    public static int tansakuKyara = 0;        //�ǂ̃L�����̃C�x���g���J�n�����邩�̔��f��ɂ���
    public static string kaiwaNo = "";         //��bNo(�J�n�������b��No��ۊǁB����Fnaoko1)
    public static int hyoujimaku = 1;�@�@�@�@�@//�����i�[�ݒ��ʂŕ\�����̖����ꎞ�I�ɕۊ�(�Z�b�e�B���O�������i�[�̐؂�ւ����Ɏg�p)

}
