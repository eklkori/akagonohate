using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koukaon : MonoBehaviour
{
    //���ʉ���炷�����̃N���X

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] Sounds;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void koukaonOn(int koukaonNo)
    {
        //�K���Ȍ��ʉ���ݒ�
        switch (koukaonNo)
        {
            case 0: audioSource.resource = Sounds[0]; break;�@//��{�̃^�b�v��
            case 1: audioSource.resource = Sounds[1]; break;�@//���ʕt�������Ƃ��̉�ʑJ�ډ�
            case 2: audioSource.resource = Sounds[2]; break;�@//���莞�E�����E�F�C�J�n����
        }

        //�����Đ�
        audioSource.PlayOneShot(audioSource.clip);
    }
}
