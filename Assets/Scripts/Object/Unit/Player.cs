using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private const float DEFAULT_FAINT_TIME = 0.5f;

    public Inventory inven;
    public Stat upgradedStat; // ��ȭ(����) ����

    public new Stat Stat => base.Stat + upgradedStat;

    public void InitFromDataManager()
    {
        inven = GameManager.Data.playerInven;
        upgradedStat = GameManager.Data.playerUpgradeStat;
    }

    public override void ReduceHP(int damage)
    {
        if (isDead) return;

        base.ReduceHP(damage);
        StartHitAnim(DEFAULT_FAINT_TIME);
    }
}
