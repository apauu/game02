using UnityEngine;
using System.Collections;

public static class GameObjectNameConst
{
    public const string PrefabPath = "Prefab/";
    public const string TexturePath = "Texture/";
    public const string TileTexture = "Tile";
    /// <summary>
    /// メニューキャンバスプレハブ名称.
    /// </summary>
    public const string MenuCanvasPrefab = "menuCanvasPrefab";
    /// <summary>
    /// キャラクターコマンドキャンバスプレハブ名称.
    /// </summary>
    public const string CharacterCommandCanvasPrefab = "characterCommandCanvas";
    /// <summary>
    /// キャラクター装備キャンバスプレハブ名称.
    /// </summary>
    public const string CharacterEquipCanvasPrefab = "characterEquipCanvas";

    /*現在選択されているキャラクター（敵味方両方）用のUIオブジェクト*/
    /// <summary>
    /// 現在選択されているキャラクター用オブジェクト名称.
    /// キャラクター名など複数のオブジェクトを内包するオブジェクト
    /// </summary>
    public const string MyStatus = "myStatus";
    /// <summary>
    /// キャラクター名テキストオブジェクト名称.
    /// </summary>
    public const string CharacterNameText = "characterNameText";
    /// <summary>
    /// キャラクター名レベルオブジェクト名称.
    /// </summary>
    public const string CharacterLevelText = "characterLevelText";
    /// <summary>
    /// キャラクター名HPオブジェクト名称.
    /// </summary>
    public const string CharacterHpText = "characterHpText";
    /// <summary>
    /// キャラクター名HPスライダーオブジェクト名称.
    /// </summary>
    public const string CharacterHpSlider = "characterHpSlider";



    /*現在選択されているキャラクター（敵味方両方）用のUIオブジェクト*/
    /// <summary>
    /// 現在選択されているキャラクター用オブジェクト名称.
    /// エネミー名など複数のオブジェクトを内包するオブジェクト
    /// </summary>
    public const string enemyStatus = "enemyStatus";
    /// <summary>
    /// エネミー名テキストオブジェクト名称.
    /// </summary>
    public const string EnemyNameText = "enemyNameText";
    /// <summary>
    /// エネミー名レベルオブジェクト名称.
    /// </summary>
    public const string EnemyLevelText = "characterLevelText";
    /// <summary>
    /// エネミー名HPオブジェクト名称.
    /// </summary>
    public const string EnemyHpText = "characterHpText";
    /// <summary>
    /// エネミー名HPスライダーオブジェクト名称.
    /// </summary>
    public const string EnemyHpSlider = "characterHpSlider";


    public const string MapPrefab = "Map";
    public const string UnitPrefab = "Goblin";

    /// <summary>
    /// 平地用タイル
    /// </summary>
    public const string PlaneTilePrefab = "Tile";

}
