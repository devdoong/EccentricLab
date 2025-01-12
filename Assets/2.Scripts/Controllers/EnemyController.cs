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
    public bool isCollision = false; //�÷��̾�� �浹 ����
    public float distance; //�÷��̾���� �Ÿ����̸� ���Ͽ� �ٷ� �ձ��� �Դٸ� �̵��� ���߱� ���ؼ�.
    public float stop_distance = 0.86f;
    #endregion

    #region ���� ü��
    public float HP = 100;
    public float MaxHP = 100;
    #endregion

    #region �˹��� ���� ����
    private bool isKnockBack = false;
    public float knockBackDuration = 0.2f; // �˹� ���� �ð�
    public float knockBackTimer = 0f; // �˹� Ÿ�̸�
    static Rigidbody enemt_rigidbody;
    Color originalColor; //������
    #endregion

    #region ����ġ ����� �ʿ��� ����
    public GameObject gem;
    private GameObject gemParent;
    #endregion

    #region �������� �ֱ� ���� ����
    public float damage = 1;
    public float damage_Timer = 0f;
    public float damage_delayTime = 0.3f;
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
        
        #region �÷��̾���� �浹 �Ǵ�
        distance = Vector3.Distance(player.position,transform.position);
        if (distance <= stop_distance) isCollision = true;
        else if (distance > stop_distance) isCollision = false;
        #endregion

        #region �÷��̾�� ���� : �ǰ��������µ� �ƴϰ� / �÷��̾�� �浹 ���µ� �ƴϸ�
        //�����Ӱ� ����
        if (isKnockBack == false && isCollision == false) 
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

        #region �÷��̾�� ������ ����
        if(isCollision == true)
        {
            damage_Timer += Time.deltaTime;

            if (damage_Timer >= damage_delayTime)
            {
                damage_Timer = 0;
                Debug.Log(Managers.HP.OnDamaged(damage));
            }
            
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        #region projectile�� ���� ������ �Ծ��� ��
        //Projectile �±׸� ���� ������Ʈ�� Ʈ���ſ� ������ ���� ��Ȱ��ȭ
        if (other.CompareTag("DamageSource"))
        {
            #region ü�°���, �˹�
            HP -= Managers.Damage.GetDamage((other.transform.parent != null) ? other.transform.parent.name : other.transform.name);
            isKnockBack = true;//�˹�
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


