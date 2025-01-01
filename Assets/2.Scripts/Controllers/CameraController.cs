using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPlayer;     // ���� Ÿ��(�÷��̾�)
    public Vector3 offset = new Vector3(0f, 5f, -7f);

    // SmoothDamp ���� �Ķ����
    // smoothTime: ��ǥ ��ġ�� �����ϴ� �� �ɸ��� �뷫���� �ð� (�ʹ� ������ �ΰ��ϰ� ��鸲)
    // velocity: SmoothDamp���� ���������� ���� ���� �̵� �ӵ�(�ʱ�ȭ 0)
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // Ÿ�� ��ġ + ���������� ī�޶� �̵��ؾ� �� ��ġ ���
        Vector3 targetPosition = targetPlayer.position + offset;

        // SmoothDamp�� ����� ī�޶� ��ġ�� �ε巴�� ��ǥ ��ġ�� �̵�
        transform.position = Vector3.SmoothDamp(
            transform.position,   // ���� ��ġ
            targetPosition,       // ��ǥ ��ġ
            ref velocity,         // ���������� ���� �ӵ�
            smoothTime            // ��ǥ�� �����ϴ� �� �ɸ��� �ð�
        );
    }
}

