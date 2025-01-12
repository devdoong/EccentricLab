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
            Debug.Log("�浹�νļ���");
            Vector3 contactNormal = collision.GetContact(0).normal;
            Vector3 reflectDir = Vector3.Reflect(transform.forward, contactNormal);
            Debug.Log("���� �� forward: " + transform.forward + ", ���� ����: " + contactNormal + ", �ݻ� �� ����: " + reflectDir);

            // ���� ȸ�� ������ ���� (��: -15�� ~ 15��)
            float randomAngle = Random.Range(-15f, 15f);

            // Y�� ���� ȸ�� ������ ����
            Quaternion randomRotation = Quaternion.Euler(0f, randomAngle, 0f);
            Vector3 randomizedReflectDir = randomRotation * reflectDir;

            // ���� ���, Y�ุ ����
            float newYRotation = Quaternion.LookRotation(randomizedReflectDir).eulerAngles.y;
            Vector3 currentEuler = transform.rotation.eulerAngles;
            Vector3 newEuler = new Vector3(currentEuler.x, newYRotation, currentEuler.z);
            transform.rotation = Quaternion.Euler(newEuler);

            // ��ü ȸ������ ó���ϰ� �ʹٸ� �Ʒ�ó�� ���:
            // transform.rotation = Quaternion.LookRotation(randomizedReflectDir);
        }

    }


}
