using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhancement : MonoBehaviour
{
    public string name;
    public string description;

    public enum EquipmentType { Weapon, Armor, Colleague, Body }

    public EquipmentType type;
    // ��� ��ȭ�� ���� Ȯ���� ���� ����.
    // �ٸ� SR ���� ���� �� ��ü������ ��ȭ�ϹǷ� ���� Ȯ���� ������ ���⿡ ���� �ٸ� �� ����.

    /// <summary>
    /// Ư�� ���⸦ ������ ������ �� ��ȭ �ɼ��� �����ϴ� ��� true
    /// </summary>
    public bool hasCondition = false;

    /// <summary>
    /// hasCondition == true �� �� � ��� �̸�(weapon.name �Ǵ� armor.name)���� ����
    /// </summary>
    public string condition;

    public Stat statEnhancement;

    public string effect;
}
