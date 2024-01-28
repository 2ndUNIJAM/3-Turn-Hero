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

    [SerializeField]
    private Dictionary<string, WeaponDataSO> weaponDataSODic;
    public Dictionary<string, WeaponDataSO> WeaponDataSODic => weaponDataSODic;

    [SerializeField]
    private Dictionary<string, ArmorDataSO> armorDataSODic;
    public Dictionary<string, ArmorDataSO> ArmorDataSODic => armorDataSODic;

    [SerializeField]
    private Dictionary<string, ColleagueDataSO> colleagueDataSODic;
    public Dictionary<string, ColleagueDataSO> ColleagueDataSODic => colleagueDataSODic;

    public List<PlayerUpgrade> playerUpgrades;
    public List<WeaponUpgrade> weaponUpgrades;
    public List<ArmorUpgrade> armorUpgrades;
    public List<FriendUpgrade> friendUpgrades;
    public List<EctUpgrade> ectUpgrades;

    public static Inventory playerInven;

    public static Stat playerUpgradeStat;

    public int stageID;

    public int currentStage;

    public void Init()
    {
        unitDataSODic = new Dictionary<string, UnitDataSO>();

        playerInven = new Inventory();
        playerUpgradeStat = new Stat();

        stageID = 0;

        currentStage = 1;

        var unitDataSOList = GameManager.Resource.LoadAll<UnitDataSO>("SO/UnitDataSO");

        foreach (var unit in unitDataSOList)
        {
            UnitDataSODic.Add(unit.Name, unit);
        }

        weaponDataSODic = new Dictionary<string, WeaponDataSO>();

        var weaponDataSOList = GameManager.Resource.LoadAll<WeaponDataSO>("SO/WeaponDataSO");

        foreach (var weapon in weaponDataSOList)
        {
            WeaponDataSODic.Add(weapon.EngName, weapon);
        }

        armorDataSODic = new Dictionary<string, ArmorDataSO>();

        var armorDataSOList = GameManager.Resource.LoadAll<ArmorDataSO>("SO/ArmorDataSO");
        foreach (var armor in armorDataSOList)
        {
            ArmorDataSODic.Add(armor.EngName, armor);
        }

        colleagueDataSODic = new Dictionary<string, ColleagueDataSO>();

        var colleagueDataSOList = GameManager.Resource.LoadAll<ColleagueDataSO>("SO/ColleagueDataSO");
        foreach (var colleague in colleagueDataSOList)
        {
            ColleagueDataSODic.Add(colleague.EngName, colleague);
        }

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
    }
}
