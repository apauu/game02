using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule.Entity
{
    /// <summary>
    /// ユニットの戦闘に影響するスペック
    /// </summary>
    public class UnitSpecEntity : BaseEntity
    {
        /// <summary>
        /// 移動量
        /// </summary>
        public int Mobility { get; set; }
        /// <summary>
        /// 妖力（HP）.
        /// </summary>
        public int Hp { get; set; }
        /// <summary>
        /// 攻撃力
        /// </summary>
        public int Atk { get; set; }
        /// <summary>
        /// 守備力
        /// </summary>
        public int Def { get; set; }
        /// <summary>
        /// 回避力
        /// </summary>
        public int Avoid { get; set; }
        /// <summary>
        /// 命中力
        /// </summary>
        public int Hit { get; set; }
        /// <summary>
        /// 呪力
        /// </summary>
        public int Magic { get; set; }

    }
}
