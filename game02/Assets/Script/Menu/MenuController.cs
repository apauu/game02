using UnityEngine;
using UnityEngine.UI;

using System.Collections;

/// <summary>
/// キャラクターコマンドメニューのボタン押下に使用するクラス
/// </summary>
public class MenuController : SingletonMonoBehaviour<MenuController>
{

    //private propaties
    private GameManager gameManager;
    private Text characterLevelText;

    //private GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init ()
    {
        //
        GameObject a = GameObject.Find("characterLevelTextObject");
        characterLevelText = GameObject.Find("characterLevelTextObject").GetComponent<Text>();
    }

    /// <summary>
    /// メニューの表示を変更する
    /// </summary>
    /// <param name="expressUnit"></param>
    public void ChangeMenuText(Unit expressUnit)
    {
        characterLevelText.text = expressUnit.lvl.ToString();
    }

    // コマンド処理　実処理はgameManager以降におまかせ
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
