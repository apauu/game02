using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ゲーム全体の進行を管理するクラス。
/// </summary>
public class GameManager : MonoBehaviour {

    //ゲーム進行状態
    //0:開始前　1:戦闘中
    int flgBattle = 0;
    //ターン管理
    //0:プレイヤー　1:敵
    int currentPlayerNo;
    int turnCnt;
    List<IActor> playerList = new List<IActor>();


    // Singlleton用プロパティ　インスタンスが存在するか？
    static bool existsInstance = false;

    // private プロパティ
    private GameObject menu;
    public GameObject menuCanvasPrefab;
    // private プロパティ
    private GameObject command;
    public GameObject characterCommandCanvasPrefab;

    //クラスインスタンス
    MapContoroller mc;
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
        //マップ、プレイヤー、キャラクターのオブジェクトを生成する
        //GenerateMap();
        //GeneratePlayer();
        //GenerateEnemy();
        //GenerateUnits(Player);
        //GenerateUnits(Enemy);

        //初回ターン設定
        currentPlayerNo = 0;
        turnCnt = 1;
        //playerList.Add(player); //0番目がプレイヤー
        //playerList.Add(enemy);　//1番目がエネミー

        //UI関係を生成する
        //GenerateUIObj();

        
        //ユニットの初期配置（ユーザ操作前）を設定する
        //DeployUnits(PlayerUnits);
        //DeployUnits(EnemyUnits);
        
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

        }
        catch (UnityException e){
            Debug.Log(e);
        }
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
                UpdatePlayer(player);
            }
            //敵ターンの場合
            else
            {
                UpdateEnemy(enemy);
            }
        }
        //戦闘開始前の場合
        else if (flgBattle == 0) {
            //プレイヤー側の準備操作が終了したら戦闘開始する
            if (StartPlayer(player))
            {
                flgBattle = 1;
            }
        }
        else
        {
            //何もしない
        }

        //動かせるユニットがいなければターン権限を次のプレイヤーに進める
        //if (!CanMoveUnit(playerList[currentPlayerNo]))
        //{
        //    currentPlayerNo++;
        //    if (currentPlayerNo > playerList.Count)
        //    {
        //        currentPlayerNo = 0;
        //        //ターン数をカウントアップ
        //        turnCnt++;
        //    }
        //}
    }

    //プレイヤーの開始時行動
    bool StartPlayer(Player actor)
    {
        return false;
    }

    //プレイヤーの行動
    void UpdatePlayer(Player actor)
    {
    }

    //敵プレイヤーの行動
    void UpdateEnemy(EnemyAI actor)
    {
    }

    //現在のプレイヤーのユニットで未行動のものがいるか確認
    //bool CanMoveUnit()
    //{
    //    return false;
    //}

    // 勝利条件に関わる物を監視し、勝利条件を満たした場合ゲームを終了する
    public void ObserveWinLose()
    {
        if (EndJudgement())
        {
            //終了処理
            GameFinish();
            while (!Input.anyKeyDown) { flgBattle = 2;} //キー入力待ち

        }
    }

    //ゲームの終了判定
    bool EndJudgement()
    {
        return false;
    }

    //ゲーム終了時の処理
    void GameFinish()
    {

    }

    // キャラクターコマンドを実際の処理に割り振る
    public void  CharacterCommandFacade(string processName)
    {
        //移動処理

        //攻撃処理

        //妖術処理

        //装備処理


        //Debug.Log(processName);
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
