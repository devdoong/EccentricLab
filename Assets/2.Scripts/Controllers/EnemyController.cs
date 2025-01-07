using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    static Transform player;
    public float moveSpeed = 3.0f;
    public float turnSpeed = 20.0f;
    public float backAmount = 1.0f;

    #region �ǰݰ���
    public int HP = 100;
    public int MaxHP = 100;
    private bool isKnockBack = false;
    public float knockBackDuration = 0.2f; // �˹� ���� �ð�
    public float knockBackTimer = 0f; // �˹� Ÿ�̸�
    static Rigidbody rigidbody;
    Color originalColor;
    #endregion

    public GameObject gem;
    public Transform gemParent;

    private void Start()
    {
        player = GameObject.Find("BasicArcher").transform;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // �÷��̾���� ���� ���� ��� (y�� ȸ���� ����Ϸ��� y=0 ó��)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // ���� ������ �����ϰ� ȸ��

        // ���Ͱ� �÷��̾ �ٶ󺸵��� ȸ��
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        #region �÷��̾�� ����
        //�����Ӱ� ����
        if (isKnockBack == false) 
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //����
        #endregion

        #region �˹��� ���� �÷��̾�� ������ �Ͻ������ϰ� �˹��� �̷���� �ð� üũ
        //�����ϴٰ� �������� �Ծ� �˹� Ÿ�̸� ���� //���� if��(�÷��̾�� ����) �� �����Ǿ�� ������ �ڷ� �˹��� �̷��������
        else if (isKnockBack == true){
            knockBackTimer += Time.deltaTime; //�˹� Ÿ�̸�
            if (knockBackTimer >= knockBackDuration) //�˹� ���ӽð� ����������
            {
                knockBackTimer = 0;
                isKnockBack = false; //�˹���� �ƴ����� ����
            }

        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        #region projectile�� ���� ������ �Ծ��� ��
        //Projectile �±׸� ���� ������Ʈ�� Ʈ���ſ� ������ ���� ��Ȱ��ȭ
        if (other.CompareTag("Projectile"))
        {
            //����
            //1. Managers.Projectile���� �������� ������ ������ ������
            //2. �˹��ܰ� ���ÿ� ü���� 0���� Ȯ��.  --> �˹� �߻��Ҷ� ���� �Ͻ�����.
            //3. 0�̸� ��Ȱ��ȭ + ü���� MAXHP�� ����

            #region ü�°���, �˹�
            //1. Managers.Projectile���� �������� ������ ������ ������
            HP -= Managers.Projectile.ArrowDamage;

            //2. �˹��ܰ� ���ÿ� ü���� 0���� Ȯ��.  --> �˹� �߻��Ҷ� ���� �Ͻ�����.
            //�˹�
            isKnockBack = true;
            rigidbody.AddForce(new Vector3(0, 0, -10), ForceMode.Impulse); //�������� addForce //false�� update������ Ÿ�̸� �����Ұ���.

            #endregion

            #region ���ó�� (��Ȱ��ȭ, ����)
            if (HP <= 0)
            {
                //3. 0�̸� ��Ȱ��ȭ +ü���� MAXHP�� ����
                Instantiate(gem,transform.position, Quaternion.identity,gemParent);
                gameObject.SetActive(false);
                HP = MaxHP;
            }
            #endregion
        }
        #endregion
    }

}


