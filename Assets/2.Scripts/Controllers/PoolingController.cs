using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{

    #region 몬스터를 스포닝 할 변수
    public Transform[] spawnPoint;
    float timer;
    #endregion



    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20f)
        {
            timer = 0;
            Spawn();
        }

        transform.position = Managers.Player.transform.position;
    }

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(); //스폰지점 모두 불러옴
    }


    void Spawn()
    {
        GameObject enemy = Managers.Pool.Active(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //자기자신 0제외하고 1부터. ~ 스폰포인트 길이만큼
    }
}