using UnityEngine;
using System.Collections;

public class GetResource : MonoBehaviour {

    public  static GameObject GetGameObjectFromResource(string objectName)
    {
        // ゲームオブジェクトを取得を取得
        GameObject gameObject = (GameObject)Resources.Load(objectName);
        return gameObject;
    }
}
