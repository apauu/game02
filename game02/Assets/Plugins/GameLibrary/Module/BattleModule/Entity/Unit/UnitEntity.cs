using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule.Entity
{
    /// <summary>
    /// ユニット
    /// </summary>
    public class UnitEntity : BaseEntity
    {
        /// <summary>
        /// ゲーム上のX,Y座標
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// GUID
        /// </summary>
        public int GUID { get; set; }
        /// <summary>
        /// ユニットID
        /// </summary>
        public string unitId { get; set; }
        /// <summary>
        /// キャラクター名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 種族名
        /// </summary>
        public string typeName { get; set; }
        /// <summary>
        /// 種族属性　近接/遠距離/呪い
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// レベル
        /// </summary>
        public int lvl { get; set; }
        /// <summary>
        /// 現在経験値
        /// </summary>
        public int exp { get; set; }
        /// <summary>
        /// 所持スキル
        /// </summary>
        public List<SkillEntity> skills { get; set; } = new List<SkillEntity>();

        /// <summary>
        /// 戦闘開始前のユニットの基礎スペック
        /// </summary>
        public UnitSpecEntity BaseSpec { get; set; }
        /// <summary>
        /// 戦闘中のユニットのスペック
        /// </summary>
        public UnitSpecEntity CurrentSpec { get; set; }
        /// <summary>
        /// 武器
        /// </summary>
        public WeaponEntity weapon { get; set; }

        /// <summary>
        /// バトル中に変化するパラメータ
        /// </summary>
        public BattleParameterEntity BattleParameter { get; set; }

    }
}
