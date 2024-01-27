using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    public void ElementFireEffect(Unit user, Unit subject, int level)
    {
        int damageAmount;
        switch (level)
        {
            case 1:
                damageAmount = 2;
                break;
            case 2:
                damageAmount = 3;
                break;
            case 3:
                damageAmount = 4;
                break;
            case 4:
                damageAmount = 5;
                break;
            default: return;
        }
        StartCoroutine(subject.DottedDamage(damageAmount));
    }
}
