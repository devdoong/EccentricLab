using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowMovement : MonoBehaviour
{
    //�Ʒ� �ڵ忡�� ��� Arrow�� ����� ���׵��� "***" ��ǥ ���� ǥ��
    //�������� ���� �����ϴ� ���� ������ �ִٸ� "@@@" ǥ��
    //������ //����



    private float arrowSpeed = 20.0f; //@@@
    public float destroyDelay = 10f; //@@@

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(destroyDelay); // ������ �ð� ��� //***
        Destroy(gameObject); // ���� ������Ʈ ���� //***
    }

    private void OnTriggerEnter(Collider other) //***
    {
        //Projectile �±׸� ���� ������Ʈ�� Ʈ���ſ� ������ ���� ��Ȱ��ȭ
        if (other.CompareTag("Enemy")) //***
            Destroy(gameObject); //***
    }

    void Update()
    {
        transform.position += transform.forward * arrowSpeed * Time.deltaTime; //����
    }
}
