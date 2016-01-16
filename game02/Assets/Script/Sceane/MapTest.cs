using UnityEngine;
using System.Collections;

/// <summary>
/// マップ表示テスト用シーン
/// </summary>
public class MapTest : MonoBehaviour {

    public GameObject prefUnit;
    public GameObject prefMap;
    public GameObject prefPlaneTile;

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
    }

    // Update is called once per frame
    void Update () {
	
	}
}
