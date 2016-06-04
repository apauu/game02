using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Map,Tileクラスを生成・管理するクラス
/// Singletonクラス
/// </summary>
public class MapController : SingletonMonoBehaviour<MapController>
{

    GameObject myMap;
    //Dictionary<int, Map> mapList;
    public GameObject prefMap { get; set; }
    public GameObject prefPlaneTile { get; set; }

    public MapController()
    {

    }

    /// <summary>
    /// 指定されたマップを読み込み生成する
    /// </summary>
    public bool GenerateMap (int mapID)
    {
        try
        {
            prefMap = new GameObject();
            prefMap.name = MapConst.MapName1;
            prefMap.AddComponent<Map>();
            prefPlaneTile = GetResource.GetGameObjectFromResource(GameObjectNameConst.TexturePath + GameObjectNameConst.PlaneTilePrefab);

            /*
            マップIDより取得したマップファイルを読み込み、
            タイルID配列を取得する
            */
            int[][] tileIDArray;
            tileIDArray = loadMapFile(mapID);

            //マップオブジェクト(空オブジェクト)を作成
            myMap = Instantiate(prefMap, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            //タイルの実体を作成
            List<List<GameObject>> tiles = CreateTiles(tileIDArray);

            //マップクラスに配列を格納
            Map map = myMap.GetComponent<Map>();
            map.init(mapID, tiles);

            //マップリストにマップを登録
            //mapList.Add(mapID,map);

            //マップ生成成功
            return true;

        }
        catch (Exception e)
        {
            //マップ生成失敗
            return false;
        }

    }

    /// <summary>
    /// 現在のマップインスタンスを返す
    /// </summary>
    public Map GetMap()
    {
        return myMap.GetComponent<Map>();
    }

    /// <summary>
    /// 指定された位置が進行可能か返す
    /// </summary>
    public bool CanEnter(int x ,int y)
    {
        //return myMap.GetComponent<Map>().CanEnter((int)vec.x, (int)vec.y);
        return myMap.GetComponent<Map>().CanEnter(x, y);
    }

    /// <summary>
    /// 指定された位置の情報（タイル）を返す
    /// </summary>
    public Tile GetTile(int x, int y)
    {
        //return myMap.GetComponent<Map>().GetTile((int)vec.x, (int)vec.y);
        return myMap.GetComponent<Map>().GetTile(x, y);
    }

    /// <summary>
    /// 指定された位置のにあるタイルの中央位置を返す
    /// </summary>
    public Vector3 GetRealPosition(int x, int y)
    {
        return myMap.GetComponent<Map>().GetRealPosition(x, y);
    }

    /// <summary>
    /// タイルクリック時のコールバック関数
    /// </summary>
    /// <param name="t">クリックされたマスのタイルクラス</param>
    public void onClickUnit(Tile t)
    {
        //ユニットマネージャへクリック処理を渡す
        //UnitManager um = UnitManager.Instance;
        //um.DoCommand(t);
    }


    #region マップ生成用独自メソッド

    #region マップIDよりマップ情報を読み込む
    /// <summary>
    /// マップIDよりマップ情報を読み込む
    /// </summary>
    /// <param name="mapID"></param>
    /// <returns></returns>
    private int[][] loadMapFile(int mapID)
    {
        int[][] tileIDArray = null;

        //マップIDよりマップファイル名を取得する

        //マップファイルよりX,Y長を取得して配列を初期化する
        tileIDArray = new int[30][];
        for (int i = 0; i < tileIDArray.Length; ++i)
            tileIDArray[i] = new int[20];


        //マップファイルよりID配列を取得する

        //暫定的にオンコーディングでマップ情報を記述する
        //Array.Resize(ref tileIDArray, 10);
        //30*20の平原マップを作成
        for (int x = 0; x < 30; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                tileIDArray[x][y] = MapConst.Plains;
            }
        }


        return tileIDArray;

    }
    #endregion

    #region タイルID配列よりタイルの実体を生成する
    /// <summary>
    /// タイルID配列よりタイルの実体を生成する
    /// </summary>
    /// <param name="tileIDArray"></param>
    /// <returns></returns>
    private List<List<GameObject>>  CreateTiles(int[][] tileIDArray)
    {
        //【tileIDArray内容未使用】
        List<List<GameObject>> tiles = new List<List<GameObject>>();

            for (int x = 0; x < tileIDArray.Length; x++)
        {
            tiles.Add(new List<GameObject>());
            for (int y = 0; y < tileIDArray[0].Length; y++)
            {
                GameObject obj = Instantiate(prefPlaneTile, new Vector3(x,MapConst.BaseY,y), Quaternion.identity) as GameObject;
                //タイル毎に個別の値（位置情報等）を持たせたい場合はここで設定する
                Tile t = obj.GetComponent<Tile>();
                obj.transform.parent = myMap.transform;
                tiles[x].Add(obj);

                //タイルクリック用にコリダーとコールバック関数を設定
                obj.AddComponent<BoxCollider>();
                t.callbackOnMouseDown = onClickUnit;

            }
        }

        return tiles;
    }
    #endregion

    #endregion
}
