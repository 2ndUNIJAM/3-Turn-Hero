using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText, descText;
    [SerializeField] private Image iconImage;

    public Upgrade upgrade;

    public int upgradeType;
    public int upgradeIdx;

    // public void Start()
    // {
    //     upgradeType = Random.Range(0, 5);

    //     upgrade = new Upgrade();

    //     switch(upgradeType)
    //     {
    //         case 0: 
    //             upgradeIdx = Random.Range(0, PlayerUpgrade.playerUpgradeNum);
    //             upgrade = GameManager.Data.playerUpgrades[upgradeIdx];
    //             nameText.SetText(PlayerUpgrade.names);
    //             break;

    //         case 1:
    //             upgradeIdx = Random.Range(0, WeaponUpgrade.weaponUpgradeNum);
    //             upgrade = GameManager.Data.weaponUpgrades[upgradeIdx];
    //             nameText.SetText(WeaponUpgrade.names);
    //             break;

    //         case 2:
    //             upgradeIdx = Random.Range(0, ArmorUpgrade.armorUpgradeNum);
    //             upgrade = GameManager.Data.armorUpgrades[upgradeIdx];
    //             nameText.SetText(ArmorUpgrade.names);
    //             break;

    //         case 3:
    //             upgradeIdx = Random.Range(0, FriendUpgrade.friendUpgradeNum);
    //             upgrade = GameManager.Data.friendUpgrades[upgradeIdx];
    //             nameText.SetText(FriendUpgrade.names);
    //             break;

    //         case 4:
    //             upgradeIdx = Random.Range(0, EctUpgrade.ectUpgradeNum);
    //             upgrade = GameManager.Data.ectUpgrades[upgradeIdx];
    //             nameText.SetText(EctUpgrade.names);
    //             break;

    //     }



    //     descText.SetText(upgrade.description);

    // }
}
