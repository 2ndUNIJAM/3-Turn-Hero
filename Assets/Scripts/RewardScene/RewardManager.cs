using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public GameObject select0;
    public GameObject select1;
    public GameObject select2;

    // Start is called before the first frame update
    void Start()
    {
        select0.SetActive(false);
        select1.SetActive(false);
        select2.SetActive(false);

        StartCoroutine(ShowSequentially());
    }

    IEnumerator ShowSequentially()
    {

        StartCoroutine(select0.GetComponent<UI_Upgrade>().FadeIn());

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(select1.GetComponent<UI_Upgrade>().FadeIn());
     
        yield return new WaitForSeconds(0.5f);
        
        StartCoroutine(select2.GetComponent<UI_Upgrade> ().FadeIn());
    }
}
