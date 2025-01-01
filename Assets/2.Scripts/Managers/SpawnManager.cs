using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Awake()
    {
        Debug.Log("�����Ŵ��� Awake");
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.7f)
        {
            timer = 0;
            Spawn();

        }
    }

    void Spawn()
    {
        
        GameObject enemy = PoolManager.Instance.Active(Random.Range(0,1));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //�ڱ��ڽ� 0�����ϰ� 1����. ~ ��������Ʈ ���̸�ŭ
    }
}
