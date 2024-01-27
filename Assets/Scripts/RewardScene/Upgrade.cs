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

    public static string names = "�÷��̾� ��ȭ";

    private static string[] descriptions =
    {
        "HP 20 ���",
        "ATK 5 ���",
        "DEF 5 ���",
        "Ÿ�ݸ��� 10% Ȯ���� 1Ÿ���� �����ϴ� �ɷ� ȹ��"
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
            case 1: stat.ATK += 5; break;
            case 2: stat.DEF += 5; break;

        }

        return stat;
    }
}

public class WeaponUpgrade : Upgrade
{
    public static int weaponUpgradeNum = 4;

    public static string names = "���� ��ȭ";

    private static string[] descriptions =
    {
        "�ٸ� �Ӽ� �ο�",
        "�Ӽ� ��ȭ",
        "���� �ӵ� ���",
        "(SR ���� ����) ���� ��"

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

    public static string names = "���� ��ȭ";

    private static string[] descriptions =
    {
        "�ٸ� �Ӽ� �ο�",
        "(�Ӽ� ���� ����) �Ӽ� ��ȭ",
        "�̵� �ӵ� ���",
        "(SR ���� ����) ���� ��"
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

    public static string names = "���� ��ȭ";

    private static string[] descriptions =
    {
        "���� ���� ��",
        "���� �Һ� count + 1"
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

    public static string names = "��Ÿ";

    private static string[] descriptions =
    {
        "��ü ü���� 30% ��"
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


