using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitDataSO data;
    public UnitDataSO Data => data;

    [SerializeField] private Stat changedStat;
    public Stat ChangedStat => changedStat;

    public Stat Stat => data.Stat + changedStat;

}
