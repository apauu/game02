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
    List<ActorAB> playerList = new List<ActorAB>();

    //クラスインスタンス
    MapContoroller mc;
    Player player;
    EnemyAI enemy;

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
        playerList.Add(player); //0番目がプレイヤー
        playerList.Add(enemy);　//1番目がエネミー

        //UI関係を生成する
        //GenerateUIObj();

        //ユニットの初期配置（ユーザ操作前）を設定する
        //DeployUnits(PlayerUnits);
        //DeployUnits(EnemyUnits);
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
        if (!CanMoveUnit(playerList[currentPlayerNo]))
        {
            currentPlayerNo++;
            if (currentPlayerNo > playerList.Count)
            {
                currentPlayerNo = 0;
                //ターン数をカウントアップ
                turnCnt++;
            }
        }
    }

    //プレイヤーの開始時行動
    bool StartPlayer(ActorAB actor)
    {
        return false;
    }

    //プレイヤーの行動
    void UpdatePlayer(ActorAB actor)
    {
    }

    //敵プレイヤーの行動
    void UpdateEnemy(ActorAB actor)
    {
    }

    //現在のプレイヤーのユニットで未行動のものがいるか確認
    bool CanMoveUnit(ActorAB actor)
    {
        return false;
    }

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
}
