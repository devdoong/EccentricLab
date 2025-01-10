using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class WallManager : MonoBehaviour
{
    public Vector3 pos;

    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        pos.x = 0f; // x ��ǥ�� �׻� 0���� ����
        pos.y = 0f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}

