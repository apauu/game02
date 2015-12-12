using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map
{

    public int mapID { get; set; }

    //タイルの二次元リストを持つ
    public List<List<Tile>> tiles { get; set; }

    public Map (int mapID, List<List<Tile>> tiles)
    {
        this.mapID = mapID;
        this.tiles = tiles;
    }

    /// <summary>
    /// 指定された位置が進行可能か返す
    /// </summary>
    public bool CanEnter(int x, int y)
    {
        return tiles[x][y].canEnter;
    }

    /// <summary>
    /// 指定された位置の情報（タイル）を返す
    /// </summary>
    public Tile GetTile(int x, int y)
    {
        return tiles[x][y];
    }

}
