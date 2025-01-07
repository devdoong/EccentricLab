using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // �迭 ũ�⸦ 9�� ���� (1���� 9����)
    public static GameObject[] maps = new GameObject[9];
    private GameObject center;

    // �߽� �����κ����� ������ (x, z)
    private Vector3[] offsets = new Vector3[]
    {
        new Vector3(-45f, 0f, 45f),  // ���� ��
        new Vector3(0f, 0f, 45f),    // ��
        new Vector3(45f, 0f, 45f),   // ������ ��
        new Vector3(-45f, 0f, 0f),   // ����
        new Vector3(45f, 0f, 0f),    // ������
        new Vector3(-45f, 0f, -45f), // ���� �Ʒ�
        new Vector3(0f, 0f, -45f),   // �Ʒ�
        new Vector3(45f, 0f, -45f)   // ������ �Ʒ�
    };

    void Start()
    {
        // ��� �ڽ� ������Ʈ�� maps �迭�� ����
        for (int i = 1; i <= 9; i++)
        {
            string childName = i.ToString();
            Transform childTransform = transform.Find(childName);

            if (childTransform != null)
            {
                maps[i - 1] = childTransform.gameObject;
                Debug.Log($"�� {childName}��(��) maps[{i - 1}]�� �Ҵ��߽��ϴ�.");
            }
        }
    }
    public void ReplaceMaps(Collider other,GameObject caller)
    {

        if (!other.gameObject.CompareTag("Player")) return;

        // �߽� ���� ���� ������Ʈ�� ����
        center = caller.gameObject;
        Debug.Log("���缾��"+center.name);

        // �߽� ���� ���� ��ġ ����
        Vector3 centerPosition = center.transform.position;

        // �������� �����ϱ� ���� �ε��� �ʱ�ȭ
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



