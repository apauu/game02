using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 戦闘計算クラス.
/// 
/// 攻撃時の命中判定、ダメージ計算を行い
/// 内部変数に保存する。
/// 利用する際はBattleCalculationのみを呼び出した後、必要な変数を取得すること
/// </summary>
public static class BattleCalc{

    /// <summary>
    /// ランダム計算に利用される定数（100以下）.
    /// </summary>
    private const int CalcNum100 = 100;
    /// <summary>
    /// ランダム計算に利用される（20以下）.
    /// </summary>
    private const int CalcNum20 = 20;

    /// <summary>
    /// 基本命中率.
    /// </summary>
    static int baseHitRate;
    /// <summary>
    /// 最小命中率.
    /// </summary>
    static int minHitRate;
    /// <summary>
    /// 最大命中率.
    /// </summary>
    static int maxHitRate;
    /// <summary>
    /// 命中判定.
    /// 
    /// 成功:true 失敗:false
    /// </summary>
    static bool isHit;
    /// <summary>
    /// 最低ダメージ.
    /// </summary>
    static int minPredictDamage;
    /// <summary>
    /// 基準ダメージ.
    /// </summary>
    static int basePredictDamage;
    /// <summary>
    /// 最大ダメージ.
    /// </summary>
    static int maxPredictDamage;
    /// <summary>
    /// ダメージ.
    /// </summary>
    static int damage;



    /// <summary>
    /// 戦闘計算.
    /// 
    /// 選ばれたskillによりダメージ計算、命中率を計算する
    /// </summary>
    /// <param name="selectUnit"></param>
    /// <param name="enemyUnit"></param>
    /// <param name="selectSkill"></param>
    static void BattleCalculation(Unit selectUnit,Unit enemyUnit,Skill selectSkill)
    {

        switch (selectSkill.attribute)
        {
            //物理攻撃
            case SkillConst.SkillKindIsPhysicalAttack:
                //命中計算
                HitPredictCalc((int)System.Math.Round(selectUnit.currentHit * selectSkill.hit), enemyUnit.currentAvoid);
                //ダメージ計算
                DamagePredictCalc(selectUnit.currentAtk, enemyUnit.currentDef, TypeJudge(selectUnit.type, enemyUnit.type), selectSkill.power);
                break;
            //魔法攻撃
            case SkillConst.SkillKindIsMagicAttack:
                //命中計算
                HitPredictCalc((int)System.Math.Round(selectUnit.currentHit * selectSkill.hit), enemyUnit.currentAvoid);
                //ダメージ計算
                DamagePredictCalc(selectUnit.currentMagic, enemyUnit.currentDef, TypeJudge(selectUnit.type, enemyUnit.type), selectSkill.power);
                break;
            //デバフ
            case SkillConst.SkillKindIsDeBuff:
                //命中計算
                HitBuffPredictCalc((int)System.Math.Round(selectUnit.currentHit * selectSkill.hit), enemyUnit.currentAvoid, TypeJudge(selectUnit.type, enemyUnit.type));
                break;
            //バフ
            case SkillConst.SkillKindIsBuff:
                //命中計算
                HitBuffPredictCalc((int)System.Math.Round(selectUnit.currentHit * selectSkill.hit), enemyUnit.currentAvoid, TypeJudge(selectUnit.type, enemyUnit.type));
                break;
            //回復
            case SkillConst.SkillKindIsHeal:
                //命中計算
                HitBuffPredictCalc((int)System.Math.Round(selectUnit.currentHit * selectSkill.hit), enemyUnit.currentAvoid, TypeJudge(selectUnit.type, enemyUnit.type));
                //ダメージ計算
                DamagePredictCalc(selectUnit.currentMagic, enemyUnit.currentDef, TypeJudge(selectUnit.type, enemyUnit.type), selectSkill.power);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// 戦闘計算初期化処理.
    /// 
    /// 戦闘に使われるダメージなどを初期化する。基本値=0
    /// </summary>
    private static void initCalc()
    {
        baseHitRate = 0;
        minHitRate = 0;
        maxHitRate = 0;
        isHit = false;
        minPredictDamage = 0;
        maxPredictDamage = 0;
        damage = 0;
    }

    /// <summary>
    /// 命中率判定(攻撃).
    /// 
    /// ランダム値(1~1.2)*(100+命中-回避)（％）により計算される
    /// </summary>
    /// <param name="selectHit">選択キャラの命中値</param>
    /// <param name="enemyAvoid">相手キャラの回避値</param>
	private static void HitPredictCalc(int selectHit, int enemyAvoid)
    {
        baseHitRate = 100 + selectHit - enemyAvoid;
        minHitRate = (int)System.Math.Round(baseHitRate * 0.8);
        maxHitRate = baseHitRate;
        //実際の命中判定　予測計算時に同時に計算しておく
        IsHit();
    }

    /// <summary>
    /// 命中率判定(バフ、デバフ、回復).
    /// 
    /// ランダム値(1~1.2)*(100+(命中*特攻値)-回避)（％）により計算される
    /// </summary>
    /// <param name="selectHit"></param>
    /// <param name="enemyAvoid"></param>
    /// <param name="special"></param>
    private static void HitBuffPredictCalc(int selectHit, int enemyAvoid, double special)
    {
        baseHitRate = (int)System.Math.Round((100 + selectHit * special) - enemyAvoid);
        minHitRate = (int)System.Math.Round(baseHitRate * 0.8);
        maxHitRate = baseHitRate;
        //実際の命中判定　予測計算時に同時に計算しておく
        IsHit();
    }

    /// <summary>
    /// 攻撃予測.
    /// 
    /// ランダム値(1~1.2)*((攻撃力or呪力*特攻値*技倍率)-防御力)
    /// </summary>
    /// <param name="attackNum">攻撃力or呪力</param>
    /// <param name="diffenceNum">防御力</param>
    /// <param name="power">技倍率</param>
    private static void DamagePredictCalc (int attackNum, int diffenceNum,double special,double power) {
        //基準ダメージ計算
        basePredictDamage = (int)System.Math.Round((attackNum * special * power) - diffenceNum);
        //最小ダメージ計算
        minPredictDamage = basePredictDamage;
        //最大ダメージ計算
        maxPredictDamage = (int)System.Math.Round(basePredictDamage * 1.2);

        //実際ダメージ計算　予測計算時に同時に計算しておく
        DamageCalc();

    }

    /// <summary>
    /// 実際のダメージ計算.
    /// </summary>
    private static void DamageCalc()
    {
        //ダメージ計算　基本攻撃力からランダム値を考慮して計算
        damage = (int)basePredictDamage * (1+RundomNumberGenerator.GetRundomNumber(CalcNum20)/100);
    }

    /// <summary>
    /// 命中判定.
    /// 
    /// 1*(100+命中-回避)（％）により計算される
    /// </summary>
    private static void IsHit()
    {
        if(baseHitRate * (1 - RundomNumberGenerator.GetRundomNumber(CalcNum20)/100) > RundomNumberGenerator.GetRundomNumber(CalcNum100))
        {
            isHit = true;
        } else
        {
            isHit = false;
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="selectType"></param>
    /// <param name="enemyType"></param>
    /// <returns></returns>
    private static double TypeJudge(int selectType,int enemyType)
    {
        return 1.2;
    }
}
