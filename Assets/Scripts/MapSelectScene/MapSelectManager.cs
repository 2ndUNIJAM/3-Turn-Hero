using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapSelectManager : MonoBehaviour
{
    [SerializeField] public GameObject UI_Upgrade_Canvas;

    GameObject UpgradeUI1, UpgradeUI2;

    public void Start()
    {
        UpgradeUI1 = Instantiate(UI_Upgrade_Canvas);
        UpgradeUI2 = Instantiate(UI_Upgrade_Canvas);

        UpgradeUI1.transform.SetParent(transform);
        UpgradeUI2.transform.SetParent(transform);

        UpgradeUI1.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(-350.0f, 150.0f, 0.0f);
        UpgradeUI1.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector3(-350.0f, 375.0f, 0.0f);
        UpgradeUI1.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(-350.0f, 100.0f, 0.0f);
        UpgradeUI1.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(-350.0f, -62.0f, 0.0f);

        UpgradeUI2.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(350.0f, 150.0f, 0.0f);
        UpgradeUI2.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector3(350.0f, 375.0f, 0.0f);
        UpgradeUI2.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector3(350.0f, 100.0f, 0.0f);
        UpgradeUI2.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector3(350.0f, -62.0f, 0.0f);

        switch (GameManager.Data.currentStage)
        {
            case 1:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "왼쪽 갈래길";
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "고블린의 으르르 거리는 소리가 들린다...";
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "오른쪽 갈래길";
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "오우거의 포효가 들린다...";
                break;
            case 2:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "왼쪽 갈래길";
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<천장 조심> 오우거의 포효가 들린다...";
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "오른쪽 갈래길";
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<천장 조심> 오우거의 포효와 쿵쿵거리는 소리가 들린다...";
                break;
            case 3:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "왼쪽 갈래길";
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<천장 주의> 오우거의 포효와 쿵쿵거리는 소리가 들린다...";
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "오른쪽 갈래길";
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<천장 주의> 고블린의 으르르 거리는 소리와 쿵쿵거리는 소리가 들린다...";
                break;
            case 4:
                UpgradeUI1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "왼쪽 갈래길";
                UpgradeUI1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<천장 위험> 아비규환의 소리가 들린다...";
                UpgradeUI2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "오른쪽 갈래길";
                UpgradeUI2.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "<천장 주의> 아비규환의 소리가 들린다...";
                break;
            default:
                break;
        }
    }
}