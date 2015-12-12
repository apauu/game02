using UnityEngine;
using System.Collections;

/// <summary>
/// マップ表示テスト用シーン
/// </summary>
public class MapTest : MonoBehaviour {

    public Transform myPlaneTile;

    // Use this for initialization
    void Start () {
        MapContoroller mc = new MapContoroller();

        // マップ１を作成
        mc.myPlaneTile = myPlaneTile;
        mc.GenerateMap(MapConst.Map1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
