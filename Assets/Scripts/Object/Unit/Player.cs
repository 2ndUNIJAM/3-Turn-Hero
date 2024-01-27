using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public Inventory inven;
    public Stat upgradedStat; // ��ȭ(����) ����

    public new Stat Stat => base.Stat + upgradedStat;

    public void InitFromDataManager()
    {
        inven = GameManager.Data.playerInven;
        upgradedStat = GameManager.Data.playerUpgradeStat;
    }
}
