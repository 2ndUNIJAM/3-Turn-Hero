using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public string englishName;
    public string koreanName;
    public string description;

    public Image icon;

    protected int _elementFireLevel = 0;
    protected int _elementGroundLevel = 0;
    protected int _elementWindLevel = 0;
    protected int _elementIceLevel = 0;

    public int ElementFireLevel
    {
        get
        {
            return _elementFireLevel;
        }
        set
        {
            _elementFireLevel = value;
        }
    }

    public int ElementGroundLevel
    {
        get
        {
            return _elementGroundLevel;
        }
        set
        {
            _elementGroundLevel = value;
            passiveElementGroundEffect(value);
        }
    }

    public int ElementWindLevel
    {
        get
        {
            return _elementWindLevel;
        }
        set
        {
            _elementWindLevel = value;
            passiveElementWindEffect(value);
        }
    }

    public int ElementIceLevel
    {
        get
        {
            return _elementIceLevel;
        }
        set
        {
            _elementIceLevel = value;
        }
    }

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

    public virtual void passiveElementGroundEffect(int newLevel)
    {

    }

    public virtual void passiveElementWindEffect(int newLevel)
    {

    }
}
