using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerTest : MonoBehaviour
{
    public void OnCreateTempPopup()
    {
        UI_TempPopup popup = GameManager.UI.ShowPopup<UI_TempPopup>("Temp_Popup");
        popup.Order++;
        popup.SetTitle($"This is a Temp UI Popup!");
        GameManager.Sound.PlaySE("ClickButton");
    }
}
