using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    //ID
    public int mapID { get; set; }
    //タイル（実体）の二次元リスト
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
        return tiles[x][y].GetComponent<Tile>().Entity.canEnter;
    }

    /// <summary>
    /// 指定された位置の情報（タイルクラス）を返す
    /// </summary>
    public Tile GetTile(int x, int y)
    {
        return tiles[x][y].GetComponent<Tile>();
    }

    /// <summary>
    /// 指定された位置のにあるタイルの中央位置を返す
    /// </summary>
    public Vector3 GetRealPosition(int x, int y)
    {
        return tiles[x][y].transform.position;  
    }

}
