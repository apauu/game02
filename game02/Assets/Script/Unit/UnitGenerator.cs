using UnityEngine;

/// <summary>
/// ユニットプレハブ生成クラス
/// </summary>
public class UnitGenerator : MonoBehaviour
{
    /// <summary>
    /// テスト用のユニットプレハブを返す
    /// </summary>
    public GameObject getTestUnitPrefab (string unitID)
    {
        return GetResource.GetGameObjectFromResource(GameObjectNameConst.PrefabPath + GameObjectNameConst.UnitPrefab);
    }

    ///// <summary>
    ///// ユニットプレハブを生成し、付属するユニットコントローラーを返す
    ///// </summary>
    ///// <param name="unitID"></param>
    ///// <returns></returns>
    //public UnitController generateUnit(string unitID)
    //{
    //    GameObject unitPrefab = null;
    //    UnitController unicon = null;
    //    Unit unit = null;

    //    switch (unitID)
    //    {
    //        case UnitConst.UnitID1:
    //            unitPrefab = (GameObject)Instantiate(GetResource.GetGameObjectFromResource(GameObjectNameConst.PrefabPath + GameObjectNameConst.UnitPrefab), new Vector3(0, 0, 0), Quaternion.identity);
    //            unicon = unitPrefab.GetComponent<UnitController>();
    //            //ユニットのステータスを設定する場合以下で行う
    //            unit = unicon.GetIndividualUnit();
    //            //initStatus(unit, unitID)
    //            break;
    //        default:
    //            break;

    //    }

    //    return unicon;
    //}
}
