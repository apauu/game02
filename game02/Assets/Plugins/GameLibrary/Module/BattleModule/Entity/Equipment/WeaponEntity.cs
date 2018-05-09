using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule.Entity
{
    /// <summary>
    /// 武器
    /// </summary>
    public class WeaponEntity : BaseEntity
    {
        /// <summary>
        /// 装備ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 攻撃力
        /// </summary>
        public int power { get; set; }

        public WeaponEntity(string id, string name, int power)
        {
            this.id = id;
            this.name = name;
            this.power = power;
        }
    }
}
