using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Hawk : MonoBehaviour
{
    private  float hawkSpeed = 40.0f;
    void Update()
    {
        transform.position += transform.forward * hawkSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Debug.Log("충돌인식성공");

            // 가까운 적 오브젝트 가져오기
            GameObject closeEnemy = Managers.closeEnemy;

            Vector3 targetDirection;

            if (closeEnemy != null) // 가까운 적이 존재할 경우
            {
                targetDirection = (closeEnemy.transform.position - transform.position).normalized;
                Debug.Log("가까운 적을 향한 방향으로 설정: " + targetDirection);
            }
            else // 가까운 적이 없을 경우 플레이어 방향으로 설정
            {
                targetDirection = (Managers.Player.transform.position - transform.position).normalized;
                Debug.Log("가까운 적이 없어 플레이어를 향한 방향으로 설정: " + targetDirection);
            }

            // 목표 방향의 회전 값 계산
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            // 현재 회전 값의 Euler 각도를 가져오기
            Vector3 currentEuler = transform.rotation.eulerAngles;

            // 목표 회전 값에서 Y축만 가져와 기존 X, Z 회전 유지
            Vector3 newEuler = new Vector3(currentEuler.x, targetRotation.eulerAngles.y, currentEuler.z);

            // 새 회전 값 적용
            transform.rotation = Quaternion.Euler(newEuler);
            Debug.Log("Y축 회전만 적용 완료: " + newEuler.y);
        }
    }


}
