using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class cBackGround : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] Sounds;

    void Start()
    {
        //�{�ԗp����(�e�X�g���̓R�����g�A�E�g)START
        //SceneManager.LoadScene("01Title", LoadSceneMode.Additive);
        //�{�ԗp����(�e�X�g���̓R�����g�A�E�g)END

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    int kirikaeFlgA = -1;
    int kirikaeFlgB = -1;
    void Update()
    {
        //���ݎ������펞�擾
        AkagonohateData.now = DateTime.Now;

        //BGM�̐ݒ�
        //�\�����̃V�[�����擾
        string sceneName = "";
        //���ݓǂݍ��܂�Ă���V�[�����������[�v
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        {
            //�ǂݍ��܂�Ă���V�[�����擾���A���̖��O�����O�ɕ\��
            sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;

            if (i == 1)
            {
                Debug.Log(sceneName);
                break;
            }
        }
        //�؂�ւ��t���O�̐ݒ�(0�F���C��BGM�A1�F�����E�F�C��BGM)
        if (sceneName != "11Runway" && sceneName != "12RunwayRes")
        {
            kirikaeFlgB = 0;
        }
        else
        {
            kirikaeFlgB = 1;
        }
        //�؂�ւ��t���O���قȂ�ꍇ�A�����������ւ���
        if (kirikaeFlgA != kirikaeFlgB)
        {
            //�Đ�����BGM���~�߂�
            audioSource.Stop();
            if (kirikaeFlgB == 0)
            {
                //�����E�F�C�ȊO�̎���BGM�Đ�
                audioSource.resource = Sounds[0];
            }
            else if (kirikaeFlgB == 1)
            {
                //�����E�F�C����BGM�Đ�
                switch (AkagonohateData.basyo)
                {
                    case 1: audioSource.resource = Sounds[1]; break;
                    case 2: audioSource.resource = Sounds[2]; break;
                    case 3: audioSource.resource = Sounds[1]; break;
                    case 4: audioSource.resource = Sounds[2]; break;
                    case 5: audioSource.resource = Sounds[1]; break;
                    case 6: audioSource.resource = Sounds[2]; break;
                    case 7: audioSource.resource = Sounds[1]; break;
                    case 8: audioSource.resource = Sounds[2]; break;
                    case 9: audioSource.resource = Sounds[1]; break;
                }
            }
            audioSource.PlayOneShot(audioSource.clip);
        }

        //�Đ����I������烋�[�v������
        if (!audioSource.isPlaying)
        {
            kirikaeFlgB = -1;
        }

        kirikaeFlgA = kirikaeFlgB;
    }

    private void OnApplicationQuit()
    {
        //�Q�[�����I�������Ƃ��̏���
        //�����ɃT�[�o�ɏ��X�̒l��n������������
        Debug.Log("OnApplicationQuit");

    }
}
