using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule.Entity
{
    public class MapEntity : BaseEntity
    {
        //ID
        public int mapID { get; set; }
        //タイル（実体）の二次元配列
        public TileEntity[][] tiles { get; set; }
    }
}
