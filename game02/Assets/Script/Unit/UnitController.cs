using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// 個別のユニットを管理するクラス
/// </summary>
public class UnitController : MonoBehaviour {

    /// <summary>
    /// ユニットクラス
    /// </summary>
    private Unit individualUnit;

    /// <summary>
    /// デリゲート用
    /// </summary>
    public delegate void DelegateFunc();
    public DelegateFunc callbackOnMouseDown = null;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public UnitController()
    {
    }

    /// <summary>
    /// コンストラクタ
    /// シーケンスNo、ユニットIDから初期化処理を行う
    /// </summary>
    public UnitController(string sequenceNo,string unitId)
    {
        //ユニットの初期化
        //individualUnit = new Unit(sequenceNo,unitId);
    }


    /// <summary>
    /// 
    /// </summary>
    public void StartTurnInit()
    {

    }


    /// <summary>
    /// ユニットクラスを返却する
    /// </summary>
    /// <returns>ユニットクラス</returns>
    public Unit GetIndividualUnit()
    {
        return individualUnit;
    }


    /// <summary>
    /// 経験値を与える
    /// レベルアップ時はレベルアップ処理を呼び出す
    /// </summary>
    /// <param name="experience">経験値</param>
    /// <returns>レベルアップ上昇値</returns>
    public Dictionary<string,int> SetExperience(int experience)
    {
        int currentLev = individualUnit.lvl;
        if (currentLev < ExperienceConst.MaxLevel)
        {
            //次に必要な経験値を取得する
            int nextReauimentLvlExp = ExperienceConst.levelTable[individualUnit.lvl + 1];
            //現在の経験値を計算
            int currentExp = individualUnit.exp + experience;
            //現在の経験値を設定
            individualUnit.exp = currentExp;
            if (currentExp >= nextReauimentLvlExp)
            {
                //レベルが上がった回数分、レベルアップ処理呼び出し
                var key = ExperienceConst.levelTable.First(x => x.Value >= currentExp).Key;
                for(int i=0; i < key - currentLev;i++) {
                    LevelUp();
                }
                //レベルアップ前とアップ後を比較し、上昇値を設定する
                //TODO:未実装
                Dictionary<string, int> upstatus = new Dictionary<string, int>();
                upstatus.Add("呪力", 1);
                return upstatus;
            }
        }
        return null;
    }


    /// <summary>
    /// レベルアップ処理
    /// </summary>
    private void LevelUp()
    {
        Dictionary<string, int> upstatus = new Dictionary<string, int>();
        //レベルアップ処理
        individualUnit.lvl = individualUnit.lvl + 1;
        //レベルアップによるステータスの更新
        //TODO:未実装

    }


    /// <summary>
    /// 武器を変更する
    /// </summary>
    /// <param name="weaponID">装備ID</param>
    public void ChangeWeapon(string weaponID)
    {
        //武器を取得する
        WeaponGenerator wg = new WeaponGenerator();
        Weapon weapon = wg.getInstance(weaponID);

        individualUnit.weapon = weapon;
    }

    /// <summary>
    /// 基本HPの更新
    /// </summary>
    /// <param name="upHp">更新するHP差分</param>
    private void ChangeBaseHp(int upHp)
    {

    }

    /// <summary>
    /// 基本攻撃力の更新
    /// </summary>
    /// <param name="upAtk">更新する攻撃力差分</param>
    private void ChangeBaseAtk(int upAtk)
    {

    }

    /// <summary>
    /// 基本守備力の更新
    /// </summary>
    /// <param name="upDef">更新する守備力差分</param>
    private void ChangeBaseDef(int upDef)
    {

    }

    /// <summary>
    /// 基本回避力の更新
    /// </summary>
    /// <param name="upAvoid">更新する回避力差分</param>
    private void ChangeBaseAvoid(int upAvoid)
    {

    }

    /// <summary>
    /// 基本命中力の更新
    /// </summary>
    /// <param name="upHit">更新する命中力差分</param>
    private void ChangeBaseHit(int upHit)
    {

    }

    /// <summary>
    /// 基本呪力の更新
    /// </summary>
    /// <param name="upMagic">更新する呪力差分</param>
    private void ChangeBaseMagic(int upMagic)
    {

    }

    /// <summary>
    /// 基本移動量の更新
    /// </summary>
    /// <param name="upMobility">更新する移動量差分</param>
    private void ChangeBaseMobility(int upMobility)
    {

    }

    /// <summary>
    /// 生死の更新
    /// </summary>
    /// <param name="upLiving">生死フラグ</param>
    private void ChangeLiving(bool upLiving)
    {

    }

    /// <summary>
    /// 行動可不可の更新
    /// </summary>
    /// <param name="upActive">行動可能フラグ</param>
    private void ChangeActive(bool upActive)
    {

    }

    /// <summary>
    /// ユニットを指定位置に移動させる。未実装
    /// </summary>
    /// <param name="myUnit">行動するユニット</param>
    /// <param name="position">移動先</param>
    public void Move(Unit myUnit, Vector3 position)
    {
        //移動力取得
        int mobi = myUnit.currentMobility;
        Vector3 nowPos = myUnit.position;

        while(mobi > 0)
        {
            //移動力がなくなるまで縦と横を交互に移動
            Vector3 nextPos = position;
            //ユニットが次の移動先に侵入可能か判定
            //if ()
            //ユニットを移動させる
            myUnit.position = nextPos;

            mobi--;
        }
    }

    public bool CanTargetSupport(Unit myUnit, Unit targetUnit)
    {
        return CanTarget(myUnit, targetUnit, false);
    }

    public bool CanTargetAttack(Unit myUnit, Unit targetUnit)
    {
        return CanTarget(myUnit, targetUnit, true);
    }

    /// <summary>
    /// 行動範囲に対象がいるかチェック
    /// </summary>
    /// <param name="myUnit">行動するユニット</param>
    /// <param name="targetUnit">相手ユニット</param>
    /// <param name="attack">行動が攻撃ならtrue、補助ならfalse</param>
    public bool CanTarget(Unit myUnit, Unit targetUnit, bool attack)
    {
        //行動可能なユニットかチェック
        if (!myUnit.active)
        {
            return false;
        }

        //行動対象のユニットかチェック
        if (attack && myUnit.ally == targetUnit.ally)
        {
            return false;
        }
        if (!attack && myUnit.ally != targetUnit.ally)
        {
            return false;
        }

        //行動範囲を取得
        List<Vector3> atkArea = GetSkillArea(myUnit, attack);
        if (atkArea.Count == 0)
        {
            return false;
        }

        //攻撃範囲の中に敵ユニットがいるかチェック
        //いる場合true
        foreach (Vector3 v in atkArea)
        {
            if (targetUnit.position.Equals(v))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 行動範囲を取得
    /// </summary>
    /// <param name="myUnit">行動するユニット</param>
    /// <param name="attack">行動が攻撃ならtrue、補助ならfalse</param>
    public List<Vector3> GetSkillArea(Unit myUnit, bool attack)
    {
        HashSet<Vector3> skillArea = new HashSet<Vector3>();

        //対象となるすべてのスキルを取得する
        //foreach(Skill skill in myUnit.skills)
        //{

        //}
        Skill skill = new Skill();
        int range = 1;

        //範囲攻撃なら範囲攻撃の射程を足す
        if (skill.area)
        {
            range =+ skill.areaRange;
        }

        //自身を起点としたエリアをリストにして返す
        Vector3 v = myUnit.position;

        for(int x = 0; x > range; x++)
        {
            for (int y = 0; y > range; y++)
            {
                v = new Vector3(myUnit.position.x + (float)x, myUnit.position.y + (float)y);
                skillArea.Add(v);
                v = new Vector3(myUnit.position.x - (float)x, myUnit.position.y + (float)y);
                skillArea.Add(v);
                v = new Vector3(myUnit.position.x + (float)x, myUnit.position.y - (float)y);
                skillArea.Add(v);
                v = new Vector3(myUnit.position.x - (float)x, myUnit.position.y - (float)y);
                skillArea.Add(v);
            }
        }

        return skillArea.ToList();
    }

    /// <summary>
    /// 攻撃行動をする
    /// </summary>
    /// <param name="myUnit">行動するユニット</param>
    /// <param name="targetUnit">相手ユニット</param>
    /// <param name="skillNo">行動ユニットのスキル番号</param>
    public bool Attack(Unit myUnit, Unit targetUnit, int skillNo)
    {

        return true;
    }
    
    /// 攻撃・デバフのダメージ、命中率を計算する
    /// </summary>
    /// <param name="myUnit"></param>
    /// <param name="enemyUnit"></param>
    /// <param name="attackKind"></param>
    /// <returns></returns>
    public Dictionary<string,string> CalPreBattleResults(Unit myUnit, Unit enemyUnit,string attackKind)
    {
        //戦闘結果を保持する
        Dictionary<string,string> battlePreResults = new Dictionary<string, string>();


        return battlePreResults;
    }

    /// <summary>
    /// ユニットクリック時のデリゲートイベント
    /// </summary>
    void OnMouseDown()
    {
        if (callbackOnMouseDown != null) callbackOnMouseDown();
    }
}
