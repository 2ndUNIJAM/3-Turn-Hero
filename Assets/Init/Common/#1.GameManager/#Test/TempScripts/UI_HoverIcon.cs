using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_HoverIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_TempHover hover = GameManager.UI.ShowHover<UI_TempHover>("Temp_Hover", eventData.position);
        hover.SetInfo("This is a Temp UI Hover!\nHave a good day:)");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.UI.CloseHover();
    }
}
