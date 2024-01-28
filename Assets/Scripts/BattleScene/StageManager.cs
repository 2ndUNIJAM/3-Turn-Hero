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

    private float faintCoolTime;

    private bool hasDragonLeatherArmor;

    private bool isFaintAll;

    private void Start()
    {
        hasDragonLeatherArmor = PlayerManager.Instance.Player.inven.armor.englishName == "DragonLeatherArmor";
        isFaintAll = false;
        faintCoolTime = 5f;

        switch (PlayerManager.Instance.Player.inven.armor.SpecialArmorLevel)
        {
            case 1:
                faintCoolTime = 5f;
                break;
            case 2:
                faintCoolTime = 4f;
                break;
            case 3:
                faintCoolTime = 3f;
                break;
            case 0:
            default:
                break;
        }

        if (hasDragonLeatherArmor)
        {
            StartCoroutine(FaintAllEnemies(faintCoolTime));
        }
    }

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
    
    IEnumerator FaintAllEnemies(float faintCoolTime)
    {
        if (RandomManager.GetFlag(0.5f))
        {
            foreach (var unit in enemyUnits)
                unit.SetFaint(2f);
        }

        yield return new WaitForSeconds(faintCoolTime);

        StartCoroutine(FaintAllEnemies(faintCoolTime));
    }
}
