using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데이터는 Scriptable Object로 관리됩니다.
/// 보통 읽기 전용이며, 게임 진행에 필요한 요소들의 정보입니다.
/// </summary>
public class DataManager : MonoBehaviour
{
    [SerializeField] private GoogleSheetManager googleSheet;
    public GoogleSheetManager GoogleSheet => googleSheet;


    [SerializeField]
    private List<JemSO> jemSOList;
    public List<JemSO> JemSOList => jemSOList;

    public void Init()
    {
        jemSOList = new List<JemSO>();
        jemSOList.AddRange(GameManager.Resource.LoadAll<JemSO>("SO/JemSO"));

        GoogleSheet.Init();
    }
}
