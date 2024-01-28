using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStartMenu : MonoBehaviour
{
    [SerializeField] public Button GameStartButton;
    [SerializeField] public Button ContinueButton;
    [SerializeField] public Button QuitButton;
    [SerializeField] public GameObject highlight;

    private int _selectedButtonIndex = 0; // 현재 선택된 버튼의 인덱스

    private void Start()
    {
        // 초기에 시작 버튼이 선택되어 있도록 설정
        SetSelectedButton(GameStartButton);
    }

    private void Update()
    {
        // 키 입력에 따라 포인팅 변경
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (_selectedButtonIndex == 0)
            {
                SetSelectedButton(ContinueButton);
                _selectedButtonIndex = 1;
            }
            else if (_selectedButtonIndex == 1)
            {
                SetSelectedButton(QuitButton);
                _selectedButtonIndex = 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (_selectedButtonIndex == 2)
            {
                SetSelectedButton(ContinueButton);
                _selectedButtonIndex = 1;
            }
            else if (_selectedButtonIndex == 1)
            {
                SetSelectedButton(GameStartButton);
                _selectedButtonIndex = 0;
            }
        }

        // 엔터 키 입력에 따라 선택된 버튼 동작 수행
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (GameStartButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 56)
            {
                GameManager.Scene.GoToScene(Scene.SelectScene, "Town_Loop_BGM");
            }
            else if (ContinueButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 56)
            {
                // 이어하기 버튼 동작
                Debug.Log("이어하기");
            }
            else if (QuitButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 56)
            {
                ExitGame();
            }
        }
    }

    // 선택된 버튼에 포인터 효과 적용
    void SetSelectedButton(Button selectedButton)
    {
        GameStartButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 48;
        ContinueButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 48;
        QuitButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 48;

        selectedButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 56;

        highlight.transform.position = new Vector3(highlight.transform.position.x, selectedButton.transform.position.y, highlight.transform.position.z);
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
