using UnityEngine;
using UnityEngine.UI;

using System.Collections;

/// <summary>
/// キャラクターコマンドメニューのボタン押下に使用するクラス
/// </summary>
public class characterCommandButton : MonoBehaviour {

    //private propaties
    private Text characterLevelText;
    private MenuManager menuManager;

    //private GameManager gameManager;

    // Use this for initialization
    void Start () {
        menuManager = MenuManager.Instance;
    }

    // Update is called once per frame
    void Update () {
	
	}

    /// <summary>
    /// クリック時のイベント　処理はgameManagerに依頼
    /// </summary>
    public void OnClick () 
    {
        menuManager.CharacterCommandFacade(this.gameObject.name);
    }

    public void ChangeMenuText(Unit expressUnit)
    {

    }
}
