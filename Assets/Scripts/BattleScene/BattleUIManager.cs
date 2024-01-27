using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIManager : MonoBehaviour
{
    public FloatingDamage CreateFloatingDamage()
    {
        return GameManager.Resource.Instantiate("FloatingDamage", this.transform).GetComponent<FloatingDamage>();
    }

    public HPBar CreateHPBar()
    {
        return GameManager.Resource.Instantiate("HPBar", this.transform).GetComponent<HPBar>();
    }
}
