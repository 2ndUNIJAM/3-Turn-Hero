using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StageManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> stageList;

    [SerializeField] private Collider2D clearWallCol;
    public Collider2D ClearWallCol => clearWallCol;

    public List<Monster> enemyUnits;

    public void SetStage(int stageID)
    {
        foreach (var stage in stageList)
            stage.SetActive(false);
        stageList[stageID].SetActive(true);

        enemyUnits = new List<Monster>();
        enemyUnits.AddRange(FindStageEnemies(stageID));
    }

    public Monster[] FindStageEnemies(int stageID) => stageList[stageID].GetComponentsInChildren<Monster>();

    public void RemoveEnemyUnit(Monster enemy)
    {
        if (!enemyUnits.Remove(enemy))
        {
            Debug.LogError("Enemy is not removed!");
        }

        if (BattleManager.Instance.CheckGameWin())
            BattleManager.Instance.GameWin();
    }
    
}
