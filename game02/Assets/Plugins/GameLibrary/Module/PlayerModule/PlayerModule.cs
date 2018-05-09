
namespace GameLibrary.PlayerModule
{
    public class PlayerModule : Singleton<PlayerModule>
    {
        public static PlayerModule Instance { get; private set; } = new PlayerModule();

        //TODO:なにかserviceのインスタンス

        public bool Initialized { get; private set; } = false;

        public void Initialize()
        {
            //TODO:各クラスの初期化

            Initialized = true;

        }

    }
}
