using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject target;
    public float height;

    public void Init(GameObject target, float height)
    {
        this.target = target;
        this.height = height;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
            this.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + Vector3.up * height);
    }

    public void SetSlider(int curHP, int maxHP)
    {
        slider.maxValue = maxHP;
        slider.value = curHP;
    }

    public void DestroyHPBar()
    {
        GameManager.Resource.Destroy(this.gameObject);   
    }
}
