using UnityEngine;

/// <summary>
/// マップの１マスの情報を保持するクラス。
/// </summary>
public class Tile :MonoBehaviour{

    #region フィールド変数
    public int tileID { get; set; }
    //画像ファイル
    public string texture { get; set; }

    //ゲーム上のX,Y座標（Unity座標上の値でない）
    public Vector2 location { get; set; }

    //Unity上の3次元座標
    public Vector3 realLocation
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    //高さ。マイナス有り
    public int hight { get; set; }

    //勢力情報
    public int belongAlly { get; set; }

    //true：拠点　false：その他
    public bool isBase { get; set; }

    //true：通行可　false：通行不可
    public bool canEnter { get; set; }

    //ユニットが通る際の追加移動力（沼地等）：０（平地）～－１０（進入不可）
    public int movementForce { get; set; }

    //ユニットが通る際の追加防御力（砦等）
    public int defensiveForce { get; set; }

    #endregion

    /// <summary>
    /// デリゲート用
    /// </summary>
    public delegate void DelegateFunc();
    public DelegateFunc callbackOnMouseDown = null;

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

    /// <summary>
    /// タイルクリック時のデリゲートイベント
    /// </summary>
    void OnMouseDown()
    {
        if (callbackOnMouseDown != null) callbackOnMouseDown();
    }
}
