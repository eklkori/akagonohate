using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[SerializeField]

public class AkagonohateData : ScriptableObject
{
    //�ȉ��ADB�Ǘ�����O���static�ϐ�
    //�� *�F��public������K�v����
    //����//
    public static int tutorealFlg = 0;    �@�@ //�`���[�g���A���t���O
    public static int tutorealFlgB = 0;    �@  //�`���[�g���A���t���O(�������B)
    public static string playerNmaeT = "EKL";  //*�v���[���[��
    public static int playerLvI = 20;           //*�v���C���[Lv
    public static int exp = 270;                 //*EXP
    public static int kenSyojiI = 0;           //*�d������������
    public static int zeniSyojiI = 0;          //*�K��������
    //�X�e�[�^�X�n
    public static int[] datePt = new int[6];   //*�L�������Ƃ̃f�[�gPt��ۊ�
    public static int[] KdatePt = new int[6];�@//*(�����E�F�C����)�l�������f�[�gPt���i�[
    public static int[] shinaido = new int[6]; //*�L�������Ƃ̐e��Lv���i�[
    public static int[] dateCount = new int[6]; //*�L�������Ƃ̗݌v�f�[�g�񐔂��i�[
    public static int[] kaiwaCount = new int[6];//*�L�������Ƃ̗݌v��b�񐔂��i�[
    public static int[] mitsugiCount = new int[6];//*�L�������Ƃ̗݌v�v�������i�[
    //��b�E�f�[�g�֘A//
    public static int dateFlg = 0;             //*�f�[�g�t���O(1�̏ꍇ�̓f�[�g�ɍs����)
    public static int nakanaoriFlg = 0;        //*������t���O(�f�[�g�Ō��܂����ꍇ�A�����B����1�ɕύX��������ł���悤�ɂȂ�)
    public static int[] kaiwaShichoFlg = new int[300];//*��b�����ς݃t���O(1�������ς�)1�L�����ɂ�50���ŋ�؂�
    public static int[] dateShichoFlg = new int[60];//*�f�[�g�����ς݃t���O(1�������ς�)1�L�����ɂ�10���ŋ�؂�
    //�����E�F�C�֘A//
    public static int moZen = 2;               //�O�񃉃��E�F�C���ɐݒ肵��������̐�
    public static int yuZen = 1;               //�O�񃉃��E�F�C���ɐݒ肵���U�����̐�
    public static int niZen = 5;               //�O�񃉃��E�F�C���ɐݒ肵���ו������̐�
    public static int basyo = 1;               //�O�񃉃��E�F�C���ɐݒ肵���ꏊ(�ݒ莞�ɓs�x�㏑��)
    public static int[] runner = new int[24];  //�ݒ蒆�̃����i�[�ߑ�No���i�[(0�`60���炢�̒l�A�s�x�㏑��)
    //�������B
    public static int busshiSyokaiFlg = 0;     //�������B����t���O(1�̎��ɕ�������`���[�g���A���Đ�)
    //�������֌W
    public static int[] itemSyojisu = new int[20];�@�@//*�e��A�C�e��������
    public static int[] isyoSyojiFlg = new int[60];�@ //*�ߑ�����/�������𔻕�

    //�ȉ��ADB�Ǘ����Ȃ�static�ϐ�
    public static int tansakuKyara = 0;        //�ǂ̃L�����̃C�x���g���J�n�����邩�̔��f��ɂ���
    public static string kaiwaNo = "";         //��bNo(�J�n�������b��No��ۊǁB����Fnaoko1)
    public static int hyoujimaku = 1;     //�����i�[�ݒ��ʂŕ\�����̖����ꎞ�I�ɕۊ�(�Z�b�e�B���O�������i�[�̐؂�ւ����Ɏg�p)
    public static int[] gacha10 = new int[10]; //�K�`�����o�\���p
    public static int gachaFlg = 0;            //�K�`�����P����10�A�����f(�P���̏ꍇ�u1�v�A10�A�̏ꍇ�u2�v)
    public static int shinaidoWho = 0;         //�N�̐e���x���m�F���Ă��邩���Ǘ�����t���O
}
