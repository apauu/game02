using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour
{

    public int mapID { get; set; }

    //タイルの二次元リストを持つ
    public List<List<GameObject>> tiles { get; set; }

    public void init (int mapID, List<List<GameObject>> tiles)
    {
        this.mapID = mapID;
        this.tiles = tiles;
    }

    /// <summary>
    /// 指定された位置が進行可能か返す
    /// </summary>
    public bool CanEnter(int x, int y)
    {
        return tiles[x][y].GetComponent<Tile>().canEnter;
    }

    /// <summary>
    /// 指定された位置の情報（タイルクラス）を返す
    /// </summary>
    public Tile GetTile(int x, int y)
    {
        return tiles[x][y].GetComponent<Tile>();
    }

}
