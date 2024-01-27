using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임을 구성하는 이미지 및 오디오 리소스를 관리합니다.
/// </summary>
public class ResourceManager : MonoBehaviour
{
    public void Init()
    {
        /*
         초기화 관련 코드 구현
         */
    }


    /// <summary>
    /// 리소스를 한번에 불러오는 함수이다.
    /// </summary>
    /// <typeparam name="T">데이터 타입</typeparam>
    /// <param name="path">리소스 폴더 경로</param>
    public T[] LoadAll<T>(string path) where T : Object
    {
        T[] resource = Resources.LoadAll<T>(path);

        if (resource == null)
        {
            Debug.LogError($"Failed to load Resource : {path}");
            return null;
        }
        Debug.Log($"Load Resource '{path}' is Successful. [{typeof(T)} : {resource.Length}]");

        return resource;
    }


    /// <summary>
    /// 리소스를 하나만 불러오는 함수이다.
    /// </summary>
    /// <typeparam name="T">데이터 타입</typeparam>
    /// <param name="path">리소스 파일 경로</param>
    public T Load<T>(string path) where T : Object
    {
        T resource = Resources.Load<T>(path);

        if (resource == null)
        {
            Debug.Log($"Failed to load Resource : {path}");
            return null;
        }

        return resource;
    }


    /// <summary>
    /// 프리팹에서 게임오브젝트를 불러와 생성하는 함수이다.
    /// </summary>
    /// <param name="path">프리팹을 제외한 리소스 파일 경로</param>
    public GameObject Instantiate(string path, Transform parent)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");

        if (prefab == null)
        {
            Debug.LogWarning($"Failed to load prefab! {path}");
            return null;
        }

        GameObject go = Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        if (index > 0)
            go.name = go.name.Substring(0, index);

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            Debug.LogWarning($"Failed to destory GameObject!");
            return;
        }

        Object.Destroy(go);
    }
}
