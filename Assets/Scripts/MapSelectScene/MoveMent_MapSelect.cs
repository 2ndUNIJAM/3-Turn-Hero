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
        // ������ ��ư�� ������ ��簡 ���������� �̵�. 
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (characterPositionIndex == 0)
            {
                Character.transform.DOMove(new Vector3(3.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 1;
            }
        }

        // ���� ��ư�� ������ ��簡 �������� �̵�. 
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (characterPositionIndex == 1)
            {
                Character.transform.DOMove(new Vector3(-3.0f, -2.0f, 0), 0.5f);
                characterPositionIndex = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Scene.GoToScene(Scene.BattleScene, "TestBGM");
        }
    }
}
