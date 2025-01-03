using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerController : MonoBehaviour
{
    #region �÷��̾� �̵��� �ʿ��� ����
    public float moveSpeed = 5.0f;
    public float turnSpeed = 10.0f;
    Vector3 m_Movement;
    #endregion

    #region ȭ�� �߻翡 �ʿ��� ����
    private GameObject arrowPrefab;
    private Transform ShootPoint;
    private Animator shoot_animator;
    private AnimatorStateInfo currentState;
    #endregion
    private void Awake()
    {
        shoot_animator = GetComponent<Animator>();
    }

    private void test()
    {
        
    }

    void Update()
    {

        #region �÷��̾� �̵� ����
        float horizontal = Input.GetAxis("Horizontal"); // ���� �Է�
        float vertical = Input.GetAxis("Vertical"); // ���� �Է�

        m_Movement = new Vector3(horizontal, 0, vertical).normalized; //���� ����ȭ

        transform.position += m_Movement * moveSpeed * Time.deltaTime;
        #endregion

        #region �� �ٶ󺸴� ����
        GameObject closeEnemy = GetCloseEnemy();
        if (closeEnemy != null)
        {
            Vector3 dir = (closeEnemy.transform.position - transform.position).normalized;
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
        #endregion

        
    }

    #region Ÿ�� Enemy ��Ī
    GameObject GetCloseEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); //Enemy �±� ��ü �˻�

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
    #endregion
}
