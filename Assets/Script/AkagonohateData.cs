using System;
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
    public static float HH = 0;                  //���ǉ��܂ł̃J�E���g(��)
    public static float MM = 0;                  //���ǉ��܂ł̃J�E���g(��)
    public static float SS = 10;                  //���ǉ��܂ł̃J�E���g(�b)
    public static int partnerNo = 13;            //�z�[����ʂŃp�[�g�i�[�ݒ肵�Ă���L�����̈ߑ�No���i�[
    public static int eventFlg = 0;            //�C�x���g����1�ɂ���t���O�@�C�x���g�����ۂ��𔻒f
    public static DateTime[] loginRireki = new DateTime[3];  //*���O�C�������̗�����ۊ�(0�F1���̍ŏ��Ƀ��O�C���i�z�[����ʂɑJ�ځj�������ԁA1�F�Q�[���ғ����͏�ɍX�V��������)
    public static int[] giftFlg = new int[10];  //�v���[���g�󂯎��ۂ𔻒f����t���O �z��0�Ԗڂ����O�C���{�[�i�X�@1�F���B���A0�F�B��(�󂯎��\)�A2�F�l���ς�
    public static DateTime[] uketoriKigen = new DateTime[10];  //*�v���[���g�󂯎�������ۊ�
    public static DateTime[] uketoriRireki = new DateTime[10];  //*�v���[���g�󂯎�藚����ۊ�
    //�X�e�[�^�X�n
    public static int[] datePt = new int[6];   //*�L�������Ƃ̃f�[�gPt��ۊ�
    public static int[] KdatePt = new int[6];�@//*(�����E�F�C����)�l�������f�[�gPt���i�[(�ꎞ�I)
    public static int[] shinaiLv = new int[6]; //*�L�������Ƃ̐e��Lv���i�[
    public static int[] shinaiPt = new int[6];   //*�L�������Ƃ̐e��Pt��ۊ�
    public static int[] KshinaiPt = new int[6]; //*(�����E�F�C����)�l�������e��Pt���i�[(�ꎞ�I)
    public static int[] KItem = new int[20];     //*(�����E�F�C����)�l�������A�C�e�������i�[(�ꎞ�I)
    public static int[] dateCount = new int[6]; //*�L�������Ƃ̗݌v�f�[�g�񐔂��i�[
    public static int[] kaiwaCount = new int[6];//*�L�������Ƃ̗݌v��b�񐔂��i�[
    public static int[] mitsugiCount = new int[6];//*�L�������Ƃ̗݌v�v�������i�[
    public static int[] countDay = new int[4];    //*������/�T���Ƃ̗݌v�񐔂��i�[(0�F��b(���Z�E������)�A1�F�����E�F�C(������)�A2�F��b(���Z�E�T����)�A3�F�����E�F�C(�T����))
    public static int[] eventRuikei = new int[5]; //*�y�C�x���g����z�e��݌v�l���i�[(0�F�C�x���gPt�A1�F�������A2�F���[���A���A3�F��b�񐔇@�A4�F��b�񐔇A)
    //��b�E�f�[�g�֘A//
    public static int[] dateFlg = new int[6];             //*�f�[�g�t���O(1�̏ꍇ�̓f�[�g�ɍs����)
    public static int[] nakanaoriFlg = new int[6];        //*������t���O(�f�[�g�Ō��܂����ꍇ�A�����B����1�ɕύX��������ł���悤�ɂȂ�)
    public static DateTime[] kaiwaRireki = new DateTime[50];  //*�L�������Ƃ̉�b���̗�����5�񕪕ۊ�
    public static int[] kimata = new int[6];  //�e�L�����̖ؖ��ւ̑z�����i�[(���F1�A���F2�A��F3)
    public static int[] KSyokaiFlg = new int[6];        //��{0�@1���̍ŏ��̉�b���̂�1���i�[(�L��������)
    public static int[] kaiwaShichoFlg = new int[300];//*��b�����ς݃t���O(1�������ς�)1�L�����ɂ�50���ŋ�؂�
    public static int[] dateShichoFlg = new int[600];//*�f�[�g�����ς݃t���O(1�������ς�)1�L�����ɂ�20���ŋ�؂� ��200�ԑ�ȍ~�F����A�����t���O�A400�ԑ�ȍ~�F����B�����t���O
    //�����E�F�C�֘A//
    public static int moZen = 2;               //�O�񃉃��E�F�C���ɐݒ肵��������̐�
    public static int yuZen = 1;               //�O�񃉃��E�F�C���ɐݒ肵���U�����̐�
    public static int niZen = 5;               //�O�񃉃��E�F�C���ɐݒ肵���ו������̐�
    public static int basyo = 1;               //�O�񃉃��E�F�C���ɐݒ肵���ꏊ(�ݒ莞�ɓs�x�㏑��)
    public static int[] runner = new int[24];  //*�ݒ蒆�̃����i�[�ߑ�No���i�[(0�`60���炢�̒l�A�s�x�㏑���A�����l��-1�ɂ���)
    public static int[] runwayRes = new int[4];//�����E�F�C���ʂ��i�[(0�F��ꖋ�A1�F��񖋁A2�F��O���A3�F�������ʁ@�D�F1�A�ǁF2�A�F3)
    public static int[] runwayMVP = new int[4];//�����E�F�CMVP�L�����̈ߑ�No���i�[(0�F��ꖋ�A1�F��񖋁A2�F��O���A3�F��������)
    public static DateTime[] runwayRireki = new DateTime[2];  //*�����E�F�C�����̗�����ۊ�(0�F�O�񃉃��E�F�C�����A1�F���̏���n�܂�������)

    //�������B
    public static int busshiSyokaiFlg = 0;     //�������B����t���O(1�̎��ɕ�������`���[�g���A���Đ�)
    //�^�X�N���
    public static int[] tasseiFlgN = new int[6];      //*�y���ہz�����B����(��V�l���\�ɂȂ������_)�ɏ���������@1�F���B���A0�F�B��(�󂯎��\)�A2�F�l���ς�
    public static int[] tasseiFlgS = new int[9];      //*�y�T�ԁz�����B����(��V�l���\�ɂȂ������_)�ɏ���������@1�F���B���A0�F�B��(�󂯎��\)�A2�F�l���ς�
    public static int[] tasseiFlgE = new int[6];      //*�y�C�x���g�z�����B����(��V�l���\�ɂȂ������_)�ɏ���������@1�F���B���A0�F�B��(�󂯎��\)�A2�F�l���ς�
    //�������֌W
    public static int[] itemSyojisu = new int[20];�@�@//*�e��A�C�e��������
    public static int[] isyoSyojiFlg = new int[60];�@ //*�ߑ�����/�������𔻕�

    //�ȉ��ADB�Ǘ����Ȃ�static�ϐ�
    public static int tansakuKyara = 0;        //�ǂ̃L�����̃C�x���g���J�n�����邩�̔��f��ɂ���
    public static string kaiwaNo = "";         //��bNo(�J�n�������b��No��ۊǁB����Fnaoko1)
    public static int hyoujimaku = 1;     //�����i�[�ݒ��ʂŕ\�����̖����ꎞ�I�ɕۊ�(�Z�b�e�B���O�������i�[�̐؂�ւ����Ɏg�p)
    public static int[] gacha10 = new int[10]; //�K�`�����o�\���p
    public static int[] gachaNotNew = new int[10]; //�K�`���p(���ɏ������Ă���ߑ����������ꍇ�A�t���O�𗧂Ă�)
    public static int gachaFlg = 0;            //�K�`�����P����10�A�����f(�P���̏ꍇ�u1�v�A10�A�̏ꍇ�u2�v)
    public static int shinaidoWho = 0;         //�N�̐e���x���m�F���Ă��邩���Ǘ�����t���O
    public static int kakuninchuFlg = 0;       //�e���x�m�F��ʓ��A�T���ȊO����V�i���I���������Ă��邱�Ƃ������t���O

    //�Œ�l
    //�e�ߑ��̔������X�e�[�^�X���i�[
    private static int[] bi = { 3, 3, 8, 8, 16, 0, 0, 0, 0, 0, 1, 1, 2, 2, 4, 0, 0, 0, 0, 0, 3, 3, 7, 7, 14, 0, 0, 0, 0, 0, 2, 2, 5, 5, 10, 0, 0, 0, 0, 0, 3, 3, 6, 6, 12, 0, 0, 0, 0, 0, 2, 2, 4, 4, 6, 0, 0, 0, 0, 0 };
    //�e�ߑ��̃��[���A���X�e�[�^�X���i�[
    private static int[] hu = { 1, 1, 2, 2, 4, 0, 0, 0, 0, 0, 3, 3, 8, 8, 16, 0, 0, 0, 0, 0, 1, 1, 3, 3, 6, 0, 0, 0, 0, 0, 2, 2, 5, 5, 10, 0, 0, 0, 0, 0, 1, 1, 4, 4, 8, 0, 0, 0, 0, 0, 2, 2, 6, 6, 14, 0, 0, 0, 0, 0 };
    //�V���A���R�[�h���i�[(�g�p���ꂽ��null�ɂ���)
    public static string[] serialCodes = { "XXXXXXXX", "YYYYYYYY", "ZZZZZZZZ" };
    public int[] GetBi  //public �߂�l �v���p�e�B��
    {
        get { return bi; } //get {return �t�B�[���h��;}
        //set { bi = value; } //set {�t�B�[���h�� = value;}
    }
    public int[] GetHu  //public �߂�l �v���p�e�B��
    {
        get { return hu; } //get {return �t�B�[���h��;}
    }

    //��runner[]�̏����l��-1�ɂ��鏈�����A��ʑJ�ڃX�N���v�g(gamenseni.cs)�̒��Ŏ����ς�
}
