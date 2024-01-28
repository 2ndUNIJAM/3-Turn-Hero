using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Movement_MapSelect : MonoBehaviour
{
    [SerializeField] GameObject Character;

    private bool isPlayerNear = false;

    private int characterPositionIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (characterPositionIndex == 0)
            {
                Character.transform.DOMove(new Vector3(3.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (characterPositionIndex == 1)
            {
                Character.transform.DOMove(new Vector3(-3.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (GameManager.Data.currentStage == 1 && characterPositionIndex == 0)
            {
                GameManager.Data.stageID = 2;
            }
            else if (GameManager.Data.currentStage == 1 && characterPositionIndex == 1)
            {
                GameManager.Data.stageID = 3;
            }
            else if (GameManager.Data.currentStage == 2 && characterPositionIndex == 0)
            {
                GameManager.Data.stageID = 4;
            }
            else if (GameManager.Data.currentStage == 2 && characterPositionIndex == 1)
            {
                GameManager.Data.stageID = 5;
            }
            else if (GameManager.Data.currentStage == 3 && characterPositionIndex == 0)
            {
                GameManager.Data.stageID = 6;
            }
            else if (GameManager.Data.currentStage == 3 && characterPositionIndex == 1)
            {
                GameManager.Data.stageID = 7;
            }
            else if (GameManager.Data.currentStage == 4 && characterPositionIndex == 0)
            {
                GameManager.Data.stageID = 8;
            }
            else if (GameManager.Data.currentStage == 4 && characterPositionIndex == 1)
            {
                GameManager.Data.stageID = 9;
            }

            GameManager.Data.currentStage++;

            GameManager.Scene.GoToScene(Scene.BattleScene, "TestBGM");
        }
    }
}
