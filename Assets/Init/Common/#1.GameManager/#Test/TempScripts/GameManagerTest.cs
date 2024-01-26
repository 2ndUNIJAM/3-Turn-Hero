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

    void Update()
    {
        // 데이터 수정 예시
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.Save.SaveData.gold += 100;

        // 웹 구글 스프레드시트 데이터 불러오기
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Data.GoogleSheet.DownloadAllSO();
        }

        // 게임 데이터 접근 예시
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            JemSO jemSO = GameManager.Data.JemSOList[0];
            Debug.Log($"'{jemSO.Price}' of '{jemSO.Name}'");
        }
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
        GameManager.Scene.GoToScene(Scene.LobbyScene, "MainBGM");
    }

    public void GoToTest()
    {
        GameManager.Sound.PlaySE("ClickButton");
        GameManager.Scene.GoToScene(Scene.TestScene, "TestBGM");
    }
}
