using UnityEngine;
using System.Collections;

public class Player : AActor, IActor
{
    //生成時にオーナーとコントローラを設定
    public Player(GameManager owner, UnitManager unitManager, MapContoroller mapCon, UnitController unitCon)
    {
        this.init(owner,unitManager, mapCon, unitCon);
    }

    //ゲーム開始前の準備動作
    public bool PreStart()
    {
        

        return true;
    }

    public void Update()
    {

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
