using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    public Transform mapViewPoint;  // 맵을 보여줄 위치
    public Transform player;        // 플레이어의 위치
    public float zoomSpeed = 5f;

    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();

        // 맵을 처음에 보여주는 초기 설정
        StartCoroutine(ShowMapView());
    }

    IEnumerator ShowMapView()
    {
        // 카메라를 맵 전체로 이동
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 1f;  // 수직으로 전체 화면 보여주기
        vcam.Follow = mapViewPoint;  // 카메라가 mapViewPoint를 따라감

        yield return new WaitForSeconds(2f);

        // 캐릭터 위치로 줌인
        vcam.Follow = player;
        StartCoroutine(ZoomInToPlayer());
    }

    IEnumerator ZoomInToPlayer()
    {
        float elapsedTime = 0f;
        float zoomDuration = 2f;

        while (elapsedTime < zoomDuration)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = Mathf.Lerp(1f, 0.6f, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
