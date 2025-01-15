using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPlayer;     // 따라갈 타겟(플레이어)
    public Vector3 offset;

    // SmoothDamp 관련 파라미터
    // smoothTime: 목표 위치에 도달하는 데 걸리는 대략적인 시간 (너무 작으면 민감하게 흔들림)
    // velocity: SmoothDamp에서 내부적으로 사용될 현재 이동 속도(초기화 0)
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // 타겟 위치 + 오프셋으로 카메라가 이동해야 할 위치 계산
        Vector3 targetPosition = targetPlayer.position + offset;

        // SmoothDamp를 사용해 카메라 위치를 부드럽게 목표 위치로 이동
        transform.position = Vector3.SmoothDamp(
            transform.position,   // 현재 위치
            targetPosition,       // 목표 위치
            ref velocity,         // 내부적으로 사용될 속도
            smoothTime            // 목표에 도달하는 데 걸리는 시간
        );
    }
}

