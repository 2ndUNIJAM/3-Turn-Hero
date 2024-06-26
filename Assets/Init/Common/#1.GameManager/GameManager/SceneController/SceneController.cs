using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private const string FADE_ANIM_IN_NAME = "SceneCtrl_FadeIn";
    private const string FADE_ANIM_OUT_NAME = "SceneCtrl_FadeOut";
    public const float FADE_INIT_TIME = 0.75f;
    private const float FADE_DEFAULT_TIME = 0.75f;

    public Animation Anim;
    public Image BlindImage;

    /// <summary> 현재 Switch가 일어나고 있는 중인지에 대한 여부 </summary>
    public bool IsChanging;


    // SceneIndex 표
    /*****************************************
    0. MainScene
    1. SelectScene
    2. BattleScene
    3. RewardScene
    *****************************************/


    public void Init()
    {
        BlindImage.color = new Color(0f, 0f, 0f, 0f);
        IsChanging = false;
        FadeIn(FADE_INIT_TIME);
    }


    public void GoToScene(Scene scene, string BGM_name)
    {
        if (IsChanging)
            return;

        StartCoroutine(SwitchScene(scene, BGM_name, FADE_DEFAULT_TIME));
    }


    public IEnumerator SwitchScene(Scene scene, string BGM_name, float fadeTime)
    {
        if (IsChanging)
            yield break; // 현재 작업 중이면 취소

        GameManager.Sound.PlayBGM(BGM_name, fadeTime);
        IsChanging = true;
        FadeOut(fadeTime);

        yield return new WaitForSeconds(fadeTime);

        // 씬 전환
        SceneManager.LoadScene((int)scene);

        IsChanging = false;
        FadeIn(fadeTime);

        yield return new WaitForSeconds(fadeTime);
    }


    public IEnumerator SwitchPos(Vector3 destination, string BGM_name, float fadeTime)
    {
        if (IsChanging)
            yield break; // 현재 작업 중이면 취소

        GameManager.Sound.PlayBGM(BGM_name, fadeTime);
        IsChanging = true;
        FadeOut(fadeTime);

        yield return new WaitForSeconds(fadeTime);

        IsChanging = false;
        FadeIn(fadeTime);

        yield return new WaitForSeconds(fadeTime);
    }


    public IEnumerator SwitchPos(Vector3 destination, float fadeInTime, float fadeOutTime)
    {
        if (IsChanging)
            yield break; // 현재 작업 중이면 취소

        FadeOut(fadeInTime);
        IsChanging = true;

        yield return new WaitForSeconds(fadeInTime);

        // FadeIn -> Out 전환 시점
        IsChanging = false;
        FadeIn(fadeOutTime);

        yield return new WaitForSeconds(fadeOutTime);
    }


    public IEnumerator SwitchPos(Vector3 destination)
    {
        if (IsChanging)
            yield break; // 현재 작업 중이면 취소

        StartCoroutine(SwitchPos(destination, FADE_DEFAULT_TIME, FADE_DEFAULT_TIME));
    }


    private void FadeIn(float _fadeTime)
    {
        Anim.Play(FADE_ANIM_IN_NAME);
        Anim[FADE_ANIM_IN_NAME].speed = 1f / _fadeTime;
    }


    private void FadeOut(float _fadeTime)
    {
        Anim.Play(FADE_ANIM_OUT_NAME);
        Anim[FADE_ANIM_OUT_NAME].speed = 1f / _fadeTime;
    }
}