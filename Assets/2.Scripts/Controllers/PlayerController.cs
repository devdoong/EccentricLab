using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 10.0f;

    Rigidbody m_Rigidbody; //  ��ü�� ����� Rigidbody ���� ��ҿ� ���� ����
    Vector3 m_Movement;


    /*void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }*/

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // ���� �Է�
        float vertical = Input.GetAxis("Vertical"); // ���� �Է�

        m_Movement = new Vector3(horizontal, 0, vertical).normalized; //���� ����ȭ

        transform.position += m_Movement * moveSpeed * Time.deltaTime;

        if (m_Movement != Vector3.zero) // Ű �Է°��� ������ ��
        {
            Quaternion toRotation = Quaternion.LookRotation(m_Movement, Vector3.up); // �ش� ������ �ٶ�
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime); // �ε巯�� ȸ��
        }
        else //Ű�Է� ������ ����� ���͸� �ٶ�
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
