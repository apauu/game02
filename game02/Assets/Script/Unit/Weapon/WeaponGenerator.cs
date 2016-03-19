/// <summary>
/// 装備インスタンスを生成する
/// </summary>
public class WeaponGenerator {

	public Weapon getInstance(string weaponID)
    {
        Weapon weapon = null;

        switch(weaponID)
        {
            case EquipConst.WeaponID1:
                weapon = new Weapon(
                    EquipConst.WeaponID1,
                    EquipConst.WeaponName1,
                    EquipConst.WeaponPower1
                    );
                break;
            case EquipConst.WeaponID2:
                weapon = new Weapon(
                    EquipConst.WeaponID2,
                    EquipConst.WeaponName2,
                    EquipConst.WeaponPower2
                    );
                break;
            case EquipConst.WeaponID3:
                weapon = new Weapon(
                    EquipConst.WeaponID3,
                    EquipConst.WeaponName3,
                    EquipConst.WeaponPower3
                    );
                break;
            default:
                break;

        }

        return weapon;
    }
}
