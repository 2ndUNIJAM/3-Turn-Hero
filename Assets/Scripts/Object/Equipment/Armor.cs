using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Armor : Equipment
{
    public static bool IsCanMiss = false;

    public enum ArmorType { Leather, Metal, Elemental }
    public ArmorType armorType;
    public delegate void ActiveEffect(Unit user, Unit subject);
    private Stat passiveBonusStat = new Stat();
    public Stat Stat => basicStat + passiveBonusStat;
    public int multiJump = 1;

    private int _specialArmorLevel = 0;
    public int SpecialArmorLevel
    {
        get
        {
            return _specialArmorLevel;
        }
        set
        {
            _specialArmorLevel = value;
            if (englishName == "AdamantiumArmor")
            {
                switch (value)
                {
                    case 0:
                        passiveBonusStat.DEF = 0;
                        break;
                    case 1:
                        passiveBonusStat.DEF = 20;
                        break;
                    case 2:
                        passiveBonusStat.DEF = 25;
                        break;
                    case 3:
                        passiveBonusStat.DEF = 30;
                        break;
                }
            }
            else if (englishName == "SylphArmor")
            {
                switch (value)
                {
                    case 0:
                        multiJump = 1;
                        break;
                    case 1:
                        multiJump = 2;
                        break;
                    case 2:
                        multiJump = 3;
                        break;
                    case 3:
                        multiJump = 4;
                        break;
                }
            }
        }
    }

    public void InvokeAttackEffect(Unit user, Unit subject)
    {
        ActiveEffect effect = null;
        if (ElementFireLevel > 0)
        {
            effect += ActiveElementFireEffect;
        }

        if (ElementIceLevel > 0)
        {
            effect += ActiveElementIceEffect;
        }

        // 경직 효과는 냉기 레벨이 0이더라도 발동
        effect += ActiveElementIceEffect;

        if (effect != null)
        {
            effect.Invoke(user, subject);
        }
    }

    public void ActiveElementFireEffect(Unit user, Unit subject)
    {
        int reflectionDamage;
        switch (ElementFireLevel)
        {
            case 1:
                reflectionDamage = 5;
                break;
            case 2:
                reflectionDamage = 7;
                break;
            case 3:
                reflectionDamage = 9;
                break;
            case 4:
                reflectionDamage = 11;
                break;
            default: return;
        }

        subject.ReduceHP(reflectionDamage);
    }

    public void ActiveElementIceEffect(Unit user, Unit subject)
    {
        float missPercent;
        switch (ElementIceLevel)
        {
            case 1:
                missPercent = 0.05f;
                break;
            case 2:
                missPercent = 0.1f;
                break;
            case 3:
                missPercent = 0.15f;
                break;
            case 4:
                missPercent = 0.2f;
                break;
            case 0:
            default:
                missPercent = 0f;
                break;
        }

        if (RandomManager.GetFlag(missPercent))
            IsCanMiss = true;
    }

    public override void passiveElementGroundEffect(int newLevel)
    {
        base.passiveElementGroundEffect(newLevel);
        switch (newLevel)
        {
            case 1:
                passiveBonusStat.DEF = 5;
                break;
            case 2:
                passiveBonusStat.DEF = 8;
                break;
            case 3:
                passiveBonusStat.DEF = 12;
                break;
            case 4:
                passiveBonusStat.DEF = 15;
                break;
            case 0:
            default:
                passiveBonusStat.DEF = 0;
                break;
        }
    }

    public override void passiveElementWindEffect(int newLevel)
    {
        base.passiveElementWindEffect(newLevel);
        switch (newLevel)
        {
            case 1:
                passiveBonusStat.MoveSpeed = 5;
                break;
            case 2:
                passiveBonusStat.MoveSpeed = 8;
                break;
            case 3:
                passiveBonusStat.MoveSpeed = 12;
                break;
            case 4:
                passiveBonusStat.MoveSpeed = 15;
                break;
            case 0:
            default:
                passiveBonusStat.MoveSpeed = 0;
                break;
        }
    }

    public int GetArmorType()
    {
        if (ElementFireLevel > 0)
        {
            if (rarity == 0) return 0;
            else return 1;
        }
        else if (ElementWindLevel > 0)
        {
            if (rarity == 0) return 2;
            else return 3;
        }
        else if (ElementGroundLevel > 0)
        {
            if (rarity == 0) return 4;
            else return 5;
        }
        else if (ElementIceLevel > 0)
        {
            if (rarity == 0) return 4;
            else return 5;
        }
        return 0;
    }
}
