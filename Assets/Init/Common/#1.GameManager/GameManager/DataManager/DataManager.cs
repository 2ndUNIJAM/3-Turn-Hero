using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ʹ� Scriptable Object�� �����˴ϴ�.
/// ���� �б� �����̸�, ���� ���࿡ �ʿ��� ��ҵ��� �����Դϴ�.
/// </summary>
public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, UnitDataSO> unitDataSODic;
    public Dictionary<string, UnitDataSO> UnitDataSODic => unitDataSODic;

    public void Init()
    {
        unitDataSODic = new Dictionary<string, UnitDataSO>();

        var unitDataSOList = GameManager.Resource.LoadAll<UnitDataSO>("SO/UnitDataSO");
        foreach (var unit in unitDataSOList)
        {
            UnitDataSODic.Add(unit.Name, unit);
        }

        Debug.Log(UnitDataSODic["���"].Stat.MaxHP);
        Debug.Log(UnitDataSODic["��"].Stat.MaxHP);
        Debug.Log(UnitDataSODic["������"].Stat.MaxHP);
    }
}
