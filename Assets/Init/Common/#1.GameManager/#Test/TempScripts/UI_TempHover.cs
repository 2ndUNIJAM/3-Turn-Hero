using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TempHover : UI_Hover
{
    [SerializeField]
    private TMP_Text info;

    public void SetInfo(string text) => info.SetText(text);
}
