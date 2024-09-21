using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[SerializeField]

public class AkagonohateData : ScriptableObject
{
    public static int tutorealFlg = 1;    　　 //チュートリアルフラグ
    public static string playerNmaeT = "EKL";   //プレーヤー名
    public static int playerLvI = 1;           //プレイヤーLv
    public static int kenSyojiI = 0;           //仕立券総所持数
    public static int zeniSyojiI = 0;          //銭総所持数
}
