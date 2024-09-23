using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[SerializeField]

public class AkagonohateData : ScriptableObject
{
    //以下、DB管理する前提のstatic変数
    public static int tutorealFlg = 0;    　　 //チュートリアルフラグ
    public static string playerNmaeT = "EKL";   //プレーヤー名
    public static int playerLvI = 1;           //プレイヤーLv
    public static int kenSyojiI = 0;           //仕立券総所持数
    public static int zeniSyojiI = 0;          //銭総所持数
    public static int dateFlg = 0;             //デートフラグ(1の場合はデートに行ける)
    public static int nakanaoriFlg = 0;        //仲直りフラグ(デートで喧嘩した場合、条件達成で1に変更→仲直りできるようになる)

    //以下、DB管理しないstatic変数
    public static int tansakuKyara = 0;        //どのキャラのイベントを開始させるかの判断基準にする
    public static string kaiwaNo = "";         //会話No(開始させる会話のNoを保管。※例：naoko1)
}
