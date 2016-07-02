using UnityEngine;
using System.Collections;

public class Player : AActor, IActor
{
    /// <summary>
    /// メニューで選択中のコマンド
    /// </summary>
    public string command = string.Empty;

    //初期化
    public void Init()
    {
        base.Init();

        this.ally = AllyConst.PlayerAlly;

    }


    //ゲーム開始前の準備動作
    public bool PreStart()
    {
        return true;
    }

    public void Update()
    {
        // 左クリックを取得
        if (Input.GetMouseButtonDown(0))
        {
            // クリックしたスクリーン座標をrayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Rayの当たったオブジェクトの情報を格納する
            RaycastHit hit = new RaycastHit();


            // rayが届く範囲
            float distance = 100f;
            // オブジェクトにrayが当たった時
            if (Physics.Raycast(ray, out hit, distance))
            {
                // rayが当たったオブジェクトを取得
                GameObject hitObj = hit.collider.gameObject;


                if (hitObj.GetComponent<Tile>())
                {
                    //クリックしたのがマップの場合

                    switch (command)
                    {
                        case "MOVE":
                            //移動コマンド選択中の場合の動作
                            DoMoveCommand(hitObj);
                            break;

                        case "ATTACK":
                            //攻撃コマンド選択中の場合の動作
                            DoAttackCommand(hitObj);
                            break;

                        case "SKILL":
                            //スキルコマンド選択中の場合の動作
                            DoAttackCommand(hitObj);
                            break;

                        default:
                            //選択中コマンドがない場合の動作
                            DoDefaultCommand(hitObj);
                            break;

                    }
                }
                else
                {
                    //クリックしたのがマップ以外のオブジェクトの場合(メニュー等)

                }

            }
        }
    }

    void TurnStart()
    {
        command = string.Empty;

    }

    void TurnEnd()
    {
        command = string.Empty;

    }

    #region コマンド分岐内処理
    /// <summary>
    /// 移動コマンド選択中の場合の動作
    /// </summary>
    /// <param name="hitObj"></param>
    private void DoMoveCommand(GameObject hitObj)
    {
        //クリック位置のユニットを取得
        Tile t = hitObj.GetComponent<Tile>();
        Vector2 xy = t.location;
        Unit u = um.SelectUnitTest(xy);
        
        //ユニットがいない場合、選択中ユニットをクリック位置へ移動
        if(u == null)
        {
            um.MoveCurrentUnit(xy);
        }


    }

    /// <summary>
    /// 攻撃コマンド選択中の場合の動作
    /// </summary>
    /// <param name="hitObj"></param>
    private void DoAttackCommand(GameObject hitObj)
    {
        //通常攻撃のID
        int skillNo = 1;

        //クリック位置のユニットを取得
        Tile t = hitObj.GetComponent<Tile>();
        Vector2 xy = t.location;
        Unit u = um.SelectUnitTest(xy);

        //選択位置に敵対ユニットがいる場合
        if (u != null && u.ally != this.ally)
        {
            um.Attack(u, skillNo);
        }

    }

    /// <summary>
    /// スキルコマンド選択中の場合の動作
    /// </summary>
    /// <param name="hitObj"></param>
    private void DoSkillCommand(GameObject hitObj)
    {

    }

    /// <summary>
    /// 選択中コマンドがない場合の動作
    /// </summary>
    /// <param name="hitObj"></param>
    private void DoDefaultCommand(GameObject hitObj)
    {
        //アクティブタイル変更　カメラ位置も変わる
        mc.SelectTile(hitObj);

        //選択位置にユニットがいればユニットを取得
        Tile t = hitObj.GetComponent<Tile>();
        Vector2 xy = t.location;
        Unit u = um.SelectUnitTest(xy);

        //ユニットのメニューを表示
        if (u != null) mm.commandOnOff(true);

        //クリック位置（ユニットがいればその名前も）ログ出力
        if (u != null) Debug.Log(u.name + "(" + (int)xy.x + "," + (int)xy.y + ") on click!");
        else Debug.Log("(" + (int)xy.x + "," + (int)xy.y + ") on click!");


    }
    #endregion
}
