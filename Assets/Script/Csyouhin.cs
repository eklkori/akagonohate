using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.UI;

public class Csyouhin : MonoBehaviour
{
    //�f�ނ̒�`
    [SerializeField] GameObject syouhinPopUp;
    [SerializeField] GameObject[] syouhinImages;
    [SerializeField] GameObject haikei;
    [SerializeField] GameObject batsu;

    public Text syouhinmei;
    public Text kaisetsu;
    public Text zeniBefore;
    public Text zeniAfter;
    public Text kosu;
    void Start()
    {
        haikeiSyouhin();
    }

    public void showSyouhinPopUp(int kyaraNo) {
        //�\���̏�����
        for (int i = 0; i < 6; i++) {
            syouhinImages[i].SetActive(false);
        }

        syouhinPopUp.SetActive(true);

        //�L�������Ƃ̕\������
        switch (kyaraNo)
        {
            case 0: 
                syouhinImages[0].SetActive(true);
                syouhinmei.text = "�n�G���";
                kaisetsu.text = "�����ڂ̊��Ɍ����L����������c�c�����������̂́A�����ƒ��q����ɓn���ׂ����낤�B";
                break;
            case 1: 
                syouhinImages[1].SetActive(true);
                syouhinmei.text = "�K�̃I�u�W�F";
                kaisetsu.text = "������c�c�������̈��|�I�������́B���������Ȃ��łق����B�N�q���قɓn��������ł���邩�ȁB";
                break;
            case 2: 
                syouhinImages[2].SetActive(true);
                syouhinmei.text = "�O�F�c�q";
                kaisetsu.text = "�S�Ȃ�����������f�J���B�X�傪������ɋ����Ă���̂��낤���B�g�q����l�ɓn���Ă��������Ȃ�ȁB";
                break;
            case 3: 
                syouhinImages[3].SetActive(true);
                syouhinmei.text = "����";
                kaisetsu.text = "�������Ƃ̂Ȃ��F�̋������ȁB�łƂ������Ă��Ȃ���Ηǂ����ǁc�c�B�G�����V����܂Ȃ�m���m���ŐA���������B";
                break;
            case 4: 
                syouhinImages[4].SetActive(true);
                syouhinmei.text = "�z�O�K�j";
                kaisetsu.text = "�Ƃ��Ă�����������������N���u���Ă���̂��C�ɂȂ�c�c�����ƗⓀ�Ȃ̂��낤�B�z�O�I�^�N�̏G�炨�V����܂ɂ����悤�B";
                break;
            case 5: 
                syouhinImages[5].SetActive(true);
                syouhinmei.text = "�����M";
                kaisetsu.text = "���̕M�ŕ����������΁A�N�ł��\�M�ƂɂȂꂿ�Ⴂ�����I�����}�j�A�̍匴��y�ɐ���I";
                break;
        }

    }

    /// <summary>
    /// ���i�|�b�v�A�b�v�̃N���[�Y
    /// </summary>
    public void haikeiSyouhin() {
        syouhinPopUp.SetActive(false);
    }
    void Update()
    {
        
    }
}
