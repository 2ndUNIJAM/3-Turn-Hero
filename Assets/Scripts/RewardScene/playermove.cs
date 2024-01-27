using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playermove : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    private bool isMoving = false;
    private float moveDistance = 7.0f;
    private bool blockKeyboardInput = false;

    void Start()
    {
        // 플레이어의 초기 위치 설정
        transform.position = new Vector3(0.46f, -2.95f, 0);
    }

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveByOffset(new Vector3(-moveDistance, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveByOffset(new Vector3(moveDistance, 0, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) && !blockKeyboardInput)
        {
            StartCoroutine(CharacterExit());
        }
    }

    void MoveByOffset(Vector3 offset)
    {
        Vector3 targetPosition = transform.position + offset;
        targetPosition.x = Mathf.Clamp(targetPosition.x, -7.0f, 7.0f);
        targetPosition.y = -2.95f; // y축 고정
        isMoving = true;
        transform.DOMove(targetPosition, 1.0f).OnComplete(() => isMoving = false);
    }

    IEnumerator CharacterExit()
    {
        blockKeyboardInput = true;
        Character.transform.DOMove(new Vector3(12.0f, -5.0f, 0), 5.0f);
        yield return new WaitForSeconds(5.0f);
        blockKeyboardInput = false;
    }
}

