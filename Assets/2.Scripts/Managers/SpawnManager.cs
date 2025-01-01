using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Awake()
    {
        Debug.Log("스폰매니저 Awake");
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
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //자기자신 0제외하고 1부터. ~ 스폰포인트 길이만큼
    }
}
