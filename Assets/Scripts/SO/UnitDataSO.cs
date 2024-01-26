using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitDataSO", menuName = "Scriptable Object/UnitDataSO")]
public class UnitDataSO : ScriptableObject
{
    [SerializeField] private new string name;
    public string Name => name;

    [SerializeField] private Stat stat;
    public Stat Stat => stat;
}
