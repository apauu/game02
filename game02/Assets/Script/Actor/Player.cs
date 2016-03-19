using UnityEngine;
using System.Collections;

public class Player : AActor, IActor
{
    //生成時にオーナーとコントローラを設定
    public Player(GameManager owner, UnitManager unitManager, MapContoroller mapCon, UnitController unitCon, MenuManager menuManager)
    {
        this.init(owner,unitManager, mapCon, unitCon, menuManager);
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
                // rayが当たったオブジェクトの名前を取得
                GameObject unitObj = hit.collider.gameObject;
                unitManager.selectUnitTest(unitObj);

                //ユニットのメニューを表示
                menuManager.commandOnOff(true);

                Debug.Log(unitObj.name + " on click!");
            }
        }
    }

    void init()
    {

    }

    void TurnStart()
    {

    }

    void TurnEnd()
    {

    }
}
