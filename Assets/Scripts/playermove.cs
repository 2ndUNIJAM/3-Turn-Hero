using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playermove : MonoBehaviour
{
    private bool isMoving = false;
    private float moveDistance = 7.0f;

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
    }

    void MoveByOffset(Vector3 offset)
    {
        isMoving = true;
        transform.DOMove(transform.position + offset, 1.0f).OnComplete(() => isMoving = false);
    }
}
