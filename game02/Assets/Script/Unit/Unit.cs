using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ユニットの状態を保持するクラス。
/// </summary>
public class Unit : MonoBehaviour{
    /// <summary>
    /// シーケンスNo
    /// </summary>
    public int sequenceNo { get; set; }
    /// <summary>
    /// ユニットID
    /// </summary>
    public string unitId { get; set; }
    /// <summary>
    /// キャラクター名
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 種族名
    /// </summary>
    public string typeName { get; set; }
    /// <summary>
    /// 種族属性　近接/遠距離/呪い
    /// </summary>
    public int type { get; set; }
    /// <summary>
    /// 陣営
    /// </summary>
    public int ally { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int buff { get; set; }
    /// <summary>
    /// レベル
    /// </summary>
    public int lvl { get; set; }
    /// <summary>
    /// 現在経験値
    /// </summary>
    public int exp { get; set; }
    /// <summary>
    /// 現在移動量
    /// </summary>
    public int currentMobility { get; set; }
    /// <summary>
    /// 基本移動量
    /// </summary>
    public int baseMobility { get; set; }
    /// <summary>
    /// 現在妖力（HP）
    /// </summary>
    public int currentHp { get; set; }
    /// <summary>
    /// 基本バフ後妖力（HP）.
    /// バフを受けた後の最大HP
    /// </summary>
    public int baseChangeHp { get; set; }
    /// <summary>
    /// 基本妖力（HP）.
    /// バフ前の最大HP
    /// </summary>
    public int baseHp { get; set; }
    /// <summary>
    /// 現在攻撃力
    /// </summary>
    public int currentAtk { get; set; }
    /// <summary>
    /// 基本攻撃力
    /// </summary>
    public int baseAtk { get; set; }
    /// <summary>
    /// 現在守備力
    /// </summary>
    public int currentDef { get; set; }
    /// <summary>
    /// 基本守備力
    /// </summary>
    public int baseDef { get; set; }
    /// <summary>
    /// 現在回避力
    /// </summary>
    public int currentAvoid { get; set; }
    /// <summary>
    /// 基本回避力
    /// </summary>
    public int baseAvoid { get; set; }
    /// <summary>
    /// 現在命中力
    /// </summary>
    public int currentHit { get; set; }
    /// <summary>
    /// 基本命中力
    /// </summary>
    public int baseHit { get; set; }
    /// <summary>
    /// 現在呪力
    /// </summary>
    public int currentMagic { get; set; }
    /// <summary>
    /// 基本呪力
    /// </summary>
    public int baseMagic { get; set; }

    /// <summary>
    /// 武器
    /// </summary>
    public Weapon weapon { get; set; }

    /// <summary>
    /// 生死 true:生 false:死
    /// </summary>
    public bool living { get; set; }
    /// <summary>
    /// 行動可不可 true:可能 false:不可能
    /// </summary>
    public bool active { get; set; }
    /// <summary>
    /// 位置
    /// </summary>
    public Vector3 position;

    /// <summary>
    /// バフ・デバフ
    /// </summary>
    private Dictionary<string, int> buffDebuff = new Dictionary<string, int>();
    /// <summary>
    /// 所持スキル
    /// </summary>
    public List<Skill> skills = new List<Skill>();





    /// <summary>
    /// バフ、デバフを設定する
    /// </summary>
    /// <param name="buffDebuffId">バフ、デバフのID</param>
    /// <param name="lestTurn">残ターン数</param>
    public void SetBuffDebuff(string buffDebuffId, int lestTurn)
    {
        buffDebuff[buffDebuffId] = lestTurn;
    }

    /// <summary>
    /// バフ、デバフの辞書を返却する
    /// 返却された辞書をもとにバフの終了判定や毒ダメージなどを計算すること
    /// </summary>
    /// <param name="buffDebuffId"></param>
    /// <returns>バフ・デバフのID、残ターン数</returns>
    public Dictionary<string,int> GetBuffDebuff(string buffDebuffId)
    {
        return buffDebuff;
    }

    /// <summary>
    /// スキルを設定する
    /// </summary>
    /// <param name="lestTurn">残ターン数</param>
    public void SetSkill(Skill skill)
    {
        skills.Add(skill);
    }

    /// <summary>
    /// 指定の番号のスキルを返却する
    /// </summary>
    /// <returns>バフ・デバフのID、残ターン数</returns>
    public Skill GetSkill(int skillNo)
    {
        return skills[skillNo];
    }


    /// <summary>
    /// Unitクラスコンストラクタ
    /// 変数の初期化
    /// </summary>
    /// <param name="sequenceNO">ユニットシーケンスNO</param>
    /// <param name="unitID">ユニットID</param>
    public void InitUnit(int sequenceNO, string unitID)
    {
        //ステータスの初期化　ファイル読み込み？
        sequenceNo = sequenceNO;
        unitId = unitID;
        name = "noName";
        typeName = "noTypeName";
        type = 0;
        ally = 0;
        buff = 0;
        lvl = 1;
        exp = 1;
        baseMobility = 1;
        currentMobility = baseMobility;
        baseHp = 1;
        baseChangeHp = 2;
        currentHp = baseHp;
        baseAtk = 1;
        currentAtk = baseAtk;
        baseDef = 1;
        currentDef = baseDef;
        baseAvoid = 1;
        currentAvoid = baseAvoid;
        baseHit = 1;
        currentHit = baseHit;
        baseMagic = 1;
        currentMagic = baseMagic;
        living = true;
        active = true;

    }




}
