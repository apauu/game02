using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule.Entity
{
    /// <summary>
    /// バトル中に変化するパラメータのまとまり
    /// </summary>
    public class BattleParameterEntity : BaseEntity
    {
        /// <summary>
        /// 陣営
        /// </summary>
        public int ally { get; set; }
        /// <summary>
        /// バフ・デバフ
        /// </summary>
        private List<BattleEffectEntity> Effects = new List<BattleEffectEntity>();
        /// <summary>
        /// 生死 true:生 false:死
        /// </summary>
        public bool living { get; set; }
        /// <summary>
        /// 行動可不可 true:可能 false:不可能
        /// </summary>
        public bool active { get; set; }
    }
}
