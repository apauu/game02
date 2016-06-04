using UnityEngine;
using System.Collections;

/// <summary>
/// マップ表示テスト用シーン
/// ゲーム起動用
/// </summary>
public class MapTest : MonoBehaviour {

    public GameObject prefUnit;
    public GameObject prefMap;
    public GameObject prefPlaneTile;
    public GameObject prefLayerSquare;
    UnitManager um;
    MenuManager menuManager;
    CameraControl camecon;

    // Use this for initialization
    void Start ()
    {
        //カメラ追従スクリプトを追加
        GameObject cameraObj = GameObject.Find("Main Camera"); ;
        camecon = cameraObj.AddComponent<CameraControl>();

        //メニューコントローラー生成
        menuManager = MenuManager.Instance;
        //メニュー生成
        menuManager.GenerateMenu();
        //Init処理
        menuManager.Init();

        //メニューを非表示に設定
        menuManager.menuOnOff(false);
        menuManager.commandOnOff(false);

        // マップコントローラーを作成
        MapController mapcon = MapController.Instance;

        mapcon.prefMap = prefMap;
        mapcon.prefPlaneTile = prefPlaneTile;
        mapcon.GenerateMap(MapConst.Map1);

        // ユニットを作成
        um = UnitManager.Instance;
        GameObject mikata = um.GenerateUnit(prefUnit, 1, 5 , 5); //味方ゴブリン
        GameObject teki = um.GenerateUnit(prefUnit, 2, 15, 15); //敵ゴブリン
        menuManager.UpdateCharacterMenuStatus(um.currentSelectUnit);

        //ユニットマネージャーにオブサーバー追加
        um.AddObserver(camecon);

        //味方ゴブリンにクリック動作を設定
        UnitController unicon = mikata.GetComponent<UnitController>();
        unicon.callbackOnMouseDown = onClickUnit;

        // レイヤーを作成
        MapLayer ml = this.gameObject.AddComponent<MapLayer>();

        ml.initialize(mapcon.GetMap(), prefLayerSquare);
        //ml.ShowMoveLayer(15, 15, 4);

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void onClickUnit()
    {
        menuManager.commandOnOff();
    }
}
