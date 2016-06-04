using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : AActor,IActor {

    //生成時にオーナーとコントローラを設定
    public EnemyAI()
    {
        gm = GameManager.Instance;
        mm = MenuManager.Instance;
        mc = MapController.Instance;
        um = UnitManager.Instance;
    }

    public void Update()
    {
        //ユニットリストの上から順に行動
        foreach (UnitController uc in unitList)
        {
            //ユニットから一番近いユニットの位置を取得
            Unit nearestEnemy = um.getNearestEnemy(u);
            Vector3 v = nearestEnemy.position;

            //ユニットを指定位置の近くまで移動させる
            uc.Move(u, v);
            //攻撃可能なら攻撃させる
            if (uc.CanTargetAttack(u, nearestEnemy))
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
