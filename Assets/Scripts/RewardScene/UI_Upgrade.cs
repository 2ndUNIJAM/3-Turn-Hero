using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText, descText;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image panel;

    public Upgrade upgrade;

    public int upgradeType;
    public int upgradeIdx;

    public void Start()
    {
        upgradeType = Random.Range(0, 5);

        upgrade = new Upgrade();
        
        switch (upgradeType)
        {
            case 0: 
                upgradeIdx = Random.Range(0, PlayerUpgrade.playerUpgradeNum);
                upgrade = GameManager.Data.playerUpgrades[upgradeIdx];
                nameText.SetText(PlayerUpgrade.names);
                break;

            case 1:
                upgradeIdx = Random.Range(0, WeaponUpgrade.weaponUpgradeNum);
                upgrade = GameManager.Data.weaponUpgrades[upgradeIdx];
                nameText.SetText(WeaponUpgrade.names);
                break;

            case 2:
                upgradeIdx = Random.Range(0, ArmorUpgrade.armorUpgradeNum);
                upgrade = GameManager.Data.armorUpgrades[upgradeIdx];
                nameText.SetText(ArmorUpgrade.names);
                break;

            case 3:
                upgradeIdx = Random.Range(0, FriendUpgrade.friendUpgradeNum);
                upgrade = GameManager.Data.friendUpgrades[upgradeIdx];
                nameText.SetText(FriendUpgrade.names);
                break;

            case 4:
                upgradeIdx = Random.Range(0, EctUpgrade.ectUpgradeNum);
                upgrade = GameManager.Data.ectUpgrades[upgradeIdx];
                nameText.SetText(EctUpgrade.names);
                break;

        }

        
        
        descText.SetText(upgrade.description);
        
    }

    public IEnumerator FadeIn()
    {
        nameText.color = new Color(nameText.color.r, nameText.color.g, nameText.color.b, 0);
        descText.color = new Color(descText.color.r, descText.color.g, descText.color.b, 0);
        iconImage.color = new Color(iconImage.color.r, iconImage.color.g, iconImage.color.b, 0);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);

        gameObject.SetActive(true);

        for(int i = 1; i<=30; i++)
        {
            nameText.color = new Color(nameText.color.r, nameText.color.g, nameText.color.b, i / 30f);
            descText.color = new Color(descText.color.r, descText.color.g, descText.color.b, i / 30f);
            iconImage.color = new Color(iconImage.color.r, iconImage.color.g, iconImage.color.b, i / 30f);
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, i / 30f);
            
            yield return null;
        }
    }
}
