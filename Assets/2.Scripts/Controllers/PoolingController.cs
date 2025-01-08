using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{

    #region ���͸� ������ �� ����
    public Transform[] spawnPoint;
    float timer;
    #endregion



    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10.0f)
        {
            timer = 0;
            Spawn();
        }

        transform.position = Managers.Player.transform.position;
    }

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(); //�������� ��� �ҷ���
    }


    void Spawn()
    {
        GameObject enemy = Managers.Pool.Active(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //�ڱ��ڽ� 0�����ϰ� 1����. ~ ��������Ʈ ���̸�ŭ
    }
}