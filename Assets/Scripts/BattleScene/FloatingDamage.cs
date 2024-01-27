using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class FloatingDamage : MonoBehaviour
{
    private const float START_FADE_TIME = 0.25f;
    private const float FADE_SPEED = 1f;
    private const float MOVEUP_SPEED = 0.3f;

    [SerializeField] private TMP_Text text;
    private GameObject target;
    private Vector3 upPos;
    private Color color;
    private bool isStart;

    // Start is called before the first frame update
    public void Init(GameObject target, int damage, Color color)
    {
        this.target = target;
        this.text.SetText($"-{damage}");
        this.color = color;
        text.color = color;
        this.upPos = Vector3.zero;

        this.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + upPos);

        StartCoroutine(FadeStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            GameManager.Resource.Destroy(this.gameObject);
            return;
        }

        upPos += Vector3.up * MOVEUP_SPEED * Time.deltaTime;
        this.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + upPos);

        if (isStart)
        {
            if (color.a > 0f)
            {
                color.a -= Time.deltaTime * FADE_SPEED;
                text.color = color;
            }
            else
            {
                color.a = 0f;
                text.color = color;
                isStart = false;
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator FadeStart()
    {
        yield return new WaitForSeconds(START_FADE_TIME);
        isStart = true;
    }
}
