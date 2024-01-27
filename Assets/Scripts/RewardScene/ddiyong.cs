using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddiyong : MonoBehaviour
{
    public GameObject Prefab4;
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    GameObject Player;
    GameObject select1;
    GameObject select2;
    GameObject select3;

    void Start()
    {
        StartCoroutine(InstantiatePrefabsWithDelay());

    }

    IEnumerator InstantiatePrefabsWithDelay()
    {

        Prefab1 = Resources.Load<GameObject>("Prefabs/UI_Upgrade");
        Vector2 spawnPosition1 = new Vector2(-4.62f, -0.37f);
        select1 = Instantiate(Prefab1, spawnPosition1, Quaternion.identity);

        
        yield return new WaitForSeconds(0.5f);

        
        Prefab2 = Resources.Load<GameObject>("Prefabs/UI_Upgrade (1)");
        Vector2 spawnPosition2 = new Vector2(2.38f, -0.37f);
        select2 = Instantiate(Prefab2, spawnPosition2, Quaternion.identity);

        
        yield return new WaitForSeconds(0.5f);

        
        Prefab3 = Resources.Load<GameObject>("Prefabs/UI_Upgrade (2)");
        Vector2 spawnPosition3 = new Vector2(9.38f, -0.37f);
        select3 = Instantiate(Prefab3, spawnPosition3, Quaternion.identity);
    }
}