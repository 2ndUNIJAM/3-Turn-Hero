using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private GameObject TutorialImage;
    [SerializeField] private GameObject TutorialText;

    // 대사와 함께 나올 스탠딩 cg들을 저장하는 배열. 
    [SerializeField] private List<String> listTexts;
    [SerializeField] private List<Sprite> listSprites;


    //  현재 몇번째 텍스트를 읽고 있는지 저장하기 위한 변수.
    private int count = 0;

    private bool blockKeyboardInput;

    public void Start()
    {
        // 초반에 몇초동안은 다이얼로그를 보여주고, 키보드를 입력받지 않는다.    
        blockKeyboardInput = true;

        TutorialImage.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 540.0f, 0), 10f);
        TutorialText.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 1080.0f, 0), 10f);

        blockKeyboardInput = false;
    }

    private void Update()
    {
        // 대화를 읽는다.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) && blockKeyboardInput == false)
        {
            count++;

            if (count == 9)
            {

            }

            // 모든 대화를 읽은 경우
            if (count == 20)
            {
                // 모든 코루틴 종료
                StopAllCoroutines();
            }
            else
            {
                // 아닌 경우 다음 다이얼로그 출력.
                StopAllCoroutines();
            }
        }
    }
}
