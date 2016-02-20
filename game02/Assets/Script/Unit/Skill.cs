using System.Collections.Generic;

/// <summary>
/// スキルの情報を保持するクラス
/// </summary>
public class Skill
{
    /// <summary>
    /// スキル名
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 攻撃力
    /// </summary>
    public int power { get; set; }
    /// <summary>
    /// 命中率
    /// </summary>
    public int hit { get; set; }
    /// <summary>
    /// 射程
    /// </summary>
    public int range { get; set; }
    /// <summary>
    /// 範囲属性　範囲：true 単体：false
    /// </summary>
    public bool area { get; set; }
    /// <summary>
    /// 貫通属性　貫通：true 非貫通：false
    /// </summary>
    public bool penetration { get; set; }
    /// <summary>
    /// 範囲射程
    /// </summary>
    public int areaRange { get; set; }
    /// <summary>
    /// 攻撃行動　攻撃：true 補助：false
    /// </summary>
    public bool attack { get; set; }
    /// <summary>
    /// 行動属性
    /// </summary>
    public int attribute { get; set; }
    /// <summary>
    /// 追加効果
    /// </summary>
    public Dictionary<string, int> addEffect { get; set; }

}
