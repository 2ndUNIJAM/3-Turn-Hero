using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance;
    public static BattleManager Instance
    {
        get { return instance; }
        set
        {
            if (instance == null)
                instance = value;
        }
    }

    [SerializeField] private BattleUIManager battleUI;
    public BattleUIManager BattleUI => battleUI;

    [SerializeField] private StageManager stage;
    public StageManager Stage => stage;

    public bool isWin;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        int stageID = GameManager.Data.stageID;
        stage.SetStage(stageID);

        isWin = false;
    }

    public bool CheckGameWin() => stage.enemyUnits.Count == 0;

    public void GameWin()
    {
        Debug.Log("Stage Clear!");
        Stage.ClearWallCol.enabled = false;
    }

    public void GameLose()
    {
        Debug.Log("Game Over!");
        Invoke("GoToMainScene", 1f);
    }

    private void GoToMainScene() => GameManager.Scene.GoToScene(Scene.MainScene, "Town_Loop_BGM");
}
