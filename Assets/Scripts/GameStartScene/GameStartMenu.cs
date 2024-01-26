using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameStartMenu : MonoBehaviour
{
    [SerializeField] public Button GameStartButton;
    [SerializeField] public Button ContinueButton;
    [SerializeField] public Button QuitButton;

    [SerializeField] public GameObject highlight; // 하이라이트 스프라이트를 나타내는 GameObject

    private int _selectedButtonIndex = 0; // 현재 선택된 버튼의 인덱스

    private void Start()
    {
        // 초기에 시작 버튼이 선택되어 있도록 설정
        SetSelectedButton(GameStartButton);
    }

    private void Update()
    {
        // 키 입력에 따라 포인팅 변경
        if (Input.GetKeyDown(KeyCode.DownArrow))
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
        else if (Input.GetKeyDown(KeyCode.UpArrow))
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameStartButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 60)
            {
                // 게임 시작 버튼 동작
                Debug.Log("게임을 시작합니다.");
            }
            else if (ContinueButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 60)
            {
                // 이어하기 버튼 동작
                Debug.Log("이어하기");
            }
            else if (QuitButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 60)
            {
                // 나가기 버튼 동작
                Debug.Log("게임을 종료합니다.");
            }
        }
    }

    // 선택된 버튼에 포인터 효과 적용
    void SetSelectedButton(Button selectedButton)
    {
        GameStartButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 48;
        ContinueButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 48;
        QuitButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 48;

        selectedButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 60;

        // 하이라이트 위치 조정
        highlight.transform.position = new Vector3(highlight.transform.position.x, selectedButton.transform.position.y, highlight.transform.position.z);
    }
}
