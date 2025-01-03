using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    static Transform player;
    public float moveSpeed = 3.0f;
    public float turnSpeed = 20.0f;

    private void Start()
    {
        player = GameObject.Find("BasicArcher").transform;
    }
    private void Update()
    {
        // �÷��̾���� ���� ���� ��� (y�� ȸ���� ����Ϸ��� y=0 ó��)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // ���� ������ �����ϰ� ȸ��

        // ���Ͱ� �÷��̾ �ٶ󺸵��� ȸ��
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //����
    }

    private void OnTriggerEnter(Collider other)
    {
        //Player �±׸� ���� ������Ʈ�� Ʈ���ſ� ������ ���� ��Ȱ��ȭ
        if (other.CompareTag("Player"))
        {
            // �� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ�� ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}


