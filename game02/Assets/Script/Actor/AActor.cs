using UnityEngine;
using System.Collections.Generic;

public abstract class AActor : IActor
{
    public int cost { get; set; }
    public int ally { get; set; }
    public List<Unit> unitList { get; set; }

    //自身のオーナー（管理クラス）
    protected GameManager owner;
    //ユニット管理クラス
    protected UnitManager unitManager;

        
    //指示できるコントローラー
    protected MapContoroller mapCon;
    protected UnitController unitCon;

    //生成時にオーナーとコントローラを設定
    protected void init(GameManager owner, UnitManager unitManager, MapContoroller mapCon, UnitController unitCon)
    {
        this.owner = owner;
        this.unitManager = unitManager;
        this.mapCon = mapCon;
        this.unitCon = unitCon;
    }
    
    public void useCost(int value)
    {

    }
}
