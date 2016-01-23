using UnityEngine;
using System.Collections;

/// <summary>
/// マップ表示テスト用シーン
/// </summary>
public class MapTest : MonoBehaviour {

    public GameObject prefUnit;
    public GameObject prefMap;
    public GameObject prefPlaneTile;
    public GameObject prefLayerSquare;

    // Use this for initialization
    void Start ()
    {
        // マップを作成
        MapContoroller mapcon = this.GetComponent<MapContoroller>();

        mapcon.prefMap = prefMap;
        mapcon.prefPlaneTile = prefPlaneTile;
        mapcon.GenerateMap(MapConst.Map1);

        // ユニットを作成
        UnitManager um = new UnitManager(mapcon);
        um.GenerateUnit(prefUnit);

        // レイヤーを作成
        MapLayer ml = new MapLayer();

        ml.initialize(mapcon.GetMap(), prefLayerSquare);
        ml.ShowMoveLayer(15, 15, 4);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
