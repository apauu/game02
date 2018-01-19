using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

    public BaseButton StartButton;

	// Use this for initialization
	void Start () {

        // 常駐シーンを呼び出す
        Application.LoadLevelAdditiveAsync("Resident");

        // ボタンにアクションを追加する
        StartButton.onClick = () =>
        {
            Application.LoadLevel("Main");
        };

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
