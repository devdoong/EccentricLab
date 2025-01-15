using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;



public class PlayerController : MonoBehaviour
{
    #region �÷��̾� �̵��� �ʿ��� ����
    public float moveSpeed = 5.0f; 
    public float turnSpeed = 10.0f;
    static public Vector3 m_Movement;
    #endregion

    #region ȭ�� �߻翡 �ʿ��� ����
    private GameObject arrowPrefab;
    private Transform shootPoint;
    #endregion

    public GameObject closeEnemy;
    void Update()
    {

        #region �÷��̾� �̵� ����
        float horizontal = Input.GetAxis("Horizontal"); // ���� �Է�
        float vertical = Input.GetAxis("Vertical"); // ���� �Է�

        m_Movement = new Vector3(horizontal, 0, vertical).normalized; //���� ����ȭ

        transform.position += m_Movement * moveSpeed * Time.deltaTime;
        #endregion

        #region �� �ٶ󺸴� ����
        closeEnemy = Managers.closeEnemy;
        if (closeEnemy != null)
        {
            Vector3 dir = (closeEnemy.transform.position - transform.position).normalized; //�ٶ������ ����
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up); //�� �������� ������ ���� ���ʹϾ�.
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
        #endregion

        
    }

}
