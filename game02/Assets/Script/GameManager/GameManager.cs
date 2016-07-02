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

    // private プロパティ
    private GameObject menu;
    private GameObject menuCanvasPrefab;
    private GameObject command;
    private GameObject characterCommandCanvasPrefab;

    //クラスインスタンス
    MapController mapCon;
    //UnitController unitCon;
    UnitManager unitManager;
    MenuManager menuManager;
    Player player;
    EnemyAI enemy;


    // Use this for initialization
    void Start ()
    {
        try
        {
            //インスタンスの取得
            menuManager = MenuManager.Instance;
            mapCon = MapController.Instance;
            unitManager = UnitManager.Instance;
            //unitCon = new UnitController();;
            player = new Player();
            enemy = new EnemyAI();

            /***************************************
            初期化処理
            ****************************************/
            //カメラ追従スクリプトを追加
            GameObject camera = GameObject.Find("Main Camera"); ;
            CameraControl camecon = camera.AddComponent<CameraControl>();
            //ユニットマネージャーにオブサーバー追加
            //unitManager.AddObserver(camecon);
            mapCon.AddObserver(camecon);

            //メニュー生成
            menuManager.GenerateMenu();
            //Init処理
            menuManager.Init();

            //マップ生成
            mapCon.GenerateMap(MapConst.Map1);

            //アクター初期化
            player.Init();
            enemy.Init();

            //キャラクターを生成する
            //unitManager.GenerateAactorUnits(player);
            //unitManager.GenerateAactorUnits(enemy);

            //キャラクター生成テスト
            unitManager.GenerateUnitsTest(player);

            //ユニットの初期配置（ユーザ操作前）を設定する
            //↓生成時に配置できれば不要？
            //unitManager.DeployUnits(PlayerUnits);
            //unitManager.DeployUnits(EnemyUnits);

            //初回ターン設定
            currentPlayerNo = 0;
            turnCnt = 1;
            flgBattle = 0;
            playerList.Add(player); //0番目がプレイヤー
            playerList.Add(enemy); //1番目がエネミー

            //テスト用に戦闘前フェーズをスキップ
            flgBattle = 1;

        }
        catch (UnityException e)
        {
            Debug.Log(e);
        }

    }

    // Update is called once per frame
    void Update ()
    {
        //戦闘中の場合
        if (flgBattle == 1)
        {
            if (currentPlayerNo == 0)
            {
                //プレイヤーターンの場合
                player.Update();
            }
            else
            {
                //敵ターンの場合
                enemy.Update();
            }
        }
        else if (flgBattle == 0)
        {
            //戦闘開始前の場合
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

        ////ユニットマネージャに指定陣営で行動可能のユニットがいるか確認依頼
        //if (!unitManager.CanMoveUnit(playerList[currentPlayerNo]))
        //{
        //    //毎ターン勝敗判定を行う
        //    if (Judgement())
        //    {
        //        //終了処理
        //        GameFinish();
        //        while (!Input.anyKeyDown) { flgBattle = 2; } //キー入力待ち

        //    } else
        //    {
        //        //動かせるユニットがいなければターン権限を次のプレイヤーに進める
        //        currentPlayerNo++;
        //        if (currentPlayerNo > playerList.Count)
        //        {
        //            currentPlayerNo = 0;
        //            //ターン数をカウントアップ
        //            turnCnt++;
        //        }

        //    }
        //}
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
    /// 3/19 shiro UnitManagerへ移動
    /// </summary>
    public void characterMove()
    {

    }

    /// <summary>
    /// メニューの画像・キャラクターステータスを変更する
    /// </summary>
    public void ChangeCharacterMenu()
    {
        menuManager.UpdateCharacterMenuStatus(GetCurrentUnit());
        //menu.transform.FindChild("Child").gameObject;
    }

    /// <summary>
    /// メニューの画像・キャラクターステータスを変更する
    /// </summary>
    public void ChangeEnemyMenu()
    {
        //menuManager.UpdateEnemyMenuStatus();
        //menu.transform.FindChild("Child").gameObject;
    }

    /// <summary>
    /// メニューより呼び出され、選択したコマンドをプレイヤーに伝える
    /// </summary>
    /// <param name="command"></param>
    public void SelectPlayerCommand(string command)
    {
        player.command = command;
    }
}
