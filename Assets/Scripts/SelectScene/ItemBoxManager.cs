using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxManager : MonoBehaviour
{
    private static ItemBoxManager instance;
    public static ItemBoxManager Instance => instance;

    [SerializeField] private List<Sprite> PanelSpriteList;
    [SerializeField] private Sprite WeaponSprite;

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

            int whilecount = 0;
            do
            {
                weaponIndex = getRandomItem.GetRandomWeaponIndex();
                whilecount++;
                if (whilecount > 100)
                {
                    Debug.Log("무한루프");
                    break;
                }
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
            itemBoxList[weaponIndexList.Count - 1].transform.GetChild(2).GetComponent<TextMeshPro>().text = selectedWeaponData.Descript.Replace("/", "\n\n");
            itemBoxList[weaponIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = WeaponSprite;
            itemBoxList[weaponIndexList.Count - 1].transform.GetChild(3).transform.position
                = new Vector3(itemBoxList[weaponIndexList.Count - 1].transform.GetChild(3).transform.position.x, -2.0f, 0);

            Color currentColor = itemBoxList[weaponIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().color;
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);
            itemBoxList[weaponIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().color = newColor;
        }

    }

    // 플레이어가 선택한 무기를 플레이어 인벤토리에 넣는다.
    public void SetWeapon(int selectedIndex, GameObject itemBox1, GameObject itemBox2, GameObject itemBox3)
    {
        List<GameObject> itemBoxList = new List<GameObject>();
        itemBoxList.Add(itemBox1);
        itemBoxList.Add(itemBox2);
        itemBoxList.Add(itemBox3);

        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).DOLocalMoveY(-1.5f, 0.5f).SetEase(Ease.OutQuad))
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).DOLocalMoveY(-2.5f, 0.5f).SetEase(Ease.OutQuad))
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).GetComponent<SpriteRenderer>().DOFade(0, 0.5f).SetEase(Ease.OutQuad))
            .Play();

        WeaponDataSO selectedWeaponData = GameManager.Data.WeaponDataSODic.ElementAt(weaponIndexList[selectedIndex]).Value;

        DataManager.playerInven.weapon = new Weapon();

        DataManager.playerInven.weapon.basicStat = new Stat();
        DataManager.playerInven.weapon.basicStat.ATK = selectedWeaponData.ATK;
        DataManager.playerInven.weapon.basicStat.AttackSpeed = selectedWeaponData.ATKSpeed;

        DataManager.playerInven.weapon.englishName = selectedWeaponData.EngName;
        DataManager.playerInven.weapon.koreanName = selectedWeaponData.KorName;
        DataManager.playerInven.weapon.description = selectedWeaponData.Descript;

        switch (selectedWeaponData.ElementType)
        {
            case ("화염"):
                DataManager.playerInven.weapon.ElementFireLevel = 1;
                break;
            case ("바람"):
                DataManager.playerInven.weapon.ElementWindLevel = 1;
                break;
            case ("대지"):
                DataManager.playerInven.weapon.ElementGroundLevel = 1;
                break;
            case ("냉기"):
                DataManager.playerInven.weapon.ElementIceLevel = 1;
                break;
            default: break;
        }

        switch (selectedWeaponData.Rarity)
        {
            case ("N"):
                DataManager.playerInven.weapon.rarity = Equipment.Rarity.N;
                break;
            case ("R"):
                DataManager.playerInven.weapon.rarity = Equipment.Rarity.R;
                break;
            case ("SR"):
                DataManager.playerInven.weapon.rarity = Equipment.Rarity.SR;
                break;
            default: break;
        }

        DataManager.playerInven.weapon.probability = selectedWeaponData.Possibility;
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

            int whilecount = 0;
            do
            {
                armorIndex = getRandomItem.GetRandomArmorIndex();
                whilecount++;
                if (whilecount > 100)
                {
                    Debug.Log("무한루프");
                    break;
                }
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
            itemBoxList[armorIndexList.Count - 1].transform.GetChild(2).GetComponent<TextMeshPro>().text = selectedArmorData.Descript.Replace("/", "\n\n");
            itemBoxList[armorIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = WeaponSprite;
            itemBoxList[armorIndexList.Count - 1].transform.GetChild(3).transform.position
                = new Vector3(itemBoxList[armorIndexList.Count - 1].transform.GetChild(3).transform.position.x, -2.0f, 0);

            Color currentColor = itemBoxList[armorIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().color;
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);
            itemBoxList[armorIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().color = newColor;
        }
    }

    public void SetArmor(int selectedIndex, GameObject itemBox1, GameObject itemBox2, GameObject itemBox3)
    {
        List<GameObject> itemBoxList = new List<GameObject>();
        itemBoxList.Add(itemBox1);
        itemBoxList.Add(itemBox2);
        itemBoxList.Add(itemBox3);

        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).DOLocalMoveY(-1.5f, 0.5f).SetEase(Ease.OutQuad))
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).DOLocalMoveY(-2.5f, 0.5f).SetEase(Ease.OutQuad))
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).GetComponent<SpriteRenderer>().DOFade(0, 0.5f).SetEase(Ease.OutQuad))
            .Play();

        ArmorDataSO selectedArmorData = GameManager.Data.ArmorDataSODic.ElementAt(armorIndexList[selectedIndex]).Value;

        DataManager.playerInven.armor = new Armor();

        DataManager.playerInven.armor.basicStat = new Stat();
        DataManager.playerInven.armor.basicStat.DEF = selectedArmorData.DEF;
        DataManager.playerInven.armor.basicStat.MoveSpeed = selectedArmorData.MoveSpeed;
        DataManager.playerInven.armor.basicStat.AttackSpeed = selectedArmorData.AttackSpeed;

        DataManager.playerInven.armor.englishName = selectedArmorData.EngName;
        DataManager.playerInven.armor.koreanName = selectedArmorData.KorName;
        DataManager.playerInven.armor.description = selectedArmorData.Descript;

        switch (selectedArmorData.ElementType)
        {
            case ("화염"):
                DataManager.playerInven.armor.ElementFireLevel = 1;
                break;
            case ("바람"):
                DataManager.playerInven.armor.ElementWindLevel = 1;
                break;
            case ("대지"):
                DataManager.playerInven.armor.ElementGroundLevel = 1;
                break;
            case ("냉기"):
                DataManager.playerInven.armor.ElementIceLevel = 1;
                break;
            default: break;
        }

        switch (selectedArmorData.Rarity)
        {
            case ("N"):
                DataManager.playerInven.armor.rarity = Equipment.Rarity.N;
                break;
            case ("R"):
                DataManager.playerInven.armor.rarity = Equipment.Rarity.R;
                break;
            case ("SR"):
                DataManager.playerInven.armor.rarity = Equipment.Rarity.SR;
                break;
            default: break;
        }

        DataManager.playerInven.armor.probability = selectedArmorData.Possibility;

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

            int whilecount = 0;
            do
            {
                whilecount++;
                if (whilecount > 100)
                {
                    Debug.Log("무한루프");
                    break;
                }
                colleagueIndex = getRandomItem.GetRandomColleagueIndex();
            } while (colleagueIndexList.Contains(colleagueIndex));

            colleagueIndexList.Add(colleagueIndex);

            ColleagueDataSO selectedColleagueData = GameManager.Data.ColleagueDataSODic.ElementAt(colleagueIndex).Value;
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = PanelSpriteList[6];
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(1).GetComponent<TextMeshPro>().text = selectedColleagueData.KorName;
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(2).GetComponent<TextMeshPro>().text = selectedColleagueData.Descript.Replace("/", "\n\n");
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = WeaponSprite;
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(3).transform.position
                = new Vector3(itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(3).transform.position.x, -2.0f, 0);

            Color currentColor = itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().color;
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);
            itemBoxList[colleagueIndexList.Count - 1].transform.GetChild(3).GetComponent<SpriteRenderer>().color = newColor;
        }
    }

    public void SetColleague(int selectedIndex, GameObject itemBox1, GameObject itemBox2, GameObject itemBox3)
    {
        List<GameObject> itemBoxList = new List<GameObject>();
        itemBoxList.Add(itemBox1);
        itemBoxList.Add(itemBox2);
        itemBoxList.Add(itemBox3);

        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).DOLocalMoveY(-1.5f, 0.5f).SetEase(Ease.OutQuad))
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).DOLocalMoveY(-2.5f, 0.5f).SetEase(Ease.OutQuad))
            .Append(itemBoxList[selectedIndex].transform.GetChild(3).GetComponent<SpriteRenderer>().DOFade(0, 0.5f).SetEase(Ease.OutQuad))
            .Play();

        ColleagueDataSO selectedColleagueData = GameManager.Data.ColleagueDataSODic.ElementAt(colleagueIndexList[selectedIndex]).Value;

        DataManager.playerInven.colleague = new Colleague();

        DataManager.playerInven.colleague.basicStat = new Stat();

        DataManager.playerInven.colleague.englishName = selectedColleagueData.EngName;
        DataManager.playerInven.colleague.koreanName = selectedColleagueData.KorName;
        DataManager.playerInven.colleague.description = selectedColleagueData.Descript;

        DataManager.playerInven.colleague.count = selectedColleagueData.Count;

        DataManager.playerInven.colleague.probability = selectedColleagueData.Possibility;
    }
}
