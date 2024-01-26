using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    [SerializeField]
    private float randPercent;

    [SerializeField]
    private float[] randPercents;

    [SerializeField]
    private AnimationCurve randCurve;

    // Start is called before the first frame update
    void Start()
    {
        int success = 0;
        for (int i = 0; i < 100; i++)
            if (RandomManager.GetFlag(randPercent))
                success++;
        Debug.Log($"단일 확률({randPercent * 100}%) 결과: {success} 성공 | {100 - success} 실패");



        int[] successes = new int[randPercents.Length];
        for (int i = 0; i < 100; i++)
            successes[RandomManager.GetElement(randPercents)]++;

        Debug.Log($"복합 확률 결과");
        for (int i = 0; i < randPercents.Length; i++)
            Debug.Log($"복합 확률 [확률 {randPercents[i] * 100}%] 결과: {successes[i]} 등장");



        float average = 0;
        for (int i = 0; i < 100; i++)
            average += RandomManager.GetWeightedNum(100, randCurve);
        average /= 100;
        Debug.Log($"랜덤 가중치 곡선 평균: {average}");



        for (int i = 0; i < 100; i++)
        {
            int[] temps = RandomManager.Shuffle(new int[] { 1, 2, 3, 4, 5 });
            foreach (var item in temps)
                Debug.Log(item);
            Debug.Log($"랜덤 섞기 {i} 번째 ---------------------------");
        }



        for (int i = 0; i < 100; i++)
        {
            int numToSelect = Random.Range(0, 5);
            List<int> temps = RandomManager.ChooseSet(new List<int>(new int[] { 1, 2, 3, 4, 5 }), numToSelect);
            foreach (var item in temps)
                Debug.Log(item);
            Debug.Log($"중복 없이 {numToSelect} 개 뽑기 {i} 번째 ---------------------------");
        }
    }
}
