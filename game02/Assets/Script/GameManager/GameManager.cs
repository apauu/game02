using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム全体の進行を管理するクラス。
/// </summary>
public class GameManager : MonoBehaviour {



    // Singlleton用プロパティ　インスタンスが存在するか？
    static bool existsInstance = false;

    // pricate プロパティ
    private GameObject menu;
    public GameObject menuCanvasPrefab;

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

        try {
            //プレハブ作成
            menu = (GameObject)Instantiate(menuCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
            //初期表示自に不要なものは非表示にする
            menu.SetActive(false);
        }
        catch (UnityException e){
            Debug.Log(e);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    // 勝利条件に関わる物を監視し、勝利条件を満たした場合ゲームを終了する
    void ObserveWinLose()
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
}
