using UnityEngine;
using System.Collections;

/// <summary>
/// マップレイヤークラス
/// マップ上に半透明の領域を表示する
/// </summary>
public class MapLayer : MonoBehaviour {

    //半透明のタイルオブジェクト
    public GameObject prefLayerSquare { get; set; }
    //マップインスタンス
    public Map map { get; set; }

    private GameObject myMapLayer;
    private GameObject[,] squareArray;

    //初期化
    public void initialize(Map map, GameObject prefLayerSquare)
    {
        this.map = map;
        this.prefLayerSquare = prefLayerSquare;
        initialize();
    }

    //初期化
    public void initialize()
    {
        //マップオブジェクトを作成
        myMapLayer = new GameObject("MapLayer");

        //レイヤータイルの二次元配列
        squareArray = new GameObject[30,30];

        for (int x = 0; x < 30; x++)
        {
            for (int y = 0; y < 30; y++)
            {
                //上方向に0.5足した座標に生成
                GameObject obj = Instantiate(prefLayerSquare, new Vector3(x, MapConst.BaseY + (float)0.5, y), Quaternion.identity) as GameObject;
                obj.transform.parent = myMapLayer.transform;
                obj.SetActive(false);
                squareArray[x, y] = obj;
            }
        }
    }

    //移動可能範囲の表示
    //引数：現在位置(x,y) 範囲
    public void ShowMoveLayer(int x,int y, int range)
    {
        int[,] area;

        //影響範囲のエリアを取得
        area = GetEffectArea(x, y, range);
        //エリアから進行不可地形を削除
        //area = SetUnmoveableArea(area);

        //レイヤーを表示
        ShowLayer(area);
    }
    //攻撃可能範囲の表示
    //引数：現在位置(x,y) 範囲
    public void ShowActionLayer(int x, int y, int range)
    {
        int[,] area;

        //影響範囲のエリアを取得
        area = GetEffectArea(x, y, range);
        //エリアから進行不可地形を削除
        SetUnmoveableArea(area);

        //レイヤーを表示
        ShowLayer(area);
    }
    //ユニット配置可能範囲の表示
    //引数：現在位置(x,y) 範囲
    public void ShowSummonLayer(int x, int y, int range)
    {
        int[,] area;

        //影響範囲のエリアを取得
        area = GetEffectArea(x, y, range);
        //エリアから進行不可地形を削除
        SetUnmoveableArea(area);

        //レイヤーを表示
        ShowLayer(area);
    }

    //レイヤーの表示
    private void ShowLayer(int[,] area)
    {
        for (int x = 0; x < area.GetLength(0); x++)
        {
            for (int y = 0; y < area.GetLength(1); y++)
            {
                //二次元配列が１の座標のみ表示する
                if(area[x,y] == 1)
                {
                    squareArray[x, y].SetActive(true);
                }
            }
        }
    }

    //レイヤーの非表示
    private void HideLayer()
    {
        for (int x = 0; x < squareArray.GetLength(0); x++)
        {
            for (int y = 0; y < squareArray.GetLength(1); y++)
            {
                squareArray[x, y].SetActive(false);
            }
        }
    }

    //レイヤーがクリックされた場合、位置を返す
    private int[] OnClickedLayer()
    {
        int[] xy = new int[2];

        xy[0] = 0;
        xy[1] = 1;

        return xy;
    }

    //受け取った座標からのマップの詳細情報を考えない有効範囲を計算
    private int[,] GetEffectArea(int x, int y,int range)
    {
        //x,yの最大値を取得
        int maxX = squareArray.GetLength(0);
        int maxY = squareArray.GetLength(1);

        //計算結果用変数
        int[,] result = new int[maxX, maxY];

        //入力値チェック
        //0～最大値の範囲外なら空を返す
        if (x < 0 || x > maxX ||
            y < 0 || y > maxY)
        {
            return result;
        }

        //有効な範囲に1を設定。range=0なら基点の位置のみ
        for (int i = 0; i <= range; i++)
        {
            for (int j = 0; j <= range - i; j++)
            {
                SetEffective(ref result, x + i, y + j, maxX, maxY);
                SetEffective(ref result, x + i, y - j, maxX, maxY);
                SetEffective(ref result, x - i, y + j, maxX, maxY);
                SetEffective(ref result, x - i, y - j, maxX, maxY);
            }
        }

        return result;
    }

    //座標範囲を超えないもののみ1を設定する
    private void SetEffective(ref int[,] area, int x, int y, int maxX, int maxY)
    {
        if (x >= 0 && x <= maxX &&
            y >= 0 && y <= maxY)
        {
            area[x,y] = 1;
        }
    }

    //マップの基本有効範囲から移動不可地形の座標を無効可する
    private int[,] SetUnmoveableArea(int[,] area)
    {
        for (int x = 0; x < area.GetLength(0); x++)
        {
            for (int y = 0; y < area.GetLength(1); y++)
            {
                //二次元配列が１の座標のみ処理を行う
                if (area[x, y] == 1)
                {
                    //座標が進行不可地形の場合、値に0を設定する
                    if (!map.CanEnter(x, y))
                    {
                        area[x,y] = 0;
                    }
                }
            }
        }

        return area;
    }
}
