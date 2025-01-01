using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 3.0f;
    public float turnSpeed = 20.0f;
    private void Update()
    {
        // 플레이어와의 방향 벡터 계산 (y축 회전만 고려하려고 y=0 처리)
        Vector3 direction = Player.position - transform.position;
        direction.y = 0f; // 수직 방향은 무시하고 회전

        // 몬스터가 플레이어를 바라보도록 회전
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //전진

        
    }
}


