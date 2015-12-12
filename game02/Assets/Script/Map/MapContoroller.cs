using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Tileクラスを生成・管理するクラス
/// </summary>
public class MapContoroller :MonoBehaviour{

    int defaultMap;
    Dictionary<int, Map> mapList;
    public Transform myPlaneTile { get; set; }

    /// <summary>
    /// 指定されたマップを読み込み生成する
    /// </summary>
    public bool GenerateMap (int mapID)
    {
        try
        {
            /*
            マップIDより取得したマップファイルを読み込み、
            タイルID配列を取得する
            */
            int[][] tileIDArray;
            tileIDArray = loadMapFile(mapID);

            //タイルの二次元配列を作成
            List<List<Tile>> tiles = createTiles(tileIDArray);

            //IDとタイルデータからマップインスタンス生成
            Map map = new Map(mapID, tiles);
            mapList.Add(mapID,map);
            defaultMap = mapID;

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
    /// 指定された位置が進行可能か返す
    /// </summary>
    public bool CanEnter(Vector2 vec)
    {
        return mapList[defaultMap].CanEnter((int)vec.x, (int)vec.y);
    }

    /// <summary>
    /// 指定された位置の情報（タイル）を返す
    /// </summary>
    public Tile GetTile(Vector2 vec)
    {
        return mapList[defaultMap].GetTile((int)vec.x, (int)vec.y);
    }

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

    //タイルIDよりタイルクラスの二次元配列を作成
    private List<List<Tile>>  createTiles(int[][] tileIDArray)
    {
        List<List<Tile>> tiles = new List<List<Tile>>();

        //セルの数だけタイルを作る
        Vector2 pos = new Vector2(0, 0);
        Vector3 realPos = new Vector3(0, 0, 0);
        Tile tile;
        for (int x = 0; x < tileIDArray.Length; x++)
        {
            tiles.Add(new List<Tile>());
            for (int y = 0; y < tileIDArray[0].Length; y++)
            {
                myPlaneTile.c
                UnityEngine.Object obj = Instantiate(myPlaneTile, new Vector3(x,MapConst.BaseY,y), new Quaternion(0,0,0,0));
                obj.
                //tile = new Tile(MapConst.Plains, pos, realPos);
                //[x].Add(tile);
            }
        }

        return tiles;
    } 
}
