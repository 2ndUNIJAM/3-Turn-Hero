using System.Collections;
using System.Collections.Generic;
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
    }
}