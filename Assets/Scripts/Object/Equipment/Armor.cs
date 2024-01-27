using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    public enum ArmorType { Leather, Metal, Elemental }
    public ArmorType armorType;
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
}
