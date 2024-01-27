using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    public enum ArmorType { Leather, Metal, Elemental }
    public ArmorType armorType;
    public Stat passiveBonusStat = new Stat();
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
                        passiveBonusStat.PArmor = 0;
                        break;
                    case 1:
                        passiveBonusStat.PArmor = 20;
                        break;
                    case 2:
                        passiveBonusStat.PArmor = 25;
                        break;
                    case 3:
                        passiveBonusStat.PArmor = 30;
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
