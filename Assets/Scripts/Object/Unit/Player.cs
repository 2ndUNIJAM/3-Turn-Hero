using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private const float DEFAULT_FAINT_TIME = 0.5f;

    public Inventory inven;
    public Stat upgradedStat; // 강화(누적) 스탯

    public new Stat Stat => base.Stat + upgradedStat;

    private void Start()
    {
        upPos = Vector3.up;
    }

    public void InitFromDataManager()
    {
        inven = GameManager.Data.playerInven;
        upgradedStat = GameManager.Data.playerUpgradeStat;
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
