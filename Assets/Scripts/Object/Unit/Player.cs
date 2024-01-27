using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private const float DEFAULT_FAINT_TIME = 0.5f;

    public Inventory inven;
    public Stat upgradedStat; // 누적(변화된) 능력치

    public new Stat Stat => base.Stat + upgradedStat;

    private void Start()
    {
        upPos = Vector3.up;
    }

    public void InitFromDataManager()
    {
        inven = DataManager.playerInven;
        upgradedStat = DataManager.playerUpgradeStat;

        upgradedStat += inven.weapon.Stat;
        upgradedStat += inven.armor.Stat;
    }


    public override void CheckDead()
    {
        base.CheckDead();

        if (Stat.CurrentHP <= 0f)
        {
            BattleManager.Instance.GameLose();
            animator.enabled = false;
        }
    }

    public override void ReduceHP(int damage)
    {
        if (isDead) return;

        ChangedStat.CurrentHP -= damage;
        CheckDead();
        StartHitAnim(DEFAULT_FAINT_TIME);
    }
}
