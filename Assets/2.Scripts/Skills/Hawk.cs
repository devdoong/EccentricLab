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
            Debug.Log("�浹�νļ���");

            // ����� �� ������Ʈ ��������
            GameObject closeEnemy = Managers.closeEnemy;

            Vector3 targetDirection;

            if (closeEnemy != null) // ����� ���� ������ ���
            {
                targetDirection = (closeEnemy.transform.position - transform.position).normalized;
                Debug.Log("����� ���� ���� �������� ����: " + targetDirection);
            }
            else // ����� ���� ���� ��� �÷��̾� �������� ����
            {
                targetDirection = (Managers.Player.transform.position - transform.position).normalized;
                Debug.Log("����� ���� ���� �÷��̾ ���� �������� ����: " + targetDirection);
            }

            // ��ǥ ������ ȸ�� �� ���
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            // ���� ȸ�� ���� Euler ������ ��������
            Vector3 currentEuler = transform.rotation.eulerAngles;

            // ��ǥ ȸ�� ������ Y�ุ ������ ���� X, Z ȸ�� ����
            Vector3 newEuler = new Vector3(currentEuler.x, targetRotation.eulerAngles.y, currentEuler.z);

            // �� ȸ�� �� ����
            transform.rotation = Quaternion.Euler(newEuler);
            Debug.Log("Y�� ȸ���� ���� �Ϸ�: " + newEuler.y);
        }
    }


}
