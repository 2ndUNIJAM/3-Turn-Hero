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
    [SerializeField] private GameObject SceneGO;
    [SerializeField] private GameObject TutorialImage;
    [SerializeField] private GameObject TutorialText;
    [SerializeField] private GameObject ItemBox;
    [SerializeField] private GameObject Character;

    // 대사와 함께 나올 스탠딩 cg들을 저장하는 배열. 
    [SerializeField] private List<String> listTexts;
    [SerializeField] private List<Sprite> listSprites;


    //  현재 몇번째 텍스트를 읽고 있는지 저장하기 위한 변수.
    private int count = 3;

    private bool blockKeyboardInput;

    private int characterPositionIndex = 0;
    private bool helpCanvasPopup = false;

    public void Start()
    {
        GameObject ItemBox1 = Instantiate(ItemBox, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject ItemBox2 = Instantiate(ItemBox, new Vector3(4.0f, 0, 0), Quaternion.identity);
        GameObject ItemBox3 = Instantiate(ItemBox, new Vector3(8.0f, 0, 0), Quaternion.identity);

        ItemBox1.transform.SetParent(SceneGO.transform);
        ItemBox2.transform.SetParent(SceneGO.transform);
        ItemBox3.transform.SetParent(SceneGO.transform);

        StartCoroutine(Tutorial());
    }

    // 튜토리얼. 왜 용사가 모험을 시작하는지 보여주고~
    IEnumerator Tutorial()
    {
        blockKeyboardInput = true;

        TutorialImage.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 540.0f, 0), 10f);

        TutorialText.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 1080.0f, 0), 10f);

        yield return new WaitForSeconds(10f);

        blockKeyboardInput = false;

        // 이후에 이미지, 텍스트는 꺼준다. 그리고 장비 선택 화면. 
        TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = false;
        TutorialText.GetComponent<TextMeshProUGUI>().enabled = false;

        StartCoroutine(ShowText());
    }

    // 정확히 CharacterExit -> ShowText -> CharacterEntrance 순서. 

    // 몇 턴 후에 모험이 시작되는지 보여주고~
    IEnumerator ShowText()
    {
        TutorialText.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

        if (count == 0)
        {
            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = true;
            TutorialText.GetComponent<TextMeshProUGUI>().text = "Adventure begins.";
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = true;

            yield return new WaitForSeconds(3f);

            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = false;
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        else
        {
            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = true;
            TutorialText.GetComponent<TextMeshProUGUI>().text = count.ToString() + "turns after, the adventure begins.";
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = true;

            yield return new WaitForSeconds(3f);

            TutorialImage.GetComponent<UnityEngine.UI.Image>().enabled = false;
            TutorialText.GetComponent<TextMeshProUGUI>().enabled = false;

            StartCoroutine(CharacterEntrance());
        }
    }

    // 그 다음 캐릭터가 입장하는거 보여주고~
    IEnumerator CharacterEntrance()
    {
        Character.transform.position = new Vector3(-12.0f, -3.0f, 0);

        blockKeyboardInput = true;

        Character.transform.DOMove(new Vector3(-4.0f, -3.0f, 0), 5.0f);

        yield return new WaitForSeconds(5.0f);

        blockKeyboardInput = false;
    }

    // 용사 퇴장하는 코드.
    IEnumerator CharacterExit()
    {
        blockKeyboardInput = true;

        Character.transform.DOMove(new Vector3(12.0f, -3.0f, 0), 5.0f);

        yield return new WaitForSeconds(5.0f);

        blockKeyboardInput = false;

        StartCoroutine(ShowText());
    }


    private void Update()
    {
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
        // 대화를 읽는다.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) && blockKeyboardInput == false)
        {
            StartCoroutine(CharacterExit());
            count--;
        }

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
