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
    /// 장비의 기본 능력치
    /// </summary>
    public Stat basicStat;

    public List<Enhancement> enhancements = new List<Enhancement>();

    /// <summary>
    /// 장비의 기본 능력치에 모든 강화 효과를 반영한 최종 능력치
    /// </summary>
    public Stat finalStat;

    // 플레이어의 공격력에서 적의 방어력 빼고, 데미지 경감 곱셈 곱하기
}
