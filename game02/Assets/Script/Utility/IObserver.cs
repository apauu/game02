using UnityEngine;
using System.Collections;

/// <summary>
///  IObserverインターフェイスです。
/// </summary>
public interface IObserver {

    // 更新します。
    void Update(GameObject obj);
}
