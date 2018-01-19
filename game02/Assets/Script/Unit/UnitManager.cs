using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class UnitManager : SingletonMonoBehaviour<UnitManager>{

    private  int sequenceCharacterNumber = 0;
    private GameObject unitObj;
    public int currentSelectAttackKind { get; set; }
    public Unit currentSelectUnit { get;  private set; }
    public Unit selectEnemyUnit { get; set; }

    /// <summary>
    /// マップ上の全ユニットリスト
    /// </summary>
    private List<Unit> unitList = new List<Unit>();
    //マップ上の全ユニットリスト
    //List<UnitController> uniconList = new List<UnitController>();

    #region ユニット生成（Generatorに移行予定）
    //ユニット生成処理
    //陣営設定あり
    public GameObject GenerateUnit(GameObject prefUnit, int ally, int x, int y)
    {
        GenerateUnit(prefUnit);
        currentSelectUnit.ally = ally;
        PlaceUnit(unitObj, x , y);

        //ユニット自体でクリック判定する場合必要
        //unitObj.AddComponent<BoxCollider>();

        return unitObj;

    }

    //ユニット生成処理
    //ユニットのステータス初期化等を踏まえ、Generatorクラスに移行予定
    public GameObject GenerateUnit(GameObject prefUnit)
    {
        //現在はユニットIDは使わずに素の状態のユニットを作成する
        //GameObject prefUnit = null;
        unitObj = (GameObject)Instantiate(prefUnit, new Vector3(0, 0, 0), Quaternion.identity);
        Unit u = unitObj.AddComponent<Unit>();
        //unitObj.AddComponent<UnitController>();
        
        //Unitの初期化
        //TODO:ユニットIDを取得/設定する仕組みを作ること
        currentSelectUnit = u;
        currentSelectUnit.InitUnit(GetSequenceNumber.SequenceNumber(sequenceCharacterNumber), "1");


        //ユニットリストに追加する
        unitList.Add(u);

        return unitObj;

    }

    //テスト用ユニット生成メソッド
    public void GenerateUnitsTest(AActor actor)
    {
        if(actor is Player)
        {
            //テスト用ゴブリン生成
            //UnitGenerator ug = new UnitGenerator();  //MonoBehaviourはnewで作成できない
            UnitGenerator ug = this.gameObject.AddComponent<UnitGenerator>();
            GameObject goblinPref = ug.getTestUnitPrefab(UnitConst.UnitID1);
            GameObject unitObj = GenerateUnit(goblinPref, actor.ally, 5, 5);
            //UnitController unicon = unitObj.GetComponent<UnitController>();
            //uniconList.Add(unicon);

        }
        else if(actor is EnemyAI)
        {
            UnitGenerator ug = this.gameObject.AddComponent<UnitGenerator>();
            GameObject goblinPref = ug.getTestUnitPrefab(UnitConst.UnitID1);
            GameObject unitObj = GenerateUnit(goblinPref, actor.ally, 5, 6);
        }
        else
        {
            Debug.Log("unknown actor");
        }

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

    #endregion

    #region ユニット配置
    /// <summary>
    /// 生成されたユニットを配置する
    /// </summary>
    /// <param name="unitObj"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool PlaceUnit(GameObject unitObj, int x, int y)
    {

        //配置場所のチェック
        MapController mc = MapController.Instance;

        //機能していない
        //if (!mc.CanEnter(x, y)
        //    || !CanPlace(new Vector2(x, y)))
        //{
        //    //その位置が進行不可能または
        //    //その位置にユニットがいる場合
        //    return false;
        //}

        //移動先のタイル位置を取得する
        Vector3 rpos = mc.GetRealPosition(x, y);//タイルの中央位置

        //ユニットの実際の位置を設定する
        rpos.y = unitObj.transform.position.y;
        unitObj.transform.position = rpos;

        //ユニットのゲーム上の位置を設定する
        Unit u = unitObj.GetComponent<Unit>();
        u.location = new Vector2(x, y);

        return true;
    }

    /// <summary>
    /// 指定位置にユニットが存在するかチェックする
    /// </summary>
    /// <param name="xy"></param>
    /// <returns></returns>
    private bool CanPlace(Vector2 xy)
    {
        
        foreach(Unit u in unitList)
        {

            //ユニットが配置されていたらfalse
            if (u.location == xy) return false;

        }

        return true;
    }
    #endregion

    #region　ユニット選択時処理

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
                int dist = (int)(Mathf.Abs(u.location.x - myUnit.location.x) + Mathf.Abs(u.location.y - myUnit.location.y));
                if (nowDist > dist)
                {
                    nowDist = dist;
                    nearestUnit = u;
                }
            }
        }

        return nearestUnit;
    }
    #endregion

    #region クリック用
    /// <summary>
    /// ユニット選択時のアクション。テスト用
    /// </summary>
    public void SelectUnitTest(GameObject unitObj)
    {
        //コントローラをマネージャ格に格上げにつきコメントアウト
        //UnitController unicon = unitObj.GetComponent<UnitController>();
        //Unit unit = unicon.GetIndividualUnit();

        Unit unit = unitObj.GetComponent<Unit>();

        currentSelectUnit = unit;
        SetCurrentSelectUnit(unitObj);

    }

    /// <summary>
    /// ユニット選択時のアクション。テスト用
    /// 何もいない場合はnullを返す
    /// </summary>
    public Unit SelectUnitTest(Vector2 vec)
    {

        //位置情報からユニットを探す
        Unit u = SearchUnit(vec);

        if(u != null)
        {
            //ユニットがいれば選択する
            currentSelectUnit = u;

            //オブサーバー通知。おそらく未使用。いらない？
            SetCurrentSelectUnit(u.gameObject);

            //メニューの表示を更新
            MenuManager mm = MenuManager.Instance;
            mm.UpdateCharacterMenuStatus(u);
        }

        return u;

    }

    /// <summary>
    /// 位置情報からユニットを探す
    /// 何もいない場合はnullを返す
    /// </summary>
    public Unit SearchUnit(Vector2 vec)
    {

        foreach(Unit u in unitList)
        {
            if(u.location == vec)
            {
                //指定位置にユニットがいれば返す
                return u;

            }
        }

        return null;

    }

    /// <summary>
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

    #endregion

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

    #region 戦闘関連
    /// 戦闘予測を実施する
    /// </summary>
    /// <param name="selectedUnit">選択キャラクターのユニットクラス</param>
    /// <param name="enemyUnit">敵キャラクターのユニットクラス</param>
    public void PreBattle(Unit selectedUnit,Unit enemyUnit)
    {
        BattleCalc.BattleCalculation(selectedUnit,enemyUnit,new Skill());
    }
    #endregion

}
