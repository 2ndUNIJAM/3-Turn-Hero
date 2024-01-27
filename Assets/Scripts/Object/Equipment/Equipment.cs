using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public string name;
    public string description;

    public bool hasElementFire = false;
    public bool hasElementGround = false;
    public bool hasElementWind = false;
    public bool hasElementIce = false;

    public enum Rarity { N, R, SR }
    public Rarity rarity;
    public float probability;

    /// <summary>
    /// ����� �⺻ �ɷ�ġ
    /// </summary>
    public Stat basicStat;

    public List<Enhancement> enhancements = new List<Enhancement>();

    /// <summary>
    /// ����� �⺻ �ɷ�ġ�� ��� ��ȭ ȿ���� �ݿ��� ���� �ɷ�ġ
    /// </summary>
    public Stat finalStat;

    // �÷��̾��� ���ݷ¿��� ���� ���� ����, ������ �氨 ���� ���ϱ�
}
