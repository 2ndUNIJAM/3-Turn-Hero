using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GetRandomItem
{
    public int GetRandomWeaponIndex()
    {
        List<float> weaponPercentList = new List<float>();

        foreach (var item in GameManager.Data.WeaponDataSODic)
        {
            weaponPercentList.Add(item.Value.Possibility);
        }

        int selectedIndex = RandomManager.GetElement(weaponPercentList.ToArray());

        return selectedIndex;
    }

    public int GetRandomArmorIndex()
    {
        List<float> armorPercentList = new List<float>();

        foreach (var item in GameManager.Data.ArmorDataSODic)
        {
            armorPercentList.Add(item.Value.Possibility);
        }

        int selectedIndex = RandomManager.GetElement(armorPercentList.ToArray());

        return selectedIndex;
    }

    public int GetRandomColleagueIndex()
    {
        List<float> colleaguePercentList = new List<float>();

        foreach (var item in GameManager.Data.ColleagueDataSODic)
        {
            colleaguePercentList.Add(item.Value.Possibility);
        }

        int selectedIndex = RandomManager.GetElement(colleaguePercentList.ToArray());

        return selectedIndex;
    }
}
