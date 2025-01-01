using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 10.0f;

    Rigidbody m_Rigidbody; //  객체에 연결된 Rigidbody 구성 요소에 대한 참조
    Vector3 m_Movement;


    /*void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }*/

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // 수평 입력
        float vertical = Input.GetAxis("Vertical"); // 수직 입력

        m_Movement = new Vector3(horizontal, 0, vertical).normalized; //벡터 정규화

        transform.position += m_Movement * moveSpeed * Time.deltaTime;

        if (m_Movement != Vector3.zero) // 키 입력값이 존재할 때
        {
            Quaternion toRotation = Quaternion.LookRotation(m_Movement, Vector3.up); // 해당 방향을 바라봄
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime); // 부드러운 회전
        }
        else //키입력 없으면 가까운 몬스터를 바라봄
        {
            GameObject closeEnemy = GetCloseEnemy();
            if (closeEnemy != null)
            {
                Vector3 dir = (closeEnemy.transform.position - transform.position).normalized;
                Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation,toRotation,turnSpeed * Time.deltaTime);
            }
        }
    }

    GameObject GetCloseEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length == 0) return null;

        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemys)
        {
            float distance = Vector3.Distance(transform.position,enemy.transform.position);
            if (distance < closestDistance)
            {
                closest = enemy;
                closestDistance = distance;
            }
        }
        return closest;
    }
}
