using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public float turnSpeed = 20.0f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        // 플레이어와의 방향 벡터 계산 (y축 회전만 고려하려고 y=0 처리)
        Vector3 direction = player.position - transform.position;
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

    private void OnTriggerEnter(Collider other)
    {
        // 예: "Player" 태그를 가진 오브젝트가 트리거에 들어왔을 때만 비활성화
        if (other.CompareTag("Player"))
        {
            Debug.Log("충돌");
            // 이 스크립트가 붙은 게임오브젝트를 비활성화
            gameObject.SetActive(false);
        }
    }
}


