using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ʹ� Scriptable Object�� �����˴ϴ�.
/// ���� �б� �����̸�, ���� ���࿡ �ʿ��� ��ҵ��� �����Դϴ�.
/// </summary>
public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, UnitDataSO> unitDataSODic;
    public Dictionary<string, UnitDataSO> UnitDataSODic => unitDataSODic;

    public List<PlayerUpgrade> playerUpgrades;
    public List<WeaponUpgrade> weaponUpgrades;
    public List<ArmorUpgrade> armorUpgrades;
    public List<FriendUpgrade> friendUpgrades;
    public List<EctUpgrade> ectUpgrades;

    public Inventory playerInven;

    public Stat playerUpgradeStat;

    public int stageID;

    public void Init()
    {
        unitDataSODic = new Dictionary<string, UnitDataSO>();

        playerUpgrades = new List<PlayerUpgrade>();
        PlayerUpgrade.Init();
        for (int i = 0; i < PlayerUpgrade.playerUpgradeNum; i++)
            playerUpgrades.Add(new PlayerUpgrade(i));

        weaponUpgrades = new List<WeaponUpgrade>();
        WeaponUpgrade.Init();
        for (int i = 0; i < WeaponUpgrade.weaponUpgradeNum; i++)
            weaponUpgrades.Add(new WeaponUpgrade(i));

        armorUpgrades = new List<ArmorUpgrade>();
        ArmorUpgrade.Init();
        for (int i = 0; i < ArmorUpgrade.armorUpgradeNum; i++)
            armorUpgrades.Add(new ArmorUpgrade(i));

        friendUpgrades = new List<FriendUpgrade>();
        FriendUpgrade.Init();
        for (int i = 0; i < FriendUpgrade.friendUpgradeNum; i++)
            friendUpgrades.Add(new FriendUpgrade(i));

        ectUpgrades = new List<EctUpgrade>();
        EctUpgrade.Init();
        for (int i = 0; i < EctUpgrade.ectUpgradeNum; i++)
            ectUpgrades.Add(new EctUpgrade(i));


        stageID = 0;

        var unitDataSOList = GameManager.Resource.LoadAll<UnitDataSO>("SO/UnitDataSO");
        foreach (var unit in unitDataSOList)
        {
            UnitDataSODic.Add(unit.Name, unit);
        }
    }
}
