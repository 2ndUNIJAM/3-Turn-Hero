using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    private const int AUTOSAVE_TIME = 60 * 5;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Save.LoadGame();
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(AUTOSAVE_TIME);

        Debug.Log("AutoSave starts.");
        GameManager.Save.SaveGame();
        StartCoroutine(AutoSave());
    }

    public void GoToLobby()
    {
        GameManager.Sound.PlaySE("ClickButton");
        //GameManager.Scene.GoToScene(Scene.LobbyScene, "MainBGM");
    }

    public void GoToTest()
    {
        GameManager.Sound.PlaySE("ClickButton");
        //GameManager.Scene.GoToScene(Scene.TestScene, "TestBGM");
    }
}
