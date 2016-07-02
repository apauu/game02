using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// 個別のユニットを管理するクラス
/// </summary>
public partial class UnitManager
{

    /// <summary>
    /// ユニットクラス
    /// </summary>
    private Unit individualUnit;

    ///// <summary>
    ///// コンストラクタ
    ///// </summary>
    //public UnitController()
    //{
    //}

    ///// <summary>
    ///// コンストラクタ
    ///// シーケンスNo、ユニットIDから初期化処理を行う
    ///// </summary>
    //public UnitController(string sequenceNo,string unitId)
    //{
    //    //ユニットの初期化
    //    //individualUnit = new Unit(sequenceNo,unitId);
    //}


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

    #region 経験値関連
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
    #endregion

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


    #region 保持データの更新

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
    #endregion

    #region 移動
    /// <summary>
    /// 選択中のユニットが移動できれば、指定位置に移動させる
    /// </summary>
    /// <param name="position">移動先</param>
    public void MoveCurrentUnit(Vector2 location)
    {
        //移動力取得
        int mobi = currentSelectUnit.currentMobility;
        Vector2 nowLoc = currentSelectUnit.location;

        if(this.CanMoveToLocation(mobi, location, nowLoc))
        {
            PlaceUnit(unitObj,(int)location.x, (int)location.y);

        }
    }

    /// <summary>
    /// 現在位置から指定位置まで移動可能ならtrue
    /// </summary>
    /// <param name="mobility"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    private bool CanMoveToLocation(int mobility, Vector2 from, Vector2 to)
    {
        int horizon = (int)(to.x - from.x);
        int vertical = (int)(to.y - from.y);

        int distance = Math.Abs(horizon) + Math.Abs(vertical);

        return distance > mobility;
    }
    #endregion

    #region ユニット対象行動

    #region 攻撃
    /// <summary>
    /// 選択中のユニットに攻撃行動をさせる
    /// </summary>
    /// <param name="targetUnit">相手ユニット</param>
    /// <param name="skillNo">行動ユニットのスキル番号</param>
    /// <return>結果</return>
    public bool Attack(Unit targetUnit, int skillNo)
    {

        //攻撃が届く場合攻撃
        if (ReachAttack(targetUnit, skillNo))
        {

            return true;

        }

        return false;
    }

    /// <summary>
    /// サポートスキルが届くかどうか
    /// </summary>
    /// <param name="targetUnit"></param>
    /// <returns></returns>
    public bool ReachSupport(Unit targetUnit, int skillNo)
    {
        return CanTarget(currentSelectUnit, targetUnit, skillNo, false);
    }

    /// <summary>
    /// 攻撃スキルが届くかどうか
    /// </summary>
    /// <param name="targetUnit"></param>
    /// <returns></returns>
    public bool ReachAttack(Unit targetUnit, int skillNo)
    {
        return CanTarget(currentSelectUnit, targetUnit, skillNo, true);
    }
    /// <summary>
    /// 行動範囲に対象がいるかチェック
    /// </summary>
    /// <param name="myUnit">行動するユニット</param>
    /// <param name="targetUnit">相手ユニット</param>
    /// <param name="skillNo">使用スキル</param>
    /// <param name="attack">行動が攻撃ならtrue、補助ならfalse</param>
    private bool CanTarget(Unit myUnit, Unit targetUnit, int skillNo, bool attack)
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
        List<Vector3> atkArea = GetSkillArea(myUnit, skillNo);
        if (atkArea.Count == 0)
        {
            return false;
        }

        //攻撃範囲の中に敵ユニットがいるかチェック
        //いる場合true
        foreach (Vector2 loc in atkArea)
        {
            if (targetUnit.location.Equals(loc))
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    /// <summary>
    /// 行動範囲を取得
    /// </summary>
    /// <param name="myUnit">行動するユニット</param>
    /// <param name="skillNo">使用スキル</param>
    private List<Vector3> GetSkillArea(Unit myUnit, int skillNo)
    {
        HashSet<Vector3> skillArea = new HashSet<Vector3>();

        //使用するスキルを取得
        Skill skill = currentSelectUnit.skills[skillNo];
        int range = skill.range;

        //範囲攻撃なら範囲攻撃の射程を足す
        if (skill.area)
        {
            range =+ skill.areaRange;
        }

        //自身を起点としたエリアをリストにして返す
        Vector2 v = myUnit.location;

        for(int x = 0; x > range; x++)
        {
            for (int y = 0; y > range; y++)
            {
                v = new Vector3(myUnit.location.x + (float)x, myUnit.location.y + (float)y);
                skillArea.Add(v);
                v = new Vector3(myUnit.location.x - (float)x, myUnit.location.y + (float)y);
                skillArea.Add(v);
                v = new Vector3(myUnit.location.x + (float)x, myUnit.location.y - (float)y);
                skillArea.Add(v);
                v = new Vector3(myUnit.location.x - (float)x, myUnit.location.y - (float)y);
                skillArea.Add(v);
            }
        }

        return skillArea.ToList();
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
    #endregion

    #region　ユニットクリック時デリゲート ユニット自体にクリックイベントを付ける場合使う
    /// <summary>
    /// デリゲート用
    /// </summary>
    public delegate void DelegateFunc();
    public DelegateFunc callbackOnMouseDown = null;

    /// <summary>
    /// ユニットクリック時のデリゲートイベント
    /// </summary>
    void OnMouseDown()
    {
        if (callbackOnMouseDown != null) callbackOnMouseDown();
        
        ////ユニットマネージャの選択中ユニットを変更する
        //UnitManager um = UnitManager.Instance;
        SetCurrentSelectUnit(this.gameObject);
    }
    #endregion
}
