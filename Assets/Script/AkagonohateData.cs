using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[SerializeField]

public class AkagonohateData : ScriptableObject
{
    //以下、DB管理する前提のstatic変数
    //※ *：非public化する必要あり
    //共通//
    public static int tutorealFlg = 0;    　　 //チュートリアルフラグ
    public static int tutorealFlgB = 0;    　  //チュートリアルフラグ(物資調達)
    public static string playerNmaeT = "EKL";  //*プレーヤー名
    public static int playerLvI = 20;           //*プレイヤーLv
    public static int exp = 270;                 //*EXP
    public static float HH = 0;                  //鍵追加までのカウント(時)
    public static float MM = 0;                  //鍵追加までのカウント(分)
    public static float SS = 10;                  //鍵追加までのカウント(秒)
    public static int partnerNo = 13;            //ホーム画面でパートナー設定しているキャラの衣装Noを格納
    public static int eventFlg = 0;            //イベント中は1にするフラグ　イベント中か否かを判断
    //ステータス系
    public static int[] datePt = new int[6];   //*キャラごとのデートPtを保管
    public static int[] KdatePt = new int[6];　//*(ランウェイ等で)獲得したデートPtを格納
    public static int[] shinaido = new int[6]; //*キャラごとの親愛Lvを格納
    public static int[] dateCount = new int[6]; //*キャラごとの累計デート回数を格納
    public static int[] kaiwaCount = new int[6];//*キャラごとの累計会話回数を格納
    public static int[] mitsugiCount = new int[6];//*キャラごとの累計貢物個数を格納
    //会話・デート関連//
    public static int dateFlg = 0;             //*デートフラグ(1の場合はデートに行ける)
    public static int nakanaoriFlg = 0;        //*仲直りフラグ(デートで喧嘩した場合、条件達成で1に変更→仲直りできるようになる)
    public static int[] kaiwaShichoFlg = new int[300];//*会話視聴済みフラグ(1が視聴済み)1キャラにつき50ずつで区切る
    public static int[] dateShichoFlg = new int[120];//*デート視聴済みフラグ(1が視聴済み)1キャラにつき10ずつで区切る
    //ランウェイ関連//
    public static int moZen = 2;               //前回ランウェイ時に設定したもぎりの数
    public static int yuZen = 1;               //前回ランウェイ時に設定した誘導員の数
    public static int niZen = 5;               //前回ランウェイ時に設定した荷物持ちの数
    public static int basyo = 1;               //前回ランウェイ時に設定した場所(設定時に都度上書き)
    public static int[] runner = new int[24];  //*設定中のランナー衣装Noを格納(0〜60くらいの値、都度上書き、初期値を-1にする)
    public static int[] runwayRes = new int[4];//ランウェイ結果を格納(0：第一幕、1：第二幕、2：第三幕、3：総合結果　優：1、良：2、可：3)
    public static int[] runwayMVP = new int[4];//ランウェイMVPキャラの衣装Noを格納(0：第一幕、1：第二幕、2：第三幕、3：総合結果)

    //物資調達
    public static int busshiSyokaiFlg = 0;     //物資調達初回フラグ(1の時に物資初回チュートリアル再生)
    //タスク画面
    public static int[] tasseiFlgN = new int[6];      //*【日課】条件達成時(報酬獲得可能になった時点)に書き換える　0：未達成、1：達成(受け取り可能)、2：獲得済み
    public static int[] tasseiFlgS = new int[9];      //*【週間】条件達成時(報酬獲得可能になった時点)に書き換える　0：未達成、1：達成(受け取り可能)、2：獲得済み
    public static int[] tasseiFlgE = new int[6];      //*【イベント】条件達成時(報酬獲得可能になった時点)に書き換える　0：未達成、1：達成(受け取り可能)、2：獲得済み
    //所持数関係
    public static int[] itemSyojisu = new int[20];　　//*各種アイテム所持数
    public static int[] isyoSyojiFlg = new int[60];　 //*衣装所持/未所持を判別

    //以下、DB管理しないstatic変数
    public static int tansakuKyara = 0;        //どのキャラのイベントを開始させるかの判断基準にする
    public static string kaiwaNo = "";         //会話No(開始させる会話のNoを保管。※例：naoko1)
    public static int hyoujimaku = 1;     //ランナー設定画面で表示中の幕を一時的に保管(セッティング→ランナーの切り替え時に使用)
    public static int[] gacha10 = new int[10]; //ガチャ演出表示用
    public static int gachaFlg = 0;            //ガチャが単発か10連か判断(単発の場合「1」、10連の場合「2」)
    public static int shinaidoWho = 0;         //誰の親愛度を確認しているかを管理するフラグ
    public static int kakuninchuFlg = 0;       //親愛度確認画面等、探索以外からシナリオを視聴していることを示すフラグ
    //固定値
    //各衣装の美しさステータスを格納
    private static int[] bi = { 3, 3, 8, 8, 16, 0, 0, 0, 0, 0, 1, 1, 2, 2, 4, 0, 0, 0, 0, 0, 3, 3, 7, 7, 14, 0, 0, 0, 0, 0, 2, 2, 5, 5, 10, 0, 0, 0, 0, 0, 3, 3, 6, 6, 12, 0, 0, 0, 0, 0, 2, 2, 4, 4, 6, 0, 0, 0, 0, 0 };
    //各衣裳のユーモア性ステータスを格納
    private static int[] hu = { 1, 1, 2, 2, 4, 0, 0, 0, 0, 0, 3, 3, 8, 8, 16, 0, 0, 0, 0, 0, 1, 1, 3, 3, 6, 0, 0, 0, 0, 0, 2, 2, 5, 5, 10, 0, 0, 0, 0, 0, 1, 1, 4, 4, 8, 0, 0, 0, 0, 0, 2, 2, 6, 6, 14, 0, 0, 0, 0, 0 };

    public int[] GetBi  //public 戻り値 プロパティ名
    {
        get { return bi; } //get {return フィールド名;}
        //set { bi = value; } //set {フィールド名 = value;}
    }
    public int[] GetHu  //public 戻り値 プロパティ名
    {
        get { return hu; } //get {return フィールド名;}
    }

    //※runner[]の初期値を-1にする処理を、画面遷移スクリプト(gamenseni.cs)の中で実装済み
}
