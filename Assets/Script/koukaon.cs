using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koukaon : MonoBehaviour
{
    //効果音を鳴らすだけのクラス

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] Sounds;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void koukaonOn(int koukaonNo)
    {
        //適当な効果音を設定
        switch (koukaonNo)
        {
            case 0: audioSource.resource = Sounds[0]; break;　//基本のタップ音
            case 1: audioSource.resource = Sounds[1]; break;　//効果付けたいときの画面遷移音
            case 2: audioSource.resource = Sounds[2]; break;　//決定時・ランウェイ開始時等
        }

        //音源再生
        audioSource.PlayOneShot(audioSource.clip);
    }
}
