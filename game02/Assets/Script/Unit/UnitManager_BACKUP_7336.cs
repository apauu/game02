using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : SingletonMonoBehaviour<UnitManager>{

    private  int sequenceCharacterNumber = 0;
    private GameObject unitObj;
    public int currentSelectAttackKind { get; set; }
    public Unit currentSelectUnit { get;  private set; }
    public Unit selectEnemyUnit { get; set; }

    //マップ上の全ユニットリスト
    List<Unit> unitList;
    //マップ上の全ユニットリスト
    List<UnitController> uniconList = new List<UnitController>();

    //初期化
    public UnitManager()
    {
    }

    //ユニット生成処理
    //陣営設定あり
    public GameObject GenerateUnit(GameObject prefUnit, int ally, int x, int y)
    {
        GenerateUnit(prefUnit);
        currentSelectUnit.ally = ally;
        PlaceUnit(unitObj, x , y);
        unitObj.AddComponent<BoxCollider>();

        return unitObj;

    }

    //ユニット生成処理
    //ユニットのステータス初期化等を踏まえ、Generatorクラスに移行予定
    public GameObject GenerateUnit(GameObject prefUnit)
    {
        //現在はユニットIDは使わずに素の状態のユニットを作成する
        //GameObject prefUnit = null;
        unitObj = (GameObject)Instantiate(prefUnit, new Vector3(0, 0, 0), Quaternion.identity);
        unitObj.AddComponent<Unit>();
        unitObj.AddComponent<UnitController>();
        //Unitの初期化
        //TODO:ユニットIDを取得/設定する仕組みを作ること
        currentSelectUnit = unitObj.GetComponent<Unit>();
        currentSelectUnit.InitUnit(GetSequenceNumber.SequenceNumber(sequenceCharacterNumber), "1");

        //生成したユニットを配置する
        //暫定的に位置[5,5]に配置する
        //PlaceUnit(unitObj, 5, 5);

        return unitObj;

    }

    //テスト用ユニット生成メソッド
    public void GenerateUnitsTest(AActor actor)
    {
        //テスト用ゴブリン生成
        UnitGenerator ug = new UnitGenerator();
        GameObject unitObj = GenerateUnit(ug.getTestUnitPrefab(UnitConst.UnitID1));
        UnitController unicon = unitObj.GetComponent<UnitController>();
        uniconList.Add(unicon);

    }

    //プレイヤー単位のユニット生成メソッド
    public void GenerateAactorUnits(AActor actor)
    {

        //プレーヤーからユニット情報を取得して配置する
        foreach (Unit u in actor.unitList)
        {
            //プレハブを元に生成ではなくユニットクラスを元に生成？
            //GenerateUnit(u);
        }

    }

    //生成されたユニットを配置する
    public bool PlaceUnit(GameObject unitObj, int x, int z)
    {

        //配置場所のチェック
        //MapController mapcon = new MapController(); //MapControllerはマネージャより取得する

        //if (mapcon.CanEnter(x,y)
        //    || UnitManager.CheckPosition(gamePosition))
        //{
        //    //その位置が進行不可でないことを確認する
        //    //その位置にユニットがいないことを確認する
        //    //位置が使えない場合エラーとなる
        //    return false;
        //}

        //移動先のタイル位置を取得する
        MapController mapcon = MapController.Instance;
        Vector3 rpos = mapcon.GetRealPosition(x, z);//タイルの中央位置

        //ユニットの実際の位置を設定する
        rpos.y = unitObj.transform.position.y;
        unitObj.transform.position = rpos;

        //ユニットのゲーム上の位置を設定する
        currentSelectUnit.position = new Vector3((float)x, 0, (float)z);


        return true;
    }
    
    //指定プレイヤーのユニットで未行動のものがいるか確認
    public bool CanMoveUnit(AActor actor)
    {
        int ally = actor.ally;

        foreach(Unit u in unitList)
        {
            if (u.ally == ally)
            {
                //ユニットが行動可能ならtrue
                if(u.active)
                {
                    return true;
                }
            }
        }

        return false;
    }

    //指定プレイヤーのユニットの数を返す
    public int getUnitCount(AActor actor)
    {
        int cnt = 0;
        int ally = actor.ally;

        foreach (Unit u in unitList)
        {
            if (u.ally == ally)
            {
                cnt++;
            }
        }

        return cnt;
    }

    //指定ユニットから一番近い指定陣営のユニットを取得する
    public Unit getNearestEnemy(Unit u)
    {
        return getNearestUnit(u, -1);
    }

    //指定ユニットから一番近い指定陣営のユニットを取得する
    public Unit getNearestFriend(Unit u)
    {
        return getNearestUnit(u, u.ally);
    }

    //指定ユニットから一番近い指定陣営のユニットを取得する
    //陣営が-1の場合、味方以外の陣営を探す
    //指定陣営のユニットがいない場合自身を返す
    public Unit getNearestUnit(Unit myUnit, int ally)
    {
        Unit nearestUnit = myUnit;

        //距離
        int nowDist = 100;

        foreach (Unit u in unitList)
        {
            if (!(ally != -1 && u.ally == ally)
                || (ally == -1 && u.ally != myUnit.ally))
            {
                //前のユニットより近い場合
                int dist = (int)(Mathf.Abs(u.position.x - myUnit.position.x) + Mathf.Abs(u.position.y - myUnit.position.y));
                if (nowDist > dist)
                {
                    nowDist = dist;
                    nearestUnit = u;
                }
            }
        }

        return nearestUnit;
    }

    /// <summary>
    /// ユニット選択時のアクション。テスト用
    /// </summary>
    public void selectUnitTest(GameObject unitObj)
    {
        UnitController unicon = unitObj.GetComponent<UnitController>();
        Unit unit = unicon.GetIndividualUnit();

        currentSelectUnit = unit;
    }

    /// <summary>
<<<<<<< HEAD
    /// 選択中のユニットを変更する
    /// オブサーバー通知あり
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    public GameObject SetCurrentSelectUnit(GameObject unitObj)
    {
        this.unitObj = unitObj;
        NotifyObservers(this.unitObj);

        return unitObj;
    }

    #region observer用

    private ArrayList observers = new ArrayList();

    // Observerを追加します。
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    // Observerを削除します。
    public void DeleteObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    /// <summary>
    /// Observerへ通知します。
    /// </summary>
    public void NotifyObservers(GameObject obj)
    {
        foreach (IObserver observer in observers)
            observer.Update(obj);
    }
    #endregion
=======
    /// 戦闘予測を実施する
    /// </summary>
    /// <param name="selectedUnit">選択キャラクターのユニットクラス</param>
    /// <param name="enemyUnit">敵キャラクターのユニットクラス</param>
    public void PreBattle(Unit selectedUnit,Unit enemyUnit)
    {
        BattleCalc.BattleCalculation(selectedUnit,enemyUnit,new Skill());
    }

>>>>>>> 71aa5aa7ea85926f960aa3daff44607ab4096b7a
}
