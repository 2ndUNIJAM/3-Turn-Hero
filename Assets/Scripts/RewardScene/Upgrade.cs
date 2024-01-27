using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public int code;
    public string description;
    public Sprite sprite;

    public virtual Stat GetStat() { return new Stat(); }
}

public class PlayerUpgrade : Upgrade
{
    public static int playerUpgradeNum = 4;

    public static string names = "플레이어 강화";

    private static string[] descriptions =
    {
        "HP 20 상승",
        "ATK 5 상승",
        "DEF 5 상승",
        "타격마다 10% 확률로 1타수가 증가하는 능력 획득"
    };
    private static Sprite[] sprites;
    
    public PlayerUpgrade(int _code)
    {
        code = _code;
        description = descriptions[_code];
        sprite = sprites[_code];
    }

    public static void Init()
    {
        sprites = GameManager.Resource.LoadAll<Sprite>("Images/Upgrade/Player");
    }

    public override Stat GetStat()
    {
        Stat stat = new Stat();

        switch (code) 
        {
            case 0: stat.MaxHP += 20; stat.CurrentHP += 20; break;
            case 1: stat.PPower += 5; break;
            case 2: stat.PArmor += 5; break;
            
        }

        return stat;
    }
}

public class WeaponUpgrade : Upgrade
{
    public static int weaponUpgradeNum = 4;

    public static string names = "무기 강화";

    private static string[] descriptions =
    {
        "다른 속성 부여",
        "속성 강화",
        "공격 속도 상승",
        "(SR 무기 한정) 레벨 업"
     
    };

    private static Sprite[] sprites;

    
    public WeaponUpgrade(int _code)
    {
        code = _code;
        description = descriptions[_code];
        sprite = sprites[_code];

    }

    public static void Init()
    {
        sprites = GameManager.Resource.LoadAll<Sprite>("Images/Upgrade/Player");
    }

    public override Stat GetStat()
    {
        Stat stat = new Stat();

        switch (code)
        {
            case 2: stat.AttackSpeed += 5; break;
        }

        return stat;
    }

}

public class ArmorUpgrade : Upgrade
{
    public static int armorUpgradeNum = 4;

    public static string names = "갑옷 강화";

    private static string[] descriptions =
    {
        "다른 속성 부여",
        "(속성 갑옷 한정) 속성 강화",
        "이동 속도 상승",
        "(SR 갑옷 한정) 레벨 업"
    };
    private static Sprite[] sprites;

    
    public ArmorUpgrade(int _code)
    {
        code = _code;
        description = descriptions[_code];
        sprite = sprites[_code];

    }

    public static void Init()
    {
        sprites = GameManager.Resource.LoadAll<Sprite>("Images/Upgrade/Player");
    }

    public override Stat GetStat()
    {
        Stat stat = new Stat();

        switch (code)
        {
            case 2: stat.MoveSpeed += 5; break;
        }

        return stat;
    }

}

public class FriendUpgrade : Upgrade
{
    public static int friendUpgradeNum = 2;

    public static string names = "동료 강화";

    private static string[] descriptions =
    {
        "동료 레벨 업",
        "동료 소비 count + 1"
    };

    private static Sprite[] sprites;

    
    public FriendUpgrade(int _code)
    {
        code = _code;
        description = descriptions[_code];
        sprite = sprites[_code];

    }

    public static void Init()
    {
        sprites = GameManager.Resource.LoadAll<Sprite>("Images/Upgrade/Player");
    }


}
public class EctUpgrade : Upgrade
{
    public static int ectUpgradeNum = 1;

    public static string names = "기타";

    private static string[] descriptions =
    {
        "전체 체력의 30% 힐"
    };
    private static Sprite[] sprites;
    
    public EctUpgrade(int _code)
    {
        code = _code;
        description = descriptions[_code];
        sprite = sprites[_code];

    }

    public static void Init()
    {
        sprites = GameManager.Resource.LoadAll<Sprite>("Images/Upgrade/Player");
    }


}

