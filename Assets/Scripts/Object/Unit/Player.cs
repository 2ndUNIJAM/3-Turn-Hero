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

        Debug.Log("CurrentHP:" + Stat.CurrentHP);
        Debug.Log("ATK: " + Stat.ATK);
        Debug.Log("DEF: " + Stat.DEF);
        Debug.Log("AttackSpeed: " + Stat.AttackSpeed);
        Debug.Log("MoveSpeed: " + Stat.MoveSpeed);
    }


    public override void CheckDead()
    {
        base.CheckDead();

        if (Stat.CurrentHP <= 0f)
        {
            GameManager.Sound.PlaySE("KO");
            BattleManager.Instance.GameLose();
            animator.enabled = false;
        }
    }

    public override void ReduceHP(int damage)
    {
        if (isDead) return;

        if (Armor.IsCanMiss)
        {
            Armor.IsCanMiss = false;

            FloatingDamage MissUI = BattleManager.Instance.BattleUI.CreateFloatingDamage();
            MissUI.Init(gameObject, "(MISS)", UpPos, Color.white);
            return;
        }

        ChangedStat.CurrentHP -= damage;
        CheckDead();
        StartHitAnim(DEFAULT_FAINT_TIME);

        FloatingDamage damageUI = BattleManager.Instance.BattleUI.CreateFloatingDamage();
        damageUI.Init(gameObject, $"-{damage}", UpPos, new Color(1f, 0.4f, 0.4f));
    }
}
