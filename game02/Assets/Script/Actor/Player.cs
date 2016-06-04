using UnityEngine;
using System.Collections;

public class Player : AActor, IActor
{

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
                um.selectUnitTest(unitObj);

                //ユニットのメニューを表示
                mm.commandOnOff(true);

                Debug.Log(unitObj.name + " on click!");
            }
        }
    }

    void TurnStart()
    {

    }

    void TurnEnd()
    {

    }
}
