using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : AActor,IActor {

    //生成時にオーナーとコントローラを設定
    public EnemyAI(GameManager owner, UnitManager unitManager, MapContoroller mapCon, UnitController unitCon)
    {
        this.init(owner, unitManager, mapCon, unitCon);
    }

    public void Update()
    {
        //ユニットリストの上から順に行動
        foreach (Unit u in unitList)
        {
            //ユニットから一番近いユニットの位置を取得
            Unit nearestEnemy = unitManager.getNearestEnemy(u);
            Vector3 v = nearestEnemy.position;

            //ユニットを指定位置の近くまで移動させる
            unitCon.Move(u, v);
            //攻撃可能なら攻撃させる
            if (unitCon.CanTargetAttack(u, nearestEnemy))
            {
                unitCon.Attack(u, nearestEnemy, 0);
            }

        }
    }

    void init()
    {

    }

    void TurnStart()
    {

    }

    void TurnEnd()
    {

    }
}
