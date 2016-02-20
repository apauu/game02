using UnityEngine;
using UnityEngine.UI;

using System.Collections;

/// <summary>
/// キャラクターコマンドメニューのボタン押下に使用するクラス
/// </summary>
public class MenuManager : SingletonMonoBehaviour<MenuManager>
{

    //private propaties
    /// <summary>
    /// ゲームマネージャー.
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// キャラクター名テキスト（UI）.
    /// </summary>
    private Text characterNameText;

    /// <summary>
    /// キャラクターレベルテキスト（UI）.
    /// </summary>
    private Text characterLevelText;

    /// <summary>
    /// キャラクターHPテキスト（UI）.
    /// </summary>
    private Text characterHPText;

    /// <summary>
    /// キャラクターHPスライダー（UI）.
    /// </summary>
    private Slider characterHPSlider;

    // private プロパティ
    /// <summary>
    /// メニューオブジェクト.
    /// </summary>
    private GameObject menu;
    /// <summary>
    /// メニュープレハブ.
    /// </summary>
    public GameObject menuCanvasPrefab;
    /// <summary>
    /// コマンドオブジェクト.
    /// </summary>
    private GameObject command;
    /// <summary>
    /// コマンドプレハブ.
    /// </summary>
    public GameObject characterCommandCanvasPrefab;

    /// <summary>
    /// インスタンス作成時処理.
    /// シングルトンのために生成できるインスタンスを１つだけとする
    /// </summary>
    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        gameManager = GameManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// メニュー関連オブジェクトの検索.
    /// </summary>
    public void Init ()
    {
        characterNameText = GameObject.Find(GameObjectNameConst.CharacterNameText).GetComponent<Text>();
        characterLevelText = GameObject.Find(GameObjectNameConst.CharacterLevelText).GetComponent<Text>();
        characterHPText = GameObject.Find(GameObjectNameConst.CharacterHpText).GetComponent<Text>();
        characterHPSlider = GameObject.Find(GameObjectNameConst.CharacterHpSlider).GetComponent<Slider>();
    }

    /// <summary>
    /// メニューオブジェクトの生成.
    /// </summary>
    public void GenerateMenu()
    {
        //プレハブ作成
        //メニュー表示用
        menu = (GameObject)Instantiate(GetResource.GetGameObjectFromResource(GameObjectNameConst.PrefabPath + GameObjectNameConst.MenuCanvasPrefab), new Vector3(0, 0, 0), Quaternion.identity);
        //コマンド表示用
        command = (GameObject)Instantiate(GetResource.GetGameObjectFromResource(GameObjectNameConst.PrefabPath + GameObjectNameConst.CharacterCommandCanvasPrefab), new Vector3(0, 0, 0), Quaternion.identity);
        //初期表示時に不要なものは非表示にする
        //メニュー
        menu.SetActive(true);
        //コマンド
        command.SetActive(true);
    }

    /// <summary>
    /// メニューのステータス表示を更新する.
    /// </summary>
    /// <param name="expressUnit"></param>
    public void UpdateMenuStatus(Unit expressUnit)
    {
        //名前更新
        characterNameText.text = expressUnit.name.ToString();

        //レベル更新
        characterLevelText.text = expressUnit.lvl.ToString();

        //HPテキスト更新
        characterHPText.text = expressUnit.currentHp.ToString()+"/"+ expressUnit.baseChangeHp.ToString();

        //HPスライダー更新
        UpdateHpSlider(expressUnit);

    }

    /// <summary>
    /// HPスライダーの最大値、現在値を更新する.
    /// </summary>
    private void UpdateHpSlider(Unit expressUnit)
    {
        //スライダーの最大値更新
        characterHPSlider.maxValue = expressUnit.baseChangeHp;
        //スライダーの現在値更新
        characterHPSlider.value = expressUnit.currentHp;
    }

    /// <summary>
    /// コマンド処理　実処理はgameManager以降におまかせ.
    /// </summary>
    /// <param name="processName"></param>
    public void CharacterCommandFacade(string processName)
    {
        switch (processName)
        {
            //移動処理
            case "moveButton":
                Debug.Log(processName);
                gameManager.characterMove();
                break;
            //攻撃処理
            case "attackButton":
                Debug.Log(processName);
                break;
            //妖術処理
            case "skillButton":
                Debug.Log(processName);
                break;
            //装備処理
            case "equipButton":
                Debug.Log(processName);
                break;
            default:
                Debug.Log(processName);
                break;
        }

        //Debug.Log(processName);
    }
}
