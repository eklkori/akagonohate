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
        //本番用処理(テスト中はコメントアウト)START
        //SceneManager.LoadScene("01Title", LoadSceneMode.Additive);
        //本番用処理(テスト中はコメントアウト)END

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    int kirikaeFlgA = -1;
    int kirikaeFlgB = -1;
    void Update()
    {
        //現在時刻を常時取得
        AkagonohateData.now = DateTime.Now;

        //BGMの設定
        //表示中のシーンを取得
        string sceneName = "";
        //現在読み込まれているシーン数だけループ
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        {
            //読み込まれているシーンを取得し、その名前をログに表示
            sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;

            if (i == 1)
            {
                Debug.Log(sceneName);
                break;
            }
        }
        //切り替えフラグの設定(0：メインBGM、1：ランウェイ中BGM)
        if (sceneName != "11Runway" && sceneName != "12RunwayRes")
        {
            kirikaeFlgB = 0;
        }
        else
        {
            kirikaeFlgB = 1;
        }
        //切り替えフラグが異なる場合、音源を差し替える
        if (kirikaeFlgA != kirikaeFlgB)
        {
            //再生中のBGMを止める
            audioSource.Stop();
            if (kirikaeFlgB == 0)
            {
                //ランウェイ以外の時のBGM再生
                audioSource.resource = Sounds[0];
            }
            else if (kirikaeFlgB == 1)
            {
                //ランウェイ中のBGM再生
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

        //再生が終わったらループさせる
        if (!audioSource.isPlaying)
        {
            kirikaeFlgB = -1;
        }

        kirikaeFlgA = kirikaeFlgB;
    }

    private void OnApplicationQuit()
    {
        //ゲームが終了したときの処理
        //ここにサーバに諸々の値を渡す処理を実装
        Debug.Log("OnApplicationQuit");

    }
}
