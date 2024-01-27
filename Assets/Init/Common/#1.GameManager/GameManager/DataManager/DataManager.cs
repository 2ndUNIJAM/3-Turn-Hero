using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데이터는 Scriptable Object로 관리됩니다.
/// 보통 읽기 전용이며, 게임 진행에 필요한 요소들의 정보입니다.
/// </summary>
public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, UnitDataSO> unitDataSODic;
    public Dictionary<string, UnitDataSO> UnitDataSODic => unitDataSODic;

    public Inventory playerInven;

    public Stat playerUpgradeStat;

    public int stageID;

    public void Init()
    {
        unitDataSODic = new Dictionary<string, UnitDataSO>();

        stageID = 0;

        var unitDataSOList = GameManager.Resource.LoadAll<UnitDataSO>("SO/UnitDataSO");
        foreach (var unit in unitDataSOList)
        {
            UnitDataSODic.Add(unit.Name, unit);
        }
    }
}
