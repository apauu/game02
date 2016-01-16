using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuOnOffTest : MonoBehaviour {

    Toggle toggle;
    //private propaties
    private GameObject gameManagerObject;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        toggle = GetComponent<Toggle>();
        gameManagerObject = GameObject.Find("GameManagerPrefab");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeToggleMenu()
    {
        gameManager.menuOnOff(toggle.isOn);
    }

    public void ChangeToggleCommand()
    {
        gameManager.commandOnOff(toggle.isOn);
    }

}
