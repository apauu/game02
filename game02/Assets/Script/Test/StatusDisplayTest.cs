using UnityEngine;
using System.Collections;

public class StatusDisplayTest : SingletonMonoBehaviour<StatusDisplayTest>
{

    //クラスインスタンス
    MapContoroller mapcon;
    UnitManager unitManager;
    MenuManager menuManager;
    Player player;
    EnemyAI enemy;

    // Use this for initialization
    void Start()
    {
        try
        {
            //ユニットマネージャー生成
            unitManager = new UnitManager();

            //ユニット生成
            unitManager.GenerateUnit(GetResource.GetGameObjectFromResource(GameObjectNameConst.PrefabPath + GameObjectNameConst.UnitPrefab));

            //メニューコントローラー生成
            menuManager = MenuManager.Instance;
            //メニュー生成
            menuManager.GenerateMenu();
            //Init処理
            menuManager.Init();


            menuManager.UpdateMenuStatus(unitManager.currentSelectUnit);

        }
        catch (UnityException e)
        {
            Debug.Log(e);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ステータス表示用関数
    /// </summary>
    public void DisplayStatus()
    {
    }

    public void ChangeToggleCommand()
    {
    }

}