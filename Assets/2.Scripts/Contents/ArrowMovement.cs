using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowMovement : MonoBehaviour
{
    //아래 코드에서 모든 Arrow에 적용될 사항들은 "***" 별표 세개 표시
    //레벨링을 통해 증가하는 값을 가지고 있다면 "@@@" 표시
    //고정은 //고정



    private float arrowSpeed = 20.0f; //@@@
    public float destroyDelay = 10f; //@@@

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(destroyDelay); // 지정된 시간 대기 //***
        Destroy(gameObject); // 게임 오브젝트 제거 //***
    }

    private void OnTriggerEnter(Collider other) //***
    {
        //Projectile 태그를 가진 오브젝트가 트리거에 들어왔을 때만 비활성화
        if (other.CompareTag("Enemy")) //***
            Destroy(gameObject); //***
    }

    void Update()
    {
        transform.position += transform.forward * arrowSpeed * Time.deltaTime; //고정
    }
}
