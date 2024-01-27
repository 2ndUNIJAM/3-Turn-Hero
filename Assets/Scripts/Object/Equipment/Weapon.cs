using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    public static bool IsCanFaint = true;

    public bool canMultiHit = false;    // true이면 한 번의 공격으로 두 명의 적을 타격
    public delegate void ActiveEffect(Unit user, Unit subject);
    private Stat passiveBonusStat = new Stat();
    public Stat Stat => basicStat + passiveBonusStat;
    private int _specialWeaponLevel = 0;  // 탐욕의 검, 롱기누스의 창 일 때에만 1 이상 

    public Weapon()
    {

    }

    public int SpecialWeaponLevel
    {
        get
        {
            return _specialWeaponLevel;
        }
        set
        {
            if (englishName == "HolyLance")
            {
                _specialWeaponLevel = value;
            }
            else if (englishName == "GreedSword" && _specialWeaponLevel < value && value <= 4)
            {
                List<string> notHaveYet = new List<string>();
                int haveCount = 0;
                if (ElementFireLevel == 0)
                    notHaveYet.Add("F");
                else
                    haveCount++;
                if (ElementGroundLevel == 0)
                    notHaveYet.Add("G");
                else
                    haveCount++;
                if (ElementIceLevel == 0)
                    notHaveYet.Add("I");
                else
                    haveCount++;
                if (ElementWindLevel == 0)
                    notHaveYet.Add("W");
                else
                    haveCount++;

                // 모자란 속성 개수만큼 랜덤으로 속성 획득
                while (haveCount < _specialWeaponLevel)
                {
                    string gainedElement = notHaveYet[Random.Range(0, notHaveYet.Count)];
                    switch (gainedElement)
                    {
                        case "F":
                            ElementFireLevel = 1;
                            notHaveYet.Remove("F");
                            break;
                        case "G":
                            ElementGroundLevel = 1;
                            notHaveYet.Remove("G");
                            break;
                        case "I":
                            ElementIceLevel = 1;
                            notHaveYet.Remove("I");
                            break;
                        case "W":
                            ElementWindLevel = 1;
                            notHaveYet.Remove("W");
                            break;
                    }
                    haveCount++;
                }
                _specialWeaponLevel = value;
            }
        }
    }

    /// <summary>
    /// 공격 시 발동하는 무기 특수 효과를 시전합니다.
    /// 공격 시 호출하면 됩니다.
    /// </summary>
    /// <param name="user">무기 사용자</param>
    /// <param name="subject">피격자</param>
    public void InvokeAttackEffect(Unit user, Unit subject)
    {
        ActiveEffect effect = null;
        if (ElementFireLevel > 0)
        {
            effect += ActiveElementFireEffect;
        }

        // 경직 효과는 냉기 레벨이 0이더라도 발동
        effect += ActiveElementIceEffect;

        if (englishName == "HolyLance")
        {
            effect += ActiveHolyLanceEffect;
        }

        if (effect != null)
        {
            effect.Invoke(user, subject);
        }
    }

    /// <summary>
    /// 불 특수 효과: 3초 간 피격자에게 1초마다 가해지는 지속 데미지 적용
    /// </summary>
    /// <param name="user"></param>
    /// <param name="subject"></param>
    public void ActiveElementFireEffect(Unit user, Unit subject)
    {
        int damageAmount;
        switch (ElementFireLevel)
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

        subject.SetDotDamage(damageAmount);
    }

    /// <summary>
    /// 냉기 특수 효과: 피격자 경직 시간 증가 (냉기 레벨이 0이어도 경직 효과를 여기서 관리)
    /// </summary>
    /// <param name="user"></param>
    /// <param name="subject"></param>
    public void ActiveElementIceEffect(Unit user, Unit subject)
    {
        float timeAmount;
        switch (ElementIceLevel)
        {
            case 1:
                timeAmount = 3f;
                break;
            case 2:
                timeAmount = 3.5f;
                break;
            case 3:
                timeAmount = 4f;
                break;
            case 4:
                timeAmount = 4.5f;
                break;
            case 0:
            default:
                timeAmount = 0.5f;
                break;
        }

        subject.SetFaint(timeAmount);
    }

    // TODO Wind, Ground 효과는 상태이상으로 인해 변하는 스탯 변수를 따로 만들어 여기에 반영
    public override void passiveElementGroundEffect(int newLevel)
    {
        base.passiveElementGroundEffect(newLevel);
        switch (newLevel)
        {
            case 1:
                passiveBonusStat.ATK = 5;
                break;
            case 2:
                passiveBonusStat.ATK = 8;
                break;
            case 3:
                passiveBonusStat.ATK = 12;
                break;
            case 4:
                passiveBonusStat.ATK = 15;
                break;
            case 0:
            default:
                passiveBonusStat.ATK = 0;
                break;
        }
    }

    public override void passiveElementWindEffect(int newLevel)
    {
        base.passiveElementWindEffect(newLevel);
        switch (newLevel)
        {
            case 1:
                passiveBonusStat.AttackSpeed = 5;
                break;
            case 2:
                passiveBonusStat.AttackSpeed = 8;
                break;
            case 3:
                passiveBonusStat.AttackSpeed = 12;
                break;
            case 4:
                passiveBonusStat.AttackSpeed = 15;
                break;
            case 0:
            default:
                passiveBonusStat.AttackSpeed = 0;
                break;
        }
    }

    // 탐욕의 검 특수 효과는 SpecialWeaponLevel 프로퍼티의 setter 함수로 구현

    /// <summary>
    /// 롱기누스의 창 특수 효과: 피격된 적의 전체 체력의 일부만큼 플레이어 체력 회복
    /// </summary>
    /// <param name="user"></param>
    /// <param name="subject"></param>
    public void ActiveHolyLanceEffect(Unit user, Unit subject)
    {
        float dreadAmount;
        switch (SpecialWeaponLevel)
        {
            case 1:
                dreadAmount = 0.03f;
                break;
            case 2:
                dreadAmount = 0.05f;
                break;
            case 3:
                dreadAmount = 0.07f;
                break;
            default:
                return;
        }
        user.AddHP(Mathf.RoundToInt(subject.Stat.MaxHP * dreadAmount));
    }
}
