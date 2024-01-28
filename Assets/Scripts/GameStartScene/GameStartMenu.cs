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
    [SerializeField] public GameObject logo;
    [SerializeField] public GameObject creditSpeech;
    [SerializeField] public TMP_Text creditButtonText;

    private int _selectedButtonIndex = 0; // 현재 선택된 버튼의 인덱스
    private bool isLogoActivated = true;

    private void Start()
    {
        // 초기에 시작 버튼이 선택되어 있도록 설정
        SetSelectedButton(GameStartButton);
        logo.SetActive(true);
        creditSpeech.SetActive(false);
        creditButtonText.text = "Credit";
        isLogoActivated = true;
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
                GameManager.Sound.PlaySE("Move");
            }
            else if (_selectedButtonIndex == 1)
            {
                SetSelectedButton(QuitButton);
                _selectedButtonIndex = 2;
                GameManager.Sound.PlaySE("Move");
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (_selectedButtonIndex == 2)
            {
                SetSelectedButton(ContinueButton);
                _selectedButtonIndex = 1;
                GameManager.Sound.PlaySE("Move");
            }
            else if (_selectedButtonIndex == 1)
            {
                SetSelectedButton(GameStartButton);
                _selectedButtonIndex = 0;
                GameManager.Sound.PlaySE("Move");
            }
        }

        // 엔터 키 입력에 따라 선택된 버튼 동작 수행
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (GameStartButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 56)
            {
                GameManager.Sound.PlaySE("Select");
                GameManager.Scene.GoToScene(Scene.SelectScene, "Town_Loop_BGM");
            }
            else if (ContinueButton.GetComponentInChildren<TextMeshProUGUI>().fontSize == 56)
            {
                GameManager.Sound.PlaySE("Reroll");
                if (isLogoActivated)
                {
                    logo.SetActive(false);
                    creditSpeech.SetActive(true);
                    creditButtonText.text = "Show Logo";
                    isLogoActivated = false;
                }
                else
                {
                    logo.SetActive(true);
                    creditSpeech.SetActive(false);
                    creditButtonText.text = "Credit";
                    isLogoActivated = true;
                }
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
