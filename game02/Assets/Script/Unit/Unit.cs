using UnityEngine;
using System.Collections;

/// <summary>
/// ユニットの状態を保持するクラス。
/// </summary>
public class Unit {

    public string name { get; set; }
    // 種族名
    public string type_name { get; set; }
    //種族属性　近接/遠距離/呪い
    public int type { get; set; }
    //陣営
    public int ally { get; set; }
    public int buff { get; set; }

    public int lvl { get; set; }
    public int exp { get; set; }

    public int mobility { get; set; }
    public int hp { get; set; }
    public int atk { get; set; }
    public int def { get; set; }
    public int dod { get; set; }
    public int hit { get; set; }


}
