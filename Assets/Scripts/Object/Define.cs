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
    public int PPower;
    public int PArmor;
    public int MPower;
    public int MArmor;
    public int AttackSpeed;
    public int MoveSpeed;

    public static Stat operator +(Stat lhs, Stat rhs)
    {
        Stat result = new();
        result.MaxHP = lhs.MaxHP + rhs.MaxHP;
        result.CurrentHP = lhs.CurrentHP + rhs.CurrentHP;
        result.PPower = lhs.PPower + rhs.PPower;
        result.PArmor = lhs.PArmor + rhs.PArmor;
        result.MPower = lhs.MPower + rhs.MPower;
        result.MArmor = lhs.MArmor + rhs.MArmor;
        result.AttackSpeed = lhs.AttackSpeed + rhs.AttackSpeed;
        result.MoveSpeed = lhs.MoveSpeed + rhs.MoveSpeed;

        return result;
    }

    public static Stat operator -(Stat lhs, Stat rhs)
    {
        Stat result = new();
        result.MaxHP = lhs.MaxHP - rhs.MaxHP;
        result.CurrentHP = lhs.CurrentHP - rhs.CurrentHP;
        result.PPower = lhs.PPower - rhs.PPower;
        result.PArmor = lhs.PArmor - rhs.PArmor;
        result.MPower = lhs.MPower - rhs.MPower;
        result.MArmor = lhs.MArmor - rhs.MArmor;
        result.AttackSpeed = lhs.AttackSpeed - rhs.AttackSpeed;
        result.MoveSpeed = lhs.MoveSpeed - rhs.MoveSpeed;

        return result;
    }

    public void ClearStat()
    {
        MaxHP = 0;
        CurrentHP = 0;
        PPower = 0;
        PArmor = 0;
        MPower = 0;
        MArmor = 0;
        AttackSpeed = 0;
        MoveSpeed = 0;
    }
}
