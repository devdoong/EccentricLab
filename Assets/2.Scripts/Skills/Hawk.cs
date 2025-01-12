using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Hawk : MonoBehaviour
{
    private  float hawkSpeed = 10.0f;
    void Update()
    {
        transform.position += transform.forward * hawkSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Debug.Log("충돌인식성공");
            Vector3 contactNormal = collision.GetContact(0).normal;
            Vector3 reflectDir = Vector3.Reflect(transform.forward, contactNormal);
            Debug.Log("변경 전 forward: " + transform.forward + ", 접촉 법선: " + contactNormal + ", 반사 후 방향: " + reflectDir);

            // 랜덤 회전 오프셋 범위 (예: -15도 ~ 15도)
            float randomAngle = Random.Range(-15f, 15f);

            // Y축 기준 회전 오프셋 적용
            Quaternion randomRotation = Quaternion.Euler(0f, randomAngle, 0f);
            Vector3 randomizedReflectDir = randomRotation * reflectDir;

            // 예를 들어, Y축만 변경
            float newYRotation = Quaternion.LookRotation(randomizedReflectDir).eulerAngles.y;
            Vector3 currentEuler = transform.rotation.eulerAngles;
            Vector3 newEuler = new Vector3(currentEuler.x, newYRotation, currentEuler.z);
            transform.rotation = Quaternion.Euler(newEuler);

            // 전체 회전으로 처리하고 싶다면 아래처럼 사용:
            // transform.rotation = Quaternion.LookRotation(randomizedReflectDir);
        }

    }


}
