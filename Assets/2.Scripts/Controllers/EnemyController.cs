using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region �⺻����
    static Transform player; //�÷��̾� transform
    public float moveSpeed = 3.0f; //�̵� �ӵ�
    public float turnSpeed = 20.0f; //rotation�Ͽ� ���ƺ��� �ӵ�
    public float backAmount = 1.0f; //�˹�Ǵ� �ð�

    #endregion

    #region �����̿��� ���߱� �뵵�� ����
    public bool isPlayerCollision = false; //�÷��̾�� �浹 ����
    public float distance; //�÷��̾���� �Ÿ����̸� ���Ͽ� �ٷ� �ձ��� �Դٸ� �̵��� ���߱� ���ؼ�.
    public float stop_distance = 0.86f;
    #endregion

    #region �ǰݰ���
    public int HP = 100;
    public int MaxHP = 100;
    private bool isKnockBack = false;
    public float knockBackDuration = 0.2f; // �˹� ���� �ð�
    public float knockBackTimer = 0f; // �˹� Ÿ�̸�
    static Rigidbody enemt_rigidbody;
    Color originalColor;
    #endregion

    #region ����ġ ����� �ʿ��� ����
    public GameObject gem;
    private GameObject gemParent;
    #endregion

    private void Start()
    {
        player = GameObject.Find("BasicArcher").transform;
        enemt_rigidbody = GetComponent<Rigidbody>();
        gemParent = GameObject.Find("@Gems");
        if (gemParent == null) Debug.LogWarning("@Gems�� ���̷�Űâ���� ã�� �� �����ϴ�.");
    }
    private void Update()
    {
        #region �÷��̾��� ���� ���
        // �÷��̾���� ���� ���� ��� (y�� ȸ���� ����Ϸ��� y=0 ó��)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // ���� ������ �����ϰ� ȸ��
        #endregion

        #region �÷��̾�� rotation
        // ���Ͱ� �÷��̾ �ٶ󺸵��� ȸ��
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );
        #endregion

        distance = Vector3.Distance(player.position,transform.position);
        Debug.Log(distance);


        #region �÷��̾�� ����
        //�����Ӱ� ����
        if (isKnockBack == false && distance > stop_distance)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //����
        #endregion

        #region �˹��� ���� �÷��̾�� ������ �Ͻ������ϰ� �˹��� �̷���� �ð� üũ
        //�����ϴٰ� �������� �Ծ� �˹� Ÿ�̸� ���� //���� if��(�÷��̾�� ����) �� �����Ǿ�� ������ �ڷ� �˹��� �̷��������
        else if (isKnockBack == true){
            knockBackTimer += Time.deltaTime; //�˹� Ÿ�̸�
            transform.position = Vector3.MoveTowards(transform.position, transform.Find("KnockBackPosition").position, 3 * Time.deltaTime);
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
            HP -= Managers.Projectile.arrowDamage;

            //2. �˹��ܰ� ���ÿ� ü���� 0���� Ȯ��.  --> �˹� �߻��Ҷ� ���� �Ͻ�����.
            //�˹�
            isKnockBack = true;
            //enemt_rigidbody.AddForce(knockBackDirection * 100f, ForceMode.Impulse);
            //enemt_rigidbody.AddForce(new Vector3(0, 0, -100), ForceMode.Impulse); //�������� addForce //false�� update������ Ÿ�̸� �����Ұ���.

            #endregion

            #region ���ó�� (��Ȱ��ȭ, ����)
            if (HP <= 0)
            {
                //3. 0�̸� ��Ȱ��ȭ +ü���� MAXHP�� ����
                GameObject instance_gem= Instantiate(gem, transform.position, Quaternion.identity, gemParent.transform);
                gameObject.SetActive(false);
                HP = MaxHP;
            }
            #endregion
        }
        #endregion
    }

}


