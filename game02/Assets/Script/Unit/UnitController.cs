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
    public Unit individualUnit;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    /// <summary>
    /// コンストラクタ
    /// シーケンスNo、ユニットIDから初期化処理を行う
    /// </summary>
    public UnitController(string sequenceNo,string unitId)
    {
        //ユニットの初期化
        individualUnit = new Unit(sequenceNo,unitId);
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
    /// <param name="weaponID">武器ID</param>
    public void ChangeWeapon(string weaponID)
    {
        individualUnit.weaponId = weaponID;
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
}
