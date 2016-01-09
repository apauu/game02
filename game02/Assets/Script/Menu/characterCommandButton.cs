using UnityEngine;
using System.Collections;

/// <summary>
/// キャラクターコマンドメニューのボタン押下に使用するクラス
/// </summary>
public class characterCommandButton : MonoBehaviour {

    //private propaties
    private GameObject gameManagerObject;
    private GameManager gameManager;

    //private GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManagerObject = GameObject.Find("GameManagerPrefab");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// クリック時のイベント　処理はgameManagerに依頼
    /// </summary>
    public void OnClick () 
    {
        gameManager.CharacterCommandFacade(this.gameObject.name);
    }
}
