using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUICanvas : MonoBehaviour
{
    [SerializeField] Image Weapon;
    [SerializeField] Image Armor;
    [SerializeField] Image Colleague;
    [SerializeField] TextMeshProUGUI HPText;
    [SerializeField] TextMeshProUGUI ATKText;
    [SerializeField] TextMeshProUGUI DEFText;
    [SerializeField] TextMeshProUGUI ATKSpeedText;
    [SerializeField] TextMeshProUGUI MoveSpeedText;

    public Stat stat = new Stat();

    void Update()
    {
        stat = PlayerManager.Instance.Player.Stat;

        Weapon.sprite = PlayerManager.Instance.Player.inven.weapon.SmallIcon;
        Armor.sprite = PlayerManager.Instance.Player.inven.armor.SmallIcon;
        Colleague.sprite = PlayerManager.Instance.Player.inven.colleague.SmallIcon;

        HPText.SetText("HP: " + stat.CurrentHP.ToString());
        ATKText.SetText("ATK: " + stat.ATK.ToString());
        DEFText.SetText("DEF: " + stat.DEF.ToString());
        ATKSpeedText.SetText("ATKSpeed: " + stat.GetRealAttackSpeed.ToString());
        MoveSpeedText.SetText("MoveSpeed: " + stat.GetRealMoveSpeed.ToString());
    }
}
