using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.BattleModule.Service
{
    public class BaseService<T> : Singleton<T> where T : new()
    {

    }
}
