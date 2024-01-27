using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhancement : MonoBehaviour
{
    public string name;
    public string description;

    public enum EquipmentType { Weapon, Armor, Colleague, Body }

    public EquipmentType type;
    // 모든 강화의 등장 확률은 서롣 동일.
    // 다만 SR 무기 장착 시 전체집합이 변화하므로 실제 확률은 장착한 무기에 따라 다를 수 있음.

    /// <summary>
    /// 특정 무기를 장착할 때에만 이 강화 옵션이 등장하는 경우 true
    /// </summary>
    public bool hasCondition = false;

    /// <summary>
    /// hasCondition == true 일 때 어떤 장비 이름(weapon.name 또는 armor.name)인지 저장
    /// </summary>
    public string condition;

    public Stat statEnhancement;

    public string effect;
}
