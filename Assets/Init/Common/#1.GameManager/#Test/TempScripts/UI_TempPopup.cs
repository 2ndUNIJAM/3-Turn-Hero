using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TempPopup : UI_Popup
{
    [SerializeField]
    private TMP_Text title;

    public int Order;

    public void SetTitle(string text) => title.SetText($"{text} [Order:{Order}]");

    public void OnCreatePopup()
    {
        UI_TempPopup popup = GameManager.UI.ShowPopup<UI_TempPopup>("Temp_Popup");
        popup.Order = this.Order + 1;
        popup.SetTitle($"This is a Temp UI Popup!");
        GameManager.Sound.PlaySE("ClickButton");
    }

    public void OnClosePopup()
    {
        GameManager.UI.ClosePopup(this);
        GameManager.Sound.PlaySE("ClickButton");
    }
}
