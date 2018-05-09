using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule
{
    public class BattleModule : Singleton<BattleModule>
    {
        //TODO:なにかserviceのインスタンス

        public bool Initialized { get; private set; } = false;

        public void Initialize()
        {
            //TODO:各クラスの初期化

            Initialized = true;

        }

    }
}
