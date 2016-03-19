
/// <summary>
/// 装備の状態を保持するクラス。
/// </summary>
public class Weapon
{
    /// <summary>
    /// 装備ID
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 名前
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 攻撃力
    /// </summary>
    public int power { get; set; }

    public Weapon(string id, string name, int power)
    {
        this.id = id;
        this.name = name;
        this.power = power;
    }

}
