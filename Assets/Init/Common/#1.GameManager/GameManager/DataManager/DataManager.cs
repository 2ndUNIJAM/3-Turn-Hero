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

    public Player player;

    public int stageID;

    public void Init()
    {
        unitDataSODic = new Dictionary<string, UnitDataSO>();

        player = new Player();
        player.Data = GameManager.Resource.Load<UnitDataSO>("SO/�÷��̾�");

        stageID = 0;

        var unitDataSOList = GameManager.Resource.LoadAll<UnitDataSO>("SO/UnitDataSO");
        foreach (var unit in unitDataSOList)
        {
            UnitDataSODic.Add(unit.Name, unit);
        }
    }
}
