using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ItemBoxManager : MonoBehaviour
{
    private static ItemBoxManager instance;
    public static ItemBoxManager Instance => instance;

    [SerializeField] private List<Sprite> PanelSpriteList;

    GetRandomItem getRandomItem;

    List<int> weaponIndexList = new List<int>();
    List<int> armorIndexList = new List<int>();
    List<int> colleagueIndexList = new List<int>();

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        getRandomItem = new GetRandomItem();
    }

    // weaponBox에 보여줄 것들 설정. 
    public void SetWeaponBox(GameObject itemBox1, GameObject itemBox2, GameObject itemBox3)
    {
        List<GameObject> itemBoxList = new List<GameObject>();
        itemBoxList.Add(itemBox1);
        itemBoxList.Add(itemBox2);
        itemBoxList.Add(itemBox3);

        for (int i = 0; i < 3; i++)
        {
            // 만약 인덱스를 뽑아왔는데 기존이랑 겹치는게 있다면 다시 뽑는다. 
            int weaponIndex = -1;

            do
            {
                weaponIndex = getRandomItem.GetRandomWeaponIndex();
            } while (weaponIndexList.Contains(weaponIndex));

            weaponIndexList.Add(weaponIndex);

            WeaponDataSO selectedWeaponData = GameManager.Data.WeaponDataSODic.ElementAt(weaponIndex).Value;

            switch (selectedWeaponData.Rarity)
            {
                case "N":
                    itemBoxList[weaponIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[0];
                    break;
                case "R":
                    itemBoxList[weaponIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[1];
                    break;
                case "SR":
                    itemBoxList[weaponIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[2];
                    break;
            }

            itemBoxList[weaponIndexList.Count - 1].transform.GetChild(1).GetComponent<TextMeshPro>().text = selectedWeaponData.KorName;
            itemBoxList[weaponIndexList.Count - 1].transform.GetChild(2).GetComponent<TextMeshPro>().text = selectedWeaponData.Descript;
        }

    }

    // 플레이어가 선택한 무기를 플레이어 인벤토리에 넣는다.
    public void SetWeapon(int selectedIndex)
    {
        WeaponDataSO selectedWeaponData = GameManager.Data.WeaponDataSODic.ElementAt(weaponIndexList[selectedIndex]).Value;

        GameManager.Data.playerInven.weapon = new Weapon();

        GameManager.Data.playerInven.weapon.basicStat = new Stat();
        GameManager.Data.playerInven.weapon.basicStat.ATK = selectedWeaponData.ATK;
        GameManager.Data.playerInven.weapon.basicStat.AttackSpeed = selectedWeaponData.ATKSpeed;

        GameManager.Data.playerInven.weapon.englishName = selectedWeaponData.EngName;
        GameManager.Data.playerInven.weapon.koreanName = selectedWeaponData.KorName;
        GameManager.Data.playerInven.weapon.description = selectedWeaponData.Descript;

        switch (selectedWeaponData.ElementType)
        {
            case ("화염"):
                GameManager.Data.playerInven.weapon.ElementFireLevel = 1;
                break;
            case ("바람"):
                GameManager.Data.playerInven.weapon.ElementWindLevel = 1;
                break;
            case ("대지"):
                GameManager.Data.playerInven.weapon.ElementGroundLevel = 1;
                break;
            case ("냉기"):
                GameManager.Data.playerInven.weapon.ElementIceLevel = 1;
                break;
            default: break;
        }

        switch (selectedWeaponData.Rarity)
        {
            case ("N"):
                GameManager.Data.playerInven.weapon.rarity = Equipment.Rarity.N;
                break;
            case ("R"):
                GameManager.Data.playerInven.weapon.rarity = Equipment.Rarity.R;
                break;
            case ("SR"):
                GameManager.Data.playerInven.weapon.rarity = Equipment.Rarity.SR;
                break;
            default: break;
        }

        GameManager.Data.playerInven.weapon.probability = selectedWeaponData.Possibility;
    }

    public void SetArmorBox(GameObject itemBox1, GameObject itemBox2, GameObject itemBox3)
    {
        List<GameObject> itemBoxList = new List<GameObject>();
        itemBoxList.Add(itemBox1);
        itemBoxList.Add(itemBox2);
        itemBoxList.Add(itemBox3);

        for (int i = 0; i < 3; i++)
        {
            // 만약 인덱스를 뽑아왔는데 기존이랑 겹치는게 있다면 다시 뽑는다. 
            int armorIndex = -1;

            do
            {
                armorIndex = getRandomItem.GetRandomArmorIndex();
            } while (armorIndexList.Contains(armorIndex));

            armorIndexList.Add(armorIndex);

            ArmorDataSO selectedArmorData = GameManager.Data.ArmorDataSODic.ElementAt(armorIndex).Value;
            switch (selectedArmorData.Rarity)
            {
                case "N":
                    itemBoxList[armorIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[3];
                    break;
                case "R":
                    itemBoxList[armorIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[4];
                    break;
                case "SR":
                    itemBoxList[armorIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[5];
                    break;
            }

            itemBoxList[armorIndexList.Count - 1].transform.GetChild(1).GetComponent<TextMeshPro>().text = selectedArmorData.KorName;
            itemBoxList[armorIndexList.Count - 1].transform.GetChild(2).GetComponent<TextMeshPro>().text = selectedArmorData.Descript;
        }
    }

    public void SetArmor(int selectedIndex)
    {
        ArmorDataSO selectedArmorData = GameManager.Data.ArmorDataSODic.ElementAt(armorIndexList[selectedIndex]).Value;

        GameManager.Data.playerInven.armor = new Armor();

        GameManager.Data.playerInven.armor.basicStat = new Stat();
        GameManager.Data.playerInven.armor.basicStat.DEF = selectedArmorData.DEF;
        GameManager.Data.playerInven.armor.basicStat.MoveSpeed = selectedArmorData.MoveSpeed;
        GameManager.Data.playerInven.armor.basicStat.AttackSpeed = selectedArmorData.AttackSpeed;

        GameManager.Data.playerInven.armor.englishName = selectedArmorData.EngName;
        GameManager.Data.playerInven.armor.koreanName = selectedArmorData.KorName;
        GameManager.Data.playerInven.armor.description = selectedArmorData.Descript;

        switch (selectedArmorData.ElementType)
        {
            case ("화염"):
                GameManager.Data.playerInven.armor.ElementFireLevel = 1;
                break;
            case ("바람"):
                GameManager.Data.playerInven.armor.ElementWindLevel = 1;
                break;
            case ("대지"):
                GameManager.Data.playerInven.armor.ElementGroundLevel = 1;
                break;
            case ("냉기"):
                GameManager.Data.playerInven.armor.ElementIceLevel = 1;
                break;
            default: break;
        }

        switch (selectedArmorData.Rarity)
        {
            case ("N"):
                GameManager.Data.playerInven.armor.rarity = Equipment.Rarity.N;
                break;
            case ("R"):
                GameManager.Data.playerInven.armor.rarity = Equipment.Rarity.R;
                break;
            case ("SR"):
                GameManager.Data.playerInven.armor.rarity = Equipment.Rarity.SR;
                break;
            default: break;
        }

        GameManager.Data.playerInven.armor.probability = selectedArmorData.Possibility;

    }

    public void SetColleagueBox(GameObject itemBox1, GameObject itemBox2, GameObject itemBox3)
    {
        List<GameObject> itemBoxList = new List<GameObject>();
        itemBoxList.Add(itemBox1);
        itemBoxList.Add(itemBox2);
        itemBoxList.Add(itemBox3);

        for (int i = 0; i < 3; i++)
        {
            // 만약 인덱스를 뽑아왔는데 기존이랑 겹치는게 있다면 다시 뽑는다. 
            int colleagueIndex = -1;

            do
            {
                colleagueIndex = getRandomItem.GetRandomColleagueIndex();
            } while (colleagueIndexList.Contains(colleagueIndex));

            colleagueIndexList.Add(colleagueIndex);

            ColleagueDataSO selectedColleagueData = GameManager.Data.ColleagueDataSODic.ElementAt(colleagueIndex).Value;
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[6];
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(1).GetComponent<TextMeshPro>().text = selectedColleagueData.KorName;
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(2).GetComponent<TextMeshPro>().text = selectedColleagueData.Descript;
        }
    }

    public void SetColleague(int selectedIndex)
    {
        ColleagueDataSO selectedColleagueData = GameManager.Data.ColleagueDataSODic.ElementAt(colleagueIndexList[selectedIndex]).Value;

        GameManager.Data.playerInven.colleague = new Colleague();

        GameManager.Data.playerInven.colleague.basicStat = new Stat();

        GameManager.Data.playerInven.colleague.englishName = selectedColleagueData.EngName;
        GameManager.Data.playerInven.colleague.koreanName = selectedColleagueData.KorName;
        GameManager.Data.playerInven.colleague.description = selectedColleagueData.Descript;

        GameManager.Data.playerInven.colleague.count = selectedColleagueData.Count;

        GameManager.Data.playerInven.colleague.probability = selectedColleagueData.Possibility;
    }
}
