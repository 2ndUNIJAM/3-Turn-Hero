using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GoToRewardScene();
        }
    }

    private void GoToRewardScene() => GameManager.Scene.GoToScene(Scene.RewardScene, "TempBGM");
}
