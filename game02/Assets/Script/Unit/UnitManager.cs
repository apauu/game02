using UnityEngine;
using System.Collections;

public class UnitManager : MonoBehaviour{

    MapContoroller mapcon;

    //初期化
    public UnitManager(MapContoroller mapcon)
    {
        this.mapcon = mapcon;
    }

    //ユニット生成処理
    public GameObject GenerateUnit(GameObject prefUnit)
    {
        //現在はユニットIDは使わずに素の状態のユニットを作成する
        //GameObject prefUnit = null;
        GameObject unitObj = (GameObject)Instantiate(prefUnit, new Vector3(0, 0, 0), Quaternion.identity);
        unitObj.AddComponent<Unit>();

        //生成したユニットを配置する
        //暫定的に位置[5,5]に配置する
        PlaceUnit(unitObj, 15, 15);
        
        return prefUnit;

    }

    //生成されたユニットを配置する
    public bool PlaceUnit(GameObject unitObj, int x, int z)
    {
        //ユニットインスタンスを取得する
        Unit unit = unitObj.GetComponent<Unit>();

        //配置場所のチェック
        //MapContoroller mapcon = new MapContoroller(); //MapContorollerはマネージャより取得する

        //if (mapcon.CanEnter(x,y)
        //    || UnitManager.CheckPosition(gamePosition))
        //{
        //    //その位置が進行不可でないことを確認する
        //    //その位置にユニットがいないことを確認する
        //    //位置が使えない場合エラーとなる
        //    return false;
        //}

        //移動先のタイル位置を取得する
        Vector3 rpos = mapcon.GetRealPosition(x, z);//タイルの中央位置

        //ユニットの実際の位置を設定する
        rpos.y = unitObj.transform.position.y;
        unitObj.transform.position = rpos;

        //ユニットのゲーム上の位置を設定する
        unit.position = new Vector3((float)x, 0, (float)z);


        return true;
    }
}
