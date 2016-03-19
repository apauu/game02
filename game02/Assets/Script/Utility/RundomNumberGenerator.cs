using UnityEngine;
using System.Collections;

/// <summary>
/// ランダム変数生成クラス.
/// </summary>
public static class RundomNumberGenerator{

    /// <summary>
    /// ランダム変数生成.
    /// 
    /// 受け取った値+1未満の数値を返却する
    /// </summary>
    /// <param name="randomSet">生成したいランダム設定値</param>
    /// <returns></returns>
    public static int GetRundomNumber(int randomSet)
    {
        // Random クラスの新しいインスタンスを生成する
        System.Random cRandom = new System.Random();
        // 100未満の乱数を取得する
        int result = cRandom.Next(randomSet + 1);
        return result;
    }
}