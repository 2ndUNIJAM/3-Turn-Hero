using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    private SelectManager instance;
    public SelectManager Instance => instance;

    [SerializeField] private GameObject SceneGO;
    [SerializeField] private GameObject TutorialImage;
    [SerializeField] private GameObject TutorialText;
    [SerializeField] private GameObject ItemBox;
    [SerializeField] private GameObject Character;

    private GameObject ItemBox1, ItemBox2, ItemBox3;

    //  현재 몇번째 텍스트를 읽고 있는지 저장하기 위한 변수.
    private int count = 3;

    private bool blockKeyboardInput;

    private int characterPositionIndex = 0;
    private bool helpCanvasPopup = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Init();
    }

    public void Init()
    {
        ItemBox1 = Instantiate(ItemBox, new Vector3(0, 0, 0), Quaternion.identity);
        ItemBox2 = Instantiate(ItemBox, new Vector3(4.0f, 0, 0), Quaternion.identity);
        ItemBox3 = Instantiate(ItemBox, new Vector3(8.0f, 0, 0), Quaternion.identity);

        ItemBox1.transform.SetParent(SceneGO.transform);
        ItemBox2.transform.SetParent(SceneGO.transform);
        ItemBox3.transform.SetParent(SceneGO.transform);

        StartCoroutine(Tutorial());
    }

    #region 'n턴 후 시작된다'는 다이얼로그, 용사 입장, 퇴장에 관한 코루틴들 다루는 코드. 

    // 튜토리얼. 왜 용사가 모험을 시작하는지 보여주고~
    IEnumerator Tutorial()
    {
        blockKeyboardInput = true;

        TutorialImage.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 540.0f, 0), 1f);

        TutorialText.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 1080.0f, 0), 1f);

        yield return new WaitForSeconds(1f);

        // 이후에 이미지, 텍스트는 꺼준다. 그리고 장비 선택 화면. 
        TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = false;
        TutorialText.GetComponent<TextMeshProUGUI>().enabled = false;

        blockKeyboardInput = false;

        StartCoroutine(ShowText());
    }

    // 정확히 CharacterExit -> ShowText -> CharacterEntrance 순서. 

    // 몇 턴 후에 모험이 시작되는지 보여주고~
    IEnumerator ShowText()
    {
        blockKeyboardInput = true;

        TutorialText.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

        if (count == 3)
        {
            ItemBoxManager.Instance.SetWeaponBox(ItemBox1, ItemBox2, ItemBox3);
        }
        else if (count == 2)
        {
            ItemBoxManager.Instance.SetArmorBox(ItemBox1, ItemBox2, ItemBox3);
        }
        else if (count == 1)
        {
            ItemBoxManager.Instance.SetColleagueBox(ItemBox1, ItemBox2, ItemBox3);
        }

        // 선택이 모두 끝난 경우 모험이 시작된다는 텍스트 출력.
        if (count == 0)
        {
            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = true;
            TutorialText.GetComponent<TextMeshProUGUI>().text = "Adventure begins.";
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = true;

            yield return new WaitForSeconds(3f);

            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = false;
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = false;

            blockKeyboardInput = false;
        }
        // 선택이 끝나지 않은 경우 다음 선택 시작. 
        else
        {
            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = true;
            TutorialText.GetComponent<TextMeshProUGUI>().text = count.ToString() + "turns after, the adventure begins.";
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = true;

            yield return new WaitForSeconds(3f);

            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = false;
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = false;

            blockKeyboardInput = false;

            StartCoroutine(CharacterEntrance());
        }

    }

    // 그 다음 캐릭터가 입장하는거 보여주고~
    IEnumerator CharacterEntrance()
    {
        blockKeyboardInput = true;

        Character.transform.position = new Vector3(-12.0f, -3.0f, 0);

        Character.transform.DOMove(new Vector3(-4.0f, -3.0f, 0), 5.0f);

        yield return new WaitForSeconds(5.0f);

        blockKeyboardInput = false;
    }

    // 용사 퇴장하는 코드.
    IEnumerator CharacterExit()
    {
        Debug.Log("weapon ATK: " + GameManager.Data.playerInven.weapon.basicStat.ATK);
        Debug.Log("weapon AttackSpeed: " + GameManager.Data.playerInven.weapon.basicStat.AttackSpeed);

        blockKeyboardInput = true;

        Character.transform.DOMove(new Vector3(12.0f, -3.0f, 0), 5.0f);

        yield return new WaitForSeconds(5.0f);

        count--;

        blockKeyboardInput = false;

        StartCoroutine(ShowText());
    }

    #endregion

    private void Update()
    {
        // 오른쪽 버튼을 누르면 용사가 오른쪽으로 이동. 
        if (Input.GetKeyDown(KeyCode.RightArrow) && blockKeyboardInput == false)
        {
            if (characterPositionIndex == 0)
            {
                Character.transform.DOMove(new Vector3(0, -3.0f, 0), 1f);
                characterPositionIndex = 1;
            }
            else if (characterPositionIndex == 1)
            {
                Character.transform.DOMove(new Vector3(4.0f, -3.0f, 0), 1f);
                characterPositionIndex = 2;
            }
        }

        // 왼쪽 버튼을 누르면 용사가 왼쪽으로 이동. 
        if (Input.GetKeyDown(KeyCode.LeftArrow) && blockKeyboardInput == false)
        {
            if (characterPositionIndex == 2)
            {
                Character.transform.DOMove(new Vector3(0.0f, -3.0f, 0), 1f);
                characterPositionIndex = 1;
            }
            else if (characterPositionIndex == 1)
            {
                Character.transform.DOMove(new Vector3(-4.0f, -3.0f, 0), 1f);
                characterPositionIndex = 0;
            }
        }

        // 스페이스바나 엔터를 누르면 다음 용사가 퇴장하고 다음 선택으로 넘어간다. 
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && blockKeyboardInput == false)
        {
            if (count == 3)
            {
                ItemBoxManager.Instance.SetWeapon(characterPositionIndex);
            }
            else if (count == 2)
            {
                ItemBoxManager.Instance.SetArmor(characterPositionIndex);
            }
            else if (count == 1)
            {
                ItemBoxManager.Instance.SetColleague(characterPositionIndex);
            }
            StartCoroutine(CharacterExit());
        }

        // f1을 누르면 도움말이 나온다. 
        if (Input.GetKeyDown(KeyCode.F1) && blockKeyboardInput == false)
        {
            if (helpCanvasPopup == false)
            {
                helpCanvasPopup = true;
                GameManager.UI.ShowPopup<HelpCanvas>("HelpCanvas");
            }
            else if (helpCanvasPopup == true)
            {
                helpCanvasPopup = false;
                GameManager.UI.ClosePopup();
            }
        }
    }
}
