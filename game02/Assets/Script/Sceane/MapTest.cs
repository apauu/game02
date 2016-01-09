using UnityEngine;
using System.Collections;

/// <summary>
/// マップ表示テスト用シーン
/// </summary>
public class MapTest : MonoBehaviour {

    public Transform prefMap;
    public Transform prefPlaneTile;

    // Use this for initialization
    void Start () {
        MapContoroller mc = this.GetComponent<MapContoroller>();

        // マップ１を作成
        mc.prefMap = prefMap;
        mc.prefPlaneTile = prefPlaneTile;
        mc.GenerateMap(MapConst.Map1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
