using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // 배열 크기를 9로 설정 (1부터 9까지)
    public static GameObject[] maps = new GameObject[9];
    public GameObject center;

    // 중심 맵으로부터의 오프셋 (x, z)
    private Vector3[] offsets = new Vector3[]
    {
        new Vector3(-45f, 0f, 45f),  // 왼쪽 위
        new Vector3(0f, 0f, 45f),    // 위
        new Vector3(45f, 0f, 45f),   // 오른쪽 위
        new Vector3(-45f, 0f, 0f),   // 왼쪽
        new Vector3(45f, 0f, 0f),    // 오른쪽
        new Vector3(-45f, 0f, -45f), // 왼쪽 아래
        new Vector3(0f, 0f, -45f),   // 아래
        new Vector3(45f, 0f, -45f)   // 오른쪽 아래
    };

    void Start()
    {
        // 모든 자식 오브젝트를 maps 배열에 저장
        for (int i = 1; i <= 9; i++)
        {
            string childName = i.ToString();
            Transform childTransform = transform.Find(childName);

            if (childTransform != null)
            {
                maps[i - 1] = childTransform.gameObject;
            }
        }
    }
    public void ReplaceMaps(Collider other,GameObject caller)
    {

        if (!other.gameObject.CompareTag("Player")) return;

        // 중심 맵을 현재 오브젝트로 설정
        center = caller.gameObject;

        // 중심 맵의 현재 위치 저장
        Vector3 centerPosition = center.transform.position;

        // 오프셋을 적용하기 위한 인덱스 초기화
        int offsetIndex = 0;

        foreach (GameObject map in maps)
        {
            if (map != center)
            {
                Vector3 newPosition = centerPosition + offsets[offsetIndex];
                map.transform.position = newPosition;
                offsetIndex++;
            }
        }
    }
}



