using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct Stat
{
    public int MaxHP;
    public int CurrentHP;
    public int ATK;
    public int DEF;
    //public int MPower;
    //public int MArmor;
    public int AttackSpeed;
    public int MoveSpeed;

    // 구조체는 기본 생성자를 만들 수 없음. 그래서 그냥 인자로 다 0 값 넣어주고, 그냥 다 0으로 세팅.
    // weapon, armor 등등 특정 스탯만 가지는 아이템들이 있어, 생성자로 0들을 넣어주고 필요한 값만 할당하는 방식으로 사용.
    public Stat(int maxHP, int currentHP, int pPower, int pArmor, int attackSpeed, int moveSpeed)
    {
        MaxHP = 0;
        CurrentHP = 0;
        ATK = 0;
        DEF = 0;
        //MPower = 0;
        //MArmor = 0;
        AttackSpeed = 0;
        MoveSpeed = 0;
    }

    public static Stat operator +(Stat lhs, Stat rhs)
    {
        Stat result = new();
        result.MaxHP = lhs.MaxHP + rhs.MaxHP;
        result.CurrentHP = Mathf.Clamp(lhs.CurrentHP + rhs.CurrentHP, 0, result.MaxHP);
        result.ATK = lhs.ATK + rhs.ATK;
        result.DEF = lhs.DEF + rhs.DEF;
        //result.MPower = lhs.MPower + rhs.MPower;
        //result.MArmor = lhs.MArmor + rhs.MArmor;
        result.AttackSpeed = lhs.AttackSpeed + rhs.AttackSpeed;
        result.MoveSpeed = lhs.MoveSpeed + rhs.MoveSpeed;

        return result;
    }

    public static Stat operator -(Stat lhs, Stat rhs)
    {
        Stat result = new();
        result.MaxHP = Mathf.Max(lhs.MaxHP - rhs.MaxHP, 0);
        result.CurrentHP = Mathf.Clamp(lhs.CurrentHP - rhs.CurrentHP, 0, result.MaxHP);
        result.ATK = lhs.ATK - rhs.ATK;
        result.DEF = lhs.DEF - rhs.DEF;
        //result.MPower = lhs.MPower - rhs.MPower;
        //result.MArmor = lhs.MArmor - rhs.MArmor;
        result.AttackSpeed = lhs.AttackSpeed - rhs.AttackSpeed;
        result.MoveSpeed = lhs.MoveSpeed - rhs.MoveSpeed;

        return result;
    }

    public float GetRealAttackSpeed => Mathf.Clamp(1f + AttackSpeed * 0.2f, 1f, 5f);

    public float GetRealMoveSpeed => Mathf.Clamp(1f + MoveSpeed * 0.2f, 3f, 12f);

    public void ClearStat()
    {
        MaxHP = 0;
        CurrentHP = 0;
        ATK = 0;
        DEF = 0;
        //MPower = 0;
        //MArmor = 0;
        AttackSpeed = 0;
        MoveSpeed = 0;
    }

    public Stat Clone()
    {
        Stat result = new();
        result.MaxHP = MaxHP;
        result.CurrentHP = CurrentHP;
        result.ATK = ATK;
        result.DEF = DEF;
        //result.MPower = MPower;
        //result.MArmor = MArmor;
        result.AttackSpeed = AttackSpeed;
        result.MoveSpeed = MoveSpeed;
        return result;
    }
}

[Serializable]
public class Inventory
{
    public Weapon weapon;
    public Armor armor;
    public Colleague colleague;
}

public enum Scene
{
    MainScene,
    SelectScene,
    BattleScene,
    RewardScene,
    MapSelectScene,
}
