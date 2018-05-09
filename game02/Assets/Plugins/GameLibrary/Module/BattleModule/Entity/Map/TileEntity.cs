using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule.Entity
{
    public class TileEntity : BaseEntity
    {
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
        public Point location { get; set; }
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
    }
}
