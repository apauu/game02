
namespace GameLibrary
{
    public class Singleton<T> where T : new()
    {
        public static T Instance { get; private set; } = new T();
    }
}