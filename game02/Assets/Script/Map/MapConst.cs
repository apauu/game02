
/// <summary>
/// マップの定数クラス
/// </summary>
public static class MapConst {

    // マップID
    public const int Map1 = 1;
    public const int Map2 = 2;
    public const int Map3 = 3;

    // マップ名
    public const string MapName1 = "Map1";

    // タイルID
    // 移動力補正なし
    public const int Plains = 0;

    // 移動力＋
    public const int Fortress = 100;

    // 移動力－
    public const int Pool = 200;
    public const int Bogland = 210;

    // 移動不可
    public const int Wall = 900;
    public const int Empty = 910;

    //y座標基準値（海抜0地点）
    public const float BaseY = 0;

    //地形別タイルクラス初期値
    public static readonly Tile PlainsTemplate = new Tile(
        Plains,
        "Plains",
        false,
        true,
        0,
        0
        );

    public static readonly Tile FortressTemplate = new Tile(
        Fortress,
        "Fortress",
        true,
        true,
        1,
        2
        );

    public static readonly Tile PoolTemplate = new Tile(
        Pool,
        "Pool",
        false,
        true,
        -3,
        0
        );

    public static readonly Tile BoglandTemplate = new Tile(
        Bogland,
        "Bogland",
        false,
        true,
        -1,
        -1
        );

    public static readonly Tile WallTemplate = new Tile(
        Wall,
        "Wall",
        false,
        false,
        0,
        0
        );

    public static readonly Tile EmptyTemplate = new Tile(
        Empty,
        "Empty",
        false,
        false,
        -100,
        0
        );

}