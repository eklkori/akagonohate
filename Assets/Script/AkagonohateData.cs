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
    public static int tutorealFlgB = 0;    　  //チュートリアルフラグ(物資調達)
    public static string playerNmaeT = "EKL";  //プレーヤー名
    public static int playerLvI = 1;           //プレイヤーLv
    public static int kenSyojiI = 0;           //仕立券総所持数
    public static int zeniSyojiI = 0;          //銭総所持数
    public static int dateFlg = 0;             //デートフラグ(1の場合はデートに行ける)
    public static int nakanaoriFlg = 0;        //仲直りフラグ(デートで喧嘩した場合、条件達成で1に変更→仲直りできるようになる)
    //所持数関係
    public static int[] itemSyojisu = new int[20];
    public static int[] isyoSyojiFlg = new int[30];  //↓の衣装所持フラグ、←の配列で管理した方が楽じゃね？
    //衣装所持フラグ(0/1で管理)
    public static int naoko01Ws = 0;　　　　　 //直子星1冬服
    public static int naoko01Ss = 0;　　　　　 //直子星1夏服
    public static int naoko02Ws = 0;　　　　　 //直子星2冬服
    public static int naoko02Ss = 0;　　　　　 //直子星2夏服
    public static int naoko03furisodes = 0;　　//直子星3振袖
    public static int yasuko01Ws = 0;　　　　　 //康子星1冬服
    public static int yasuko01Ss = 0;　　　　　 //康子星1夏服
    public static int yasuko02Ws = 0;　　　　　 //康子星2冬服
    public static int yasuko02Ss = 0;　　　　　 //康子星2夏服
    public static int yasuko03XXs = 0;　　　　　//康子星3
    public static int yoshiko01Ws = 0;　　　　　 //吉子星1冬服
    public static int yoshiko01Ss = 0;　　　　　 //吉子星1夏服
    public static int yoshiko02Ws = 0;　　　　　 //吉子星2冬服
    public static int yoshiko02Ss = 0;　　　　　 //吉子星2夏服
    public static int yoshiko03XXs = 0;　　　　　//吉子星3
    public static int hideta01Ws = 0;　　　　　 //秀太星1冬服
    public static int hideta01Ss = 0;　　　　　 //秀太星1夏服
    public static int hideta02Ws = 0;　　　　　 //秀太星2冬服
    public static int hideta02Ss = 0;　　　　　 //秀太星2夏服
    public static int hideta03syougatsu1s = 0;　//秀太星3正月1
    public static int hideya01Ws = 0;　　　　　 //秀也星1冬服
    public static int hideya01Ss = 0;　　　　　 //秀也星1夏服
    public static int hideya02Ws = 0;　　　　　 //秀也星2冬服
    public static int hideya02Ss = 0;　　　　　 //秀也星2夏服
    public static int hideya03syougatsu1s = 0;　//秀也星3正月1
    public static int yasuo01Ws = 0;　　　　　 //康男星1冬服
    public static int yasuo01Ss = 0;　　　　　 //康男星1夏服
    public static int yasuo02Ws = 0;　　　　　 //康男星2冬服
    public static int yasuo02Ss = 0;　　　　　 //康男星2夏服
    public static int yasuo03XXs = 0;　　 　　 //康男星3


    //以下、DB管理しないstatic変数
    public static int tansakuKyara = 0;        //どのキャラのイベントを開始させるかの判断基準にする
    public static string kaiwaNo = "";         //会話No(開始させる会話のNoを保管。※例：naoko1)
    public static int hyoujimaku = 1;　　　　　//ランナー設定画面で表示中の幕を一時的に保管(セッティング→ランナーの切り替え時に使用)

}
