using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ゲーム全体の進行を管理するクラス。
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{

    //ゲーム進行状態
    //0:開始前　1:戦闘中
    int flgBattle = 0;
    //ターン管理
    //0:プレイヤー　1:敵
    int currentPlayerNo;
    int turnCnt;
    List<AActor> playerList = new List<AActor>();

    // Singlleton用プロパティ　インスタンスが存在するか？
    static bool existsInstance = false;

    // private プロパティ
    private GameObject menu;
    public GameObject menuCanvasPrefab;
    // private プロパティ
    private GameObject command;
    public GameObject characterCommandCanvasPrefab;

    //クラスインスタンス
    MapContoroller mapCon;
    UnitController unitCon;
    UnitManager unitManager;
    MenuController menuController;
    Player player;
    EnemyAI enemy;

    // 初期化
    void Awake()
    {
        // インスタンスが存在するなら破棄する
        if (existsInstance)
        {
            Destroy(gameObject);
            return;
        }

        // 存在しない場合
        // 自身が唯一のインスタンスとなる
        existsInstance = true;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        //コントローラー生成
        mapCon = new MapContoroller();
        unitCon = new UnitController();
        //ユニットマネージャー生成
        unitManager = new UnitManager(mapCon);
        //menuController.Init();

        //マップ、プレイヤーのオブジェクトを生成する
        //mapCon.GenerateMap(MapConst.Map1);
        player = new Player(this, unitManager,mapCon, unitCon);
        enemy = new EnemyAI(this, unitManager, mapCon, unitCon);

        //キャラクターを生成する
        unitManager.GenerateAactorUnits(player);
        unitManager.GenerateAactorUnits(enemy);

        //ユニットの初期配置（ユーザ操作前）を設定する
        //↓生成時に配置できれば不要？
        //DeployUnits(PlayerUnits);
        //DeployUnits(EnemyUnits);

        //初回ターン設定
        currentPlayerNo = 0;
        turnCnt = 1;
        playerList.Add(player); //0番目がプレイヤー
        playerList.Add(enemy); //1番目がエネミー

        //UI関係を生成する
        //GenerateUIObj();

        try {
            //プレハブ作成
            //メニュー表示用
            menu = (GameObject)Instantiate(menuCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //コマンド表示用
            command = (GameObject)Instantiate(characterCommandCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //初期表示時に不要なものは非表示にする
            //メニュー
            menu.SetActive(false);
            //コマンド
            command.SetActive(false);

            //ユニット生成
            unitManager.GenerateUnit(GetResource.GetGameObjectFromResource(GameObjectNameConst.PrefabPath + GameObjectNameConst.UnitPrefab));

            //メニューコントローラー生成
            menuController = MenuController.Instance;
            menuController.Init();

        }
        catch (UnityException e){
            Debug.Log(e);
        }


        //TODO:ステータス表示用のテスト
        ChangeMenu();
    }

    // Update is called once per frame
    void Update ()
    {
        //戦闘中の場合
        if (flgBattle == 1)
        {
            //プレイヤーターンの場合
            if (currentPlayerNo == 0)
            {
                player.Update();
            }
            //敵ターンの場合
            else
            {
                enemy.Update();
            }
        }
        //戦闘開始前の場合
        else if (flgBattle == 0) {
            //プレイヤー側の準備操作が終了したら戦闘開始する
            if (player.PreStart())
            {
                flgBattle = 1;
            }
        }
        else
        {
            //何もしない
        }

        //ユニットマネージャに指定陣営で行動可能のユニットがいるか確認依頼
        if (!unitManager.CanMoveUnit(playerList[currentPlayerNo]))
        {
            //毎ターン勝敗判定を行う
            if (Judgement())
            {
                //終了処理
                GameFinish();
                while (!Input.anyKeyDown) { flgBattle = 2; } //キー入力待ち

            } else
            {
                //動かせるユニットがいなければターン権限を次のプレイヤーに進める
                currentPlayerNo++;
                if (currentPlayerNo > playerList.Count)
                {
                    currentPlayerNo = 0;
                    //ターン数をカウントアップ
                    turnCnt++;
                }

            }
        }
    }

    //未使用
    // 勝利条件に関わる物を監視し、勝利条件を満たした場合ゲームを終了する
    public void ObserveWinLose()
    {
        if (Judgement())
        {
            //終了処理
            GameFinish();
            while (!Input.anyKeyDown) { flgBattle = 2;} //キー入力待ち

        }
    }

    //ゲームの終了判定
    bool Judgement()
    {
        //ユニットが0体のプレイヤーがいないか調べる。いるならtrue
        foreach(AActor actor in playerList)
        {
            if (unitManager.getUnitCount(actor) == 0)
            {
                return true;
            }
        }

        return false;
    }

    //ゲーム終了時の処理
    void GameFinish()
    {

    }

    private Unit GetCurrentUnit()
    {
        return unitManager.currentSelectUnit;
    } 

    /// <summary>
    /// キャラクター移動処理
    /// </summary>
    public void characterMove()
    {

    }

    /// <summary>
    /// メニューの画像・キャラクターステータスを変更する
    /// </summary>
    public void ChangeMenu()
    {
        menuController.ChangeMenuText(GetCurrentUnit());
        //menu.transform.FindChild("Child").gameObject;
    }


    /// <summary>
    /// メニューのOn/Offを制御する
    /// </summary>
    public void menuOnOff(bool isOn)
    {
        menu.SetActive(isOn);
    }

    /// <summary>
    /// コマンドのOn/Offを制御する
    /// </summary>
    public void commandOnOff(bool isOn)
    {
        command.SetActive(isOn);
    }
}
