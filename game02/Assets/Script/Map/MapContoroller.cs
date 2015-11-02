using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Tileクラスを生成・管理するクラス
/// </summary>
public class MapContoroller {

    public int mapID { get; set; }


    private List<List<Tile>> tiles;


    /// <summary>
    /// 指定されたマップを読み込み生成する
    /// </summary>
    public bool GenerateMap (int mapID)
    {
        try
        {
            // マップ初期化
            tiles = new List<List<Tile>>();

            Vector2 pos = new Vector2(0, 0);
            Vector3 realPos = new Vector3(0, 0, 0);
            Tile tile;
            int[][] tileIDArray;

            this.mapID = mapID;

            /*
            マップIDより取得したマップファイルを読み込み、
            タイルID配列を取得する
            */
            tileIDArray = loadMapFile(mapID);

            //セルの数だけタイルを作る
            for (int x = 0; x < tileIDArray.Length; x++)
            {
                tiles.Add(new List<Tile>());
                for (int y = 0; y < tileIDArray[0].Length; y++)
                {
                    tile = new Tile(MapConst.Plains, pos, realPos);
                    tiles[x].Add(tile);
                }
            }

            return true;

        }
        catch (Exception e)
        {
            return false;
        }

    }

    /// <summary>
    /// 指定された位置が進行可能か返す
    /// </summary>
    public bool CanEnterLocation(Vector2 vec)
    {
        return true;
    }

    /// <summary>
    /// 指定された位置の情報（タイル）を返す
    /// </summary>
    public Tile GetLocationInformation(Vector2 pos)
    {
        int x = (int)pos.x;
        int y = (int)pos.y;
        return tiles[x][y];
    }

    private int[][] loadMapFile(int mapID)
    {
        int[][] tileIDArray;

        //マップIDよりマップファイル名を取得する

        //マップファイルよりX,Y長を取得して配列を初期化する
        tileIDArray = new int[][] { };

        //マップファイルよりID配列を取得する


        return tileIDArray;

    }
}
