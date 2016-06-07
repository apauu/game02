using UnityEngine;

/// <summary>
/// マップの１マスの情報を保持するクラス。
/// </summary>
public class Tile :MonoBehaviour{

    #region フィールド変数
    /// <summary>
    /// ID
    /// </summary>
    public int tileID { get; set; }
    /// <summary>
    /// 画像ファイル
    /// </summary>
    public string texture { get; set; }
    /// <summary>
    /// ゲーム上のX,Y座標（Unity座標上の値でない）
    /// </summary>
    public Vector2 location { get; set; }
    /// <summary>
    /// Unity上の3次元座標
    /// </summary>
    public Vector3 realLocation
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    /// <summary>
    /// 高さ。マイナス有り
    /// </summary>
    public int hight { get; set; }
    /// <summary>
    /// 勢力情報
    /// </summary>
    public int belongAlly { get; set; }
    /// <summary>
    /// true：拠点　false：その他
    /// </summary>
    public bool isBase { get; set; }
    /// <summary>
    /// true：通行可　false：通行不可
    /// </summary>
    public bool canEnter { get; set; }
    /// <summary>
    /// ユニットが通る際の追加移動力（沼地等）：０（平地）～－１０（進入不可）
    /// </summary>
    public int movementForce { get; set; }
    /// <summary>
    /// ユニットが通る際の追加防御力（砦等）
    /// </summary>
    public int defensiveForce { get; set; }
    #endregion

    #region コンストラクタ
    //通常のタイル
    public Tile(
        int tileID,
        Vector2 location,
        Vector3 realLocation,
        int hight = 0,
        int belongAlly = AllyConst.NoAlly)
    {
        this.tileID = tileID;
        this.location = location;
        this.realLocation = realLocation;
        this.hight = hight;
        this.belongAlly = belongAlly;

        switch (tileID)
        {
            case MapConst.Plains: //平地
                InitCopy(MapConst.PlainsTemplate);
                break;
            case MapConst.Fortress: //拠点
                InitCopy(MapConst.FortressTemplate);
                break;
            case MapConst.Wall: //壁
                InitCopy(MapConst.FortressTemplate);
                break;
            case MapConst.Pool: //水場
                InitCopy(MapConst.PoolTemplate);
                break;
            case MapConst.Bogland: //沼地
                InitCopy(MapConst.BoglandTemplate);
                break;
            case MapConst.Empty: //何も無い
                InitCopy(MapConst.EmptyTemplate);
                break;
            default :
                break;
        }
    }

    //テンプレート宣言用
    public Tile(
        int tileID,
        string texture,
        bool isBase,
        bool canEnter,
        int movementForce,
        int defensiveForce
        )
    {
        this.tileID = tileID;
        this.texture = texture;
        this.isBase = isBase;
        this.canEnter = canEnter;
        this.movementForce = movementForce;
        this.defensiveForce = defensiveForce;
    }

    //テンプレートから値をコピー
    private void InitCopy(Tile template)
    {
        this.texture = template.texture;
        this.isBase = template.isBase;
        this.canEnter = template.canEnter;
        this.movementForce = template.movementForce;
        this.defensiveForce = template.defensiveForce;
    }
    #endregion

    #region タイルクリック時のデリゲート関数
    public delegate void DelegateFunc(Tile t);
    public DelegateFunc callbackOnMouseDown = null;

    /// <summary>
    /// タイルクリック時のデリゲートイベント
    /// </summary>
    void OnMouseDown()
    {
        if (callbackOnMouseDown != null) callbackOnMouseDown(this);
    }
    #endregion
}
