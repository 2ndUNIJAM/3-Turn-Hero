using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager instance;
    public static UpgradeManager Instance => instance;
    [SerializeField] public GameObject UI_Upgrade_Canvas;

    GameObject UpgradeUI1, UpgradeUI2, UpgradeUI3;

    public List<int> selectedTypes = new List<int>();
    public List<int> selectedIndex = new List<int>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        // 일단 먼저 어떤 타입들을 보여줄지 0~4의 숫자 중 3개를 뽑아야 함. 

        selectedTypes = SelectNumbers(0, 4, 3);
        selectedIndex = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            switch (selectedTypes[i])
            {
                case 0:
                    selectedIndex.Add(Random.Range(0, PlayerUpgrade.playerUpgradeNum));
                    break;
                case 1:
                    selectedIndex.Add(Random.Range(0, WeaponUpgrade.weaponUpgradeNum));
                    break;
                case 2:
                    selectedIndex.Add(Random.Range(0, ArmorUpgrade.armorUpgradeNum));
                    break;
                case 3:
                    selectedIndex.Add(Random.Range(0, FriendUpgrade.friendUpgradeNum));
                    break;
                case 4:
                    selectedIndex.Add(Random.Range(0, EctUpgrade.ectUpgradeNum));
                    break;
            }
        }


        UpgradeUI1 = Instantiate(UI_Upgrade_Canvas);
        UpgradeUI2 = Instantiate(UI_Upgrade_Canvas);
        UpgradeUI3 = Instantiate(UI_Upgrade_Canvas);

        UpgradeUI1.transform.SetParent(transform);
        UpgradeUI2.transform.SetParent(transform);
        UpgradeUI3.transform.SetParent(transform);

        UpgradeUI1.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(-550.0f, 150.0f, 0.0f);
        UpgradeUI1.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector3(-550.0f, 375.0f, 0.0f);
        UpgradeUI1.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(-550.0f, 100.0f, 0.0f);
        UpgradeUI1.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(-550.0f, -62.0f, 0.0f);

        switch (selectedTypes[0])
        {
            case 0:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PlayerUpgrade.names;
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.playerUpgrades[selectedIndex[0]].description;
                break;
            case 1:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = WeaponUpgrade.names;
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.weaponUpgrades[selectedIndex[0]].description;
                break;
            case 2:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ArmorUpgrade.names;
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.armorUpgrades[selectedIndex[0]].description;
                break;
            case 3:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = FriendUpgrade.names;
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.friendUpgrades[selectedIndex[0]].description;
                break;
            case 4:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = EctUpgrade.names;
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.ectUpgrades[selectedIndex[0]].description;
                break;
        }


        UpgradeUI2.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 150.0f, 0.0f);
        UpgradeUI2.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 375.0f, 0.0f);
        UpgradeUI2.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, 100.0f, 0.0f);
        UpgradeUI2.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(0.0f, -62.0f, 0.0f);

        switch (selectedTypes[1])
        {
            case 0:
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PlayerUpgrade.names;
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.playerUpgrades[selectedIndex[1]].description;
                break;
            case 1:
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = WeaponUpgrade.names;
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.weaponUpgrades[selectedIndex[1]].description;
                break;
            case 2:
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ArmorUpgrade.names;
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.armorUpgrades[selectedIndex[1]].description;
                break;
            case 3:
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = FriendUpgrade.names;
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.friendUpgrades[selectedIndex[1]].description;
                break;
            case 4:
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = EctUpgrade.names;
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.ectUpgrades[selectedIndex[1]].description;
                break;
        }


        UpgradeUI3.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(550.0f, 150.0f, 0.0f);
        UpgradeUI3.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector3(550.0f, 375.0f, 0.0f);
        UpgradeUI3.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(550.0f, 100.0f, 0.0f);
        UpgradeUI3.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(550.0f, -62.0f, 0.0f);

        switch (selectedTypes[2])
        {
            case 0:
                UpgradeUI3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = PlayerUpgrade.names;
                UpgradeUI3.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.playerUpgrades[selectedIndex[2]].description;
                break;
            case 1:
                UpgradeUI3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = WeaponUpgrade.names;
                UpgradeUI3.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.weaponUpgrades[selectedIndex[2]].description;
                break;
            case 2:
                UpgradeUI3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ArmorUpgrade.names;
                UpgradeUI3.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.armorUpgrades[selectedIndex[2]].description;
                break;
            case 3:
                UpgradeUI3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = FriendUpgrade.names;
                UpgradeUI3.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.friendUpgrades[selectedIndex[2]].description;
                break;
            case 4:
                UpgradeUI3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = EctUpgrade.names;
                UpgradeUI3.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameManager.Data.ectUpgrades[selectedIndex[2]].description;
                break;
        }

    }

    public void UpdateStat(int position)
    {
        int type = selectedTypes[position];
        int index = selectedIndex[position];

        if (type == 0)
        {
            switch (index)
            {
                case 0:
                    PlayerManager.Instance.Player.inven.weapon.basicStat.MaxHP += 20;
                    PlayerManager.Instance.Player.inven.weapon.basicStat.CurrentHP += 20;
                    break;
                case 1:
                    PlayerManager.Instance.Player.inven.weapon.basicStat.ATK += 5;
                    break;
                case 2:
                    PlayerManager.Instance.Player.inven.weapon.basicStat.DEF += 5;
                    break;
                case 3:
                    break;
            }
        }
        else if (type == 1)
        {
            switch (index)
            {
                case 0:
                    List<int> typeList = new List<int>();
                    if (PlayerManager.Instance.Player.inven.weapon.ElementFireLevel == 0) typeList.Add(0);
                    if (PlayerManager.Instance.Player.inven.weapon.ElementGroundLevel == 0) typeList.Add(1);
                    if (PlayerManager.Instance.Player.inven.weapon.ElementWindLevel == 0) typeList.Add(2);
                    if (PlayerManager.Instance.Player.inven.weapon.ElementIceLevel == 0) typeList.Add(3);
                    int typeIndex = Random.Range(0, typeList.Count);
                    if (typeList[typeIndex] == 0) PlayerManager.Instance.Player.inven.weapon.ElementFireLevel = 1;
                    else if (typeList[typeIndex] == 1) PlayerManager.Instance.Player.inven.weapon.ElementGroundLevel = 1;
                    else if (typeList[typeIndex] == 2) PlayerManager.Instance.Player.inven.weapon.ElementWindLevel = 1;
                    else if (typeList[typeIndex] == 3) PlayerManager.Instance.Player.inven.weapon.ElementIceLevel = 1;
                    break;
                case 1:
                    if (PlayerManager.Instance.Player.inven.weapon.ElementFireLevel > 0) PlayerManager.Instance.Player.inven.weapon.ElementFireLevel++;
                    else if (PlayerManager.Instance.Player.inven.weapon.ElementGroundLevel > 0) PlayerManager.Instance.Player.inven.weapon.ElementGroundLevel++;
                    else if (PlayerManager.Instance.Player.inven.weapon.ElementWindLevel > 0) PlayerManager.Instance.Player.inven.weapon.ElementWindLevel++;
                    else if (PlayerManager.Instance.Player.inven.weapon.ElementIceLevel > 0) PlayerManager.Instance.Player.inven.weapon.ElementIceLevel++;
                    break;
                case 2:
                    PlayerManager.Instance.Player.inven.weapon.basicStat.AttackSpeed += 5;
                    break;
                case 3:
                    if (PlayerManager.Instance.Player.inven.weapon.SpecialWeaponLevel >= 1)
                    {
                        PlayerManager.Instance.Player.inven.weapon.SpecialWeaponLevel++;
                    }
                    break;
            }
        }
        else if (type == 2)
        {
            switch (index)
            {
                case 0:
                    List<int> typeList = new List<int>();
                    if (PlayerManager.Instance.Player.inven.armor.ElementFireLevel == 0) typeList.Add(0);
                    if (PlayerManager.Instance.Player.inven.armor.ElementGroundLevel == 0) typeList.Add(1);
                    if (PlayerManager.Instance.Player.inven.armor.ElementWindLevel == 0) typeList.Add(2);
                    if (PlayerManager.Instance.Player.inven.armor.ElementIceLevel == 0) typeList.Add(3);
                    int typeIndex = Random.Range(0, typeList.Count);
                    if (typeList[typeIndex] == 0) PlayerManager.Instance.Player.inven.armor.ElementFireLevel = 1;
                    else if (typeList[typeIndex] == 1) PlayerManager.Instance.Player.inven.armor.ElementGroundLevel = 1;
                    else if (typeList[typeIndex] == 2) PlayerManager.Instance.Player.inven.armor.ElementWindLevel = 1;
                    else if (typeList[typeIndex] == 3) PlayerManager.Instance.Player.inven.armor.ElementIceLevel = 1;
                    break;
                case 1:
                    if (PlayerManager.Instance.Player.inven.armor.ElementFireLevel > 0) PlayerManager.Instance.Player.inven.armor.ElementFireLevel++;
                    else if (PlayerManager.Instance.Player.inven.armor.ElementGroundLevel > 0) PlayerManager.Instance.Player.inven.armor.ElementGroundLevel++;
                    else if (PlayerManager.Instance.Player.inven.armor.ElementWindLevel > 0) PlayerManager.Instance.Player.inven.armor.ElementWindLevel++;
                    else if (PlayerManager.Instance.Player.inven.armor.ElementIceLevel > 0) PlayerManager.Instance.Player.inven.armor.ElementIceLevel++;
                    break;
                case 2:
                    PlayerManager.Instance.Player.inven.armor.basicStat.MoveSpeed += 5;
                    break;
                case 3:
                    if (PlayerManager.Instance.Player.inven.armor.SpecialArmorLevel >= 1)
                    {
                        PlayerManager.Instance.Player.inven.armor.SpecialArmorLevel++;
                    }
                    break;
            }
        }
        else if (type == 3)
        {
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
        else if (type == 4)
        {
            switch (index)
            {
                case 0:
                    PlayerManager.Instance.Player.inven.weapon.basicStat.CurrentHP
                        += (int)(PlayerManager.Instance.Player.upgradedStat.MaxHP * 0.3f);
                    break;
            }

        }
    }

    List<int> SelectNumbers(int minValue, int maxValue, int count)
    {
        List<int> numbers = new List<int>();

        // 사용 가능한 숫자 생성
        List<int> availableNumbers = new List<int>();
        for (int i = minValue; i <= maxValue; i++)
        {
            availableNumbers.Add(i);
        }

        // 랜덤하게 숫자 선택
        for (int i = 0; i < count; i++)
        {
            // 사용 가능한 숫자 중에서 랜덤하게 선택
            int randomIndex = Random.Range(0, availableNumbers.Count);
            int selectedNumber = availableNumbers[randomIndex];

            // 선택된 숫자를 결과 리스트에 추가
            numbers.Add(selectedNumber);

            // 이미 선택된 숫자는 사용 가능한 숫자에서 제거
            availableNumbers.RemoveAt(randomIndex);
        }

        return numbers;
    }
}