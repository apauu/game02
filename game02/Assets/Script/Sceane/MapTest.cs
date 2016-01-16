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
        MapContoroller mc = this.GetComponent<MapContoroller>();

        mc.prefMap = prefMap;
        mc.prefPlaneTile = prefPlaneTile;
        mc.GenerateMap(MapConst.Map1);

        // ユニットを作成
        UnitManager gm = new UnitManager();
        gm.GenerateUnit();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
