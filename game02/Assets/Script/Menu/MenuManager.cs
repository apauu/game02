using UnityEngine;
using UnityEngine.UI;

using System.Collections;

/// <summary>
/// キャラクターコマンドメニューのボタン押下に使用するクラス
/// </summary>
public class MenuManager : SingletonMonoBehaviour<MenuManager>
{

    #region フィールド変数
    /// <summary>
    /// メニュープレハブ.
    /// </summary>
    private GameObject menuCanvasPrefab;
    /// <summary>
    /// コマンドプレハブ.
    /// </summary>
    private GameObject characterCommandCanvasPrefab;
    /// <summary>
    /// 装備リストプレハブ.
    /// </summary>
    private GameObject characterEquipCanvasPrefab;

    //private propaties

    /// <summary>
    /// ユニットマネージャー.
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// ユニットマネージャー.
    /// </summary>
    private UnitManager unitManager;

    /// <summary>
    /// キャラクター名テキスト（UI）.
    /// </summary>
    private Text characterNameText;

    /// <summary>
    /// キャラクターレベルテキスト（UI）.
    /// </summary>
    private Text characterLevelText;

    /// <summary>
    /// キャラクター妖力テキスト（UI）.
    /// </summary>
    private Text characterHPText;

    /// <summary>
    /// キャラクター妖力スライダー（UI）.
    /// </summary>
    private Slider characterHPSlider;

    /// <summary>
    /// キャラクター経験値テキスト（UI）.
    /// </summary>
    private Text characterExperienceText;

    /// <summary>
    /// キャラクター経験値スライダー（UI）.
    /// </summary>
    private Slider characterExperienceSlider;

    /// <summary>
    /// エネミー名テキスト（UI）.
    /// </summary>
    private Text enemyNameText;

    /// <summary>
    /// エネミーレベルテキスト（UI）.
    /// </summary>
    private Text enemyLevelText;

    /// <summary>
    /// エネミー妖力テキスト（UI）.
    /// </summary>
    private Text enemyHPText;

    /// <summary>
    /// エネミー妖力スライダー（UI）.
    /// </summary>
    private Slider enemyHPSlider;

    /// <summary>
    /// エネミー経験値テキスト（UI）.
    /// </summary>
    private Text enemyExperienceText;

    /// <summary>
    /// エネミー経験値スライダー（UI）.
    /// </summary>
    private Slider enemyExperienceSlider;
    
    /// <summary>
    /// フレーバーテキスト（UI）.
    /// </summary>
    private Text flavorText;

    /// <summary>
    /// メニューオブジェクト.
    /// </summary>
    private GameObject menu;
    /// <summary>
    /// コマンドオブジェクト.
    /// </summary>
    private GameObject command;

    /// <summary>
    /// ステータスオブジェクト.
    /// </summary>
    private GameObject statusObject;

    /// <summary>
    /// フレーバーテキストオブジェクト.
    /// </summary>
    private GameObject flavorTextObject;

    #endregion

    // Use this for initialization
    void Start () {
        unitManager = UnitManager.Instance;
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

        //フレーバーテキストオブジェクトを紐づけ
        flavorTextObject = GameObject.Find(GameObjectNameConst.FlavorTextObject);
        //フレーバーテキストを紐づけ
        flavorText = GameObject.Find(GameObjectNameConst.FlavorText).GetComponent<Text>();
        //ステータスオブジェクトを紐づけ
        statusObject = GameObject.Find(GameObjectNameConst.StatusObject);
        /* キャラクターオブジェクトの検索 */
        //キャラクター名オブジェクトを紐づけ
        characterNameText = GameObject.Find(GameObjectNameConst.CharacterNameText).GetComponent<Text>();
        //キャラクターレベル名オブジェクトを紐づけ
        characterLevelText = GameObject.Find(GameObjectNameConst.CharacterLevelText).GetComponent<Text>();
        //キャラクター妖力オブジェクトを紐づけ
        characterHPText = GameObject.Find(GameObjectNameConst.CharacterHpText).GetComponent<Text>();
        characterHPSlider = GameObject.Find(GameObjectNameConst.CharacterHpSlider).GetComponent<Slider>();
        //キャラクター経験値オブジェクトを紐づけ
        characterExperienceText = GameObject.Find(GameObjectNameConst.CharacterExperienceText).GetComponent<Text>();
        characterExperienceSlider = GameObject.Find(GameObjectNameConst.CharacterExperienceSlider).GetComponent<Slider>();

        /* エネミーオブジェクトの検索 */
        //エネミー名オブジェクトを紐づけ
        enemyNameText = GameObject.Find(GameObjectNameConst.EnemyNameText).GetComponent<Text>();
        //エネミーレベル名オブジェクトを紐づけ
        enemyLevelText = GameObject.Find(GameObjectNameConst.EnemyLevelText).GetComponent<Text>();
        //エネミー妖力オブジェクトを紐づけ
        enemyHPText = GameObject.Find(GameObjectNameConst.EnemyHpText).GetComponent<Text>();
        enemyHPSlider = GameObject.Find(GameObjectNameConst.EnemyHpSlider).GetComponent<Slider>();
        //エネミー経験値オブジェクトを紐づけ
        enemyExperienceText = GameObject.Find(GameObjectNameConst.EnemyExperienceText).GetComponent<Text>();
        enemyExperienceSlider = GameObject.Find(GameObjectNameConst.EnemyExperienceSlider).GetComponent<Slider>();

        statusObject.SetActive(true);
        flavorTextObject.SetActive(false);
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
    /// キャラクターメニューのステータス表示を更新する
    /// </summary>
    /// <param name="expressUnit">ユニットクラス</param>
    public void UpdateCharacterMenuStatus(Unit expressUnit)
    {
        //名前更新
        characterNameText.text = expressUnit.name.ToString();

        //レベル更新
        characterLevelText.text = expressUnit.lvl.ToString();

        //HPテキスト更新
        characterHPText.text = expressUnit.currentHp.ToString()+"/"+ expressUnit.baseChangeHp.ToString();

        //HPスライダー更新
        UpdateCharacterHpSlider(expressUnit);

        //経験テキスト更新
        //TODO:経験値の最大値をどこからか取得する必要あり
        characterExperienceText.text = expressUnit.exp.ToString() + "/" + expressUnit.exp.ToString();

        //経験スライダー更新
        UpdateCharacterExpSlider(expressUnit);

    }

    /// <summary>
    /// キャラクターHPスライダーの最大値、現在値を更新する
    /// </summary>
    /// <param name="expressUnit">選択キャラクターのユニットクラス</param>
    private void UpdateCharacterHpSlider(Unit expressUnit)
    {
        //スライダーの最大値更新
        characterHPSlider.maxValue = expressUnit.baseChangeHp;
        //スライダーの現在値更新
        characterHPSlider.value = expressUnit.currentHp;
    }

    /// <summary>
    /// キャラクター経験値スライダーの最大値、現在値を更新する
    /// </summary>
    /// <param name="expressUnit">選択キャラクターのユニットクラス</param>
    private void UpdateCharacterExpSlider(Unit expressUnit)
    {
        //スライダーの最大値更新
        //TODO:経験値の最大値をどこからか取得する必要あり
        characterExperienceSlider.maxValue = (float)expressUnit.exp;
        //スライダーの現在値更新
        characterExperienceSlider.value = (float)expressUnit.exp;
    }


    /// <summary>
    /// エネミーメニューのステータス表示を更新する
    /// </summary>
    /// <param name="expressUnit">敵キャラクターのユニットクラス</param>
    public void UpdateEnemyMenuStatus(Unit expressUnit)
    {
        //名前更新
        enemyNameText.text = expressUnit.name.ToString();

        //レベル更新
        enemyLevelText.text = expressUnit.lvl.ToString();

        //HPテキスト更新
        enemyHPText.text = expressUnit.currentHp.ToString() + "/" + expressUnit.baseChangeHp.ToString();

        //HPスライダー更新
        UpdateEnemyHpSlider(expressUnit);

        //経験テキスト更新
        //TODO:経験値の最大値をどこからか取得する必要あり
        enemyExperienceText.text = expressUnit.exp.ToString() + "/" + expressUnit.exp.ToString();

        //経験スライダー更新
        UpdateEnemyExpSlider(expressUnit);

    }

    /// <summary>
    /// エネミーHPスライダーの最大値、現在値を更新する
    /// </summary>
    /// <param name="expressUnit">敵キャラクターのユニットクラス</param>
    private void UpdateEnemyHpSlider(Unit expressUnit)
    {
        //スライダーの最大値更新
        enemyHPSlider.maxValue = expressUnit.baseChangeHp;
        //スライダーの現在値更新
        enemyHPSlider.value = expressUnit.currentHp;
    }

    /// <summary>
    /// エネミー経験値スライダーの最大値、現在値を更新する
    /// </summary>
    /// <param name="expressUnit">敵キャラクターのユニットクラス</param>
    private void UpdateEnemyExpSlider(Unit expressUnit)
    {
        //スライダーの最大値更新
        //TODO:経験値の最大値をどこからか取得する必要あり
        enemyExperienceSlider.maxValue = (float)expressUnit.exp;
        //スライダーの現在値更新
        enemyExperienceSlider.value = (float)expressUnit.exp;
    }




    /// <summary>
    /// コマンド処理の分岐　実処理は別メソッドにて実施
    /// </summary>
    /// <param name="processName"></param>
    public void CharacterCommandFacade(string processName)
    {
        //初期化処理 開いているメニューを閉じるなど
        //InitCommandPut();
        switch (processName)
        {
            //移動処理
            case GameObjectNameConst.MoveButton:
                Debug.Log(processName);
                //gameManager.characterMove();
                break;
            //攻撃処理
            case GameObjectNameConst.AttackButton:
                //選択したコマンド（物理攻撃）をセット
                unitManager.currentSelectAttackKind = SkillConst.SkillKindIsPhysicalAttack;
                Debug.Log(processName);
                break;
            //妖術処理
            case GameObjectNameConst.SkillButton:
                Debug.Log(processName);
                break;
            //装備処理
            case GameObjectNameConst.EquipButton:
                Debug.Log(processName);
                ShowEquipList();
                break;
            //感情処理
            case GameObjectNameConst.EmotionButton:
                statusObject.SetActive(false);
                flavorTextObject.SetActive(true);
                SetFlavorText();
                Debug.Log(processName);
                break;
            default:
                Debug.Log(processName);
                break;
        }

        //Debug.Log(processName);
    }

    /// <summary>
    /// コマンド押下時の初期化処理
    /// コマンド押下によって展開されたメニューを閉じる
    /// </summary>
    private void InitCommandPut()
    {
        //characterEquipCanvasPrefab.SetActive(false);
    }

    /// <summary>
    /// フレーバーテキストを設定する
    /// TODO:実際のテキストを取得してくる仕組みが必要
    /// </summary>
    private void SetFlavorText()
    {
        flavorText.text = "flavor text";
    }

    /// <summary>
    /// 装備選択画面を表示する
    /// </summary>
    private void ShowEquipList()
    {
        //プレハブ作成
        //装備リスト表示用
        characterEquipCanvasPrefab = (GameObject)Instantiate(GetResource.GetGameObjectFromResource(GameObjectNameConst.PrefabPath + GameObjectNameConst.CharacterEquipCanvasPrefab), new Vector3(0, 0, 0), Quaternion.identity);
        //初期表示時に不要なものは非表示にする
        //装備リスト
        characterEquipCanvasPrefab.SetActive(true);
    }

    /// <summary>
    /// コマンド処理　実処理はgameManager以降におまかせ
    /// 仮で固定で３つの装備を選択できるようにする。
    /// </summary>
    /// <param name="processName"></param>
    public void CharacterEquipFacade(string processName)
    {
        //現在選択中のユニット(仮)
        //UnitController myUnit = new UnitController();
        //選択した装備ID
        string weaponID;

        switch (processName)
        {
            //装備１処理
            case "equipButton1":
                Debug.Log(processName);
                weaponID = EquipConst.WeaponID1;
                //myUnit.ChangeWeapon(weaponID);
                break;
            //装備２処理
            case "equipButton2":
                Debug.Log(processName);
                weaponID = EquipConst.WeaponID2;
                //myUnit.ChangeWeapon(weaponID);
                break;
            //装備３処理
            case "equipButton3":
                Debug.Log(processName);
                weaponID = EquipConst.WeaponID3;
                //myUnit.ChangeWeapon(weaponID);
                break;
            default:
                Debug.Log(processName);
                break;
        }

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

    /// <summary>
    /// メニューのOn/Offを制御する(反転)
    /// </summary>
    public void menuOnOff()
    {
        menu.SetActive(!menu.activeSelf);
    }

    /// <summary>
    /// コマンドのOn/Offを制御する(反転)
    /// </summary>
    public void commandOnOff()
    {
        command.SetActive(!command.activeSelf);
    }
}
