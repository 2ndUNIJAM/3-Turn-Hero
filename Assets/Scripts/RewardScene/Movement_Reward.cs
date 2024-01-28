using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Movement_Reward : MonoBehaviour
{
    [SerializeField] GameObject Character;

    private bool isPlayerNear = false;

    private int characterPositionIndex = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (characterPositionIndex == 0)
            {
                Character.transform.DOMove(new Vector3(0.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 1;
                GameManager.Sound.PlaySE("Move");
            }
            else if (characterPositionIndex == 1)
            {
                Character.transform.DOMove(new Vector3(5.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 2;
                GameManager.Sound.PlaySE("Move");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (characterPositionIndex == 2)
            {
                Character.transform.DOMove(new Vector3(0.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 1;
                GameManager.Sound.PlaySE("Move");
            }
            else if (characterPositionIndex == 1)
            {
                Character.transform.DOMove(new Vector3(-5.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 0;
                GameManager.Sound.PlaySE("Move");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            UpgradeManager.Instance.UpdateStat(characterPositionIndex);
            GameManager.Sound.PlaySE("Coins");
            GameManager.Scene.GoToScene(Scene.MapSelectScene, "Combat_MR");
        }
    }
}
